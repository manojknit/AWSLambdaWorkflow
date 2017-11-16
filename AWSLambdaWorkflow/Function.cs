using Amazon.Lambda.Core;
using Amazon.Runtime;
using Amazon.Runtime.CredentialManagement;
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;
using Amazon.StepFunctions;
using Amazon.StepFunctions.Model;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
//using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace AWSLambdaWorkflow
{
    public class Function
    {
        protected CredentialProfileStoreChain _CredentialProfileStoreChain = null;
        //const aws = require('aws-sdk');
        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public string FunctionHandler(ILambdaContext context)
        {
            //try
            //{
            //    var bucketName = System.Environment.GetEnvironmentVariable("mysqlconnection");
            //    var quotenumber = GetQuote(58);
            //    string input = quotenumber.QuoteNumber;
            //    return input?.ToUpper();
            //}
            //catch (Exception e)
            //{ }
            LambdaLogger.Log("1. Lambda start");
            //Starts workflow instance with parameter
            var stste =  StartWorkflowInstanceAsync();
            LambdaLogger.Log("2. Workflow started."+ stste??"".ToString());
            string emailstatus = "Problem occured in email approval.";
            string token = string.Empty;
            try
            {
                //AmazonStepFunctionsClient stepfunctions = new AmazonStepFunctionsClient(Amazon.RegionEndpoint.USEast1);
                AmazonSimpleEmailServiceClient ses = new AmazonSimpleEmailServiceClient(Amazon.RegionEndpoint.USEast1);
                Task<GetActivityTaskResponse> responsetask = null;
                GetActivityTaskResponse response = null;
                //return "Success";
                LambdaLogger.Log("Task ARN");
                var aws_access_key_id = Environment.GetEnvironmentVariable("aws_access_key_id");
                var aws_secret_access_key = Environment.GetEnvironmentVariable("aws_secret_access_key");
                using (AmazonStepFunctionsClient stepfunctions = new AmazonStepFunctionsClient(aws_access_key_id, aws_secret_access_key, Amazon.RegionEndpoint.USEast1))
                {
                    GetActivityTaskRequest request = new GetActivityTaskRequest {ActivityArn = "arn:aws:states:us-east-1:494875521123:activity:PMApprovalStep", WorkerName = "PMApprovingTaskActivity" };
                    LambdaLogger.Log("Response Output req sent ");
                    responsetask = stepfunctions.GetActivityTaskAsync(request);
                    responsetask.GetAwaiter();
                    response = responsetask.Result;
                    //if(responsetask.)
                    if (response != null)
                        LambdaLogger.Log("Response Output = " + response.Input);
                    else
                        LambdaLogger.Log("Response Output = null");
                    token = response.TaskToken;
                    LambdaLogger.Log("Token = "+token);
                }
                if (!string.IsNullOrEmpty(response.Input))
                {
                    //TODO get email from db
                    var input = JObject.Parse(response.Input);
                    var email = "manojsjsu@gmail.com"; //get to mail from salesOrg as per approval level
                    var quoteid = (int)input.SelectToken("quoteid");
                    var tolst = new List<string>();
                    tolst.Add(email);
                    Body body = new Body
                    {
                        Html = new Content
                        {
                            Charset = "UTF-8",
                            Data = "<div>Hi!<br /><br /> " +
                                        "Promotion '" + (string)input.SelectToken("promodesc") + "' needs your approval!<br />" +
                                        "Can you please approve:<br /> <h3><a href='https://wyunsq1ccf.execute-api.us-east-1.amazonaws.com/respond/approve?taskToken="+ Uri.EscapeDataString(token) + "&quoteid=" + quoteid + "'>Click To Approve</a></h3><br />" + 
                                        //"https://wyunsq1ccf.execute-api.us-east-1.amazonaws.com/respond/approve?taskToken=" + Uri.EscapeDataString(token) + "&quoteid=" + quoteid + "<br />" +
                                        "Or reject:<br />" +
                                        "<h3><a href='https://wyunsq1ccf.execute-api.us-east-1.amazonaws.com/respond/reject?taskToken=" + Uri.EscapeDataString(token) + "&quoteid=" + quoteid + "'>Click To Reject</a></h3></div><br /><br />Thank You,<br />Application Team"
                            //"https://wyunsq1ccf.execute-api.us-east-1.amazonaws.com/respond/reject?taskToken=" + Uri.EscapeDataString(token) + "&quoteid=" + quoteid + "</div>"
                        }
                    };
                    Content subjectContent = new Content
                    {
                        Charset = "UTF-8",
                        Data = "Your Approval Needed as Pricing Manager for Promotion Id " + quoteid
                    };

                    LambdaLogger.Log("Starting Mail sending.. ");
                    Message msg = new Message { Body = body, Subject = subjectContent };
                    SendEmailRequest s = new SendEmailRequest
                    {
                        Source = "erpatel@gmail.com",
                        Destination = new Destination { ToAddresses = tolst },
                        Message = msg,
                        ConfigurationSetName = "sesconfigset",
                        SourceArn = "arn:aws:ses:us-east-1:494875521123:identity/erpatel@gmail.com"
                    };
                    var status =  ses.SendEmailAsync(s);
                    status.GetAwaiter();
                    
                    emailstatus = status.Result.HttpStatusCode.ToString();
                    LambdaLogger.Log("Going to update Db");
                    if(!string.IsNullOrEmpty(token))
                        UpdateApprovalStatusWithToken(quoteid, Uri.EscapeDataString(token));   //Moving quote status to 3(PM) and updating token
                    //string input,
                    //var bucketName = System.Environment.GetEnvironmentVariable("mysqlconnection");
                    //var quotenumber = GetQuote(58);
                    //input = quotenumber.QuoteNumber;
                    //return input?.ToUpper();
                }
            }
            catch (Exception e)
            { LambdaLogger.Log("Response Output = " + e); }
            return emailstatus;
        }

        private async Task<StartExecutionResponse> StartWorkflowInstanceAsync()
        {
            StartExecutionResponse status = null;
            try
            {
                LambdaLogger.Log("1. Lambda start1");
                List<Quote> quotes = GetQuotesAsPerStage(2);//1 for Submitted
                LambdaLogger.Log("1. Lambda start2");
                
                foreach (var item in quotes)
                {
                    //Check if any Promotion is submitted

                    //LambdaLogger.Log("1. Lambda start3"+ Directory.GetCurrentDirectory() + @"\iam.json");
                    //_CredentialProfileStoreChain = new CredentialProfileStoreChain( );//@"/iam.json"
                    //LambdaLogger.Log("Profile Location="+_CredentialProfileStoreChain.ProfilesLocation);
                    //AWSCredentials awsCredentials;
                    //if (_CredentialProfileStoreChain.TryGetAWSCredentials("default", out awsCredentials))//local-test-profile
                    //{
                    //    if (awsCredentials != null)
                    //    {
                    string inputToStepFunc = "{ \"quoteid\": \"" + item.QuoteID + "\", \"promodesc\" : \"" + item.TPBackground + "\" }";

                    var aws_access_key_id = Environment.GetEnvironmentVariable("aws_access_key_id");
                    var aws_secret_access_key = Environment.GetEnvironmentVariable("aws_secret_access_key");
                    using (AmazonStepFunctionsClient stepfunctions = new AmazonStepFunctionsClient(aws_access_key_id, aws_secret_access_key, Amazon.RegionEndpoint.USEast1))
                    {
                        LambdaLogger.Log("Gocha credentials going to invoke Step function");
                        string nameunique = "WF" + DateTime.Now.ToString("ddMMyyyyHHmmssfff");
                        StartExecutionRequest newRequest = new StartExecutionRequest { StateMachineArn = "arn:aws:states:us-east-1:494875521123:stateMachine:ApprovalWorkflow", Input = inputToStepFunc, Name = nameunique };
                        LambdaLogger.Log("Step Func object is ready to be invoked.");
                        status = await stepfunctions.StartExecutionAsync(newRequest);
                        LambdaLogger.Log("Step Func invoke done"+status.ToString());
                    }
                    //}
                    //else
                    //    LambdaLogger.Log("Null AWS Credentilas found.");
                    //}
                    LambdaLogger.Log("Workflow is created for Quote id = " + item.QuoteID );
                }
                
            }
            catch (Exception ex)
            {
                LambdaLogger.Log("Error"+ex.ToString());
                throw ex;
            }
            return status;
        }

        private List<Quote> GetQuotesAsPerStage(int promoStage)
        {
            Quote quote = null;
            List<Quote> lstquote = new List<Quote>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(string.Format("select * from Quote where QuoteStatusResultID ={0}", promoStage), conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        quote = new Quote()
                        {
                            QuoteID = Convert.ToInt32(reader["QuoteID"]),
                            QuoteNumber = reader["QuoteNumber"].ToString(),
                            QuoteTypeID = Convert.ToInt32(reader["QuoteTypeID"]),
                            QuoteStatusResultID = Convert.ToInt32(reader["QuoteStatusResultID"]),
                            TPBackground = reader["TPBackground"].ToString()
                        };
                        lstquote.Add(quote);
                    }
                }
            }
            return lstquote;
        }
        private string UpdateApprovalStatusWithToken(int quoteid, string token)
        {
            try
            {
                if (!string.IsNullOrEmpty(token))
                {
                    using (MySqlConnection conn = GetConnection())
                    {

                        conn.Open();
                        //This is my update query in which i am taking input from the user through windows forms and update the record.  
                        string Query = "update Quote set Token='" + token + "',QuoteStatusResultID=" + 3 + " where quoteid = " + quoteid + ";";
                        LambdaLogger.Log("Query= " + Query);
                        //This is  MySqlConnection here i have created the object and pass my connection string.  
                        MySqlCommand MyCommand2 = new MySqlCommand(Query, conn);
                        MySqlDataReader MyReader2;
                        
                        MyReader2 = MyCommand2.ExecuteReader();
                        LambdaLogger.Log("Token Updated");
                        while (MyReader2.Read())
                        {
                            LambdaLogger.Log("After update read");
                        }
                        conn.Close();//Connection closed here  
                    }
                }
            }
            catch (Exception ex)
            {
                LambdaLogger.Log(ex.ToString());
                return ex.ToString();
            }
            return "Success token update";
        }
        private MySqlConnection GetConnection()
        {
            string connectionstring = System.Environment.GetEnvironmentVariable("mysqlconnection");
            return new MySqlConnection(connectionstring);
        }
        public Quote GetQuote(int quoteid)
        {
            Quote quote = null;

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(string.Format("select * from Quote where QuoteID ={0}", quoteid), conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        quote = new Quote()
                        {
                            QuoteID = Convert.ToInt32(reader["QuoteID"]),
                            QuoteNumber = reader["QuoteNumber"].ToString(),
                            QuoteTypeID = Convert.ToInt32(reader["QuoteTypeID"]),
                            QuoteStatusResultID = Convert.ToInt32(reader["QuoteStatusResultID"]),
                            TPBackground = reader["TPBackground"].ToString()
                        };
                    }
                }
            }
            return quote;
        }
        //public List<Quote> GetAllQuotes()
        //{
        //    List<Quote> list = new List<Quote>();

        //    using (MySqlConnection conn = GetConnection())
        //    {
        //        conn.Open();
        //        MySqlCommand cmd = new MySqlCommand("select * from Quote where id < 100", conn);

        //        using (var reader = cmd.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                list.Add(new Quote()
        //                {
        //                    QuoteID = Convert.ToInt32(reader["Id"]),
        //                    QuoteNumber = reader["QuoteNumber"].ToString(),
        //                    QuoteTypeID = Convert.ToInt32(reader["QuoteTypeID"]),
        //                    QuoteStatusResultID = Convert.ToInt32(reader["QuoteStatusResultID"]),
        //                    TPBackground = reader["TPBackground"].ToString()
        //                });
        //            }
        //        }
        //    }
        //    return list;
        //}
        //public static List<string> Get_Rule_Group()
        //{
        //    using (SqlConnection con = new SqlConnection(CS))
        //    {
        //        string query = "SELECT abc from table where abc = xyz";
        //        SqlCommand cmd = new SqlCommand(query, con);
        //        con.Open();
        //        SqlDataReader reader = cmd.ExecuteReader();
        //        List<string> Rule_Group = new List<string>();
        //        while (reader.Read())
        //        {
        //            Rule_Group.Add(reader["abc"].ToString());
        //        }
        //        return Rule_Group;
        //    }
        //}

    }
}

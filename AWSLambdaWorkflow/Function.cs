using Amazon.Lambda.Core;
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

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace AWSLambdaWorkflow
{
    public class Function
    {
        //const aws = require('aws-sdk');
               /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public async System.Threading.Tasks.Task<string> FunctionHandlerAsync(ILambdaContext context)
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

            //Starts workflow instance with parameter
            StartWorkflowInstance();

            AmazonStepFunctionsClient stepfunctions = new AmazonStepFunctionsClient(Amazon.RegionEndpoint.USEast1);
            AmazonSimpleEmailServiceClient ses = new AmazonSimpleEmailServiceClient(Amazon.RegionEndpoint.USEast1);

            //return "Success";
            //arn:aws:states:us-east-1:494875521123:stateMachine:PromotionApprovalStepFunction
            GetActivityTaskRequest request = new GetActivityTaskRequest { ActivityArn= "arn:aws:states:us-east-1:494875521123:activity:PricingManagerStep" };
            GetActivityTaskResponse response = await stepfunctions.GetActivityTaskAsync(request);
            LambdaLogger.Log(response.Input);
            string emailstatus = "Problem occured in email approval."; 
            
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
                        Data = "<div>Hi!<br /> " +
                                    (string)input.SelectToken("promodesc") + " promotion need your approval!<br />" +
                                    "Can you please approve:<br />" +
                                    "https://dwjtuavq6g.execute-api.us-east-1.amazonaws.com/respond/approved?taskToken=" + Uri.EscapeUriString(response.TaskToken) + "<br />" +
                                    "Or reject:<br />" +
                                    "https://dwjtuavq6g.execute-api.us-east-1.amazonaws.com/respond/reject?taskToken=" + Uri.EscapeUriString(response.TaskToken) + "</div>"
                    }
                };
                Content subjectContent = new Content
                {
                    Charset = "UTF-8",
                    Data = "Your Approval Needed for Promotion Id " + quoteid
                };
                //return response.Input ?? "".ToString();
                //body = new Body
                //{
                //    Html = new Content
                //    {
                //        Charset = "UTF-8",
                //        Data = "<h1>Hi Test</h1>"
                //    }//,
                //    //Text = new Content
                //    //{
                //    //    Charset = "UTF-8",
                //    //    Data = textBody
                //    //}
                //};


                Message msg = new Message { Body = body, Subject = subjectContent };
                SendEmailRequest s = new SendEmailRequest {
                    Source = "erpatel@gmail.com",
                    Destination= new Destination { ToAddresses= tolst },
                    Message= msg, 
                    ConfigurationSetName="sesconfigset",
                    SourceArn= "arn:aws:ses:us-east-1:494875521123:identity/erpatel@gmail.com"
                };
                var sataus = ses.SendEmailAsync(s);
                emailstatus =  sataus.Status.ToString();
                //string input,
                //var bucketName = System.Environment.GetEnvironmentVariable("mysqlconnection");
                //var quotenumber = GetQuote(58);
                //input = quotenumber.QuoteNumber;
                //return input?.ToUpper();
            }
            return emailstatus;
        }

        private void StartWorkflowInstance()
        {
            try {
            List<Quote> quotes = GetQuotesAsPerStage(1);//1 for Submitted
            foreach (var item in quotes)
            {
            //Check if any Promotion is submitted
            string inputToStepFunc = "{ \"quoteid\": \""+ item.QuoteID + "\", \"promodesc\" : \""+ item.TPBackground + "\" }";

            AmazonStepFunctionsClient stepfunctions = new AmazonStepFunctionsClient(Amazon.RegionEndpoint.USEast1);
            StartExecutionRequest newRequest = new StartExecutionRequest { StateMachineArn = "arn:aws:states:us-east-1:494875521123:stateMachine:PromotionApprovalStepFunction", Input = inputToStepFunc };
            stepfunctions.StartExecutionAsync(newRequest);
            }
            }
            catch (Exception ex)
            { throw ex; }
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

using Amazon.StepFunctions;
using Amazon.StepFunctions.Model;
using iPromoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iPromoWeb.DAO
{
    public class QuotePageDAO
    {
        public async Task<StartExecutionResponse> StartWorkflowInstanceAsync(Quote item)
        {
            StartExecutionResponse status = null;
            try
            {

                //Check if any Promotion is submitted

                //Console.WriteLine("1. Lambda start3"+ Directory.GetCurrentDirectory() + @"\iam.json");
                //_CredentialProfileStoreChain = new CredentialProfileStoreChain( );//@"/iam.json"
                //Console.WriteLine("Profile Location="+_CredentialProfileStoreChain.ProfilesLocation);
                //AWSCredentials awsCredentials;
                //if (_CredentialProfileStoreChain.TryGetAWSCredentials("default", out awsCredentials))//local-test-profile
                //{
                //    if (awsCredentials != null)
                //    {
                var aws_access_key_id = Environment.GetEnvironmentVariable("aws_access_key_id");
                var aws_secret_access_key = Environment.GetEnvironmentVariable("aws_secret_access_key");
                string inputToStepFunc = "{ \"quoteid\": \"" + item.QuoteID + "\", \"promodesc\" : \"" + item.TPBackground + "\" }";
                    using (AmazonStepFunctionsClient stepfunctions = new AmazonStepFunctionsClient(aws_access_key_id, aws_secret_access_key, Amazon.RegionEndpoint.USEast1))
                    {
                        Console.WriteLine("Gocha credentials going to invoke Step function");
                        string nameunique = "WF-"+ item.QuoteID + "-ON-"+ DateTime.Now.ToString("ddMMyyyyHHmmssfff");
                        StartExecutionRequest newRequest = new StartExecutionRequest { StateMachineArn = "arn:aws:states:us-east-1:494875521123:stateMachine:PromotionApprovalStepFunction", Input = inputToStepFunc, Name = nameunique };
                        Console.WriteLine("Step Func object is ready to be invoked.");
                        status = await stepfunctions.StartExecutionAsync(newRequest);
                        Console.WriteLine("Step Func invoke done" + status.ToString());
                    }
                    //}
                    //else
                    //    Console.WriteLine("Null AWS Credentilas found.");
                    //}
                    Console.WriteLine("Workflow is created for Quote id = " + item.QuoteID);
                

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.ToString());
                throw ex;
            }
            return status;
        }

    }
}

using Amazon.Lambda.Core;
using MySql.Data.MySqlClient;
//using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace AWSLambdaWorkflow
{
    public class Function
    {
        
        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public string FunctionHandler( ILambdaContext context)
        {
            //string input,
            string input = "www";
            var bucketName = System.Environment.GetEnvironmentVariable("mysqlconnection");
            var quotenumber = GetQuote(58);
            input = quotenumber.QuoteNumber;
            return input?.ToUpper();
        }
        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(System.Environment.GetEnvironmentVariable("mysqlconnection"));
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

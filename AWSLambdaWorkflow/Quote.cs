using System;
using System.Collections.Generic;
using System.Text;

namespace AWSLambdaWorkflow
{
    public class Quote
    {
        public int QuoteID { get; set; }
        public string QuoteNumber { get; set; }
        public int QuoteTypeID { get; set; }
        public int QuoteStatusLevelID { get; set; }
        public int QuoteStatusResultID { get; set; }
        public string TPBackground { get; set; }
    }
}

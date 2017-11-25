using System;
using System.Collections.Generic;
using System.Text;

namespace AWSLambdaWorkflow
{
    public partial class SalesOrg
    {


        public int UserID { get; set; }

        public string Title { get; set; }

        public int? BPartner { get; set; }

        public DateTime? ValidFrom { get; set; }

        public DateTime? ValidTo { get; set; }
        
        public string Email { get; set; }

        public string UserName { get; set; }

        public bool? IsRSM { get; set; }

        public string ADUserID { get; set; }
    }
}

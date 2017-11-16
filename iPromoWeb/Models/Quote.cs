using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace iPromoWeb.Models
{
    public class Quote
    {

        public int QuoteID { get; set; }
        [Required]
        [Display(Name = "QuoteNumber", Description = "QuoteNumber")]
        public string QuoteNumber { get; set; }
        [Required]
        [Display(Name = "Status", Description = "Status")]
        public int QuoteStatusResultID { get; set; }
        [Required]
        [Display(Name = "TPBackground", Description = "TPBackground")]
        public string TPBackground { get; set; }

        
        [Display(Name = "PromoFromDatetime", Description = "PromoFromDatetime")]
        public DateTime PromoFromDatetime { get; set; }

        [Display(Name = "PromolToDatetime", Description = "PromolToDatetime")]
        public DateTime PromolToDatetime { get; set; }

        
        [Display(Name = "Token", Description = "Token")]
        public string Token { get; set; }

        
    }
}

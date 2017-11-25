using System;
using System.Collections.Generic;
using System.Text;

namespace AWSLambdaWorkflow
{
  
    public partial class Quote
    {
           
        public long QuoteID { get; set; }

      
        public string QuoteNumber { get; set; }

      
        public string ValidTill { get; set; }

        public int QuoteTypeID { get; set; }

        public int QuoteStatusLevelID { get; set; }

        public int QuoteStatusResultID { get; set; }

      
        public string PlanningAccountNumber { get; set; }

       
        public string EndCustomerID { get; set; }

  
        public string EndUser { get; set; }

    
        public string CustomerWebSite { get; set; }

        public byte[] Comments { get; set; }

        public DateTime? NeedPriceApprovedBy { get; set; }

        public DateTime? PromoFromDatetime { get; set; }

        public DateTime? PromolToDatetime { get; set; }

        public string TPBackground { get; set; }

        public byte[] AdditionalRequirements { get; set; }

        public DateTime? SubmitDatetime { get; set; }

        public int? SubmittedByUserID { get; set; }

        public int? CreatedByUserID { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public int? LastModifiedByUserID { get; set; }

        public DateTime? LastModifiedDatetime { get; set; }

        public DateTime? QuoteExpirationDate { get; set; }

        public string RejRetReason { get; set; }

     
        public string SerialNumber { get; set; }

        public string PublicComments { get; set; }

        public string PrivateComments { get; set; }

        public int? AccountManagerID { get; set; }

        public DateTime? ExpiryNotificationDate { get; set; }

       
        public string Currency { get; set; }

        public byte? QuoteSubTypeID { get; set; }

   
        public string CRM_Status { get; set; }

        public string CRM_Messages { get; set; }

        public int? RSMApprovedByUserID { get; set; }

        public int? RSMActualApprovedByUserID { get; set; }

        public DateTime? RSMApprovedDateTime { get; set; }

        public int? RSDApprovedByUserID { get; set; }

        public int? RSDActualApprovedByUserID { get; set; }

        public DateTime? RSDApprovedDateTime { get; set; }

        public int? PMApprovedByUserID { get; set; }

        public int? PMActualApprovedByUserID { get; set; }

        public DateTime? PMApprovedDateTime { get; set; }

        public int? VPFinanceApprovedByUserID { get; set; }

        public int? VPFinanceActualApprovedByUserID { get; set; }

        public DateTime? VPFinanceApprovedDateTime { get; set; }

        public int? CanceledByUserID { get; set; }

        public DateTime? CanceledDateTime { get; set; }

        public byte[] CancelReason { get; set; }

        public DateTime? SecondExpiryNotificationDate { get; set; }

        public DateTime? FinalExpiryNotificationDate { get; set; }

        public DateTime? LossNotificationDate { get; set; }

        public decimal? TotalValue { get; set; }
        public decimal? ExchangeRate { get; set; }

  
        public string Application { get; set; }


        public string Project { get; set; }

        public bool? ExistingProject { get; set; }

        public DateTime? ExpectedShipDate { get; set; }

        public DateTime? WinLossDateTime { get; set; }

        public int? WinLossUserID { get; set; }

        public DateTime? RevenueApporvalDate { get; set; }

        public DateTime? InQWinlossDate { get; set; }

      
        public string BillTo { get; set; }

   
        public string ShipTo { get; set; }

        public byte[] CommentforPDF { get; set; }

        public int? PEApprovedByUserId { get; set; }

        public int? PEActualApprovedByUserId { get; set; }

        public DateTime? PEApprovedDateTime { get; set; }
        
        public string Action { get; set; }

        public string Token { get; set; }


    }
}

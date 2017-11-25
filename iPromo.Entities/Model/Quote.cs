namespace iPromo.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("Quote")]
    public partial class Quote
    {
        public Quote()
        {
            QuoteItem = new HashSet<QuoteItem>();
        }
        [Key]
        public long QuoteID { get; set; }

        [StringLength(100)]
        public string QuoteNumber { get; set; }

        [StringLength(10)]
        public string ValidTill { get; set; }

        public byte? QuoteTypeID { get; set; }

        public byte? QuoteStatusLevelID { get; set; }

        public byte? QuoteStatusResultID { get; set; }

        [StringLength(10)]
        public string PlanningAccountNumber { get; set; }

        [StringLength(10)]
        public string EndCustomerID { get; set; }

        [StringLength(250)]
        public string EndUser { get; set; }

        [StringLength(250)]
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

        [StringLength(50)]
        public string SerialNumber { get; set; }

        public string PublicComments { get; set; }

        public string PrivateComments { get; set; }

        public int? AccountManagerID { get; set; }

        public DateTime? ExpiryNotificationDate { get; set; }

        [StringLength(50)]
        public string Currency { get; set; }

        public byte? QuoteSubTypeID { get; set; }

        [Column("CRM Status")]
        [StringLength(50)]
        public string CRM_Status { get; set; }

        [Column("CRM Messages")]
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

        [StringLength(100)]
        public string Application { get; set; }

        [StringLength(100)]
        public string Project { get; set; }

        public bool? ExistingProject { get; set; }

        public DateTime? ExpectedShipDate { get; set; }

        public DateTime? WinLossDateTime { get; set; }

        public int? WinLossUserID { get; set; }

        public DateTime? RevenueApporvalDate { get; set; }

        public DateTime? InQWinlossDate { get; set; }

        [StringLength(10)]
        public string BillTo { get; set; }

        [StringLength(10)]
        public string ShipTo { get; set; }

        public byte[] CommentforPDF { get; set; }

        public int? PEApprovedByUserId { get; set; }

        public int? PEActualApprovedByUserId { get; set; }

        public DateTime? PEApprovedDateTime { get; set; }

  
        public string Action { get; set; }

        public string Token { get; set; }

        public virtual ICollection<QuoteItem> QuoteItem { get; set; }

    }
}

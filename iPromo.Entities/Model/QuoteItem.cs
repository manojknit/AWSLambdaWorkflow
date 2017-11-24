namespace iPromo.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("QuoteItem")]
    public partial class QuoteItem
    {
        public QuoteItem()
        {
        }

        public long QuoteItemID { get; set; }

        public long QuoteID { get; set; }

        public byte? QuoteItemTypeID { get; set; }

        [StringLength(50)]
        public string ProductNumber { get; set; }

        public decimal? ListPrice { get; set; }

        [StringLength(1)]
        public string WinLoss { get; set; }

        public int? WinQuantity { get; set; }

        public decimal? WinNetPrice { get; set; }

        public decimal? WinPOS { get; set; }

        public decimal? WinAdCost { get; set; }

        public bool? IsPOS { get; set; }

        [StringLength(500)]
        public string LossReason { get; set; }

        [StringLength(250)]
        public string Competitor1 { get; set; }

        public decimal? Competitor1Price { get; set; }

        [StringLength(250)]
        public string Competitor2 { get; set; }

        public decimal? Competitor2Price { get; set; }

        public int? RequestedQuantity { get; set; }

        public decimal? RequestedNetPrice { get; set; }

        public decimal? RequestedPOS { get; set; }

        public decimal? RSMRedLine { get; set; }

        public decimal? RSDRedLine { get; set; }

        public decimal? RSDApprovedPrice { get; set; }

        public decimal? BidDeskRedLine { get; set; }

        public decimal? BidDeskApprovedPrice { get; set; }

        public decimal? MMRedLine { get; set; }

        public decimal? MMApprovedPrice { get; set; }

        public decimal? PMRedLine { get; set; }

        public decimal? PMApprovedPrice { get; set; }

        public decimal? VPSalesRedLine { get; set; }

        public decimal? VPSalesApprovedPrice { get; set; }

        public decimal? VPFinanceApprovedPrice { get; set; }

        public int CreatedByUserID { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedDateTime { get; set; }

        public int LastUpdatedByUserID { get; set; }

        public DateTime UpdatedByDateTime { get; set; }

        [StringLength(60)]
        public string ProductDescription { get; set; }

        [StringLength(60)]
        public string ProductName { get; set; }

        public DateTime? ListPriceAsOf { get; set; }

        public decimal? ProductCost { get; set; }

        public int? ProductCostRegionID { get; set; }

        public decimal? MSRP { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public decimal? PERedLine { get; set; }

        public decimal? PEApprovedPrice { get; set; }

        public virtual Quote Quote { get; set; }


    }
}

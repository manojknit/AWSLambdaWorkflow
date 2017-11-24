namespace iPromo.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("Redline")]
    public partial class Redline
    {
        public long RedlineID { get; set; }

        public long RedLineFileInfoID { get; set; }

        [StringLength(5)]
        public string Channel { get; set; }

        public short Status { get; set; }

        [Required]
        [StringLength(20)]
        public string ProductFamily { get; set; }

        public short CurrencyID { get; set; }

        [Required]
        [StringLength(50)]
        public string Role { get; set; }

        public DateTime ValidFrom { get; set; }

        public DateTime ValidTo { get; set; }

        public decimal RedLineValue { get; set; }

        [StringLength(18)]
        public string SKU { get; set; }

        [StringLength(10)]
        public string CustomerNumber { get; set; }

        [StringLength(10)]
        public string SalesRegion { get; set; }

        [StringLength(10)]
        public string SalesSubRegion { get; set; }

        public int? ApprovedUserID { get; set; }

        public DateTime? ApprovedDateTime { get; set; }

        public int? RejectedUserID { get; set; }

        public DateTime? RejectedDateTime { get; set; }

        public int? RevokedUserID { get; set; }

        public DateTime? RevokedDateTime { get; set; }

    }
}

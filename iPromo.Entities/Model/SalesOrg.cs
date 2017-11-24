namespace iPromo.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("SalesOrg")]
    public partial class SalesOrg
    {
        
        [Column(Order = 0)]
        
        public int UserID { get; set; }

        
        [Column(Order = 1)]
        [StringLength(20)]
        public string Title { get; set; }

        public int? BPartner { get; set; }

        public DateTime? ValidFrom { get; set; }

        public DateTime? ValidTo { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        [StringLength(255)]
        public string UserName { get; set; }

        public bool? IsRSM { get; set; }

        [StringLength(255)]
        public string ADUserID { get; set; }
    }
}

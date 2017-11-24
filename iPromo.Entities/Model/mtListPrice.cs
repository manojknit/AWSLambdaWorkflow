using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace iPromo.Entities
{
    [Table("mtListPrice")]
    public partial class mtListPrice
    {
        [StringLength(50)]
        public string Material { get; set; } //[varchar](50) NULL,
        [StringLength(50)]
        public string Price_List { get; set; }//[varchar] (50) NULL,
        [StringLength(50)]
        public string Price_Grp { get; set; }//  [varchar] (50) NULL,
        [StringLength(50)]
        public string Bic_ZConType { get; set; }// [varchar] (50) NULL,
        [StringLength(50)]
        public string Prc_Lst_Su { get; set; }// [varchar] (50) NULL,
        [StringLength(50)]
        public string Currency { get; set; }// [varchar] (50) NULL,
        [StringLength(50)]
        public string ValidTo { get; set; }//[varchar] (50) NULL,
        [StringLength(50)]
        public string ValidFrom { get; set; }// [varchar] (50) NULL
    }
}

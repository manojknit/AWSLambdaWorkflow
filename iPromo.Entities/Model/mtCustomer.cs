namespace iPromo.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("mtCustomer")]
    public partial class mtCustomer
    {
        [Key]
        [StringLength(10)]
        public string CustomerNumber { get; set; }

        [Column("Customer Desc")]
        [StringLength(255)]
        public string Customer_Desc { get; set; }

        [Column("Customer Acct Grp")]
        [StringLength(255)]
        public string Customer_Acct_Grp { get; set; }

        [Column("Customer Acct Grp Desc")]
        [StringLength(255)]
        public string Customer_Acct_Grp_Desc { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        [Column("Bill-to party")]
        [StringLength(255)]
        public string Bill_to_party { get; set; }

        [Column("Bill-to party Desc")]
        [StringLength(255)]
        public string Bill_to_party_Desc { get; set; }

        [Column("Business Partner")]
        [StringLength(255)]
        public string Business_Partner { get; set; }

        [StringLength(35)]
        public string Location { get; set; }

        [StringLength(3)]
        public string CountryKey { get; set; }

        [StringLength(255)]
        public string CountryName { get; set; }

        [Column("Customer Segment")]
        [StringLength(255)]
        public string Customer_Segment { get; set; }

        [Column("Customer Segment Desc")]
        [StringLength(255)]
        public string Customer_Segment_Desc { get; set; }

        [Column("Allocation Territory")]
        [StringLength(255)]
        public string Allocation_Territory { get; set; }

        [Column("Allocation Territory Desc")]
        [StringLength(255)]
        public string Allocation_Territory_Desc { get; set; }

        [Column("CustHier 1")]
        [StringLength(255)]
        public string CustHier_1 { get; set; }

        [Column("CustHier 2")]
        [StringLength(255)]
        public string CustHier_2 { get; set; }

        [Column("CustHier 3")]
        [StringLength(255)]
        public string CustHier_3 { get; set; }

        [Column("Customer Market")]
        [StringLength(255)]
        public string Customer_Market { get; set; }

        [Column("Customer is Consumer")]
        [StringLength(255)]
        public string Customer_is_Consumer { get; set; }

        [StringLength(31)]
        public string FaxNumber { get; set; }

        [Column("Fiscal Year Variant")]
        [StringLength(255)]
        public string Fiscal_Year_Variant { get; set; }

        [StringLength(35)]
        public string Name1 { get; set; }

        [StringLength(35)]
        public string Name2 { get; set; }

        [StringLength(35)]
        public string Name3 { get; set; }

        [StringLength(255)]
        public string Payer { get; set; }

        [Column("Payer Desc")]
        [StringLength(255)]
        public string Payer_Desc { get; set; }

        [Column("Telephone 1")]
        [StringLength(255)]
        public string Telephone_1 { get; set; }

        [StringLength(255)]
        public string Plant { get; set; }

        [Column("P#O# Box")]
        [StringLength(255)]
        public string P_O__Box { get; set; }

        [StringLength(10)]
        public string PostalCode { get; set; }

        [StringLength(2)]
        public string CustomerPriceGroup { get; set; }

        [StringLength(2)]
        public string PriceListType { get; set; }

        [StringLength(3)]
        public string State { get; set; }

        [Column("Sales District")]
        [StringLength(255)]
        public string Sales_District { get; set; }

        [Column("Sales District Desc")]
        [StringLength(255)]
        public string Sales_District_Desc { get; set; }

        [Column("Fund Sales District")]
        [StringLength(255)]
        public string Fund_Sales_District { get; set; }

        [Column("Fund Sales District Desc")]
        [StringLength(255)]
        public string Fund_Sales_District_Desc { get; set; }

        [StringLength(10)]
        public string SortField { get; set; }

        [Column("Street Name")]
        [StringLength(255)]
        public string Street_Name { get; set; }

        [StringLength(255)]
        public string Vendor { get; set; }

        [Column("Allocation Channel")]
        [StringLength(255)]
        public string Allocation_Channel { get; set; }

        [Column("Allocation Territory Group")]
        [StringLength(255)]
        public string Allocation_Territory_Group { get; set; }

        [Column("Channle Partner Prof")]
        [StringLength(255)]
        public string Channle_Partner_Prof { get; set; }

        [Column("Customer Business Group")]
        [StringLength(255)]
        public string Customer_Business_Group { get; set; }

        [Column("Credit Hold Status")]
        [StringLength(255)]
        public string Credit_Hold_Status { get; set; }

        [StringLength(10)]
        public string ExternalSalesRep1 { get; set; }

        [StringLength(10)]
        public string ExternalSalesRep2 { get; set; }

        [StringLength(10)]
        public string ExternalSalesRep3 { get; set; }

        [Column("Geographical Region")]
        [StringLength(255)]
        public string Geographical_Region { get; set; }

        [Column("I2 RSM Allocation Channel")]
        [StringLength(255)]
        public string I2_RSM_Allocation_Channel { get; set; }

        [Column("I2 RSM Allocation Territory Group")]
        [StringLength(255)]
        public string I2_RSM_Allocation_Territory_Group { get; set; }

        [Column("I2 RSM Customer Group 4")]
        [StringLength(255)]
        public string I2_RSM_Customer_Group_4 { get; set; }

        [Column("I2 Distribution Channel")]
        [StringLength(255)]
        public string I2_Distribution_Channel { get; set; }

        [Column("I2 RSM Promotion Group")]
        [StringLength(255)]
        public string I2_RSM_Promotion_Group { get; set; }

        [Column("I2 RSM ID")]
        [StringLength(255)]
        public string I2_RSM_ID { get; set; }

        [StringLength(10)]
        public string InternalSalesRep1 { get; set; }

        [StringLength(10)]
        public string InternalSalesRep2 { get; set; }

        [StringLength(10)]
        public string InternalSalesRep3 { get; set; }

        [StringLength(4)]
        public string SalesOrg { get; set; }

        [StringLength(2)]
        public string DistributionChannel { get; set; }

        public bool? ShowAll { get; set; }

        [StringLength(255)]
        public string PRICE_GROUP_DESC { get; set; }

        [StringLength(255)]
        public string PRICE_LIST_TYPE { get; set; }

        [StringLength(255)]
        public string SOLDTO_SHIPTO_DESC { get; set; }

        [StringLength(255)]
        public string CUST_HIER1_DESC { get; set; }

        [StringLength(255)]
        public string STATE_DESC { get; set; }

        [StringLength(255)]
        public string MARKET_COUNTRY { get; set; }

        [StringLength(255)]
        public string MARKET_SUBREGION { get; set; }

        [StringLength(255)]
        public string CUSTOMER_CLASSIFICATION { get; set; }

        [StringLength(255)]
        public string ALLOCATION_CHANNEL_DESC { get; set; }

        [StringLength(255)]
        public string ALLOCATION_TERR_GRP_DESC { get; set; }

        [StringLength(255)]
        public string CUSTOMER_BUS_GROUP_DESC { get; set; }

        [StringLength(50)]
        public string OrderBlock { get; set; }

        [StringLength(60)]
        public string MARKET_SUBREGION_Desc { get; set; }

        [StringLength(60)]
        public string Geographical_Region_desc { get; set; }

        [StringLength(50)]
        public string Currency { get; set; }

        [StringLength(50)]
        public string Market_Country_desc { get; set; }

        [StringLength(60)]
        public string SalesOrg_desc { get; set; }

        [StringLength(50)]
        public string DISTRI_CHAN_DESC { get; set; }

        [StringLength(50)]
        public string CRM_SALORG { get; set; }

        [StringLength(50)]
        public string MARKED_FOR_DELETE { get; set; }

        [StringLength(50)]
        public string TAX_STATUS { get; set; }

        [Column("OEM Subgroup")]
        [StringLength(50)]
        public string OEM_Subgroup { get; set; }

        [StringLength(50)]
        public string CustomerType { get; set; }

        [StringLength(50)]
        public string IndustryCode { get; set; }

        public int? SortOrder { get; set; }

        public bool? DoNotUse { get; set; }

        public bool? CustomCostCalc { get; set; }
    }
}

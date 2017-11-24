namespace iPromo.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using iPromo.Entities;
    using Microsoft.EntityFrameworkCore;

    public partial class iPromoDataContext : DbContext
    {
        string _cn;
        public iPromoDataContext()
        {
            _cn = "server=192.168.14.62;database=iPromo6;user=root;password=sa@123456;port=3306;SslMode=none";
        }
        public iPromoDataContext(string cn)
        {
            _cn = cn;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(_cn);
        }
        public virtual DbSet<mtCustomer> mtCustomer { get; set; }
        public virtual DbSet<Quote> Quote { get; set; }
        public virtual DbSet<QuoteItem> QuoteItem { get; set; }
        public virtual DbSet<Redline> Redline { get; set; }
        public virtual DbSet<SalesOrg> SalesOrg { get; set; }

        public virtual DbSet<mtListPrice> mtListPrice { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.CustomerNumber)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.Customer_Desc)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.Customer_Acct_Grp)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.Customer_Acct_Grp_Desc)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.Bill_to_party)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.Bill_to_party_Desc)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.Business_Partner)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.Location)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.CountryKey)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.CountryName)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.Customer_Segment)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.Customer_Segment_Desc)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.Allocation_Territory)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.Allocation_Territory_Desc)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.CustHier_1)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.CustHier_2)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.CustHier_3)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.Customer_Market)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.Customer_is_Consumer)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.FaxNumber)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.Fiscal_Year_Variant)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.Name1)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.Name2)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.Name3)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.Payer)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.Payer_Desc)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.Telephone_1)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.Plant)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.P_O__Box)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.PostalCode)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.CustomerPriceGroup)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.PriceListType)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.State)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.Sales_District)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.Sales_District_Desc)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.Fund_Sales_District)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.Fund_Sales_District_Desc)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.SortField)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.Street_Name)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.Vendor)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.Allocation_Channel)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.Allocation_Territory_Group)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.Channle_Partner_Prof)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.Customer_Business_Group)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.Credit_Hold_Status)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.ExternalSalesRep1)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.ExternalSalesRep2)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.ExternalSalesRep3)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.Geographical_Region)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.I2_RSM_Allocation_Channel)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.I2_RSM_Allocation_Territory_Group)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.I2_RSM_Customer_Group_4)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.I2_Distribution_Channel)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.I2_RSM_Promotion_Group)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.I2_RSM_ID)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.InternalSalesRep1)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.InternalSalesRep2)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.InternalSalesRep3)
                .IsUnicode(false);


            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.SalesOrg)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.DistributionChannel)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.PRICE_GROUP_DESC)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.PRICE_LIST_TYPE)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.SOLDTO_SHIPTO_DESC)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.CUST_HIER1_DESC)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.STATE_DESC)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.MARKET_COUNTRY)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.MARKET_SUBREGION)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.CUSTOMER_CLASSIFICATION)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.ALLOCATION_CHANNEL_DESC)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.ALLOCATION_TERR_GRP_DESC)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.CUSTOMER_BUS_GROUP_DESC)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.OrderBlock)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.MARKET_SUBREGION_Desc)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.Geographical_Region_desc)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.Currency)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.Market_Country_desc)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.SalesOrg_desc)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.DISTRI_CHAN_DESC)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.CRM_SALORG)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.MARKED_FOR_DELETE)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.TAX_STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.OEM_Subgroup)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.CustomerType)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
                .Property(e => e.IndustryCode)
                .IsUnicode(false);

            modelBuilder.Entity<Quote>()
                .Property(e => e.QuoteNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Quote>()
                .Property(e => e.ValidTill)
                .IsUnicode(false);

            modelBuilder.Entity<Quote>()
                .Property(e => e.PlanningAccountNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Quote>()
                .Property(e => e.EndCustomerID)
                .IsUnicode(false);

            modelBuilder.Entity<Quote>()
                .Property(e => e.EndUser)
                .IsUnicode(false);


            modelBuilder.Entity<Quote>()
                .Property(e => e.Comments)
                .IsUnicode(false);

            modelBuilder.Entity<Quote>()
                .Property(e => e.TPBackground)
                .IsUnicode(false);

            modelBuilder.Entity<Quote>()
                .Property(e => e.RejRetReason)
                .IsUnicode(false);

            modelBuilder.Entity<Quote>()
                .Property(e => e.SerialNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Quote>()
                .Property(e => e.PublicComments)
                .IsUnicode(false);

            modelBuilder.Entity<Quote>()
                .Property(e => e.PrivateComments)
                .IsUnicode(false);

            modelBuilder.Entity<Quote>()
                .Property(e => e.Currency)
                .IsUnicode(false);

            modelBuilder.Entity<Quote>()
                .Property(e => e.CRM_Status)
                .IsUnicode(false);

            modelBuilder.Entity<Quote>()
                .Property(e => e.CRM_Messages)
                .IsUnicode(false);

            modelBuilder.Entity<Quote>()
                .Property(e => e.CancelReason)
                .IsUnicode(false);

            modelBuilder.Entity<Quote>()
                .Property(e => e.TotalValue)
                 .HasColumnType("decimal(13, 2)");

            modelBuilder.Entity<Quote>()
                .Property(e => e.ExchangeRate)
                 .HasColumnType("decimal(13, 6)");

            modelBuilder.Entity<Quote>()
                .Property(e => e.Application)
                .IsUnicode(false);

            modelBuilder.Entity<Quote>()
                .Property(e => e.Project)
                .IsUnicode(false);

            modelBuilder.Entity<Quote>()
                .Property(e => e.BillTo)
                .IsUnicode(false);

            modelBuilder.Entity<Quote>()
                .Property(e => e.ShipTo)
                .IsUnicode(false);

            modelBuilder.Entity<Quote>()
                .Property(e => e.CommentforPDF)
                .IsUnicode(false);

            modelBuilder.Entity<Quote>()
                .Property(e => e.Action)
                .IsUnicode(false);

            modelBuilder.Entity<Quote>()
                .HasMany(e => e.QuoteItem)
                .WithOne(e => e.Quote);

            modelBuilder.Entity<QuoteItem>()
                .Property(e => e.ProductNumber)
                .IsUnicode(false);

            modelBuilder.Entity<QuoteItem>()
                .Property(e => e.ListPrice)
                 .HasColumnType("decimal(13, 2)");

            modelBuilder.Entity<QuoteItem>()
                .Property(e => e.WinLoss)
                .IsUnicode(false);

            modelBuilder.Entity<QuoteItem>()
                .Property(e => e.WinNetPrice)
                 .HasColumnType("decimal(13, 2)");

            modelBuilder.Entity<QuoteItem>()
                .Property(e => e.WinPOS)
                 .HasColumnType("decimal(13, 2)");

            modelBuilder.Entity<QuoteItem>()
                .Property(e => e.WinAdCost)
                .HasColumnType("decimal(13, 2)");

            modelBuilder.Entity<QuoteItem>()
                .Property(e => e.LossReason)
                .IsUnicode(false);

            modelBuilder.Entity<QuoteItem>()
                .Property(e => e.Competitor1)
                .IsUnicode(false);

            modelBuilder.Entity<QuoteItem>()
                .Property(e => e.Competitor1Price)
                .HasColumnType("decimal(13, 2)");

            modelBuilder.Entity<QuoteItem>()
                .Property(e => e.Competitor2)
                .IsUnicode(false);

            modelBuilder.Entity<QuoteItem>()
                .Property(e => e.Competitor2Price)
                .HasColumnType("decimal(13, 2)");

            modelBuilder.Entity<QuoteItem>()
                .Property(e => e.RequestedNetPrice)
                .HasColumnType("decimal(13, 2)");

            modelBuilder.Entity<QuoteItem>()
                .Property(e => e.RequestedPOS)
                .HasColumnType("decimal(13, 2)");

            modelBuilder.Entity<QuoteItem>()
                .Property(e => e.RSMRedLine)
                .HasColumnType("decimal(13, 2)");

            modelBuilder.Entity<QuoteItem>()
                .Property(e => e.RSDRedLine)
                .HasColumnType("decimal(13, 2)");

            modelBuilder.Entity<QuoteItem>()
                .Property(e => e.RSDApprovedPrice)
                .HasColumnType("decimal(13, 2)");

            modelBuilder.Entity<QuoteItem>()
                .Property(e => e.BidDeskRedLine)
                .HasColumnType("decimal(13, 2)");

            modelBuilder.Entity<QuoteItem>()
                .Property(e => e.BidDeskApprovedPrice)
                .HasColumnType("decimal(13, 2)");

            modelBuilder.Entity<QuoteItem>()
                .Property(e => e.MMRedLine)
                .HasColumnType("decimal(13, 2)");

            modelBuilder.Entity<QuoteItem>()
                .Property(e => e.MMApprovedPrice)
                .HasColumnType("decimal(13, 2)");

            modelBuilder.Entity<QuoteItem>()
                .Property(e => e.PMRedLine)
                .HasColumnType("decimal(13, 2)");

            modelBuilder.Entity<QuoteItem>()
                .Property(e => e.PMApprovedPrice)
                .HasColumnType("decimal(13, 2)");

            modelBuilder.Entity<QuoteItem>()
                .Property(e => e.VPSalesRedLine)
                .HasColumnType("decimal(13, 2)");

            modelBuilder.Entity<QuoteItem>()
                .Property(e => e.VPSalesApprovedPrice)
                .HasColumnType("decimal(13, 2)");

            modelBuilder.Entity<QuoteItem>()
                .Property(e => e.VPFinanceApprovedPrice)
                .HasColumnType("decimal(13, 2)");

            modelBuilder.Entity<QuoteItem>()
                .Property(e => e.ProductDescription)
                .IsUnicode(false);

            modelBuilder.Entity<QuoteItem>()
                .Property(e => e.ProductName)
                .IsUnicode(false);

            modelBuilder.Entity<QuoteItem>()
                .Property(e => e.ProductCost)
                .HasColumnType("decimal(13, 2)");

            modelBuilder.Entity<QuoteItem>()
                .Property(e => e.MSRP)
                .HasColumnType("decimal(13, 2)");

            modelBuilder.Entity<QuoteItem>()
                .Property(e => e.PERedLine)
                .HasColumnType("decimal(13, 2)");

            modelBuilder.Entity<QuoteItem>()
                .Property(e => e.PEApprovedPrice)
                .HasColumnType("decimal(13, 2)");


            modelBuilder.Entity<Redline>()
                .Property(e => e.Channel)
                .IsUnicode(false);

            modelBuilder.Entity<Redline>()
                .Property(e => e.ProductFamily)
                .IsUnicode(false);

            modelBuilder.Entity<Redline>()
                .Property(e => e.Role)
                .IsUnicode(false);

            modelBuilder.Entity<Redline>()
                .Property(e => e.RedLineValue)
                .HasColumnType("decimal(13, 2)");

            modelBuilder.Entity<Redline>()
                .Property(e => e.SKU)
                .IsUnicode(false);

            modelBuilder.Entity<Redline>()
                .Property(e => e.CustomerNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Redline>()
                .Property(e => e.SalesRegion)
                .IsUnicode(false);

            modelBuilder.Entity<Redline>()
                .Property(e => e.SalesSubRegion)
                .IsUnicode(false);


            modelBuilder.Entity<SalesOrg>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<SalesOrg>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<SalesOrg>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<SalesOrg>()
                .Property(e => e.ADUserID)
                .IsUnicode(false);

            modelBuilder.Entity<mtCustomer>()
              .HasKey(c => new { c.CustomerNumber });


            modelBuilder.Entity<SalesOrg>()
                .HasKey(c => new { c.UserID, c.Title });

            modelBuilder.Entity<SalesOrg>()
                .HasKey(c => new { c.UserID, c.Title });


            modelBuilder.Entity<mtListPrice>()
                .HasKey(c => new { c.Material, c.Price_List, c.Price_Grp });
        }
    }
}

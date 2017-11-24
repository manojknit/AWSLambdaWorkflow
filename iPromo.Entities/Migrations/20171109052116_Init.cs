using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace iPromo.Entities.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mtCustomer",
                columns: table => new
                {
                    CustomerNumber = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    ALLOCATION_CHANNEL_DESC = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ALLOCATION_TERR_GRP_DESC = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Address = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    AllocationChannel = table.Column<string>(name: "Allocation Channel", type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    AllocationTerritory = table.Column<string>(name: "Allocation Territory", type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    AllocationTerritoryDesc = table.Column<string>(name: "Allocation Territory Desc", type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    AllocationTerritoryGroup = table.Column<string>(name: "Allocation Territory Group", type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Billtoparty = table.Column<string>(name: "Bill-to party", type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    BilltopartyDesc = table.Column<string>(name: "Bill-to party Desc", type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    BusinessPartner = table.Column<string>(name: "Business Partner", type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    CRM_SALORG = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CUSTOMER_BUS_GROUP_DESC = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    CUSTOMER_CLASSIFICATION = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    CUST_HIER1_DESC = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ChannlePartnerProf = table.Column<string>(name: "Channle Partner Prof", type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    CountryKey = table.Column<string>(type: "varchar(3)", unicode: false, maxLength: 3, nullable: true),
                    CountryName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    CreditHoldStatus = table.Column<string>(name: "Credit Hold Status", type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Currency = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CustHier1 = table.Column<string>(name: "CustHier 1", type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    CustHier2 = table.Column<string>(name: "CustHier 2", type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    CustHier3 = table.Column<string>(name: "CustHier 3", type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    CustomCostCalc = table.Column<bool>(type: "bit", nullable: true),
                    CustomerPriceGroup = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: true),
                    CustomerType = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CustomerAcctGrp = table.Column<string>(name: "Customer Acct Grp", type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    CustomerAcctGrpDesc = table.Column<string>(name: "Customer Acct Grp Desc", type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    CustomerBusinessGroup = table.Column<string>(name: "Customer Business Group", type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    CustomerDesc = table.Column<string>(name: "Customer Desc", type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    CustomerMarket = table.Column<string>(name: "Customer Market", type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    CustomerSegment = table.Column<string>(name: "Customer Segment", type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    CustomerSegmentDesc = table.Column<string>(name: "Customer Segment Desc", type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    CustomerisConsumer = table.Column<string>(name: "Customer is Consumer", type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    DISTRI_CHAN_DESC = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    DistributionChannel = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: true),
                    DoNotUse = table.Column<bool>(type: "bit", nullable: true),
                    ExternalSalesRep1 = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    ExternalSalesRep2 = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    ExternalSalesRep3 = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    FaxNumber = table.Column<string>(type: "varchar(31)", unicode: false, maxLength: 31, nullable: true),
                    FiscalYearVariant = table.Column<string>(name: "Fiscal Year Variant", type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    FundSalesDistrict = table.Column<string>(name: "Fund Sales District", type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    FundSalesDistrictDesc = table.Column<string>(name: "Fund Sales District Desc", type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    GeographicalRegion = table.Column<string>(name: "Geographical Region", type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Geographical_Region_desc = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: true),
                    I2DistributionChannel = table.Column<string>(name: "I2 Distribution Channel", type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    I2RSMAllocationChannel = table.Column<string>(name: "I2 RSM Allocation Channel", type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    I2RSMAllocationTerritoryGroup = table.Column<string>(name: "I2 RSM Allocation Territory Group", type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    I2RSMCustomerGroup4 = table.Column<string>(name: "I2 RSM Customer Group 4", type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    I2RSMID = table.Column<string>(name: "I2 RSM ID", type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    I2RSMPromotionGroup = table.Column<string>(name: "I2 RSM Promotion Group", type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    IndustryCode = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    InternalSalesRep1 = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    InternalSalesRep2 = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    InternalSalesRep3 = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    Location = table.Column<string>(type: "varchar(35)", unicode: false, maxLength: 35, nullable: true),
                    MARKED_FOR_DELETE = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    MARKET_COUNTRY = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    MARKET_SUBREGION = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    MARKET_SUBREGION_Desc = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: true),
                    Market_Country_desc = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Name1 = table.Column<string>(type: "varchar(35)", unicode: false, maxLength: 35, nullable: true),
                    Name2 = table.Column<string>(type: "varchar(35)", unicode: false, maxLength: 35, nullable: true),
                    Name3 = table.Column<string>(type: "varchar(35)", unicode: false, maxLength: 35, nullable: true),
                    OEMSubgroup = table.Column<string>(name: "OEM Subgroup", type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    OrderBlock = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    PRICE_GROUP_DESC = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    PRICE_LIST_TYPE = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    POBox = table.Column<string>(name: "P#O# Box", type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Payer = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    PayerDesc = table.Column<string>(name: "Payer Desc", type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Plant = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    PostalCode = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    PriceListType = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: true),
                    SOLDTO_SHIPTO_DESC = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    STATE_DESC = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    SalesOrg = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: true),
                    SalesOrg_desc = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: true),
                    SalesDistrict = table.Column<string>(name: "Sales District", type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    SalesDistrictDesc = table.Column<string>(name: "Sales District Desc", type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ShowAll = table.Column<bool>(type: "bit", nullable: true),
                    SortField = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    SortOrder = table.Column<int>(type: "int", nullable: true),
                    State = table.Column<string>(type: "varchar(3)", unicode: false, maxLength: 3, nullable: true),
                    StreetName = table.Column<string>(name: "Street Name", type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    TAX_STATUS = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Telephone1 = table.Column<string>(name: "Telephone 1", type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Vendor = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mtCustomer", x => x.CustomerNumber);
                });

            migrationBuilder.CreateTable(
                name: "Quote",
                columns: table => new
                {
                    QuoteID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AccountManagerID = table.Column<int>(type: "int", nullable: true),
                    Action = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    AdditionalRequirements = table.Column<byte[]>(type: "longblob", nullable: true),
                    Application = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    BillTo = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    CRMMessages = table.Column<string>(name: "CRM Messages", type: "longtext", unicode: false, nullable: true),
                    CRMStatus = table.Column<string>(name: "CRM Status", type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CancelReason = table.Column<byte[]>(type: "longblob", unicode: false, nullable: true),
                    CanceledByUserID = table.Column<int>(type: "int", nullable: true),
                    CanceledDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CommentforPDF = table.Column<byte[]>(type: "longblob", unicode: false, nullable: true),
                    Comments = table.Column<byte[]>(type: "longblob", unicode: false, nullable: true),
                    CreatedByUserID = table.Column<int>(type: "int", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Currency = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CustomerWebSite = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    EndCustomerID = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    EndUser = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    ExchangeRate = table.Column<decimal>(type: "decimal(13, 6)", nullable: true),
                    ExistingProject = table.Column<bool>(type: "bit", nullable: true),
                    ExpectedShipDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ExpiryNotificationDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    FinalExpiryNotificationDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    InQWinlossDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifiedByUserID = table.Column<int>(type: "int", nullable: true),
                    LastModifiedDatetime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LossNotificationDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    NeedPriceApprovedBy = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    PEActualApprovedByUserId = table.Column<int>(type: "int", nullable: true),
                    PEApprovedByUserId = table.Column<int>(type: "int", nullable: true),
                    PEApprovedDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    PMActualApprovedByUserID = table.Column<int>(type: "int", nullable: true),
                    PMApprovedByUserID = table.Column<int>(type: "int", nullable: true),
                    PMApprovedDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    PlanningAccountNumber = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    PrivateComments = table.Column<string>(type: "longtext", unicode: false, nullable: true),
                    Project = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    PromoFromDatetime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    PromolToDatetime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    PublicComments = table.Column<string>(type: "longtext", unicode: false, nullable: true),
                    QuoteExpirationDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    QuoteNumber = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    QuoteStatusLevelID = table.Column<byte>(type: "tinyint unsigned", nullable: true),
                    QuoteStatusResultID = table.Column<byte>(type: "tinyint unsigned", nullable: true),
                    QuoteSubTypeID = table.Column<byte>(type: "tinyint unsigned", nullable: true),
                    QuoteTypeID = table.Column<byte>(type: "tinyint unsigned", nullable: true),
                    RSDActualApprovedByUserID = table.Column<int>(type: "int", nullable: true),
                    RSDApprovedByUserID = table.Column<int>(type: "int", nullable: true),
                    RSDApprovedDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    RSMActualApprovedByUserID = table.Column<int>(type: "int", nullable: true),
                    RSMApprovedByUserID = table.Column<int>(type: "int", nullable: true),
                    RSMApprovedDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    RejRetReason = table.Column<byte[]>(type: "longblob", unicode: false, nullable: true),
                    RevenueApporvalDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    SecondExpiryNotificationDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    SerialNumber = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ShipTo = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    SubmitDatetime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    SubmittedByUserID = table.Column<int>(type: "int", nullable: true),
                    TPBackground = table.Column<string>(type: "longtext", unicode: false, nullable: true),
                    Token = table.Column<byte[]>(type: "longblob", nullable: true),
                    TotalValue = table.Column<decimal>(type: "decimal(13, 2)", nullable: true),
                    VPFinanceActualApprovedByUserID = table.Column<int>(type: "int", nullable: true),
                    VPFinanceApprovedByUserID = table.Column<int>(type: "int", nullable: true),
                    VPFinanceApprovedDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ValidTill = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    WinLossDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    WinLossUserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quote", x => x.QuoteID);
                });

            migrationBuilder.CreateTable(
                name: "Redline",
                columns: table => new
                {
                    RedlineID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ApprovedDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ApprovedUserID = table.Column<int>(type: "int", nullable: true),
                    Channel = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true),
                    CurrencyID = table.Column<short>(type: "smallint", nullable: false),
                    CustomerNumber = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    ProductFamily = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    RedLineFileInfoID = table.Column<long>(type: "bigint", nullable: false),
                    RedLineValue = table.Column<decimal>(type: "decimal(13, 2)", nullable: false),
                    RejectedDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    RejectedUserID = table.Column<int>(type: "int", nullable: true),
                    RevokedDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    RevokedUserID = table.Column<int>(type: "int", nullable: true),
                    Role = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    SKU = table.Column<string>(type: "varchar(18)", unicode: false, maxLength: 18, nullable: true),
                    SalesRegion = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    SalesSubRegion = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    Status = table.Column<short>(type: "smallint", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ValidTo = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Redline", x => x.RedlineID);
                });

            migrationBuilder.CreateTable(
                name: "SalesOrg",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    ADUserID = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    BPartner = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    IsRSM = table.Column<bool>(type: "bit", nullable: true),
                    UserName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ValidFrom = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ValidTo = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrg", x => new { x.UserID, x.Title });
                });

            migrationBuilder.CreateTable(
                name: "QuoteItem",
                columns: table => new
                {
                    QuoteItemID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BidDeskApprovedPrice = table.Column<decimal>(type: "decimal(13, 2)", nullable: true),
                    BidDeskRedLine = table.Column<decimal>(type: "decimal(13, 2)", nullable: true),
                    Competitor1 = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    Competitor1Price = table.Column<decimal>(type: "decimal(13, 2)", nullable: true),
                    Competitor2 = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    Competitor2Price = table.Column<decimal>(type: "decimal(13, 2)", nullable: true),
                    CreatedByUserID = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    EndDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsPOS = table.Column<bool>(type: "bit", nullable: true),
                    LastUpdatedByUserID = table.Column<int>(type: "int", nullable: false),
                    ListPrice = table.Column<decimal>(type: "decimal(13, 2)", nullable: true),
                    ListPriceAsOf = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LossReason = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    MMApprovedPrice = table.Column<decimal>(type: "decimal(13, 2)", nullable: true),
                    MMRedLine = table.Column<decimal>(type: "decimal(13, 2)", nullable: true),
                    MSRP = table.Column<decimal>(type: "decimal(13, 2)", nullable: true),
                    PEApprovedPrice = table.Column<decimal>(type: "decimal(13, 2)", nullable: true),
                    PERedLine = table.Column<decimal>(type: "decimal(13, 2)", nullable: true),
                    PMApprovedPrice = table.Column<decimal>(type: "decimal(13, 2)", nullable: true),
                    PMRedLine = table.Column<decimal>(type: "decimal(13, 2)", nullable: true),
                    ProductCost = table.Column<decimal>(type: "decimal(13, 2)", nullable: true),
                    ProductCostRegionID = table.Column<int>(type: "int", nullable: true),
                    ProductDescription = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: true),
                    ProductName = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: true),
                    ProductNumber = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    QuoteID = table.Column<long>(type: "bigint", nullable: false),
                    QuoteItemTypeID = table.Column<byte>(type: "tinyint unsigned", nullable: true),
                    RSDApprovedPrice = table.Column<decimal>(type: "decimal(13, 2)", nullable: true),
                    RSDRedLine = table.Column<decimal>(type: "decimal(13, 2)", nullable: true),
                    RSMRedLine = table.Column<decimal>(type: "decimal(13, 2)", nullable: true),
                    RequestedNetPrice = table.Column<decimal>(type: "decimal(13, 2)", nullable: true),
                    RequestedPOS = table.Column<decimal>(type: "decimal(13, 2)", nullable: true),
                    RequestedQuantity = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdatedByDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    VPFinanceApprovedPrice = table.Column<decimal>(type: "decimal(13, 2)", nullable: true),
                    VPSalesApprovedPrice = table.Column<decimal>(type: "decimal(13, 2)", nullable: true),
                    VPSalesRedLine = table.Column<decimal>(type: "decimal(13, 2)", nullable: true),
                    WinAdCost = table.Column<decimal>(type: "decimal(13, 2)", nullable: true),
                    WinLoss = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: true),
                    WinNetPrice = table.Column<decimal>(type: "decimal(13, 2)", nullable: true),
                    WinPOS = table.Column<decimal>(type: "decimal(13, 2)", nullable: true),
                    WinQuantity = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuoteItem", x => x.QuoteItemID);
                    table.ForeignKey(
                        name: "FK_QuoteItem_Quote_QuoteID",
                        column: x => x.QuoteID,
                        principalTable: "Quote",
                        principalColumn: "QuoteID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuoteItem_QuoteID",
                table: "QuoteItem",
                column: "QuoteID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mtCustomer");

            migrationBuilder.DropTable(
                name: "QuoteItem");

            migrationBuilder.DropTable(
                name: "Redline");

            migrationBuilder.DropTable(
                name: "SalesOrg");

            migrationBuilder.DropTable(
                name: "Quote");
        }
    }
}


/*Table structure for table `mtcustomer` */

DROP TABLE IF EXISTS `mtCustomer`;

CREATE TABLE `mtCustomer` (
  `CustomerNumber` varchar(10) NOT NULL,
  `ALLOCATION_CHANNEL_DESC` varchar(255) DEFAULT NULL,
  `ALLOCATION_TERR_GRP_DESC` varchar(255) DEFAULT NULL,
  `Address` varchar(255) DEFAULT NULL,
  `Allocation Channel` varchar(255) DEFAULT NULL,
  `Allocation Territory` varchar(255) DEFAULT NULL,
  `Allocation Territory Desc` varchar(255) DEFAULT NULL,
  `Allocation Territory Group` varchar(255) DEFAULT NULL,
  `Bill-to party` varchar(255) DEFAULT NULL,
  `Bill-to party Desc` varchar(255) DEFAULT NULL,
  `Business Partner` varchar(255) DEFAULT NULL,
  `CRM_SALORG` varchar(50) DEFAULT NULL,
  `CUSTOMER_BUS_GROUP_DESC` varchar(255) DEFAULT NULL,
  `CUSTOMER_CLASSIFICATION` varchar(255) DEFAULT NULL,
  `CUST_HIER1_DESC` varchar(255) DEFAULT NULL,
  `Channle Partner Prof` varchar(255) DEFAULT NULL,
  `CountryKey` varchar(3) DEFAULT NULL,
  `CountryName` varchar(255) DEFAULT NULL,
  `Credit Hold Status` varchar(255) DEFAULT NULL,
  `Currency` varchar(50) DEFAULT NULL,
  `CustHier 1` varchar(255) DEFAULT NULL,
  `CustHier 2` varchar(255) DEFAULT NULL,
  `CustHier 3` varchar(255) DEFAULT NULL,
  `CustomCostCalc` bit(1) DEFAULT NULL,
  `CustomerPriceGroup` varchar(2) DEFAULT NULL,
  `CustomerType` varchar(50) DEFAULT NULL,
  `Customer Acct Grp` varchar(255) DEFAULT NULL,
  `Customer Acct Grp Desc` varchar(255) DEFAULT NULL,
  `Customer Business Group` varchar(255) DEFAULT NULL,
  `Customer Desc` varchar(255) DEFAULT NULL,
  `Customer Market` varchar(255) DEFAULT NULL,
  `Customer Segment` varchar(255) DEFAULT NULL,
  `Customer Segment Desc` varchar(255) DEFAULT NULL,
  `Customer is Consumer` varchar(255) DEFAULT NULL,
  `DISTRI_CHAN_DESC` varchar(50) DEFAULT NULL,
  `DistributionChannel` varchar(2) DEFAULT NULL,
  `DoNotUse` bit(1) DEFAULT NULL,
  `ExternalSalesRep1` varchar(10) DEFAULT NULL,
  `ExternalSalesRep2` varchar(10) DEFAULT NULL,
  `ExternalSalesRep3` varchar(10) DEFAULT NULL,
  `FaxNumber` varchar(31) DEFAULT NULL,
  `Fiscal Year Variant` varchar(255) DEFAULT NULL,
  `Fund Sales District` varchar(255) DEFAULT NULL,
  `Fund Sales District Desc` varchar(255) DEFAULT NULL,
  `Geographical Region` varchar(255) DEFAULT NULL,
  `Geographical_Region_desc` varchar(60) DEFAULT NULL,
  `I2 Distribution Channel` varchar(255) DEFAULT NULL,
  `I2 RSM Allocation Channel` varchar(255) DEFAULT NULL,
  `I2 RSM Allocation Territory Group` varchar(255) DEFAULT NULL,
  `I2 RSM Customer Group 4` varchar(255) DEFAULT NULL,
  `I2 RSM ID` varchar(255) DEFAULT NULL,
  `I2 RSM Promotion Group` varchar(255) DEFAULT NULL,
  `IndustryCode` varchar(50) DEFAULT NULL,
  `InternalSalesRep1` varchar(10) DEFAULT NULL,
  `InternalSalesRep2` varchar(10) DEFAULT NULL,
  `InternalSalesRep3` varchar(10) DEFAULT NULL,
  `Location` varchar(35) DEFAULT NULL,
  `MARKED_FOR_DELETE` varchar(50) DEFAULT NULL,
  `MARKET_COUNTRY` varchar(255) DEFAULT NULL,
  `MARKET_SUBREGION` varchar(255) DEFAULT NULL,
  `MARKET_SUBREGION_Desc` varchar(60) DEFAULT NULL,
  `Market_Country_desc` varchar(50) DEFAULT NULL,
  `Name1` varchar(35) DEFAULT NULL,
  `Name2` varchar(35) DEFAULT NULL,
  `Name3` varchar(35) DEFAULT NULL,
  `OEM Subgroup` varchar(50) DEFAULT NULL,
  `OrderBlock` varchar(50) DEFAULT NULL,
  `PRICE_GROUP_DESC` varchar(255) DEFAULT NULL,
  `PRICE_LIST_TYPE` varchar(255) DEFAULT NULL,
  `P#O# Box` varchar(255) DEFAULT NULL,
  `Payer` varchar(255) DEFAULT NULL,
  `Payer Desc` varchar(255) DEFAULT NULL,
  `Plant` varchar(255) DEFAULT NULL,
  `PostalCode` varchar(10) DEFAULT NULL,
  `PriceListType` varchar(2) DEFAULT NULL,
  `SOLDTO_SHIPTO_DESC` varchar(255) DEFAULT NULL,
  `STATE_DESC` varchar(255) DEFAULT NULL,
  `SalesOrg` varchar(4) DEFAULT NULL,
  `SalesOrg_desc` varchar(60) DEFAULT NULL,
  `Sales District` varchar(255) DEFAULT NULL,
  `Sales District Desc` varchar(255) DEFAULT NULL,
  `ShowAll` bit(1) DEFAULT NULL,
  `SortField` varchar(10) DEFAULT NULL,
  `SortOrder` int(11) DEFAULT NULL,
  `State` varchar(3) DEFAULT NULL,
  `Street Name` varchar(255) DEFAULT NULL,
  `TAX_STATUS` varchar(50) DEFAULT NULL,
  `Telephone 1` varchar(255) DEFAULT NULL,
  `Vendor` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`CustomerNumber`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `mtCustomer` */

insert  into `mtCustomer`(`CustomerNumber`,`ALLOCATION_CHANNEL_DESC`,`ALLOCATION_TERR_GRP_DESC`,`Address`,`Allocation Channel`,`Allocation Territory`,`Allocation Territory Desc`,`Allocation Territory Group`,`Bill-to party`,`Bill-to party Desc`,`Business Partner`,`CRM_SALORG`,`CUSTOMER_BUS_GROUP_DESC`,`CUSTOMER_CLASSIFICATION`,`CUST_HIER1_DESC`,`Channle Partner Prof`,`CountryKey`,`CountryName`,`Credit Hold Status`,`Currency`,`CustHier 1`,`CustHier 2`,`CustHier 3`,`CustomCostCalc`,`CustomerPriceGroup`,`CustomerType`,`Customer Acct Grp`,`Customer Acct Grp Desc`,`Customer Business Group`,`Customer Desc`,`Customer Market`,`Customer Segment`,`Customer Segment Desc`,`Customer is Consumer`,`DISTRI_CHAN_DESC`,`DistributionChannel`,`DoNotUse`,`ExternalSalesRep1`,`ExternalSalesRep2`,`ExternalSalesRep3`,`FaxNumber`,`Fiscal Year Variant`,`Fund Sales District`,`Fund Sales District Desc`,`Geographical Region`,`Geographical_Region_desc`,`I2 Distribution Channel`,`I2 RSM Allocation Channel`,`I2 RSM Allocation Territory Group`,`I2 RSM Customer Group 4`,`I2 RSM ID`,`I2 RSM Promotion Group`,`IndustryCode`,`InternalSalesRep1`,`InternalSalesRep2`,`InternalSalesRep3`,`Location`,`MARKED_FOR_DELETE`,`MARKET_COUNTRY`,`MARKET_SUBREGION`,`MARKET_SUBREGION_Desc`,`Market_Country_desc`,`Name1`,`Name2`,`Name3`,`OEM Subgroup`,`OrderBlock`,`PRICE_GROUP_DESC`,`PRICE_LIST_TYPE`,`P#O# Box`,`Payer`,`Payer Desc`,`Plant`,`PostalCode`,`PriceListType`,`SOLDTO_SHIPTO_DESC`,`STATE_DESC`,`SalesOrg`,`SalesOrg_desc`,`Sales District`,`Sales District Desc`,`ShowAll`,`SortField`,`SortOrder`,`State`,`Street Name`,`TAX_STATUS`,`Telephone 1`,`Vendor`) values 
('0002000014','OEM','Europe','','TRD','008','TRD-EU','EU','0002000012','ComputerSysteme Inc','0002000012','50000002','Not assigned','03','Comp','R','DE','Germany','','USD','0001000107','0001000108','',NULL,'X4','','Z001','Sold-to party CloudJibe','','ComputerSysteme','','00','SHARED','','OEM Distributors','30',NULL,'0005000015','','','05119-83-81-49','','302001','Central Europe','04','REST OF THE WORLD','','TRD','EU','008','000000000000000000000002574','','','00002574','00013142','00004570','LANGENHAGEN','','DE','CE','','Germany','Comp ComputerSysteme GmbH','ATTN: ACCOUNTS PAYABLE','','03','','OEM Europe Disty','OEM Europe Disty','','0002000014','Comp ComputerSysteme GmbH','','30855','IE','Not assigned','','3000','SDI EMEA','302001','Central Europe',NULL,'Comp COMP',NULL,'','Bayernstrassse 10','Tax Exempt','05119000000',''),
('0002000219','OEM','Americas','','TRD','006','TRD-AM','AM','0002000119','Mul Comm, Inc.','0002000119','50000000','DEVICES','03','Mul Comm, Inc.','R','US','USA','','USD','0001001587','0001001588','',NULL,'','','Z001','Sold-to party CloudJibe','070','Comp, Inc.','','71','CBC Drives - SATA','','OEM Direct','10',NULL,'0005000090','','','','','100003','US','01','NORTH AMERICA','','TRD','AM','006','000000000000000000000003498','','','00005039','00003533','00022975','San Diego','','US','US','','USA','MyComm, Inc.','ATTN: ACCOUNTS PAYABLE','','02','','','','','0002000219','MyComm, Inc.','','92191-9042','','Not assigned','California','1000','CloudJibe Tech','100003','US',NULL,'MyComm,',NULL,'CA','P.O. Box 9190','Tax Exempt','(859) 587-1121',''),
('0002000312','RETAIL','Americas','','RTL','002','RTL-AM','AM','0002003312','MN Distributing Company','0002003311','50000001','Not assigned','03','Distributing Company','R','US','USA','','USD','0001000507','0001000509','',NULL,'A8','','Z001','Sold-to party CloudJibe','','Distributing Company','','00','SHARED','','Retail Distributors','60',NULL,'0005000056','0005000037','0005000131','717-255-7816','','100004','Americas - Disty','','Not assigned','','RTL','AM','002','000000000000000001000028254','','','00016705','00016779','00005884','HARRISBURG','','US','US','','USA','Distributing Company','ATTN: Amanda Nailor A/P','','','','Amer Disty Primary','North America','','0002000312','Distributing Company','','17110','NA','Not assigned','Pennsylvania','1000','CloudJibe Tech','100004','Americas - Disty',NULL,'D&H DISTRI',NULL,'PA','2525 N. 7TH STREET','Tax Exempt','717-255-6000',''),
('0002001043','OEM','Americas','','TRD','006','TRD-AM','AM','0002001040','Tim Modular Technologies, Inc.','0002001040','50000005','Not assigned','01','CISCO','R','US','USA','','USD','0001000407','0001000408','',NULL,'','','Z001','Sold-to party CloudJibe','','Modular Technologies, Inc.','','00','SHARED','','OEM Direct','10',NULL,'','','','510 624 8287','','100003','US','01','NORTH AMERICA','','TRD','AM','006','RSTRD-AM','','','00021469','00022143','00025338','Newark','','US','US','','USA','SMART Modular Technologies, Inc.','','','02','','','','','0002001043','SMART Modular Technologies, Inc.','','94560-4809','','Not assigned','California','1000','CloudJibe Tech','100003','US',NULL,'SMART MODU',NULL,'CA','39870 Eureka Drive','Tax Exempt','590 624 0000',''),
('0002001440','OEM','Europe','','TRD','008','TRD-EU','EU','0002001447','My Car Inc','0002001447','50000004','Not assigned','03','CSI','R','PL','Poland','','USD','0001000485','0001000487','',NULL,'X4','','Z001','Sold-to party CloudJibe','','CSI B,','','00','SHARED','','OEM Distributors','30',NULL,'0005000015','','','01148126383751','','302002','CIS','02','EUROPE','','TRD','EU','008','000000000000000000000002574','','','00002574','00019603','00006059','Krakow','','PL','CE','','Poland','Company, B. Company,','A. Zasucha spolka jawna','','03','','OEM Europe Disty','OEM Europe Disty','','0002001440','Company, B. Company,','','31-149','IE','Not assigned','','3020','SDI EMEA','302002','CIS',NULL,'CSI BEATA',NULL,'','Balicka 53','Liable for Taxes','0114800030000',''),
('0002001677','OEM','Europe','','TRD','008','TRD-EU','EU','0002001679','Rapac Inc','0002001679','50000004','Not assigned','03','Rapac-EU','N','IL','Israel','','USD','0001000159','0001000160','',NULL,'X4','','Z001','Sold-to party CloudJibe','','Rapac Inc.','','00','SHARED','','OEM Distributors','30',NULL,'0005000086','','','97235795522','','302003','Middle East/Africa','04','REST OF THE WORLD','','TRD','EU','008','RSTRD-EU','','','00006059','00021031','00022713','Petach Tilva','','IL','ME','','Israel','Rapac Inc','ATTN:  ACCOUNTS PAYABLE','','03','','OEM Europe Disty','OEM Europe Disty','','0002001677','Rapac Inc','','49256','IE','Not assigned','','3020','SDI EMEA','302003','Middle East/Africa',NULL,'RAP',NULL,'','30 Shaham St.','Liable for Taxes','',''),
('0002004340','OEM','Europe','','TRD','008','TRD-EU','EU','0002004341','Broadband','0002004341','50000004','Not assigned','03','Broadband','R','FR','France','','USD','0001004865','0001004895','',NULL,'','','Z001','Sold-to party CloudJibe','','Broadband','','00','SHARED','','OEM Direct','10',NULL,'0005000150','','','0157613927','','302005','Southern Europe','02','EUROPE','','','','','','','','00002574','00013142','00035409','Ruiel-Malmaison Cedex','','FR','NO','','France','Sagemcom Broadband SAS','Accounts Department','','02','','','','','0002004340','Sagemcom Broadband SAS','','92848','','Not assigned','','3020','SDI EMEA','302005','Southern Europe',NULL,'SAGEMCOM B',NULL,'','200 Route de l\'empereur','Liable for Taxes','0159612906','');

/*Table structure for table `mtlistprice` */

DROP TABLE IF EXISTS `mtListPrice`;

CREATE TABLE `mtListPrice` (
  `Material` varchar(50) NOT NULL,
  `Price_List` varchar(50) NOT NULL,
  `Price_Grp` varchar(50) NOT NULL,
  `Bic_ZConType` varchar(50) DEFAULT NULL,
  `Currency` varchar(50) DEFAULT NULL,
  `Prc_Lst_Su` varchar(50) DEFAULT NULL,
  `ValidFrom` varchar(50) DEFAULT NULL,
  `ValidTo` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`Material`,`Price_List`,`Price_Grp`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `mtlistprice` */

insert  into `mtListPrice`(`Material`,`Price_List`,`Price_Grp`,`Bic_ZConType`,`Currency`,`Prc_Lst_Su`,`ValidFrom`,`ValidTo`) values 

('102256UB5G236','IP','X1','ZPRO','USD','121788.00 ','04/06/2016','12/31/9999'),
('102Y0UB5G236','IU','X2','ZPRO','USD','121788.00 ','04/06/2016','12/31/9999'),
('FAC825GSF1G1','IP','X1','ZPRO','USD','12.00 ','05/18/2015','07/05/2015'),
('SS7SB7S-010T-1122','EE','E2','ZPRO','EUR','301.66 ','12/07/2015','01/10/2016'),
('SS7SN6S-512G','IP','X1','ZPRO','USD','180.00 ','12/07/2015','01/30/2016'),
('STSN6S-512G','IU','X2','ZPRO','USD','180.00 ','12/07/2015','01/30/2016'),
('KDFF-064GIR','IE','X4','ZPRO','USD','26.50 ','06/16/2016','06/30/2017'),
('ND-128GIR','IE','X4','ZPRO','USD','60.00 ','04/03/2017','06/30/2017');

/*Table structure for table `quote` */

DROP TABLE IF EXISTS `Quote`;

CREATE TABLE `Quote` (
  `QuoteID` bigint(20) NOT NULL AUTO_INCREMENT,
  `AccountManagerID` int(11) DEFAULT NULL,
  `Action` varchar(20) DEFAULT NULL,
  `AdditionalRequirements` longblob,
  `Application` varchar(100) DEFAULT NULL,
  `BillTo` varchar(10) DEFAULT NULL,
  `CRM Messages` longtext,
  `CRM Status` varchar(50) DEFAULT NULL,
  `CancelReason` longblob,
  `CanceledByUserID` int(11) DEFAULT NULL,
  `CanceledDateTime` datetime(6) DEFAULT NULL,
  `CommentforPDF` longblob,
  `Comments` longblob,
  `CreatedByUserID` int(11) DEFAULT NULL,
  `CreatedDateTime` datetime(6) NOT NULL,
  `Currency` varchar(50) DEFAULT NULL,
  `CustomerWebSite` varchar(250) DEFAULT NULL,
  `EndCustomerID` varchar(10) DEFAULT NULL,
  `EndUser` varchar(250) DEFAULT NULL,
  `ExchangeRate` decimal(13,6) DEFAULT NULL,
  `ExistingProject` bit(1) DEFAULT NULL,
  `ExpectedShipDate` datetime(6) DEFAULT NULL,
  `ExpiryNotificationDate` datetime(6) DEFAULT NULL,
  `FinalExpiryNotificationDate` datetime(6) DEFAULT NULL,
  `InQWinlossDate` datetime(6) DEFAULT NULL,
  `LastModifiedByUserID` int(11) DEFAULT NULL,
  `LastModifiedDatetime` datetime(6) DEFAULT NULL,
  `LossNotificationDate` datetime(6) DEFAULT NULL,
  `NeedPriceApprovedBy` datetime(6) DEFAULT NULL,
  `PEActualApprovedByUserId` int(11) DEFAULT NULL,
  `PEApprovedByUserId` int(11) DEFAULT NULL,
  `PEApprovedDateTime` datetime(6) DEFAULT NULL,
  `PMActualApprovedByUserID` int(11) DEFAULT NULL,
  `PMApprovedByUserID` int(11) DEFAULT NULL,
  `PMApprovedDateTime` datetime(6) DEFAULT NULL,
  `PlanningAccountNumber` varchar(10) DEFAULT NULL,
  `PrivateComments` longtext,
  `Project` varchar(100) DEFAULT NULL,
  `PromoFromDatetime` datetime(6) DEFAULT NULL,
  `PromolToDatetime` datetime(6) DEFAULT NULL,
  `PublicComments` longtext,
  `QuoteExpirationDate` datetime(6) DEFAULT NULL,
  `QuoteNumber` varchar(100) DEFAULT NULL,
  `QuoteStatusLevelID` tinyint(3) unsigned DEFAULT NULL,
  `QuoteStatusResultID` tinyint(3) unsigned DEFAULT NULL,
  `QuoteSubTypeID` tinyint(3) unsigned DEFAULT NULL,
  `QuoteTypeID` tinyint(3) unsigned DEFAULT NULL,
  `RSDActualApprovedByUserID` int(11) DEFAULT NULL,
  `RSDApprovedByUserID` int(11) DEFAULT NULL,
  `RSDApprovedDateTime` datetime(6) DEFAULT NULL,
  `RSMActualApprovedByUserID` int(11) DEFAULT NULL,
  `RSMApprovedByUserID` int(11) DEFAULT NULL,
  `RSMApprovedDateTime` datetime(6) DEFAULT NULL,
  `RejRetReason` longtext,
  `RevenueApporvalDate` datetime(6) DEFAULT NULL,
  `SecondExpiryNotificationDate` datetime(6) DEFAULT NULL,
  `SerialNumber` varchar(50) DEFAULT NULL,
  `ShipTo` varchar(10) DEFAULT NULL,
  `SubmitDatetime` datetime(6) DEFAULT NULL,
  `SubmittedByUserID` int(11) DEFAULT NULL,
  `TPBackground` longtext,
  `Token` longtext,
  `TotalValue` decimal(13,2) DEFAULT NULL,
  `VPFinanceActualApprovedByUserID` int(11) DEFAULT NULL,
  `VPFinanceApprovedByUserID` int(11) DEFAULT NULL,
  `VPFinanceApprovedDateTime` datetime(6) DEFAULT NULL,
  `ValidTill` varchar(10) DEFAULT NULL,
  `WinLossDateTime` datetime(6) DEFAULT NULL,
  `WinLossUserID` int(11) DEFAULT NULL,
  PRIMARY KEY (`QuoteID`)
) ENGINE=InnoDB AUTO_INCREMENT=82052 DEFAULT CHARSET=utf8mb4;

/*Data for the table `quote` */

insert  into `Quote`(`QuoteID`,`AccountManagerID`,`Action`,`AdditionalRequirements`,`Application`,`BillTo`,`CRM Messages`,`CRM Status`,`CancelReason`,`CanceledByUserID`,`CanceledDateTime`,`CommentforPDF`,`Comments`,`CreatedByUserID`,`CreatedDateTime`,`Currency`,`CustomerWebSite`,`EndCustomerID`,`EndUser`,`ExchangeRate`,`ExistingProject`,`ExpectedShipDate`,`ExpiryNotificationDate`,`FinalExpiryNotificationDate`,`InQWinlossDate`,`LastModifiedByUserID`,`LastModifiedDatetime`,`LossNotificationDate`,`NeedPriceApprovedBy`,`PEActualApprovedByUserId`,`PEApprovedByUserId`,`PEApprovedDateTime`,`PMActualApprovedByUserID`,`PMApprovedByUserID`,`PMApprovedDateTime`,`PlanningAccountNumber`,`PrivateComments`,`Project`,`PromoFromDatetime`,`PromolToDatetime`,`PublicComments`,`QuoteExpirationDate`,`QuoteNumber`,`QuoteStatusLevelID`,`QuoteStatusResultID`,`QuoteSubTypeID`,`QuoteTypeID`,`RSDActualApprovedByUserID`,`RSDApprovedByUserID`,`RSDApprovedDateTime`,`RSMActualApprovedByUserID`,`RSMApprovedByUserID`,`RSMApprovedDateTime`,`RejRetReason`,`RevenueApporvalDate`,`SecondExpiryNotificationDate`,`SerialNumber`,`ShipTo`,`SubmitDatetime`,`SubmittedByUserID`,`TPBackground`,`Token`,`TotalValue`,`VPFinanceActualApprovedByUserID`,`VPFinanceApprovedByUserID`,`VPFinanceApprovedDateTime`,`ValidTill`,`WinLossDateTime`,`WinLossUserID`) values 
(83000,32994,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,32994,'2017-11-20 19:07:42.440031','USD',NULL,'0002000312','0002001428',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-11-23 00:00:00.000000',32994,32994,'2017-11-20 19:08:15.493938',32994,32994,'2017-11-20 19:07:56.192571','0002000139',NULL,NULL,'2017-11-20 00:00:00.000000','2017-11-30 00:00:00.000000',NULL,NULL,'00082051',2,17,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2017-11-20 00:00:00.000000',32994,'full flow',NULL,NULL,32994,32994,'2017-11-20 19:08:31.211453',NULL,'2017-11-20 19:08:58.359871',32994);

/*Table structure for table `quoteitem` */

DROP TABLE IF EXISTS `QuoteItem`;

CREATE TABLE `QuoteItem` (
  `QuoteItemID` bigint(20) NOT NULL AUTO_INCREMENT,
  `BidDeskApprovedPrice` decimal(13,2) DEFAULT NULL,
  `BidDeskRedLine` decimal(13,2) DEFAULT NULL,
  `Competitor1` varchar(250) DEFAULT NULL,
  `Competitor1Price` decimal(13,2) DEFAULT NULL,
  `Competitor2` varchar(250) DEFAULT NULL,
  `Competitor2Price` decimal(13,2) DEFAULT NULL,
  `CreatedByUserID` int(11) NOT NULL,
  `CreatedDateTime` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
  `EndDate` datetime(6) DEFAULT NULL,
  `IsPOS` bit(1) DEFAULT NULL,
  `LastUpdatedByUserID` int(11) NOT NULL,
  `ListPrice` decimal(13,2) DEFAULT NULL,
  `ListPriceAsOf` datetime(6) DEFAULT NULL,
  `LossReason` varchar(500) DEFAULT NULL,
  `MMApprovedPrice` decimal(13,2) DEFAULT NULL,
  `MMRedLine` decimal(13,2) DEFAULT NULL,
  `MSRP` decimal(13,2) DEFAULT NULL,
  `PEApprovedPrice` decimal(13,2) DEFAULT NULL,
  `PERedLine` decimal(13,2) DEFAULT NULL,
  `PMApprovedPrice` decimal(13,2) DEFAULT NULL,
  `PMRedLine` decimal(13,2) DEFAULT NULL,
  `ProductCost` decimal(13,2) DEFAULT NULL,
  `ProductCostRegionID` int(11) DEFAULT NULL,
  `ProductDescription` varchar(60) DEFAULT NULL,
  `ProductName` varchar(60) DEFAULT NULL,
  `ProductNumber` varchar(50) DEFAULT NULL,
  `QuoteID` bigint(20) NOT NULL,
  `QuoteItemTypeID` tinyint(3) unsigned DEFAULT NULL,
  `RSDApprovedPrice` decimal(13,2) DEFAULT NULL,
  `RSDRedLine` decimal(13,2) DEFAULT NULL,
  `RSMRedLine` decimal(13,2) DEFAULT NULL,
  `RequestedNetPrice` decimal(13,2) DEFAULT NULL,
  `RequestedPOS` decimal(13,2) DEFAULT NULL,
  `RequestedQuantity` int(11) DEFAULT NULL,
  `StartDate` datetime(6) DEFAULT NULL,
  `UpdatedByDateTime` datetime(6) NOT NULL,
  `VPFinanceApprovedPrice` decimal(13,2) DEFAULT NULL,
  `VPSalesApprovedPrice` decimal(13,2) DEFAULT NULL,
  `VPSalesRedLine` decimal(13,2) DEFAULT NULL,
  `WinAdCost` decimal(13,2) DEFAULT NULL,
  `WinLoss` varchar(1) DEFAULT NULL,
  `WinNetPrice` decimal(13,2) DEFAULT NULL,
  `WinPOS` decimal(13,2) DEFAULT NULL,
  `WinQuantity` int(11) DEFAULT NULL,
  PRIMARY KEY (`QuoteItemID`),
  KEY `IX_QuoteItem_QuoteID` (`QuoteID`),
  CONSTRAINT `FK_QuoteItem_Quote_QuoteID` FOREIGN KEY (`QuoteID`) REFERENCES `Quote` (`QuoteID`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=871035 DEFAULT CHARSET=utf8mb4;

/*Data for the table `quoteitem` */

-- insert  into `QuoteItem`(`QuoteItemID`,`BidDeskApprovedPrice`,`BidDeskRedLine`,`Competitor1`,`Competitor1Price`,`Competitor2`,`Competitor2Price`,`CreatedByUserID`,`CreatedDateTime`,`EndDate`,`IsPOS`,`LastUpdatedByUserID`,`ListPrice`,`ListPriceAsOf`,`LossReason`,`MMApprovedPrice`,`MMRedLine`,`MSRP`,`PEApprovedPrice`,`PERedLine`,`PMApprovedPrice`,`PMRedLine`,`ProductCost`,`ProductCostRegionID`,`ProductDescription`,`ProductName`,`ProductNumber`,`QuoteID`,`QuoteItemTypeID`,`RSDApprovedPrice`,`RSDRedLine`,`RSMRedLine`,`RequestedNetPrice`,`RequestedPOS`,`RequestedQuantity`,`StartDate`,`UpdatedByDateTime`,`VPFinanceApprovedPrice`,`VPSalesApprovedPrice`,`VPSalesRedLine`,`WinAdCost`,`WinLoss`,`WinNetPrice`,`WinPOS`,`WinQuantity`) values 
-- (870677,NULL,NULL,NULL,0.00,NULL,0.00,5400321,'2017-11-09 00:00:00.000000',NULL,NULL,3656,149.90,NULL,NULL,NULL,NULL,NULL,0.00,0.00,88.30,87.40,20.08,NULL,NULL,NULL,'SDSDQAD-256G',81675,NULL,0.00,999999.00,999999.00,80.00,69.90,1000,NULL,'2017-10-01 00:00:00.000000',0.00,NULL,999999.00,NULL,NULL,NULL,NULL,NULL),
-- (871034,NULL,NULL,NULL,NULL,NULL,NULL,0,'2017-11-20 19:08:58.383997',NULL,NULL,0,995.00,NULL,NULL,NULL,NULL,NULL,12.00,NULL,11.00,NULL,NULL,NULL,NULL,NULL,'FABAMOD785GSF1G12',82051,NULL,NULL,NULL,NULL,800.00,195.00,100,NULL,'0001-01-01 00:00:00.000000',14.00,NULL,NULL,NULL,'',15.00,NULL,11);

/*Table structure for table `redline` */

DROP TABLE IF EXISTS `Redline`;

CREATE TABLE `Redline` (
  `RedlineID` bigint(20) NOT NULL AUTO_INCREMENT,
  `ApprovedDateTime` datetime(6) DEFAULT NULL,
  `ApprovedUserID` int(11) DEFAULT NULL,
  `Channel` varchar(5) DEFAULT NULL,
  `CurrencyID` smallint(6) NOT NULL,
  `CustomerNumber` varchar(10) DEFAULT NULL,
  `ProductFamily` varchar(20) NOT NULL,
  `RedLineFileInfoID` bigint(20) NOT NULL,
  `RedLineValue` decimal(13,2) NOT NULL,
  `RejectedDateTime` datetime(6) DEFAULT NULL,
  `RejectedUserID` int(11) DEFAULT NULL,
  `RevokedDateTime` datetime(6) DEFAULT NULL,
  `RevokedUserID` int(11) DEFAULT NULL,
  `Role` varchar(50) NOT NULL,
  `SKU` varchar(18) DEFAULT NULL,
  `SalesRegion` varchar(10) DEFAULT NULL,
  `SalesSubRegion` varchar(10) DEFAULT NULL,
  `Status` smallint(6) NOT NULL,
  `ValidFrom` datetime(6) NOT NULL,
  `ValidTo` datetime(6) NOT NULL,
  PRIMARY KEY (`RedlineID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `redline` */

/*Table structure for table `salesorg` */

DROP TABLE IF EXISTS `SalesOrg`;

CREATE TABLE `SalesOrg` (
  `UserID` int(11) NOT NULL,
  `Title` varchar(20) NOT NULL,
  `ADUserID` varchar(255) DEFAULT NULL,
  `BPartner` int(11) DEFAULT NULL,
  `Email` varchar(255) DEFAULT NULL,
  `IsRSM` bit(1) DEFAULT NULL,
  `UserName` varchar(255) DEFAULT NULL,
  `ValidFrom` datetime(6) DEFAULT NULL,
  `ValidTo` datetime(6) DEFAULT NULL,
  PRIMARY KEY (`UserID`,`Title`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `salesorg` */

insert  into `SalesOrg`(`UserID`,`Title`,`ADUserID`,`BPartner`,`Email`,`IsRSM`,`UserName`,`ValidFrom`,`ValidTo`) values 
(3000,'Analyst','manoj.kumar@cloudjibe.com',NULL,'manojsjsu@gmail.com',NULL,'Manoj Kumar','2009-06-26 00:00:00.000000','9999-12-31 00:00:00.000000'),
(3000,'PM','manoj.kumar@cloudjibe.com',NULL,'manojsjsu@gmail.com',NULL,'Manoj Kumar','2009-06-26 00:00:00.000000','9999-12-31 00:00:00.000000'),
(3000,'RSM','manoj.kumar@cloudjibe.com',NULL,'manojsjsu@gmail.com',NULL,'Manoj Kumar','2009-06-26 00:00:00.000000','9999-12-31 00:00:00.000000'),
(3010,'PM','test.account@cloudjibe.com',NULL,'erpatel@gmail.com',NULL,'Test Account','2009-06-26 00:00:00.000000','9999-12-31 00:00:00.000000'),
(3010,'RSM','test.account@cloudjibe.com',NULL,'erpatel@gmail.com',NULL,'Test Account','2009-06-26 00:00:00.000000','9999-12-31 00:00:00.000000'),
(3030,'RSM','himangini.agrawal@cloudjibe.com',NULL,'himangini.agrawal@sjsu.edu',NULL,'himangini agrawal','2009-06-26 00:00:00.000000','9999-12-31 00:00:00.000000'),
(3030,'PM','himangini.agrawal@cloudjibe.com',NULL,'himangini.agrawal@sjsu.edu',NULL,'himangini agrawal','2009-06-26 00:00:00.000000','9999-12-31 00:00:00.000000');

DROP TABLE IF EXISTS `mtproduct`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `mtproduct` (
  `ProductID` varchar(50) NOT NULL,
  `Description` varchar(60) DEFAULT NULL,
  `Base UOM` varchar(3) DEFAULT NULL,
  `Created on` datetime DEFAULT NULL,
  `Product` varchar(32) DEFAULT NULL,
  `Material Segment` varchar(2) DEFAULT NULL,
  `Material Segment desc` varchar(255) DEFAULT NULL,
  `Material group` varchar(255) DEFAULT NULL,
  `Material type` varchar(4) DEFAULT NULL,
  `Material type desc` varchar(60) DEFAULT NULL,
  `Prod#hierarchy` varchar(255) DEFAULT NULL,
  `Card SubType` varchar(20) DEFAULT NULL,
  `Card Type` varchar(20) DEFAULT NULL,
  `Controller Technology Code` varchar(20) DEFAULT NULL,
  `Gross MB` varchar(20) DEFAULT NULL,
  `Memory Packaging` varchar(20) DEFAULT NULL,
  `Memory Pin Count` varchar(20) DEFAULT NULL,
  `Mem Tech Cd` varchar(20) DEFAULT NULL,
  `MemoryCapacityGroup` varchar(10) DEFAULT NULL,
  `Mem Capacity Type` varchar(255) DEFAULT NULL,
  `New Cost Technology` varchar(255) DEFAULT NULL,
  `Old Cost Technology` varchar(20) DEFAULT NULL,
  `Material Business Group` varchar(3) DEFAULT NULL,
  `Product Family` varchar(20) DEFAULT NULL,
  `ProductLine` varchar(20) DEFAULT NULL,
  `ProductLineDesc` varchar(60) DEFAULT NULL,
  `Product Type` varchar(20) DEFAULT NULL,
  `Shippable MB` varchar(20) DEFAULT NULL,
  `Status` varchar(2) DEFAULT NULL,
  `X-Plant Material Status desc` varchar(60) DEFAULT NULL,
  `StandardPrice` decimal(18,2) DEFAULT NULL,
  `MemoryCapacityGroupDesc` varchar(255) DEFAULT NULL,
  `DESIGN_GROUP` varchar(255) DEFAULT NULL,
  `MARKETING_PROGRAM` varchar(255) DEFAULT NULL,
  `PROMO_GROUP` varchar(255) DEFAULT NULL,
  `PRODUCT_PRIORITY` varchar(255) DEFAULT NULL,
  `OBS_PROJECTED_DATE` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `mtproduct`
--

INSERT INTO `mtproduct` VALUES ('102256UB5G236','102256UB5G236',NULL,NULL,'102256UB5G236',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2GB',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),('102Y0UB5G236','102Y0UB5G236',NULL,NULL,'102Y0UB5G236',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2GB',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),('FAC825GSF1G1','FAC825GSF1G1',NULL,NULL,'FAC825GSF1G1',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2GB',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),('KDFF-064GIR','KDFF-064GIR',NULL,NULL,'KDFF-064GIR',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2GB',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),('ND-128GIR','ND-128GIR',NULL,NULL,'ND-128GIR',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2GB',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),('SS7SB7S-010T-1122','SS7SB7S-010T-1122',NULL,NULL,'SS7SB7S-010T-1122',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2GB',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),('SS7SN6S-512G','SS7SN6S-512G',NULL,NULL,'SS7SN6S-512G',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2GB',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),('STSN6S-512G','STSN6S-512G',NULL,NULL,'STSN6S-512G',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2GB',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL);



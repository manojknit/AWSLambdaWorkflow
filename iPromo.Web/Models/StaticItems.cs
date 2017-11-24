using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iPromo.Web
{
    public static class StaticItems
    {
        public static Dictionary<int, string> QuoteTypes = new Dictionary<int, string>() {
            {1,"TPM" }
            ,{2,"SPA" }
            ,{3,"FIRM" }
        };

        public static Dictionary<int, string> QuoteStatusResult = new Dictionary<int, string>() {
          {1    ,"In Q"},
            {2  ,"Approved"},
            {3  ,"Rejected"},
            {4  ,"Returned"},
            {5  ,"Escalated"},
            {6  ,"OOO"},
            {7  ,"Delegated"},
            {8  ,"RFM/RFC Timed Auto Approved"},
            {9  ,"Fulfillment Everyday Auto Approved"},
            {10 ,"TPM Upload Success"},
            {11 ,"TPM Upload Failure"},
            {12 ,"Saved"},
            {13 ,"Submitted"},
            {14 ,"In Q - WinLoss"},
            {15 ,"In Q - Return"},
            {16 ,"Expired"},
            {17 ,"Complete"},
            {18 ,"Complete"},
            {19 ,"Complete"},
            {20 ,"Complete"},
            {21 ,"Canceled"},
            {22 ,"Pending Cancel"},
            {23 ,"Final Review"}
        };

        public static Dictionary<int, string> QuoteStatusLevel = new Dictionary<int, string>() {
            {1   ,"EXTERNAL R"},
            {2  ,"RSM"},
            {3  ,"RSD"},
            {4  ,"MM"},
            {5  ,"BIDDESK"},
            {6  ,"PM"},
            {7  ,"VP SALES"},
            {8  ,"VP FINANCE"},
            {9  ,"REVENUE"},
            {10 ,"CMM"},
            {11 ,"RVP"},
            {12 ,"RFM"},
            {13 ,"RFC"},
            {14 ,"RMD"},
            {15 ,"PMD"},
            {16 ,"MONITORING"},
            {17 ,"RMM"},
            {18 ,"MKTD"},
            {19 ,"POE"}
        };

        public static Tuple<byte, byte> GetNextStatus(byte? currentLevel, byte? currentResult)
        {
            var level = (byte)currentLevel.Value;
            var result = (byte)currentResult.Value;

            switch (currentLevel)
            {
                case 2:
                    if (currentResult == 12)
                    {
                        level = 6;
                        result = 1;
                    }
                    else if (currentResult == 14)
                    {
                        result = 17;
                    }
                    break;
                case 6:
                    level = 19;
                    result = 1;
                    break;
                case 19:
                    level = 8;
                    result = 1;
                    break;
                case 8:
                    level = 2;
                    result = 14;
                    break;
            }
            return Tuple.Create(level, result);
        }

    }
}

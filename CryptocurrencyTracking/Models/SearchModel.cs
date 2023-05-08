using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptocurrencyTracking.Models
{
    public class SearchModel
    {
        public string status { get; set; }
        public SearchData data { get; set; }
    }
}
    public class SearchData
    {
        public SearchCoins coin { get; set; }
    }

    public class SearchCoins
{
        public string uuid { get; set; }

        public string symbol { get; set; }
        public string name { get; set; }
        public string iconUrl { get; set; }
        public string marketCap { get; set; }
        public string price { get; set; }
        public string change { get; set; }
        public string coinrankingUrl { get; set; }
        public string btcPrice { get; set; }
}

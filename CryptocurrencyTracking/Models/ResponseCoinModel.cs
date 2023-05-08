using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptocurrencyTracking.Models
{
    public class ResponseCoinModel
    {
        public string status { get; set; }
        public ResponseCoinData data { get; set; }
    }
    public class ResponseCoinData
    {
        public ResponseCoinStatus status { get; set; }
        public CoinsResponse coins { get; set; }
    }
    public class ResponseCoinStatus
    {
        public int total { get; set; }
        public int totalCoins { get; set; }
        public int totalMarkets { get; set; }
        public int totalExchanges { get; set; }
    }
    public class CoinsResponse
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
}

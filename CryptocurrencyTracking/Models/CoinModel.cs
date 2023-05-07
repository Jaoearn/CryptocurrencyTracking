using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptocurrencyTracking.Models
{
    public class CoinModel
    {
        public string status { get; set; }
        public Data data { get; set; }
    }
    public class Data
    {
        public Status status { get; set; }
        public Coins[] coins { get; set; }
    }
    public class Status
    {
        public int total { get; set; }
        public int totalCoins { get; set; }
        public int totalMarkets { get; set; }
        public int totalExchanges { get; set; }
    }
    public class Coins
    {
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptocurrencyTracking.Models
{
    public class StatsModel
    {
        public string status { get; set; }
        public DataStats data { get; set; }
    }
    public class DataStats
    {
        public BestCoins[] bestCoins { get; set; }
        public NewestCoins[] newestCoins { get; set; }
    }
    public class BestCoins
    {
        public string symbol { get; set; }
        public string name { get; set; }
        public string iconUrl { get; set; }
        public string coinrankingUrl { get; set; }
    }
    public class NewestCoins
    {
        public string symbol { get; set; }
        public string name { get; set; }
        public string iconUrl { get; set; }
        public string coinrankingUrl { get; set; }
    }
}

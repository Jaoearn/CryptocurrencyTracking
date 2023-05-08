using CryptocurrencyTracking.Models;
using Flurl.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CryptocurrencyTracking.Controllers
{
    public class CryptocurrencyTrackingController : Controller
    {
        private readonly ILogger<CryptocurrencyTrackingController> _logger;
        private readonly string path = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "/json/";

        public CryptocurrencyTrackingController(ILogger<CryptocurrencyTrackingController> logger)
        {
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            List<CoinModel> coin = new List<CoinModel>();
            List<SearchModel> testModel = new List<SearchModel>();
            string json1 = System.IO.File.ReadAllText(path + $"search.json");
            var Info = JsonConvert.DeserializeObject<List<TestModel>>(json1);
            if (Info.Count() > 0)
            {
                for (int i = 0; i < Info.Count; i++)
                {
                    string url1 = "https://api.coinranking.com/v2/coin/" + Info[i].uuid;
                    var responseString = await url1.GetAsync().ReceiveJson<SearchModel>();
                    testModel = JsonConvert.DeserializeObject<List<SearchModel>>(json);
                    testModel.Add(responseString);
                    var jsondata = JsonConvert.SerializeObject(testModel);
                    await System.IO.File.WriteAllTextAsync(path + $"response.json", jsondata);
                }
            }
            string url = "https://api.coinranking.com/v2/stats";
            var responseString = await url.GetAsync().ReceiveJson<StatsModel>();
            ViewData["BestCoins"] = responseString.data.bestCoins;
            ViewData["NewestCoins"] = responseString.data.newestCoins;
            return View();
        }

        public async Task<IActionResult> Trade()
        {
            string url = "https://api.coinranking.com/v2/coins";
            var responseString = await url.GetAsync().ReceiveJson<CoinModel>();
            return View(responseString.data.coins);
        }

        public IActionResult Login()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpPost]
        [Route("/api/login")]
        public bool LoginForm([FromBody] LoginModel loginModel)
        {
            if (loginModel.username == "asdf" && loginModel.password == "1234") return true;
            else return false;
        }
        [HttpPost]
        [Route("/api/coin")]
        public async Task<dynamic> CoinForm([FromBody] UuidModel uuidModel)
        {
            string url = "https://api.coinranking.com/v2/coin/" + uuidModel.uuid;
            var responseString = await url.GetAsync().ReceiveJson<SearchModel>();
            var jsondata = JsonConvert.SerializeObject(responseString);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            await System.IO.File.WriteAllTextAsync(path + $"{uuidModel.uuid}.json", jsondata);

            return uuidModel.uuid;
        }
        [HttpPost]
        [Route("/api/search")]
        public async Task<dynamic> SearchCoin()
        {
            List<SearchModel> testModel = new List<SearchModel>();
            string json1 = System.IO.File.ReadAllText(path + $"search.json");
            var Info = JsonConvert.DeserializeObject<List<TestModel>>(json1);
            if (Info.Count() > 0)
            {
                for (int i = 0; i < Info.Count; i++)
                {
                    string url = "https://api.coinranking.com/v2/coin/" + Info[i].uuid;
                    var responseString = await url.GetAsync().ReceiveJson<SearchModel>();
                    testModel = JsonConvert.DeserializeObject<List<SearchModel>>(json1);
                    testModel.Add(responseString);
                    var jsondata = JsonConvert.SerializeObject(testModel);
                    await System.IO.File.WriteAllTextAsync(path + $"response.json", jsondata);
                }
            }
            else
            {
                for (int i = 0; i < Info.Count; i++)
                {
                    string url = "https://api.coinranking.com/v2/coin/" + Info[i].uuid;
                    var responseString = await url.GetAsync().ReceiveJson<SearchModel>();
                    testModel.Add(responseString);
                    var jsondata = JsonConvert.SerializeObject(testModel);
                    await System.IO.File.WriteAllTextAsync(path + $"response.json", jsondata);
                }
            }


            return "";
        }
        [HttpPost]
        [Route("/api/test")]
        public async Task<dynamic> Tt([FromBody] UuidModel uuidModel)
        {
            List<TestModel> testModel = new List<TestModel>();
            if (System.IO.File.Exists(path + $"search.json"))
            {
                string json = System.IO.File.ReadAllText(path + $"search.json");
                testModel = JsonConvert.DeserializeObject<List<TestModel>>(json);
                testModel.Add(new TestModel() { uuid = uuidModel.uuid });
                var jsondata = JsonConvert.SerializeObject(testModel);
                await System.IO.File.WriteAllTextAsync(path + $"search.json", jsondata);
            }
            else
            {
                testModel.Add(new TestModel() { uuid = uuidModel.uuid });
                var jsondata = JsonConvert.SerializeObject(testModel);
                await System.IO.File.WriteAllTextAsync(path + $"search.json", jsondata);
            }

            return "";
        }
    }
}

using CryptocurrencyTracking.Models;
using Flurl.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CryptocurrencyTracking.Controllers
{
    public class CryptocurrencyTrackingController : Controller
    {
        private readonly ILogger<CryptocurrencyTrackingController> _logger;

        public CryptocurrencyTrackingController(ILogger<CryptocurrencyTrackingController> logger)
        {
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
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

        [HttpGet]
        [Route("/api/coins")]
        public async Task<JsonResult> GetURL()
        {
            string url = "https://api.coinranking.com/v2/coins";
            var responseString = await url.GetAsync().ReceiveJson<CoinModel>();
            return Json(responseString.data.coins);
        }
        [HttpGet]
        [Route("/api/stats")]
        public async Task<JsonResult> GetStats()
        {
            string url = "https://api.coinranking.com/v2/stats";
            var responseString = await url.GetAsync().ReceiveJson<StatsModel>();
            return Json(responseString.data);
        }
        [HttpPost]
        [Route("/api/login")]
        public bool LoginForm([FromBody] LoginModel loginModel)
        {
            if (loginModel.username == "asdf" && loginModel.password == "1234") return true;
            else return false;
        }
    }
}

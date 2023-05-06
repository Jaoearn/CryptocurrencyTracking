using CryptocurrencyTracking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        [Route("/api/MockCreatePayment")]
        public string GetURL()
        {

            return "";
        }
    }
}

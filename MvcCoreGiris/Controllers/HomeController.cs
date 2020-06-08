using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcCoreGiris.Models;
using MvcCoreGiris.Services;

namespace MvcCoreGiris.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private static LuckyNumberService lns=new LuckyNumberService();
        //bir defa newlenir.Aynı controller da aynı değer farklı kontroller da yeni newlenen değer


        private readonly LuckyNumberService _luckyNumberService;
        public HomeController(ILogger<HomeController> logger,LuckyNumberService luckyNumberService)
        {
            _logger = logger;
            _luckyNumberService = luckyNumberService;
        }
            
        public IActionResult Index()
        {
            //ViewBag.lns = lns;

            ViewBag.SansliSayi = _luckyNumberService.LuckyNumber;
            return View();
        }

        public IActionResult Privacy([FromServices]LuckyNumberService luckyNumberService)
        {       
            ViewBag.SansliSayi = luckyNumberService.LuckyNumber;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

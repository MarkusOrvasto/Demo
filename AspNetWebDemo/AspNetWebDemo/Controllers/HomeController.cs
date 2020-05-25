using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AspNetWebDemo.Models;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using AspNetWebDemo.Tietokanta;
using System.Threading.Tasks.Dataflow;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AspNetWebDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration configuration;

        public HomeController(IConfiguration config)
        {
            this.configuration = config;
        }
        

        readonly Db dbop = new Db();
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index([Bind] LoginDb ad)
        {
            int res = dbop.LoginCheck(ad);
            if (res == 1)
            {
                return RedirectToAction("Varasto", "home");
            }
            else
            {
                TempData["msg"] = "Username or password is incorrect.";
            }
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

        public IActionResult Kotisivut()
        {
            return View();
        }

        public IActionResult Varasto()
        {
            VarastoContext konteksti = new VarastoContext();
            List<VarastoTilanne> varastotilanne = konteksti.VarastoTilanne.ToList();
            return View(varastotilanne);
        }
        public IActionResult Varaus()
        {
            VarastoContext konteksti = new VarastoContext();
            List<VarastoTilanne> varastotilanne = konteksti.VarastoTilanne.ToList();
            return View(varastotilanne);
        }
    }
}

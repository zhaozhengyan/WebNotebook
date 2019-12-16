using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebNotebook.Models;

namespace WebNotebook.Controllers
{
    public class HomeController : Controller
    {
        private string AppName;
        public HomeController(IConfiguration configuration)
        {
            AppName = configuration["App.Id"];
        }
        public IActionResult Index()
        {
            ViewBag.AppName = AppName;
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
    }
}

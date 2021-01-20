using System;
using Microsoft.AspNetCore.Mvc;

namespace DutchTreat.Controllers
{
    public class AppController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contact()
        {
            ViewBag.Tittle = "Contact US";
            throw new Exception("Bye bye..");
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Tittle = "About US";
            return View();
        }
    }
}

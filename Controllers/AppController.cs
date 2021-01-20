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

        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(object model)
        {
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Tittle = "About US";
            return View();
        }
    }
}

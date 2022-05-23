using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApp_Traverl_Agency.Models;

namespace WebApp_Traverl_Agency.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View("Homepage");
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }

    }
}
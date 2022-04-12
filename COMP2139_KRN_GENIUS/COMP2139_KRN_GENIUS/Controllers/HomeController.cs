using COMP2139_KRN_GENIUS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace COMP2139_KRN_GENIUS.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        [Route("about")]
        public ViewResult About()
        {
            return View();
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TvcLesson08Models.Models;

namespace TvcLesson08Models.Controllers
{
    public class TvcHomeController : Controller
    {
        public IActionResult TvcIndex()
        {
            return View();
        }

        public IActionResult TvcPrivacy()
        {
            return View();
        }
        public IActionResult TvcAbout()
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

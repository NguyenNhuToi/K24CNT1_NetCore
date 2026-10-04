using Microsoft.AspNetCore.Mvc;

namespace Nnt_TvcLesson14.Areas.Admins.Controllers
{
    [Area("Admins")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
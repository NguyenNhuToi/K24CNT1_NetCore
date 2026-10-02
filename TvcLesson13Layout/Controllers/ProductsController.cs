using Microsoft.AspNetCore.Mvc;

namespace TvcLesson13Layout.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Search(string keyword)
        {
            ViewData["Keyword"] = keyword;
            return View();
        }
        public IActionResult Hots()
        {
            return View();
        }
    }
}

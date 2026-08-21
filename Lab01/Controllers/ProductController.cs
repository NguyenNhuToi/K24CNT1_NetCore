using Microsoft.AspNetCore.Mvc;

namespace Lab01.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

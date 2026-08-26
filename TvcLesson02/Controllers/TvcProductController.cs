using Microsoft.AspNetCore.Mvc;
using TvcLesson02.Models;

namespace TvcLesson02.Controllers
{
    public class TvcProductController : Controller
    {
        public IActionResult Index()
        {
            //Đưa dũ liệu ra view
            ViewBag.name= "Như Tới";
            ViewData["address"] = "Fit NTU";
            TempData["UNI"] = "Trường Đại học Nguyễn Trãi";

            return View();
        }
        //Chi tiết sản phẩm
        public IActionResult GetProduct()
        {
            //Mock data
            TvcProduct tvcProduct = new TvcProduct()
            {
                ProductId = "P001",
                ProductName = "Laptop ASUS ROG Strix SCAR 16",
                YearRelease = 2024,
                Price = 80000000,
            };

            ViewData["productVD"] = tvcProduct;
            ViewBag.productVB = tvcProduct;

            return View();
        }
    }
}

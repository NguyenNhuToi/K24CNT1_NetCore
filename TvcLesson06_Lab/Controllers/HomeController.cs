using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TvcLesson06_Lab.Models;

namespace TvcLesson06_Lab.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var newProducts = new List<Product>
            {
                new Product { ProductId = 1, ProductName = "Laptop ASUS TUF Gaming A15", ImageUrl = "/images/TufGaming.jpg", Price = 27490000 },
                new Product { ProductId = 2, ProductName = "Laptop Gaming Acer Nitro 5", ImageUrl = "/images/AcerNitro.jpg", Price = 21990000 },
                new Product { ProductId = 3, ProductName = "Laptop Gaming Lenovo LOQ 2025", ImageUrl = "/images/LOQ.jpg", Price = 34840000 }
            };

            ViewBag.NewProducts = newProducts;
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
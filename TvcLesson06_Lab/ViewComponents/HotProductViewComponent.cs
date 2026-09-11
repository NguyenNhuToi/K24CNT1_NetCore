using Microsoft.AspNetCore.Mvc;
using TvcLesson06_Lab.Models;

namespace TvcLesson06_Lab.ViewComponents
{
    public class HotProductViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var hotProducts = new List<Product>
            {
                new Product { ProductId = 4, ProductName = "Laptop Gaming Asus ROG Strix G15", ImageUrl = "/images/AsusGaming.jpg", Price = 32990000 },
                new Product { ProductId = 5, ProductName = "Laptop Gaming Acer Predator Helios Neo 18", ImageUrl = "/images/Helios.jpg", Price = 35990000 },
                new Product { ProductId = 6, ProductName = "Laptop Gaming Lenovo Legion 5 Pro", ImageUrl = "/images/LenovoLegion.jpg", Price = 41990000 }
            };
            return View(hotProducts);
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TvcLesson09Annotation.Models.DataModels;
using TvcLesson09Annotation.Models.DataViewModels;

namespace TvcLesson09Annotation.Controllers
{
    public class ProductController : Controller
    {
        // Giả lập database (Static list)
        private static List<Product> _products = new List<Product>();
        private static List<Category> _categories = new List<Category>()
        {
            new Category { Id = 1, Name = "Điện thoại" },
            new Category { Id = 2, Name = "Laptop" },
            new Category { Id = 3, Name = "Phụ kiện" }
        };

        private static readonly string[] BadWords = { "admin", "fuck", "shit", "dm", "dcm" };

        // ==================== TVCINDEX ====================
        // GET: Product/TvcIndex
        public IActionResult TvcIndex()
        {
            return View(_products);
        }

        // ==================== TVCCREATE (GET) ====================
        // GET: Product/TvcCreate
        public IActionResult TvcCreate()
        {
            var model = new ProductViewModel
            {
                Categories = _categories
            };
            return View(model);
        }

        // ==================== TVCCREATE (POST) ====================
        // POST: Product/TvcCreate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TvcCreate(ProductViewModel model)
        {
            if (model.SalePrice >= model.Price * 0.9)
            {
                ModelState.AddModelError("SalePrice", "Giá khuyến mãi phải nhỏ hơn 10% so với giá gốc.");
            }

            if (!string.IsNullOrEmpty(model.Description))
            {
                foreach (var word in BadWords)
                {
                    if (model.Description.ToLower().Contains(word))
                    {
                        ModelState.AddModelError("Description", $"Mô tả không được chứa từ nhạy cảm: {word}");
                        break;
                    }
                }
            }

            // 3. Upload ảnh
            string fileName = "";
            if (model.ImageFile != null)
            {
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                var extension = Path.GetExtension(model.ImageFile.FileName).ToLower();

                if (!allowedExtensions.Contains(extension))
                {
                    ModelState.AddModelError("ImageFile", "Chỉ chấp nhận file ảnh (.jpg, .jpeg, .png, .gif)");
                }
                else
                {
                    fileName = Guid.NewGuid().ToString() + extension;
                    var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "products");
                    if (!Directory.Exists(folderPath))
                        Directory.CreateDirectory(folderPath);

                    var filePath = Path.Combine(folderPath, fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.ImageFile.CopyToAsync(stream);
                    }
                }
            }
            else
            {
                ModelState.AddModelError("ImageFile", "Vui lòng chọn hình ảnh.");
            }

            if (ModelState.IsValid)
            {
                var product = new Product
                {
                    Id = _products.Count > 0 ? _products.Max(p => p.Id) + 1 : 1,
                    Name = model.Name,
                    Image = fileName,
                    Price = model.Price,
                    SalePrice = model.SalePrice,
                    Description = model.Description,
                    CategoryId = model.CategoryId
                };

                _products.Add(product);
                return RedirectToAction(nameof(TvcIndex));   // ✅ Đổi thành TvcIndex
            }

            model.Categories = _categories;
            return View(model);
        }

        // GET: Product/Edit/5
        public IActionResult TvcEdit(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();

            var model = new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                ExistingImage = product.Image,
                Price = product.Price,
                SalePrice = product.SalePrice,
                Description = product.Description,
                CategoryId = product.CategoryId,
                Categories = _categories
            };
            return View(model);
        }
        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TvcEdit(int id, ProductViewModel model)
        {
            if (id != model.Id) return NotFound();

            // 1. Kiểm tra SalePrice < 10% Price
            if (model.SalePrice >= model.Price * 0.9)
            {
                ModelState.AddModelError("SalePrice", "Giá khuyến mãi phải nhỏ hơn 10% so với giá gốc.");
            }

            // 2. Kiểm tra từ nhạy cảm
            if (!string.IsNullOrEmpty(model.Description))
            {
                foreach (var word in BadWords)
                {
                    if (model.Description.ToLower().Contains(word))
                    {
                        ModelState.AddModelError("Description", $"Mô tả không được chứa từ nhạy cảm: {word}");
                        break;
                    }
                }
            }

            // 3. Upload ảnh mới (nếu có)
            string fileName = model.ExistingImage ?? "";
            if (model.ImageFile != null)
            {
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                var extension = Path.GetExtension(model.ImageFile.FileName).ToLower();

                if (!allowedExtensions.Contains(extension))
                {
                    ModelState.AddModelError("ImageFile", "Chỉ chấp nhận file ảnh (.jpg, .jpeg, .png, .gif)");
                }
                else
                {
                    fileName = Guid.NewGuid().ToString() + extension;
                    var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "products");
                    if (!Directory.Exists(folderPath))
                        Directory.CreateDirectory(folderPath);

                    var filePath = Path.Combine(folderPath, fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.ImageFile.CopyToAsync(stream);
                    }
                }
            }

            if (ModelState.IsValid)
            {
                var product = _products.FirstOrDefault(p => p.Id == id);
                if (product == null) return NotFound();

                product.Name = model.Name;
                product.Image = fileName;
                product.Price = model.Price;
                product.SalePrice = model.SalePrice;
                product.Description = model.Description;
                product.CategoryId = model.CategoryId;

                return RedirectToAction(nameof(TvcIndex));
            }

            model.Categories = _categories;
            return View(model);
        }

        // ==================== DETAILS ====================
        // GET: Product/Details/5
        public IActionResult TvcDetails(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();
            return View(product);
        }

        // ==================== DELETE (GET) ====================
        // GET: Product/Delete/5
        public IActionResult TvcDelete(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();
            return View(product);
        }

        // ==================== DELETE (POST) ====================
        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _products.Remove(product);
            }
            return RedirectToAction(nameof(TvcIndex));   // ✅ Đổi thành TvcIndex
        }
    }
}
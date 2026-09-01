using Microsoft.AspNetCore.Mvc;
using TvcLesson04Lab.Models;

namespace TvcLesson04Lab.Controllers
{
    public class TvcProductController : Controller
    {
        private readonly List<TvcCategory> tvcCategories = new()
        {
            new TvcCategory { Id = 1, Name = "Game hành động - Kinh dị" },
            new TvcCategory { Id = 2, Name = "Game kinh dị sinh tồn" },
            new TvcCategory { Id = 3, Name = "Game bắn súng" },
            new TvcCategory { Id = 4, Name = "Đồ lưu niệm" }
        };

        private readonly List<TvcProduct> tvcProducts = new()
        {
            new TvcProduct
            {
                Id = 1,
                Name = "Resident Evil 2 Remake",
                Description = "Virus chết người bao phủ Raccoon City vào tháng 9/1998, nhấn chìm thành phố trong hỗn loạn khi xác sống tràn lan trên đường phố. Hồi hộp nghẹt thở, cốt truyện hấp dẫn và nỗi kinh hoàng tột độ đang chờ bạn. Chào mừng sự trở lại của Resident Evil 2.",
                Price = 990000,
                SalePrice = 690000,
                Category = "Game hành động - Kinh dị",
                ImageUrl = "/images/re2.jpg",
                ReleaseYear = 2019,
                Platform = "PS4, PS5, Xbox One, Xbox Series X/S, PC",
                Rating = 9.3,
                Publisher = "Capcom",
                Developer = "Capcom",
                IsHot = true,
                IsNew = false
            },
            new TvcProduct
            {
                Id = 2,
                Name = "Resident Evil 3 Remake",
                Description = "Jill Valentine là một trong số ít người còn sống sót ở Raccoon City để chứng kiến những hành động tàn bạo của tập đoàn Umbrella. Để bịt miệng cô, Umbrella đã phóng thích vũ khí bí mật cuối cùng của chúng: Nemesis! Đi kèm với Resident Evil Resistance, một tựa game trực tuyến 1 đấu 4 hoàn toàn mới lấy bối cảnh trong thế giới Resident Evil.",
                Price = 990000,
                SalePrice = 590000,
                Category = "Game hành động - Kinh dị",
                ImageUrl = "/images/re3.jpg",
                ReleaseYear = 2020,
                Platform = "PS4, PS5, Xbox One, Xbox Series X/S, PC",
                Rating = 8.5,
                Publisher = "Capcom",
                Developer = "Capcom",
                IsHot = false,
                IsNew = false
            },
            new TvcProduct
            {
                Id = 3,
                Name = "Resident Evil 4 Remake",
                Description = "Sinh tồn chỉ là khởi đầu của mọi chuyện. Sáu năm đã qua kể từ thảm họa sinh học ở thành phố Raccoon. Leon S. Kennedy, một trong những người sống sót, đã truy tung con gái của tổng thống bị bắt cóc đến một ngôi làng hẻo lánh ở châu Âu, nơi người dân nơi đây mang một bí mật kinh hoàng.",
                Price = 1490000,
                SalePrice = 990000,
                Category = "Game hành động - Kinh dị",
                ImageUrl = "/images/re4.jpg",
                ReleaseYear = 2023,
                Platform = "PS5, Xbox Series X/S, PC, PS4, Xbox One",
                Rating = 9.5,
                Publisher = "Capcom",
                Developer = "Capcom",
                IsHot = true,
                IsNew = false
            },
            new TvcProduct
            {
                Id = 4,
                Name = "Resident Evil 7 Biohazard",
                Description = "Sợ hãi và cô đơn thấm đẫm từng bức tường của trang trại bỏ hoang ở miền Nam. '7' là sự khởi đầu mới cho kinh dị sinh tồn với phong cách 'Góc nhìn cô lập' - góc nhìn thứ nhất chân thực đến nghẹt thở.",
                Price = 890000,
                SalePrice = 490000,
                Category = "Game kinh dị sinh tồn",
                ImageUrl = "/images/re7.jpg",
                ReleaseYear = 2017,
                Platform = "PS4, PS5, Xbox One, Xbox Series X/S, PC, Nintendo Switch",
                Rating = 8.8,
                Publisher = "Capcom",
                Developer = "Capcom",
                IsHot = false,
                IsNew = false
            },
            new TvcProduct
            {
                Id = 5,
                Name = "Resident Evil Village",
                Description = "Trải nghiệm cảm giác kinh dị sinh tồn mãnh liệt chưa từng có trong phần chính thứ 8 của series Resident Evil - Resident Evil Village. Với nền đồ họa chi tiết sống động, lối chơi góc nhìn thứ nhất đầy kịch tính và câu chuyện được dẫn dắt một cách xuất sắc, nỗi kinh hoàng trở nên chân thực hơn bao giờ hết.",
                Price = 1290000,
                SalePrice = 890000,
                Category = "Game hành động - Kinh dị",
                ImageUrl = "/images/Re8.jpg",
                ReleaseYear = 2021,
                Platform = "PS5, PS4, Xbox Series X/S, Xbox One, PC",
                Rating = 9.0,
                Publisher = "Capcom",
                Developer = "Capcom",
                IsHot = true,
                IsNew = false
            },
            new TvcProduct
            {
                Id = 6,
                Name = "Resident Evil: Requiem",
                Description = "Khúc cầu siêu cho kẻ chết. Cơn ác mộng cho người sống. Hãy sẵn sàng thoát khỏi cái chết trong trải nghiệm nghẹt thở sẽ làm bạn lạnh sống lưng.",
                Price = 1690000,
                SalePrice = 1290000,
                Category = "Game hành động - Kinh dị",
                ImageUrl = "/images/re9.jpg",
                ReleaseYear = 2026,
                Platform = "PS5, Xbox Series X/S, PC, Nintendo Switch 2",
                Rating = 9.2,
                Publisher = "Capcom",
                Developer = "Capcom",
                IsHot = true,
                IsNew = true
            }
        };

        public IActionResult Index(int? categoryId = null)
        {
            var categories = tvcCategories ?? new List<TvcCategory>();
            var products = tvcProducts ?? new List<TvcProduct>();

            ViewBag.TvcCategories = categories;

            List<TvcProduct> filteredProducts;
            if (categoryId.HasValue && categoryId.Value > 0)
            {
                var selectedCategory = categories.FirstOrDefault(c => c.Id == categoryId.Value);
                if (selectedCategory != null)
                {
                    filteredProducts = products.Where(p => p.Category == selectedCategory.Name).ToList();
                    ViewBag.SelectedCategory = categoryId.Value;
                }
                else
                {
                    filteredProducts = products;
                    ViewBag.SelectedCategory = null;
                }
            }
            else
            {
                filteredProducts = products;
                ViewBag.SelectedCategory = null;
            }

            ViewBag.TvcProducts = filteredProducts;
            return View();
        }

        [Route("san-pham-cua-toi", Name = "tvcproductdetail")]
        public IActionResult TvcSanPham(int? id)
        {
            var products = tvcProducts ?? new List<TvcProduct>();

            TvcProduct tvcProduct = products.FirstOrDefault();

            if (id != null)
            {
                tvcProduct = products.FirstOrDefault(x => x.Id == id);
                if (tvcProduct == null)
                {
                    tvcProduct = products.FirstOrDefault();
                }
            }

            ViewBag.TvcProduct = tvcProduct;

            if (tvcProduct != null)
            {
                var relatedProducts = products
                    .Where(p => p.Category == tvcProduct.Category && p.Id != tvcProduct.Id)
                    .Take(4)
                    .ToList();
                ViewBag.RelatedProducts = relatedProducts;
            }

            return View();
        }
    }
}
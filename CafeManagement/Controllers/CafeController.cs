using Microsoft.AspNetCore.Mvc;
using CafeManagement.Models;

namespace CafeManagement.Controllers
{
    public class CafeController : Controller
    {
        private static List<CafeItem> cafeItems = new List<CafeItem>
        {
            new CafeItem { Id = 1, Name = "Cà phê sữa", Category = "Coffee", Price = 25000, Quantity = 20, Description = "Cà phê sữa truyền thống" },
            new CafeItem { Id = 2, Name = "Trà đào", Category = "Tea", Price = 30000, Quantity = 15, Description = "Trà đào cam sả" },
            new CafeItem { Id = 3, Name = "Bạc xỉu", Category = "Coffee", Price = 28000, Quantity = 18, Description = "Bạc xỉu đá" },
            new CafeItem { Id = 4, Name = "Latte", Category = "Coffee", Price = 32000, Quantity = 25, Description = "Latte kem sữa" },
            new CafeItem { Id = 5, Name = "Cappuccino", Category = "Coffee", Price = 33000, Quantity = 22, Description = "Cappuccino thơm ngon" },
            new CafeItem { Id = 6, Name = "Trà xanh", Category = "Tea", Price = 22000, Quantity = 30, Description = "Trà xanh matcha" },
            new CafeItem { Id = 7, Name = "Sinh tố bơ", Category = "Smoothie", Price = 35000, Quantity = 12, Description = "Sinh tố bơ mịn" },
            new CafeItem { Id = 8, Name = "Hồng trà sữa", Category = "Tea", Price = 29000, Quantity = 16, Description = "Hồng trà sữa trân châu" },
            new CafeItem { Id = 9, Name = "Espresso", Category = "Coffee", Price = 20000, Quantity = 40, Description = "Espresso đậm vị" },
            new CafeItem { Id = 10, Name = "Mocha", Category = "Coffee", Price = 34000, Quantity = 14, Description = "Mocha socola" },
            new CafeItem { Id = 11, Name = "Trà sữa truyền thống", Category = "Tea", Price = 26000, Quantity = 20, Description = "Trà sữa cổ điển" },
            new CafeItem { Id = 12, Name = "Nước cam", Category = "Juice", Price = 24000, Quantity = 18, Description = "Nước cam tươi" },
            new CafeItem { Id = 13, Name = "Trà chanh", Category = "Tea", Price = 18000, Quantity = 28, Description = "Trà chanh sả" },
            new CafeItem { Id = 14, Name = "Bánh mì kẹp", Category = "Snack", Price = 20000, Quantity = 10, Description = "Bánh mì kẹp thịt" },
            new CafeItem { Id = 15, Name = "Bánh ngọt", Category = "Dessert", Price = 22000, Quantity = 8, Description = "Bánh ngọt tráng miệng" },
            new CafeItem { Id = 16, Name = "Sinh tố dứa", Category = "Smoothie", Price = 33000, Quantity = 11, Description = "Sinh tố dứa mát" },
            new CafeItem { Id = 17, Name = "Trà ô long", Category = "Tea", Price = 27000, Quantity = 17, Description = "Trà ô long thơm" },
            new CafeItem { Id = 18, Name = "Cold Brew", Category = "Coffee", Price = 36000, Quantity = 9, Description = "Cold Brew ủ lạnh" },
            new CafeItem { Id = 19, Name = "Soda chanh", Category = "Juice", Price = 20000, Quantity = 19, Description = "Soda chanh mát" },
            new CafeItem { Id = 20, Name = "Trà hoa cúc", Category = "Tea", Price = 21000, Quantity = 13, Description = "Trà hoa cúc thảo mộc" }
        };

        public IActionResult Index(string search, string sortOrder, int page = 1, int pageSize = 10)
        {
            var data = cafeItems.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                data = data.Where(x => x.Name.ToLower().Contains(search.ToLower())
                                    || x.Category.ToLower().Contains(search.ToLower()));
            }

            ViewBag.PriceSort = sortOrder == "price_asc" ? "price_desc" : "price_asc";

            data = sortOrder switch
            {
                "price_asc" => data.OrderBy(x => x.Price),
                "price_desc" => data.OrderByDescending(x => x.Price),
                _ => data.OrderBy(x => x.Id)
            };

            // Pagination
            var totalCount = data.Count();
            var totalPages = (int)System.Math.Ceiling(totalCount / (double)pageSize);

            // Ensure page bounds
            if (page < 1) page = 1;
            if (page > totalPages) page = totalPages == 0 ? 1 : totalPages;

            var paged = data.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            ViewBag.Page = page;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalPages = totalPages;
            ViewBag.TotalCount = totalCount;

            return View(paged);
        }

        public IActionResult Detail(int id)
        {
            var item = cafeItems.FirstOrDefault(x => x.Id == id);

            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CafeItem model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            model.Id = cafeItems.Count > 0 ? cafeItems.Max(x => x.Id) + 1 : 1;
            cafeItems.Add(model);

            TempData["Message"] = "Thêm món thành công!";
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var item = cafeItems.FirstOrDefault(x => x.Id == id);

            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        [HttpPost]
        public IActionResult Edit(CafeItem model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var item = cafeItems.FirstOrDefault(x => x.Id == model.Id);

            if (item == null)
            {
                return NotFound();
            }

            item.Name = model.Name;
            item.Category = model.Category;
            item.Price = model.Price;
            item.Quantity = model.Quantity;
            item.Description = model.Description;

            TempData["Message"] = "Cập nhật món thành công!";
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var item = cafeItems.FirstOrDefault(x => x.Id == id);

            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var item = cafeItems.FirstOrDefault(x => x.Id == id);

            if (item == null)
            {
                return NotFound();
            }

            cafeItems.Remove(item);

            TempData["Message"] = "Xóa món thành công!";
            return RedirectToAction("Index");
        }
    }
}
using LabNgay7TuLam.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LabNgay7TuLam.Controllers
{
    public class ProductController : Controller
    {
        private readonly string _uploadDir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "products");

        private static List<Product> _products = new List<Product>();
        private static List<Category> _categories = new List<Category>()
    {
        new Category { Id = 1, Name = "Điện thoại" },
        new Category { Id = 2, Name = "Laptop" },
        new Category { Id = 3, Name = "Phụ kiện" },
        new Category { Id = 4, Name = "Máy tính bảng" }
    };        
        // GET: ProductController
        public ActionResult Index()
        {
            return View(_products);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();
            return View(product);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(_categories, "Id", "Name");
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                if (product.ImageUpload != null)
                {
                    if (!Directory.Exists(_uploadDir)) Directory.CreateDirectory(_uploadDir);

                    string fileName = Guid.NewGuid().ToString() + "_" + product.ImageUpload.FileName;
                    string filePath = Path.Combine(_uploadDir, fileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        product.ImageUpload.CopyTo(fileStream);
                    }
                    product.Image = fileName;
                }

                product.Id = _products.Count > 0 ? _products.Max(p => p.Id) + 1 : 1;
                _products.Add(product);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.CategoryId = new SelectList(_categories, "Id", "Name", product.CategoryId);
            return View(product);
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();
            ViewBag.CategoryId = new SelectList(_categories, "Id", "Name", product.CategoryId);
            return View(product);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Product product)
        {
            if (id != product.Id) return NotFound();

            if (ModelState.IsValid)
            {
                if (product.ImageUpload != null)
                {
                    if (!Directory.Exists(_uploadDir)) Directory.CreateDirectory(_uploadDir);

                    string fileName = Guid.NewGuid().ToString() + "_" + product.ImageUpload.FileName;
                    string filePath = Path.Combine(_uploadDir, fileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        product.ImageUpload.CopyTo(fileStream); // Đồng bộ
                    }
                    product.Image = fileName;
                }
                else
                {
                    var oldProduct = _products.FirstOrDefault(p => p.Id == id);
                    if (oldProduct != null) product.Image = oldProduct.Image;
                }

                var index = _products.FindIndex(p => p.Id == id);
                if (index != -1) _products[index] = product;

                return RedirectToAction(nameof(Index));
            }

            ViewBag.CategoryId = new SelectList(_categories, "Id", "Name", product.CategoryId);
            return View(product);
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();
            return View(product);
        }

        // POST: ProductController/Delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product != null) _products.Remove(product);
            return RedirectToAction(nameof(Index));
        }
        [AcceptVerbs("GET", "POST")]
        public IActionResult VerifySalePrice(float salePrice, float price)
        {
            if (salePrice > price * 0.9)
            {
                return Json($"Giá khuyến mãi ({salePrice}) phải nhỏ hơn giá chuẩn ({price}) ít nhất 10%");
            }

            return Json(true);
        }
    }
}

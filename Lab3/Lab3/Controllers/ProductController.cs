using Microsoft.AspNetCore.Mvc;
using Lab3.Models;
using System.Linq;
namespace Lab3.Controllers
{
    public class ProductController : Controller
    {
        [Route("danh-sach-san-pham", Name = "product_index")]
        public IActionResult Index(int? categoryId)
        {
            List<Category> categories = new List<Category>
            {
                new Category() { Id = 1, Name = "Điện thoại" },
                new Category() { Id = 2, Name = "Laptop" },
                new Category() { Id = 3, Name = "Phụ kiện" }
            };

            List<Product> products = new List<Product>
            {
                new Product() { 
                    Id = 1, 
                    Name = "iPhone 15 Pro Max", 
                    Image = "/images/product/iphone15promax.png", 
                    Price = 25000000, 
                    SalePrice = 22990000, 
                    CategoryId = 1, 
                    Description = "Màn hình 6.7 inch, chip A17 Pro, camera 48MP", 
                    Status = 1, 
                    CreatedAt = new DateTime(2024, 7, 15, 12, 0, 0) },
                new Product() { 
                    Id = 2, 
                    Name = "Samsung Galaxy S24 Ultra", 
                    Image = "/images/product/galaxys24ultra.png", 
                    Price = 23000000, SalePrice = 20990000, 
                    CategoryId = 1, 
                    Description = "Màn hình 6.8 inch, chip Snapdragon 8 Gen 3, camera 200MP", 
                    Status = 1, 
                    CreatedAt = new DateTime(2024, 7, 16, 14, 30, 0) },
                new Product() {
                    Id = 3, 
                    Name = "MacBook Pro 16 inch", 
                    Image = "/images/product/macbookpro16.png", 
                    Price = 45000000, SalePrice = 42990000, 
                    CategoryId = 2,
                    Description = "Màn hình Liquid Retina XDR, chip M3 Pro, RAM 18GB", 
                    Status = 1, 
                    CreatedAt = new DateTime(2024, 7, 17, 10, 15, 0) },
                new Product() { 
                    Id = 4, 
                    Name = "Dell XPS 13 Plus", 
                    Image = "/images/product/dellxps13.png", 
                    Price = 28000000, SalePrice = 25990000, 
                    CategoryId = 2, 
                    Description = "Màn hình 13.4 inch OLED, chip Intel Core i7", 
                    Status = 1, 
                    CreatedAt = new DateTime(2024, 7, 18, 9, 0, 0) },
                new Product() { 
                    Id = 5, 
                    Name = "Tai nghe AirPods Pro 2", 
                    Image = "/images/product/airpodspro2.png", 
                    Price = 5000000,
                    SalePrice = 4490000, 
                    CategoryId = 3, 
                    Description = "Chống ồn chủ động, âm thanh không gian, chip H2", 
                    Status = 1, 
                    CreatedAt = new DateTime(2024, 7, 19, 16, 45, 0) },
                new Product() { 
                    Id = 6,
                    Name = "Sạc nhanh Anker 65W", 
                    Image = "/images/product/anker65w.png", 
                    Price = 1200000, 
                    SalePrice = 990000, 
                    CategoryId = 3, 
                    Description = "Sạc nhanh 65W, 2 cổng USB-C, 1 cổng USB-A", 
                    Status = 1, 
                    CreatedAt = new DateTime(2024, 7, 20, 8, 20, 0) }
            };

            
            if (categoryId.HasValue)
            {
                products = products.Where(p => p.CategoryId == categoryId.Value).ToList();
            }

            ViewBag.Categories = categories;
            ViewBag.Products = products;

            return View();
        }

        [Route("san-pham/{id}", Name = "product_detail")]
        public IActionResult Detail(int id)
        {
            List<Product> products = new List<Product>
            {
                new Product() {
                    Id = 1, 
                    Name = "iPhone 15 Pro Max",
                    Image = "/images/product/iphone15promax.png",
                    Price = 25000000,
                    SalePrice = 22990000,
                    CategoryId = 1, 
                    Description = "Màn hình 6.7 inch, chip A17 Pro, camera 48MP",
                    Status = 1, 
                    CreatedAt = new DateTime(2024, 7, 15, 12, 0, 0) },
                new Product() { 
                    Id = 2,
                    Name = "Samsung Galaxy S24 Ultra", 
                    Image = "/images/product/galaxys24ultra.png", 
                    Price = 23000000, 
                    SalePrice = 20990000, 
                    CategoryId = 1, 
                    Description = "Màn hình 6.8 inch, chip Snapdragon 8 Gen 3, camera 200MP", 
                    Status = 1, 
                    CreatedAt = new DateTime(2024, 7, 16, 14, 30, 0) },
                new Product() { 
                    Id = 3, 
                    Name = "MacBook Pro 16 inch", 
                    Image = "/images/product/macbookpro16.png", 
                    Price = 45000000, SalePrice = 42990000, CategoryId = 2, 
                    Description = "Màn hình Liquid Retina XDR, chip M3 Pro, RAM 18GB", 
                    Status = 1,
                    CreatedAt = new DateTime(2024, 7, 17, 10, 15, 0) },
                new Product() { 
                    Id = 4,
                    Name = "Dell XPS 13 Plus",
                    Image = "/images/product/dellxps13.png",
                    Price = 28000000,
                    SalePrice = 25990000, 
                    CategoryId = 2, Description = "Màn hình 13.4 inch OLED, chip Intel Core i7", 
                    Status = 1,
                    CreatedAt = new DateTime(2024, 7, 18, 9, 0, 0) },
                new Product() { 
                    Id = 5,
                    Name = "Tai nghe AirPods Pro 2", 
                    Image = "/images/product/airpodspro2.png",
                    Price = 5000000, 
                    SalePrice = 4490000,
                    CategoryId = 3, 
                    Description = "Chống ồn chủ động, âm thanh không gian, chip H2",
                    Status = 0,
                    CreatedAt = new DateTime(2024, 7, 19, 16, 45, 0) },
                new Product() {
                    Id = 6, 
                    Name = "Sạc nhanh Anker 65W",
                    Image = "/images/product/anker65w.png",
                    Price = 1200000, 
                    SalePrice = 990000, 
                    CategoryId = 3,
                    Description = "Sạc nhanh 65W, 2 cổng USB-C, 1 cổng USB-A", 
                    Status = 0, 
                    CreatedAt = new DateTime(2024, 7, 20, 8, 20, 0) }
            };


            var product = products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
    }
}

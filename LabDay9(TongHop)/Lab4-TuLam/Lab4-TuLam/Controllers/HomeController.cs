using System.Diagnostics;
using Lab4_TuLam.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab4_TuLam.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var newestProducts = new List<Product>
        {
            new Product { Id = 1, Name = "Nồi cơm điện cao tần Nagakawa NAG0102", ImageUrl = "/images/NoiCom.jpg", Price = 2000000 },
            new Product { Id = 2, Name = "Nồi cơm điện cao tần Nagakawa NAG0102", ImageUrl = "/images/NoiCom.jpg", Price = 2100000 },
            new Product { Id = 3, Name = "Nồi cơm điện cao tần Nagakawa NAG0102", ImageUrl = "/images/NoiCom.jpg", Price = 2200000 }
        };

            return View(newestProducts);
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

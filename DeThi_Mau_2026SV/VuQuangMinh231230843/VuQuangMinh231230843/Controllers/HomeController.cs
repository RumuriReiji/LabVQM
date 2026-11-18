using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VuQuangMinh231230843.Models;

namespace VuQuangMinh231230843.Controllers
{
    public class HomeController : Controller
    {
        private readonly QlnhaSachContext _context;
        public HomeController(QlnhaSachContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var ds = _context.Saches.Where(h => h.Gia >= 100).ToList();
            return View(ds);
        }
        public IActionResult LocTheoLoai(int MaTl)
        {
            var ds = (MaTl == 0)
                ? _context.Saches.Where(x => x.Gia >= 100).ToList()
                : _context.Saches.Where(x => x.MaTl == MaTl && x.Gia >= 100).ToList();

            return PartialView("VuQuangMinh_MainContent", ds);

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

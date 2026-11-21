using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VuQuangMinh_231230843.Models;

namespace VuQuangMinh_231230843.Controllers
{
    public class HomeController : Controller
    {
        public readonly QltaiSanContext _context;
        public HomeController(QltaiSanContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var dsTaiSan = _context.TaiSans.Where(h => h.NguyenGia >= 20).ToList();
            return View(dsTaiSan);
        }
        public IActionResult LocTheoLoai(int MaLoai)
        {
            var ds = (MaLoai == 0) ? _context.TaiSans.Where(h => h.NguyenGia >= 20).ToList() : _context.TaiSans.Where(h => h.NguyenGia >= 20 && h.MaLoai == MaLoai).ToList();
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

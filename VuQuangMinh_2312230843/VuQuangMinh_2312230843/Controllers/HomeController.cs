using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VuQuangMinh_2312230843.Models;

namespace VuQuangMinh_2312230843.Controllers
{
    public class HomeController : Controller
    {
        public readonly QlhangHoaContext _context;
        public HomeController(QlhangHoaContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var dsHangHoa = _context.HangHoas.Where(h => h.Gia >= 100).ToList();
            return View(dsHangHoa);
        }
        public IActionResult LocTheoLoai(int maLoai)
        {
            var ds = (maLoai == 0) ? _context.HangHoas.Where(h => h.Gia >= 100).ToList() : _context.HangHoas.Where(h => h.Gia >= 100 &&  h.MaLoai == maLoai).ToList();
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

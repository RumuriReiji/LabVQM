using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VuQuangMinh_231230843.Models;

namespace VuQuangMinh_231230843.Controllers
{
    public class TaiSanController : Controller
    {
        public readonly QltaiSanContext _context;
        public TaiSanController(QltaiSanContext context)
        {
            _context = context;
        }
        // GET: TaiSanController
        public ActionResult Index()
        {
            return View();
        }

        // GET: TaiSanController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TaiSanController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TaiSanController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TaiSanController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var taiSan = await _context.TaiSans.FindAsync(id);
            if (taiSan == null) return NotFound();

            ViewData["MaLoai"] = new SelectList(_context.LoaiTaiSans, "MaLoai", "TenLoai", taiSan.MaLoai);
            return View(taiSan);
        }


        // POST: TaiSanController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaTs,MaLoai,TenTs,NguyenGia,Anh")] TaiSan taiSan)
        {
            if (id != taiSan.MaTs) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taiSan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.TaiSans.Any(e => e.MaTs == taiSan.MaTs))
                        return NotFound();
                    else throw;
                }
                return RedirectToAction("Index", "Home");
            }
            ViewData["MaLoai"] = new SelectList(_context.LoaiTaiSans, "MaLoai", "TenLoai", taiSan.MaLoai);
            return View(taiSan);
        }


        // GET: TaiSanController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TaiSanController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

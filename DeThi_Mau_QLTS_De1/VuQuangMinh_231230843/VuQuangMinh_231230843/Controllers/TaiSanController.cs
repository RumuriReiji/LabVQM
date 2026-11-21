using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VuQuangMinh_231230843.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace VuQuangMinh_231230843.Controllers
{
    public class TaiSanController : Controller
    {
        private readonly QltaiSanContext _context;

        public TaiSanController(QltaiSanContext context)
        {
            _context = context;
        }
        // GET: TaiSanController
        public async Task<IActionResult> Index()
        {
            return View(await _context.TaiSans.ToListAsync());
        }
        // GET: TaiSanController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TaiSanController/Create
        public ActionResult Create()
        {
            ViewData["MaLoai"] = new SelectList(_context.LoaiTaiSans, "MaLoai", "TenLoai");
            return View();
        }

        // POST: TaiSanController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaTs,MaLoai,TenTs,NguyenGia,Anh,MaLoaiNavigation")] TaiSan taiSan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taiSan);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            ViewData["MaTl"] = new SelectList(_context.LoaiTaiSans, "MaLoai", "TenLoai", taiSan);

            return View(taiSan);
        }

        // GET: TaiSanController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TaiSanController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

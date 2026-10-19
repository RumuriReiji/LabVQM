using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LabDay9TuLam.Data;
using LabDay9TuLam.Models;

namespace LabDay9TuLam.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BannerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BannerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Banner
        public async Task<IActionResult> Index()
        {
            var banners = await _context.Banners
                .OrderBy(b => b.Prioty)
                .ToListAsync();
            return View(banners);
        }

        // GET: Admin/Banner/Create
        public IActionResult Create()
        {
            var banner = new Banner
            {
                Status = 1,
                Prioty = 0
            };
            return View(banner);
        }

        // POST: Admin/Banner/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Banner banner)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    bool isNameExist = await _context.Banners
                        .AnyAsync(b => b.Name.ToLower() == banner.Name.Trim().ToLower());
                    if (isNameExist)
                    {
                        ModelState.AddModelError("Name", "Tên banner đã tồn tại");
                        return View(banner);
                    }

                    _context.Add(banner);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("Name", "Tên banner đã tồn tại");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "Đã xảy ra lỗi khi thêm banner: " + ex.Message);
                }
            }
            return View(banner);
        }

        // GET: Admin/Banner/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var banner = await _context.Banners.FindAsync(id);
            if (banner == null)
            {
                return NotFound();
            }
            return View(banner);
        }

        // POST: Admin/Banner/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Banner banner)
        {
            if (id != banner.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    bool isNameExist = await _context.Banners
                        .AnyAsync(b => b.Id != banner.Id && b.Name.ToLower() == banner.Name.Trim().ToLower());
                    if (isNameExist)
                    {
                        ModelState.AddModelError("Name", "Tên banner đã tồn tại");
                        return View(banner);
                    }

                    _context.Update(banner);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await BannerExists(banner.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("Name", "Tên banner đã tồn tại");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "Đã xảy ra lỗi khi cập nhật banner: " + ex.Message);
                }
            }
            return View(banner);
        }

        // GET: Admin/Banner/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var banner = await _context.Banners
                .FirstOrDefaultAsync(m => m.Id == id);
            if (banner == null)
            {
                return NotFound();
            }

            return View(banner);
        }

        // POST: Admin/Banner/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var banner = await _context.Banners.FindAsync(id);
            if (banner != null)
            {
                try
                {
                    _context.Banners.Remove(banner);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "Không thể xóa banner: " + ex.Message);
                    return View("Delete", banner);
                }
            }

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> BannerExists(int id)
        {
            return await _context.Banners.AnyAsync(e => e.Id == id);
        }
    }
}

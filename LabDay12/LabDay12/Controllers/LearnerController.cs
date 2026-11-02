using LabDay12.Data;
using LabDay12.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LabDay12.Controllers
{
    public class LearnerController : Controller
    {
        private readonly SchoolContext _context;
        private int pageSize = 3;

        public LearnerController(SchoolContext context)
        {
            _context = context;
        }

        // GET: Learner - Lab5: filter by mid | Lab6: pagination
        public IActionResult Index(int? mid)
        {
            var learners = (IQueryable<Learner>)_context.Learners.Include(m => m.Major);
            if (mid != null)
            {
                learners = (IQueryable<Learner>)_context.Learners
                    .Where(l => l.MajorId == mid)
                    .Include(m => m.Major);
            }
            int pageNum = (int)Math.Ceiling(learners.Count() / (float)pageSize);
            ViewBag.pageNum = pageNum;
            var result = learners.Take(pageSize).ToList();
            return View(result);
        }

        // Lab5: AJAX filter by MajorID
        public IActionResult LearnerByMajorID(int mid)
        {
            var learners = _context.Learners
                .Where(l => l.MajorId == mid)
                .Include(m => m.Major).ToList();
            return PartialView("LearnerTable", learners);
        }

        // Lab6: Combined filter + search + pagination
        public IActionResult LearnerFilter(int? mid, string? keyword, int? pageIndex)
        {
            var learners = (IQueryable<Learner>)_context.Learners;
            int page = (int)(pageIndex == null || pageIndex <= 0 ? 1 : pageIndex);
            if (mid != null)
            {
                learners = learners.Where(l => l.MajorId == mid);
                ViewBag.mid = mid;
            }
            if (keyword != null)
            {
                learners = learners.Where(l => l.FirstMidName.ToLower()
                            .Contains(keyword.ToLower()));
                ViewBag.keyword = keyword;
            }
            int pageNum = (int)Math.Ceiling(learners.Count() / (float)pageSize);
            ViewBag.pageNum = pageNum;
            var result = learners.Skip(pageSize * (page - 1))
                        .Take(pageSize).Include(m => m.Major);
            return PartialView("LearnerTable", result);
        }

        // GET: Learner/Create
        public IActionResult Create()
        {
            ViewBag.MajorId = new SelectList(_context.Majors, "MajorId", "MajorName");
            return View();
        }

        // POST: Learner/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstMidName,LastName,EnrollmentDate,MajorId")] Learner learner)
        {
            if (ModelState.IsValid)
            {
                _context.Add(learner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.MajorId = new SelectList(_context.Majors, "MajorId", "MajorName", learner.MajorId);
            return View(learner);
        }

        // GET: Learner/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var learner = await _context.Learners.FindAsync(id);
            if (learner == null)
            {
                return NotFound();
            }
            ViewBag.MajorId = new SelectList(_context.Majors, "MajorId", "MajorName", learner.MajorId);
            return View(learner);
        }

        // POST: Learner/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LearnerId,FirstMidName,LastName,EnrollmentDate,MajorId")] Learner learner)
        {
            if (id != learner.LearnerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(learner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Learners.Any(e => e.LearnerId == learner.LearnerId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.MajorId = new SelectList(_context.Majors, "MajorId", "MajorName", learner.MajorId);
            return View(learner);
        }

        // GET: Learner/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var learner = await _context.Learners
                .Include(l => l.Major)
                .FirstOrDefaultAsync(m => m.LearnerId == id);
            if (learner == null)
            {
                return NotFound();
            }

            // Kiểm tra ràng buộc: không xóa nếu đã có ghi danh
            var hasEnrollments = await _context.Enrollments.AnyAsync(e => e.LearnerId == id);
            ViewBag.HasEnrollments = hasEnrollments;

            return View(learner);
        }

        // POST: Learner/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // Kiểm tra ràng buộc trước khi xóa
            var hasEnrollments = await _context.Enrollments.AnyAsync(e => e.LearnerId == id);
            if (hasEnrollments)
            {
                TempData["Error"] = "Không thể xóa sinh viên này vì đã có dữ liệu ghi danh (Enrollment).";
                return RedirectToAction(nameof(Delete), new { id = id });
            }

            var learner = await _context.Learners.FindAsync(id);
            if (learner != null)
            {
                _context.Learners.Remove(learner);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

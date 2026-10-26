using LabDay11.Data;
using LabDay11.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LabDay11.Controllers
{
    public class LearnerController : Controller
    {
        private readonly SchoolContext _context;

        public LearnerController(SchoolContext context)
        {
            _context = context;
        }

        // GET: Learner
        public async Task<IActionResult> Index()
        {
            var learners = _context.Learners.Include(l => l.Major);
            return View(await learners.ToListAsync());
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

using DemoDay7.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoDay7.Controllers
{
    public class VqmMembersController : Controller
    {
        private static List<VqmMember> vqmMembers = new List<VqmMember>(); 
        // GET: VqmMembersController
        public ActionResult Index()
        {
            return View(vqmMembers);
        }

        // GET: VqmMembersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VqmMembersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VqmMembersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VqmMember vqmMember)
        {
            try
            {
                if (!ModelState.IsValid) 
                { 
                    return View(vqmMember);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VqmMembersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VqmMembersController/Edit/5
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

        // GET: VqmMembersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VqmMembersController/Delete/5
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

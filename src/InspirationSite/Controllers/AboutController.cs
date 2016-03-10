using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using InspirationSite.Models;

namespace InspirationSite.Controllers
{
    public class AboutController : Controller
    {
        private AppDbContext _context;

        public AboutController(AppDbContext context)
        {
            _context = context;    
        }

        // GET: About
        [Route("OurTeam")]
        public IActionResult OurTeam()
        {
            return View(_context.PackMember.ToList());
        }

        // GET: About/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            PackMembers packMembers = _context.PackMember.Single(m => m.MemberId == id);
            if (packMembers == null)
            {
                return HttpNotFound();
            }

            return View(packMembers);
        }

        // GET: About/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: About/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PackMembers packMembers)
        {
            if (ModelState.IsValid)
            {
                _context.PackMember.Add(packMembers);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(packMembers);
        }

        // GET: About/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            PackMembers packMembers = _context.PackMember.Single(m => m.MemberId == id);
            if (packMembers == null)
            {
                return HttpNotFound();
            }
            return View(packMembers);
        }

        // POST: About/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PackMembers packMembers)
        {
            if (ModelState.IsValid)
            {
                _context.Update(packMembers);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(packMembers);
        }

        // GET: About/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            //Deletes PackMember Account
            if (ModelState.IsValid)
            {
                PackMembers packMemberToRemove = _context.PackMember.Single(m => m.MemberId == id);
                _context.Remove(packMemberToRemove);
                _context.SaveChanges();
            }

            return RedirectToAction("OurTeam");
        }

        // POST: About/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            PackMembers packMembers = _context.PackMember.Single(m => m.MemberId == id);
            _context.PackMember.Remove(packMembers);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

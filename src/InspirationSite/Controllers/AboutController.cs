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
        [ActionName("Edit")]
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            PackMembers packMember = _context.PackMember.Single(m => m.MemberId == id);

            if (packMember != null)
            {
                return View(packMember);
            }
            return RedirectToAction("OurTeam");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, PackMembers packMember)//[Bind(include:"MemberId,Username,Password,Name,ImageURL,FacebookURL,TwitterURL,Bio")] PackMembers packMember)
        {
            //Edits a PackMembers account based on input from administrator
            var currentPackMember = _context.PackMember.Where(model => model.MemberId.Equals(id)).FirstOrDefault();

            if (ModelState.IsValid)
            {
                currentPackMember.Bio = packMember.Bio;
                _context.SaveChanges();
                return RedirectToAction("OurTeam");
            }
            return RedirectToAction("Index","Home");
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
    }
}

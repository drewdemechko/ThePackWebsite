using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using InspirationSite.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace InspirationSite.Controllers
{
    public class PhotosController : Controller
    {
        private AppDbContext _context;

        public PhotosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        [Route("[Controller]")]
        public IActionResult Album()
        {
            return View(_context.Photos.ToList());
        }
        [HttpGet]
        [Route("[Controller]/{id?}")]
        public IActionResult Photoid(Photos photo)
        {
            return View(photo);
        }

        [Route("[Controller]/AddPhoto")]
        public IActionResult AddPhoto()
        {
            return View();
        }

        [HttpPost]
        [Route("[Controller]/AddPhoto")]
        [ValidateAntiForgeryToken]
        public IActionResult AddPhoto(Photos photo)
        {
            DateTime todaysDate = DateTime.Now;
            todaysDate.ToString("dd MMMM yyyy");

            if (ModelState.IsValid)
            {
                var currentPhoto = _context.Photos.Where(model => model.ImageURL.Equals(photo.ImageURL)).FirstOrDefault();

                if(currentPhoto == null)
                {
                    photo.InAlbum = true;
                    photo.DateAdded = todaysDate; //Add current date of addition
                    _context.Photos.Add(photo);
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("Album");
        }

        [HttpGet]
        public IActionResult DeletePhoto(int? id)
        {
            if(ModelState.IsValid)
            {
                Photos photoToRemove = _context.Photos.Single(m => m.PhotoId == id);
                _context.Remove(photoToRemove);
                _context.SaveChanges();
            }
            return RedirectToAction("Album");
        }
    }
}

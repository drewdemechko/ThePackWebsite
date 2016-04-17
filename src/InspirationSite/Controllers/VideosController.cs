using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using InspirationSite.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace InspirationSite.Controllers
{
    public class VideosController : Controller
    {
        private AppDbContext _context;

        public VideosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        [Route("[Controller]")]
        public IActionResult Vlogs()
        {
            return View(_context.Videos.ToList());
        }

        [Route("[Controller]/AddVideo")]
        public IActionResult AddVideo()
        {
            return View();
        }

        [HttpPost]
        [Route("[Controller]/AddVideo")]
        [ValidateAntiForgeryToken]
        public IActionResult AddVideo(Videos video)
        {
            DateTime todaysDate = DateTime.Now;

            if (ModelState.IsValid)
            {
                //prevent duplicates
                var currentVideo = _context.Videos.Where(model => model.VideoURL.Equals(video.VideoURL)).FirstOrDefault();

                if(currentVideo == null)
                {
                    video.DateAdded = todaysDate;

                    var url = video.VideoURL.Split('=');
                    video.VideoURL = url[1];
                    _context.Videos.Add(video);
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("Vlogs");
        }

        [HttpGet]
        public IActionResult DeleteVideo(int? id)
        {
            if (ModelState.IsValid)
            {
                Videos videoToRemove = _context.Videos.Single(m => m.VideoId == id);
                _context.Remove(videoToRemove);
                _context.SaveChanges();
            }
            return RedirectToAction("Vlogs");
        }
    }
}

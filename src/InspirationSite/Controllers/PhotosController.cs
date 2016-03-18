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
        // GET: /<controller>/
        [Route("[Controller]")]
        public IActionResult Album()
        {
            return View();
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
            return RedirectToAction("Album");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace InspirationSite.Controllers
{
    public class BlogController : Controller
    {
        public static String encodeBlog(string content)
        {
            return content;
        }

        public static String decodeBlog(string content)
        {
            return content;
        }

        // GET: /<controller>/
        [Route("Blog")]
        public IActionResult Entries()
        {
            return View();
        }

        [HttpGet]
        [Route("[Controller]/{id?}/")]
        public IActionResult Blogid(int? id)
        {
            return View();
        }

        // GET: About/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            return View();
        }
    }
}

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
        // GET: /<controller>/
        [Route("Blog")]
        public IActionResult Entries()
        {
            return View();
        }

        [Route("[Controller]/{id?}/")]
        public IActionResult Blogid()
        {
            return View();
        }
    }
}

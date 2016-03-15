using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using InspirationSite.BusinessLogic;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace InspirationSite.Controllers
{
    public class ContactController : Controller
    {
        // GET: /<controller>/
        [Route("[Controller]")]
        [HttpGet]
        public IActionResult ContactUs()
        {
            MailHelper newMail = new MailHelper("drew.a.demechko@gmail.com", "drew.a.demechko@gmail.com", "TestSubject", "TestBody");
            newMail.Send();
            return View();
        }

   /*     [HttpPost]
        public IActionResult ContactUs()
        {
            MailHelper newMail = new MailHelper("drew.a.demechko@gmail.com", "drew.a.demechko@gmail.com", "TestSubject", "TestBody");
            newMail.Send();
            return View();
        }*/
    }
}

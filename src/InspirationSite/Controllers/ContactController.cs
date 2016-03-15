using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using InspirationSite.BusinessLogic;
using InspirationSite.Models;

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
            return View();
        }

        [Route("[Controller]")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ContactUs(ContactMessage model)
        {
            MailHelper newMail = new MailHelper("drew.a.demechko@gmail.com", "drew.a.demechko@gmail.com", 
                model.Subject, model.Message, model.FullName, model.PhoneNumber, model.EmailAddress);
            newMail.Send();
            return View();
        }
    }
}

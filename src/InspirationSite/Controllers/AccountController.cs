using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Http.Internal;
using InspirationSite.Models;
using Microsoft.AspNet.Http;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace InspirationSite.Controllers
{
    public class AccountController : Controller
    {
        private AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        [Route("Login")]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [Route("Login")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(PackMembers packMember)
        {
            if(ModelState.IsValid)
            {
                    var validate = _context.PackMembers.Where(model => model.Username.Equals(packMember.Username) &&
                                    model.Password.Equals(packMember.Password)).FirstOrDefault();

                    if (validate != null)
                    {
                        HttpContext.Session.SetString("Username", validate.Username.ToString());
                        return RedirectToAction("Login");
                        //HttpContext.Session.SetString("Authority", validate.Authority.ToString()); 
                            //Stores authority level of user account
                    }
            }
            return View("Register");
        }

        [Route("Account/Register")]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(string username, string password, string name, string imageUrl,
            string facebookUrl, string twitterUrl, string bio)
        {

            if (ModelState.IsValid)
            {
                _context.PackMembers.Add(new PackMembers { Name = username, Password = "test" });
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();

            //return View(user);
            //return Content("worked");
        }
    }
}

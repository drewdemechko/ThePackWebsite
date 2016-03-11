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
                    //Checks for valid login information
                    var validated = _context.PackMember.Where(model => model.Username.Equals(packMember.Username) &&
                                    model.Password.Equals(packMember.Password)).FirstOrDefault();

                    if (validated != null)
                    {
                        HttpContext.Session.SetString("Username", validated.Username.ToString());
                        return RedirectToAction("Index","Home");
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

        [Route("Account/Register")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(PackMembers packMember)
        {

            if (ModelState.IsValid)
            {
                var currentPackMember = _context.PackMember.Where(model => model.Username.Equals(packMember.Username)).FirstOrDefault();

                //If current PackMember username does not currently exist
                if (currentPackMember == null)
                {
                    _context.PackMember.Add(packMember);
                    _context.SaveChanges();
                    return RedirectToAction("Login");
                }
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.SetString("Username", "");
            return RedirectToAction("Index","Home");
        }
    }
}

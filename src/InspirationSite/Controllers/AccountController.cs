using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace InspirationSite.Controllers
{
    public class AccountController : Controller
    {
        // GET: /<controller>/
        [Route("Login")]
        public IActionResult Login()
        {
            return View();
        }
        [Route("Account/Register")]
        public IActionResult Register()
        {
            return View();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using InspirationSite.Models;
using Microsoft.AspNet.Http;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace InspirationSite.Controllers
{
    public class BlogController : Controller
    {
        private AppDbContext _context;

        public BlogController(AppDbContext context)
        {
            _context = context;
        }

        public static String encodeBlog(string content)
        {
            return content;
        }

        public static String decodeBlog(string content)
        {
            return content;
        }

        // GET: /<controller>/
        [Route("[Controller]")]
        public IActionResult Entries()
        {
            return View(_context.BlogPosts.ToList());
        }

        [HttpGet]
        [Route("[Controller]/{id?}/")]
        public IActionResult Blogid(int? id)
        {
            return View();
        }

        [Route("[Controller]/New")]
        [HttpGet]
        public IActionResult AddBlogPost()
        {
            return View();
        }

        [Route("[Controller]/New")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddBlogPost(BlogPosts newPost)
        {
            DateTime todaysDate = DateTime.Now;

            if (ModelState.IsValid)
            {
                //prevent duplicates
                var currentVideo = _context.BlogPosts.Where(model => model.Content.Equals(newPost.Content)).FirstOrDefault();

                if(currentVideo == null)
                {
                    newPost.PostDate = todaysDate;

                    //Check for logged in user and set as author
                    foreach(PackMembers currentMember in _context.PackMember)
                    {
                        if (currentMember.Username == HttpContext.Session.GetString("Username"))
                            newPost.Author = currentMember;
                    }

                    _context.BlogPosts.Add(newPost);
                    _context.SaveChanges();   
                }
            }
            return RedirectToAction("Entries");
        }
        // GET: About/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (ModelState.IsValid)
            {
                BlogPosts blogEntryToRemove = _context.BlogPosts.Single(m => m.BlogPostId == id);
                _context.Remove(blogEntryToRemove);
                _context.SaveChanges();
            }
            return RedirectToAction("Entries");
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            return View();
        }
    }
}

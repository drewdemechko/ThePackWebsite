using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InspirationSite.Models
{
    public class BlogPosts
    {
        [Key]
        public int BlogPostId { get; set; }
        //Author of blog post
        public virtual PackMembers Author { get; set; }
        //public String ImageURL { get; set; } for images
        public String Title { get; set; }
        public String Content { get; set; }
        //public String[] Tags { get; set; } for SEO optimization
        public DateTime PostDate { get; set; }
    }
}

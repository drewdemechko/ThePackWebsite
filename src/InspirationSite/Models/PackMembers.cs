using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InspirationSite.Models
{
    public class PackMembers
    {
      //  public PackMembers()
      //  {
      //      BlogPosts = new List<BlogPosts>();
      //  }

        [Key]
        public int MemberId { get; set; }
        public String ImageURL { get; set; }
        public String Name { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public String Bio { get; set; }
        public String FacebookURL { get; set; }
        public String TwitterURL { get; set; }
        public virtual ICollection<BlogPosts> BlogPosts { get; set; }
        public virtual ICollection<Photos> Photos { get; set; }
    }
}

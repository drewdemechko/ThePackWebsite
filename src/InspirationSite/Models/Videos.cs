using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InspirationSite.Models
{
    public class Videos
    {
        [Key]
        public int VideoId { get; set; }
        public String Title { get; set; }
        public String VideoURL { get; set; }
        public DateTime DateAdded { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InspirationSite.Models
{
    public class Photos
    {
        [Key]
        public int PhotoId { get; set; }
        //Stores image as bytes
        public PackMembers PhotoOf { get; set; }
        public String ImageURL { get; set; }
        public bool InAlbum { get; set; }
        public DateTime DateAdded { get; set; }
    }
}

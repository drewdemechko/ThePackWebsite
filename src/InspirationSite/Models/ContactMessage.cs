using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Do not store data in database
namespace InspirationSite.Models
{
    public class ContactMessage
    {
        public String FullName { get; set; }
        public String PhoneNumber { get; set; }
        public String EmailAddress { get; set; }
        public String Subject { get; set; }
        public String Message { get; set; }
    }
}

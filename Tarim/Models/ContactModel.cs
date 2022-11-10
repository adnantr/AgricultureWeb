using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tarim.Models
{
    public class ContactModel
    {
        public int ContactId { get; set; }
        public string ContactName { get; set; }
        public string ContactMail { get; set; }
        public string ContactMessage { get; set; }
        public DateTime ContactDate { get; set; }
    }
}

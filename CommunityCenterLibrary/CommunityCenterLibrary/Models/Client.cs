using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityCenterLibrary.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CommunityCenterLibrary.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public DateTime Date { get; set; }


    }
    public class BookDBContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
    }
}
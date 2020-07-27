using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryBookLending.Models
{
    public class Book
    {
        public Int32 BookId { get; set; }
        public string Title { get; set; }
        public string Isbn { get; set; }
        public DateTime DateOfPublication { get; set; }
      //  "bookId": 1,
      //"title": "Effective Java",
      //"isbn": "978-0134685991",
      //"dateOfPublication": "2000-01-01T00:00:00"
    }
}
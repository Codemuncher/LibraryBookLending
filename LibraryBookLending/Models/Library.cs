using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryBookLending.Models
{
    public class Library
    {
        public Int32 LibraryId {get;set;}
        public string Name { get; set; }
        public string City { get; set; }

    }
}
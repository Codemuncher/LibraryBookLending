using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryBookLending.Models
{
    public class LibraryBook
    {
        public Int32 LibararyId { get; set; }
        public Int32 TotalPurchasedByLibrary { get; set; }
        public Book Book { get; set; }

    }
}
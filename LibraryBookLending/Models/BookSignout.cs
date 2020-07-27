using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryBookLending.Models
{
    public class BookSignout
    {
        public Int32 LibraryBookSid { get; set; }
        public Int32 MemberId { get; set; }
        public DateTime WhenSignedOut { get; set; }
        public DateTime? WhenReturned { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace u20548312_HW03.Models
{
    public class BorrowVM
    {
        public string name { get; set; }
        public Nullable<System.DateTime> takenDate { get; set; }
        public Nullable<System.DateTime> broughtDate { get; set; }
    }
}
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList.EntityFramework;
using System.Data.Entity;

namespace u20548312_HW03.Models
{
    public class StudentBookVM
    {
        public string name { get; set; }
        public string surname { get; set; }
        public Nullable<System.DateTime> birthdate { get; set; }
        public string gender { get; set; }
        public string tclass { get; set; }
        public Nullable<int> point { get; set; }
        public string Bname { get; set; }
        public Nullable<int> pagecount { get; set; }
        public Nullable<int> Bpoint { get; set; }

        public Nullable<System.DateTime> takenDate { get; set; }
        public Nullable<System.DateTime> broughtDate { get; set; }

        public string Status { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace u20548312_HW03.Models
{
    public class HVM
    {
        public IPagedList<StudentBookVM> Students { get; set; }
        public IPagedList<StudentBookVM> Books { get; set; }
    }
}
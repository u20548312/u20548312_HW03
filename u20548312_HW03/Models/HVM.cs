using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using PagedList.EntityFramework;
using System.Data.Entity;

namespace u20548312_HW03.Models
{
    public class HVM
    {
        public IPagedList<StudentVM> Students { get; set; }
        public IPagedList<BookVM> Books { get; set; }
    }
}
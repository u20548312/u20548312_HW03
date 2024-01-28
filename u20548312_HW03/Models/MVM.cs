using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using PagedList.EntityFramework;
using System.Data.Entity;

namespace u20548312_HW03.Models
{
    public class MVM
    {
        public IPagedList<AuthorVM> Authors { get; set; }
        public IPagedList<TypeVm> Types { get; set; }
        public IPagedList<BorrowVM> Borrows { get; set; }
    }
}
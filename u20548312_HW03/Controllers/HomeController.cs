using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using u20548312_HW03.Models;
using System.Threading.Tasks;
using System.Data.Entity; //installed nuget package
using PagedList;

namespace u20548312_HW03.Controllers
{
    public class HomeController : Controller
    {
        int NoElPage = 20;
        private LibraryEntities db = new LibraryEntities();
        public ActionResult Index(int? pageIndex)
        {
            var StudBook = (from b in db.books
                            join br in db.borrows
                            on b.bookId equals br.bookId
                            join s in db.students
                            on br.studentId equals s.studentId
                            select new StudentBookVM
                            {
                                name = s.name,
                                surname = s.surname,
                                birthdate = s.birthdate,
                                gender = s.gender,
                                tclass = s.@class,
                                point = (int)s.point,
                                Bname = b.name,
                                pagecount = (int)b.pagecount,
                                Bpoint = (int)b.point,
                                takenDate = br.takenDate,
                                broughtDate = br.broughtDate
                            }).ToList();

            int page = (pageIndex ?? 1);
            var pStuBo = StudBook.ToPagedList(page, NoElPage);
            return View(pStuBo);
        }

        public ActionResult Maintain(int? pageIndex)
        {
            int El = 8;
            var AutTyBor = (from br in db.borrows
                            join b in db.books
                            on br.bookId equals b.bookId
                            join t in db.types
                            on b.typeId equals t.typeId
                            join a in db.authors
                            on b.authorId equals a.authorId
                            select new AuthorTypeBorrowVM
                            {
                                name = a.name,
                                surname = a.surname,
                                Tname = t.name,
                                takenDate = br.takenDate,
                                broughtDate = br.broughtDate
                            }).ToList();

            int page = (pageIndex ?? 1);
            var pStuBo = AutTyBor.ToPagedList(page, El);
            return View(pStuBo);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
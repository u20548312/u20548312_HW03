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
        int NoElPage = 10;
        private LibraryEntities db = new LibraryEntities();
        public ActionResult Index(int? pageIndex, int? pageIndex2)
        {
            var Stud = (from s in db.students
                            select new StudentVM
                            {
                                name = s.name,
                                surname = s.surname,
                                birthdate = s.birthdate,
                                gender = s.gender,
                                tclass = s.@class,
                                point = (int)s.point
                            }).ToList();

            var Book = (from b in db.books
                            join br in db.borrows
                            on b.bookId equals br.bookId
                       select new BookVM
                       {
                           Bname = b.name,
                           pagecount = (int)b.pagecount,
                           Bpoint = (int)b.point,
                           takenDate = br.takenDate,
                           broughtDate = br.broughtDate
                       }).ToList();

            int page = (pageIndex ?? 1);
            int page2 = (pageIndex2 ?? 1);

            var pStud = Stud.ToPagedList(page, NoElPage);
            var pBook = Book.ToPagedList(page2, NoElPage);

            var Index = new HVM
            {
                Students = pStud,
                Books = pBook
            };

           
            return View(Index);
        }

        [HttpPost]
        public ActionResult CreateBook(BookVM model)
        {
            if (ModelState.IsValid)
            {
                // Create a new Book entity and map data from the ViewModel
                var book = new book
                {
                    name = model.Bname,
                    pagecount = model.pagecount,
                    point = model.Bpoint
                };

                // Add the book to the DbContext and save changes
                db.books.Add(book);
                db.SaveChanges();

                // Redirect to a view or action after successful creation
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult CreateStudent(StudentVM model)
        {
            if (ModelState.IsValid)
            {
                // Create a new Student entity and map data from the ViewModel
                var stud = new student
                {
                    name = model.name,
                    surname = model.surname,
                    birthdate = model.birthdate,
                    gender = model.gender,
                    @class = model.tclass,
                    point = model.point
                };

                // Add the student  to the DbContext and save changes
                db.students.Add(stud);
                db.SaveChanges();

                // Redirect to a view or action after successful creation
                return RedirectToAction("Index");
            }

            return View(model);
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

        public ActionResult Report()
        {
            var StudBook = (from b in db.books
                            join br in db.borrows
                            on b.bookId equals br.bookId
                            join s in db.students
                            on br.studentId equals s.studentId
                            select new StudentVM
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
            return View(StudBook);
        }
    }
}
using System.IO;
using System.Web;
using System.Web.Mvc;
using u20548312_HW03.Models;

namespace u20548312_HW03.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase Files)
        {
           if(Files != null && Files.ContentLength>0)
            {
              var Fname = Path.GetFileName(Files.FileName);

              var path = Path.Combine(Server.MapPath("~/App_Data/Uploaded Files"), Fname);

              Files.SaveAs(path);
            }
           

            return RedirectToAction("AboutMe");
        }

        public ActionResult AboutMe()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
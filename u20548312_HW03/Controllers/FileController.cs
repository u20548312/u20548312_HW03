using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using u20548312_HW03.Models;


namespace u20548312_HW03.Controllers
{
    public class FileController : Controller
    {
        // GET: File
        public ActionResult Index()
        {
            string[] filePaths = Directory.GetFiles(Server.MapPath("~/App_Data/Uploaded Files"));

            List<FileModel> files = new List<FileModel>();

            foreach(string filePath in filePaths)
            {
                files.Add(new FileModel { FileName = Path.GetFileName(filePath) });
            }

            return View(files);
        }
        public FileResult DownloadFile(string fileName) 
        {
            
            string path = Server.MapPath("~/App_Data/Uploaded Files/") + fileName;


            byte[] bytes = System.IO.File.ReadAllBytes(path);

            return File(bytes, "application/octet-stream", fileName);
        }

        public ActionResult DeleteFile(string fileName)
        {
           string path = Server.MapPath("~/App_Data/Uploaded Files/") + fileName;
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            System.IO.File.Delete(path);

            return RedirectToAction("Index");
        }
    }
}
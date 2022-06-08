using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using u20548312_HW03.Models;

namespace u20548312_HW03.Controllers
{
    public class VideoController : Controller
    {
        // GET: Video
        public ActionResult Index()
        {
            string[] filePaths = Directory.GetFiles(Server.MapPath("~/App_Data/Uploaded Files"));



            List<FileModel> files = new List<FileModel>();

            foreach (string filePath in filePaths)
            {
                if (filePath.EndsWith(".MP4"))
                {
                    files.Add(new FileModel { FileName = Path.GetFileName(filePath) });
                }
                if (filePath.EndsWith(".AVI"))
                {
                    files.Add(new FileModel { FileName = Path.GetFileName(filePath) });
                }
                if (filePath.EndsWith(".WEBM"))
                {
                    files.Add(new FileModel { FileName = Path.GetFileName(filePath) });
                }

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
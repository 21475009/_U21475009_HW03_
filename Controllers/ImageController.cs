using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _U21475009_HW03_.Models;
using System.IO;

namespace _U21475009_HW03_.Controllers
{
    public class ImageController : Controller
    {
        // GET: Image
        public ActionResult Index()
        {

            string[] filePaths = Directory.GetFiles(Server.MapPath("~/App_Data/Media/Images"));

            List<FileModel> files = new List<FileModel>();

            foreach (string filePath in filePaths)
            {
                files.Add(new FileModel { FileName = Path.GetFileName(filePath) });
            }

            return View(files);

        }

        public FileResult DownloadFile(string fileName)
        {

            // the path used
            string path = Server.MapPath("~/App_Data/Uploads/Images/") + fileName;

            //Byte array
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            //Download file
            return File(bytes, "application/octet-stream", fileName);

        }
    }
}
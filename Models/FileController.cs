using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace _U21475009_HW03_.Models
{
    public class FileController : Controller
    {
        // GET: File
        public ActionResult Index()
        {
            string[] filePaths = Directory.GetFiles(Server.MapPath("~/App_Data/Media"));

            List<FileModel> files = new List<FileModel>();

            foreach(string filePath in filePaths)
            {
                files.Add(new FileModel { FileName = Path.GetFileName(filePath) });
            }
            
            return View(files);
        }

        public FileResult DownloadFile(string fileName)
        {

            // the path used
            string path = Server.MapPath("~/App_Data/Media/") + fileName;

            //Byte array
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            //Download file
            return File(bytes, "application/octet-stream", fileName);

        }
    }
}
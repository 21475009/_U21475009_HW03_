using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace _U21475009_HW03_.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Index(HttpPostedFileBase files)
        {
            if (files != null && files.ContentLength > 0)
            {
                var fileName = Path.GetFileName(files.FileName);
                var path = Path.Combine(Server.MapPath("~/App_Data/Media/"), fileName);
                files.SaveAs(path);
            }


            return RedirectToAction("Index");
        }

        public ActionResult Index(string FileType, HttpPostedFileBase files)
        {
            if (files != null && files.ContentLength > 0)
            {
                string extension = Path.GetExtension(files.FileName);

                if (FileType == "Document")
                {
                    files.SaveAs(Path.Combine(HttpContext.Server.MapPath("~App_Data/Media/Documents/"), Path.GetFileName(files.FileName)));
                    ViewBag.Message = "Upload was successful";
                }

                else if (FileType == "Image")
                {
                    files.SaveAs(Path.Combine(HttpContext.Server.MapPath("~App_Data/Media/Images/"), Path.GetFileName(files.FileName)));
                    ViewBag.Message = "Upload was successful";
                }

                else if (FileType == "Video")
                {
                    files.SaveAs(Path.Combine(HttpContext.Server.MapPath("~App_Data/Media/Videos/"), Path.GetFileName(files.FileName)));
                    ViewBag.Message = "Upload was successful";
                }


            }
            return RedirectToAction("Index");


        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }







    }
}
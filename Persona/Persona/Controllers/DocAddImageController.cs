using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Persona.Controllers
{
    public class DocAddImageController : Controller
    {
        // GET: DocAddImage
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Upload()
        {
            var httpRequest = Request;
            var serverPath = Server.MapPath("~/img/");
            string postedFilePath = null;
            //upload image to wherever we're uploading images to
            try
            {
                foreach (string file in httpRequest.Files)
                {
                    HttpPostedFileBase postedFile = httpRequest.Files[file];

                    postedFilePath = postedFile.FileName;

                    postedFile.SaveAs(serverPath + postedFilePath);
                }
            }
            catch (Exception ex)
            {
            }

            string imagePath = String.Format("http://{0}{1}{2}", Request.Url.Host, "/img/", postedFilePath);
            //calls third-party api

            return View("/Views/Doc/Verification.cshtml", new { imagePath = imagePath });
        }
    }
    
}
using Lab.Management.Utils.QrCode;
using System;
using System.Web.Mvc;

namespace LabManagement.System.Controllers
{
    public class WebCamController : Controller
    {
        private string urlPath
        {
            get
            {
                if (string.IsNullOrEmpty(_urlPath) && Request != null)
                {
                    _urlPath = $"{Request.Url.AbsoluteUri}/QrCodePath/";
                }
                return _urlPath;
            }
        }

        private string _urlPath;

        [HttpGet]
        public ActionResult Index()
        {
            Session["val"] = "";
            return View();
        }

        [HttpPost]
        public ActionResult Index(string Imagename)
        {
            ViewBag.pic = $"{urlPath}{Convert.ToString(Session["val"])}";
            return View();
        }

        [HttpGet]
        public ActionResult ChangePhoto()
        {
            if (Convert.ToString(Session["val"]) != string.Empty)
            {
                ViewBag.pic = $"{urlPath}{Convert.ToString(Session["val"])}";
            }
            else
            {
                ViewBag.pic = "../../QrCodePath/person.jpg";
            }
            return View();
        }

        public JsonResult Rebind()
        {
            string path = $"{urlPath}{Convert.ToString(Session["val"])}";
            return Json(path, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Capture()
        {
            var stream = Request.InputStream;
            var folderPath = Server.MapPath("~/QrCodePath");
            string date = DateTime.Now.ToString("yyyymmddMMss");
            folderPath = $"{folderPath}/{date}test.jpg";
            var qrCam = new QrScannerWebCam();
            qrCam.ReadFromStream(stream, folderPath);
            ViewData["path"] = date + "test.jpg";
            Session["val"] = date + "test.jpg";
            return View("Index");
        }
    }
}

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
        public ActionResult Index(string scannerType = "")
        {
            Session["QrCodeFile"] = "";
            ViewBag.ScannerType = scannerType;
            return View();
        }

        [HttpPost]
        public ActionResult IndexPost(string Imagename)
        {
            ViewBag.pic = $"{urlPath}{Convert.ToString(Session["QrCodeFile"])}";
            return View();
        }

        [HttpGet]
        public ActionResult ChangePhoto()
        {
            if (Convert.ToString(Session["QrCodeFile"]) != string.Empty)
            {
                ViewBag.pic = $"{urlPath}{Convert.ToString(Session["QrCodeFile"])}";
            }
            else
            {
                ViewBag.pic = "../../QrCodePath/person.jpg";
            }
            return View();
        }

        public JsonResult Rebind()
        {
            string path = Convert.ToString(Session["QrCodeFile"]);
            return Json(path, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Capture()
        {
            var stream = Request.InputStream;
            var folderPath = Server.MapPath("~/QrCodePath");
            folderPath.DeletingQrCodeFiles();
            string fileName = $"{DateTime.Now.ToString("yyyymmddMMss")}-hpmsQrCode.jpg";
            folderPath = $"{folderPath}/{fileName}";
            var qrCam = new QrScannerWebCam();
            qrCam.ReadFromStream(stream, folderPath);
            Session["QrCodeFile"] = fileName;
            return View("Index");
        }
    }
}

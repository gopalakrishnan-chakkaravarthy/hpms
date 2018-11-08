using Lab.Management.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab.Management.Entities;
using System.IO;
using Lab.Management.Common;
using Lab.Management.Engine.Utils;
namespace LabManagement.System.Controllers
{
    public class HopitalMasterController : Controller
    {
        private readonly IHospitalMaster _objIHospitalMaster;
        public HopitalMasterController(IHospitalMaster objIHospitalMaster)
        {
            _objIHospitalMaster = objIHospitalMaster;
        }
        public ActionResult ViewDrug(int DrugId, string viewMessage = "")
        {
            var getDrug = _objIHospitalMaster.GetDrugDetailsById(DrugId);
            ViewBag.Message = viewMessage;
            return View(getDrug);
        }
        public ActionResult ViewAllDrug(string viewMessage = "")
        {
            var getAll = _objIHospitalMaster.GetAllDrug();
            ViewBag.Message = viewMessage;
            return View(getAll);
        }
        [HttpPost]
        public ActionResult EditDrug(lmsDrug objDrugMaster)
        {

            objDrugMaster.MANUFACTUREDATE = Request["MANUFACTUREDATE"] == null ? DateTime.Now : Request["MANUFACTUREDATE"].ToLmsSystemDate();
            objDrugMaster.EXPIRYDATE = Request["EXPIRYDATE"] == null ? DateTime.Now : Request["MANUFACTUREDATE"].ToLmsSystemDate();

            /*  objDrugMaster.MANUFACTUREDATE = Convert.ToDateTime(Request["MANUFACTUREDATE"]);
              objDrugMaster.EXPIRYDATE = Convert.ToDateTime(Request["EXPIRYDATE"]);
             * */
            var saveDrugDetails = _objIHospitalMaster.SaveDrug(objDrugMaster);
            //ViewBag.Message = viewMessage;
            return RedirectToAction("ViewDrug", new { DrugId = saveDrugDetails, viewMessage = "Drug Details Saved Successfully" });
        }

        public ActionResult DeleteDrug(int DrugId)
        {
            var deletDrug = _objIHospitalMaster.DeleteDrug(DrugId);
            return RedirectToAction("ViewAllDrug", new { viewMessage = "Drug Detail Deleted Successfully" });
        }
        public ActionResult ViewMedicalTest(int MedicalTestId, string viewMessage = "")
        {
            var getMedicalTest = _objIHospitalMaster.GetMedicalTestDetailsById(MedicalTestId);
            ViewBag.Message = viewMessage;
            return View(getMedicalTest);
        }
        public ActionResult ViewAllMedicalTest(string viewMessage = "")
        {
            var getAll = _objIHospitalMaster.GetAllMedicalTest();
            ViewBag.Message = viewMessage;
            return View(getAll);
        }
        [HttpPost]
        public ActionResult EditMedicalTest(lmsMedicalTest objMedicalTestMaster)
        {
            var saveMedicalTestDetails = _objIHospitalMaster.SaveMedicalTest(objMedicalTestMaster);
            //ViewBag.Message = viewMessage;
            return RedirectToAction("ViewMedicalTest", new { MedicalTestId = saveMedicalTestDetails, viewMessage = "MedicalTest Details Saved Successfully" });
        }

        public ActionResult DeleteMedicalTest(int MedicalTestId)
        {
            var deletMedicalTest = _objIHospitalMaster.DeleteMedicalTest(MedicalTestId);
            return RedirectToAction("ViewAllMedicalTest", new { viewMessage = "MedicalTest Detail Deleted Successfully" });
        }
        public ActionResult ViewScan(int ScanId, string viewMessage = "")
        {
            var getScan = _objIHospitalMaster.GetScanDetailsById(ScanId);
            ViewBag.Message = viewMessage;
            return View(getScan);
        }
        public ActionResult ViewAllScan(string viewMessage = "")
        {
            var getAll = _objIHospitalMaster.GetAllScan();
            ViewBag.Message = viewMessage;
            return View(getAll);
        }
        [HttpPost]
        public ActionResult EditScan(lmsScan objScanMaster)
        {
            var saveScanDetails = _objIHospitalMaster.SaveScan(objScanMaster);
            //ViewBag.Message = viewMessage;
            return RedirectToAction("ViewScan", new { ScanId = saveScanDetails, viewMessage = "Scan Details Saved Successfully" });
        }

        public ActionResult DeleteScan(int ScanId)
        {
            var deletScan = _objIHospitalMaster.DeleteScan(ScanId);
            return RedirectToAction("ViewAllScan", new { viewMessage = "Scan Detail Deleted Successfully" });
        }
        public ActionResult ViewFileDownload(string downloadfor)
        {
            ViewBag.DownloadFor = downloadfor;
            var getFileLis = _objIHospitalMaster.GetFiles(downloadfor);
            return View(getFileLis);
        }
        public FileResult Download(string FileID, string downloadfor = "")
        {
            int CurrentFileID = Convert.ToInt32(FileID);
            var filesCol = _objIHospitalMaster.GetFiles(downloadfor);
            string CurrentFileName = (from fls in filesCol
                                      where fls.FileId == CurrentFileID
                                      select fls.FilePath).First();

            string contentType = string.Empty;

            if (CurrentFileName.Contains(".pdf"))
            {
                contentType = "application/pdf";
            }

            else if (CurrentFileName.Contains(".docx"))
            {
                contentType = "application/docx";
            }
            return File(CurrentFileName, contentType, CurrentFileName);
        }

        public ActionResult UploadFile(string message = "")
        {
            ViewBag.message = message;
            return View();
        }
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase uploadFile)
        {
            var uploadFor = Convert.ToString(Request["uploadfor"]);
            var filePath = uploadFor.ToUpper() == "TEMPLATE" ? ConfigurationWrapper.StringSettings(ConfigKey.TemplateUploadPath) : ConfigurationWrapper.StringSettings(ConfigKey.PatientUploadPath);

            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];

                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var fullFilePath = Path.Combine(filePath, fileName);
                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    file.SaveAs(fullFilePath);
                }
            }

            return RedirectToAction("UploadFile", new { message = "Uploaded" });
        }
        public ActionResult ViewVendor(int VendorId, string viewMessage = "")
        {
            var getVendor = _objIHospitalMaster.GetVendorDetailsById(VendorId);
            ViewBag.Message = viewMessage;
            return View(getVendor);
        }
        public ActionResult ViewAllVendor(string viewMessage = "")
        {
            var getAll = _objIHospitalMaster.GetAllVendor();
            ViewBag.Message = viewMessage;
            return View(getAll);
        }
        [HttpPost]
        public ActionResult EditVendor(lmsVendor objVendorMaster)
        {

            var saveVendorDetails = _objIHospitalMaster.SaveVendor(objVendorMaster);
            //ViewBag.Message = viewMessage;
            return RedirectToAction("ViewVendor", new { VendorId = saveVendorDetails, viewMessage = "Vendor Details Saved Successfully" });
        }

        public ActionResult DeleteVendor(int VendorId)
        {
            var deletVendor = _objIHospitalMaster.DeleteVendor(VendorId);
            return RedirectToAction("ViewAllVendor", new { viewMessage = "Vendor Detail Deleted Successfully" });
        }
        public ActionResult ViewInventory(int InventoryId, string viewMessage = "")
        {
            var VendorList = _objIHospitalMaster.GetAllVendor();
            var getInventory = _objIHospitalMaster.GetInventoryDetailsById(InventoryId);
            getInventory.VendorDdl = new SelectList(VendorList, "VENDORID", "VENDORNAME");
            if (InventoryId > 0 && getInventory.VENDORID.HasValue)
            {
                getInventory.SelectedVendor = getInventory.VENDORID.Value;
            }
            ViewBag.Message = viewMessage;
            return View(getInventory);
        }
        public ActionResult ViewAllInventory(string viewMessage = "")
        {
            var getAll = _objIHospitalMaster.GetAllInventory();
            ViewBag.Message = viewMessage;
            return View(getAll);
        }
        [HttpPost]
        public ActionResult EditInventory(lmsInventory objInventoryMaster)
        {

            objInventoryMaster.VENDORID = objInventoryMaster.SelectedVendor;
            var saveInventoryDetails = _objIHospitalMaster.SaveInventory(objInventoryMaster);
            //ViewBag.Message = viewMessage;
            return RedirectToAction("ViewInventory", new { InventoryId = saveInventoryDetails, viewMessage = "Inventory Details Saved Successfully" });
        }

        public ActionResult DeleteInventory(int InventoryId)
        {
            var deletInventory = _objIHospitalMaster.DeleteInventory(InventoryId);
            return RedirectToAction("ViewAllInventory", new { viewMessage = "Inventory Detail Deleted Successfully" });
        }
        public ActionResult ViewBed(int BedId, string viewMessage = "")
        {

            var getBed = _objIHospitalMaster.GetBedDetailsById(BedId);
            ViewBag.Message = viewMessage;
            return View(getBed);
        }
        public ActionResult ViewAllBed(string viewMessage = "")
        {
            var getAll = _objIHospitalMaster.GetAllBed();
            ViewBag.Message = viewMessage;
            return View(getAll);
        }
        [HttpPost]
        public ActionResult EditBed(lmsBed objBedMaster)
        {
            var saveBedDetails = _objIHospitalMaster.SaveBed(objBedMaster);
            //ViewBag.Message = viewMessage;
            return RedirectToAction("ViewBed", new { BedId = saveBedDetails, viewMessage = "Bed Details Saved Successfully" });
        }

        public ActionResult DeleteBed(int BedId)
        {
            var deletBed = _objIHospitalMaster.DeleteBed(BedId);
            return RedirectToAction("ViewAllBed", new { viewMessage = "Bed Detail Deleted Successfully" });
        }
        public ActionResult ViewWard(int WardId, string viewMessage = "")
        {
            var BedList = _objIHospitalMaster.GetAllBed();
            var getWard = _objIHospitalMaster.GetWardDetailsById(WardId);
            getWard.BedDdl = new SelectList(BedList, "BEDID", "BEDNAME");
            if (WardId > 0 && getWard.BEDID.HasValue)
            {
                getWard.SelectedBed = getWard.BEDID.Value;
            }
            ViewBag.Message = viewMessage;
            return View(getWard);
        }
        public ActionResult ViewAllWard(string viewMessage = "")
        {
            var getAll = _objIHospitalMaster.GetAllWard();
            ViewBag.Message = viewMessage;
            return View(getAll);
        }
        [HttpPost]
        public ActionResult EditWard(lmsWard objWardMaster)
        {
            objWardMaster.BEDID = objWardMaster.SelectedBed;
            var saveWardDetails = _objIHospitalMaster.SaveWard(objWardMaster);
            //ViewBag.Message = viewMessage;
            return RedirectToAction("ViewWard", new { WardId = saveWardDetails, viewMessage = "Ward Details Saved Successfully" });
        }

        public ActionResult DeleteWard(int WardId)
        {
            var deletWard = _objIHospitalMaster.DeleteWard(WardId);
            return RedirectToAction("ViewAllWard", new { viewMessage = "Ward Detail Deleted Successfully" });
        }
    }
}

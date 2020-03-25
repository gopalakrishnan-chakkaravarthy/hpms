using Lab.Management.Common;
using Lab.Management.Engine.Service;
using Lab.Management.Entities;
using Lab.Management.Utils.QrCode;
using LabManagement.System.Enums;
using System;
using System.Web.Mvc;

namespace LabManagement.System.Controllers
{
    public class DrugsController : Controller
    {
        private readonly IHospitalMaster _objIHospitalMaster;
        public DrugsController(IHospitalMaster objIHospitalMaster)
        {
            _objIHospitalMaster = objIHospitalMaster;
        }

        public ActionResult ViewDrug(int DrugId, string transactionType)
        {
            var getDrug = _objIHospitalMaster.GetDrugDetailsById(DrugId);
            getDrug.OLDORDERCOUNT = getDrug.ORDERCOUNT;
            ViewBag.transactionType = transactionType;
            return View(getDrug);
        }

        public ActionResult ViewAllDrug(string transactionType)
        {
            var getAll = _objIHospitalMaster.GetAllDrug();
            ViewBag.transactionType = transactionType;
            return View(getAll);
        }

        [HttpPost]
        public ActionResult EditDrug(lmsDrug objDrugMaster)
        {
            objDrugMaster.MANUFACTUREDATE = Request["MANUFACTUREDATE"] == null ? DateTime.Now : Request["MANUFACTUREDATE"].ToLmsSystemDate();
            objDrugMaster.EXPIRYDATE = Request["EXPIRYDATE"] == null ? DateTime.Now : Request["EXPIRYDATE"].ToLmsSystemDate();
            objDrugMaster.ORDERCOUNT = GetTotalDrugOrder(objDrugMaster.OLDORDERCOUNT, objDrugMaster.ORDERCOUNT);
            var qrCodeData = $"{objDrugMaster.DRUGNAME}-{objDrugMaster.EXPIRYDATE}";
            objDrugMaster.QrCodeContent = qrCodeData;
            objDrugMaster.QrCodeBase64 = qrCodeData.GenerateQrCode();
            var saveDrugDetails = _objIHospitalMaster.SaveDrug(objDrugMaster);
            return RedirectToAction("ViewDrug", new { DrugId = saveDrugDetails, transactionType = nameof(TransactionType.Save) });
        }

        public ActionResult DeleteDrug(int DrugId)
        {
             _objIHospitalMaster.DeleteDrug(DrugId);
            return RedirectToAction("ViewAllDrug", new { transactionType = nameof(TransactionType.Remove) });
        }
        private int GetTotalDrugOrder(int? orderCount, int?newOrder)
        {
            int totalOrder = 0;
            if (orderCount.HasValue)
            {
                var orderValue = orderCount.Value > 0 ? orderCount.Value : 0;
                var newOrderValue = (newOrder.HasValue ? newOrder.Value : 0) + orderValue;
                totalOrder = newOrderValue;
            }
            return totalOrder;
        }
    }
}

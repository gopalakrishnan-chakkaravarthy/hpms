using Lab.Management.Common;
using Lab.Management.Engine.Service;
using Lab.Management.Engine.Service.Tax;
using Lab.Management.Entities;
using Lab.Management.Utils.QrCode;
using LabManagement.System.Enums;
using LabManagement.System.Common;
using System;
using System.Web.Mvc;
using Lab.Management.Engine.Enum;

namespace LabManagement.System.Controllers
{
    public class MedicinesController : Controller
    {
        private readonly IHospitalMaster _objIHospitalMaster;
        private readonly ITaxService taxService;
        public MedicinesController(IHospitalMaster objIHospitalMaster,
            ITaxService taxService)
        {
            _objIHospitalMaster = objIHospitalMaster;
            this.taxService = taxService;
        }

        public ActionResult ViewMedicine(int medicineId, string transactionType="")
        {
            var getDrug = _objIHospitalMaster.GetDrugDetailsById(medicineId);
            getDrug.OLDORDERCOUNT = getDrug.ORDERCOUNT;
            var taxDdl = taxService.GetTaxList();
            ViewBag.TaxDdl = taxDdl.GetDropDownList("Key", "Value");
            ViewBag.TransactionType = transactionType;
            return View(getDrug);
        }

        public ActionResult ViewAllMedicines(QueryFilterAttribute queryFilterAttribute = QueryFilterAttribute.none, string filterValue = "", string transactionType = "")
        {
            var getAll = _objIHospitalMaster.GetAllDrug(queryFilterAttribute, filterValue);
            var filterList = _objIHospitalMaster.GetDrugFilterList();
            ViewBag.FilterList = new SelectList(filterList, "Value", "Text");
            ViewBag.TransactionType = transactionType;
            return View(getAll);
        }

        [HttpPost]
        public ActionResult EditDrug(lmsDrug objDrugMaster)
        {
            objDrugMaster.MANUFACTUREDATE = Request["MANUFACTUREDATE"] == null ? DateTime.Now : Request["MANUFACTUREDATE"].ToLmsSystemDate();
            objDrugMaster.EXPIRYDATE = Request["EXPIRYDATE"] == null ? DateTime.Now : Request["EXPIRYDATE"].ToLmsSystemDate();
           // objDrugMaster.ORDERCOUNT = GetTotalDrugOrder(objDrugMaster.OLDORDERCOUNT, objDrugMaster.ORDERCOUNT);
            var qrCodeData = $"{objDrugMaster.DRUGNAME}-{objDrugMaster.EXPIRYDATE}";
            objDrugMaster.QrCodeContent = qrCodeData;
            objDrugMaster.QrCodeBase64 = qrCodeData.GenerateQrCode();
            var saveDrugDetails = _objIHospitalMaster.SaveDrug(objDrugMaster);
            return RedirectToAction("ViewMedicine", new { DrugId = saveDrugDetails, transactionType = nameof(TransactionType.Save) });
        }

        public ActionResult DeleteMedicine(int medicineId)
        {
             _objIHospitalMaster.DeleteDrug(medicineId);
            return RedirectToAction("ViewAllMedicines", new { transactionType = nameof(TransactionType.Remove) });
        }
        private int GetTotalDrugOrder(int? orderCount, int?newOrder)
        {
            int totalOrder = 0;
            if (orderCount.HasValue)
            {
                var orderValue = orderCount.Value > 0 ? orderCount.Value : 0;
                var newOrderValue = newOrder.HasValue ? newOrder.Value : 0;
                if (orderValue!= newOrderValue)
                {
                    newOrderValue = newOrderValue + orderValue;
                }
                else
                {
                    newOrderValue = orderValue;
                }
                 
                totalOrder = newOrderValue;
            }
            return totalOrder;
        }
    }
}

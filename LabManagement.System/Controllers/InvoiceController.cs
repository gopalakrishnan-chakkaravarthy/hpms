﻿using Lab.Management.Common;
using Lab.Management.Engine.Enum;
using Lab.Management.Engine.Service;
using Lab.Management.Engine.Service.Drugs;
using Lab.Management.Engine.Service.MedicalTest;
using Lab.Management.Entities;
using LabManagement.System.Common;
using LabManagement.System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace LabManagement.System.Controllers
{
    public class InvoiceController : BaseController
    {
        private readonly IInvoice _objIInvoice;
        private readonly IPatient _objIPatient;
        private readonly IHospitalMaster _objIHospitalMaster;
        private readonly IAdminOperations _adminOperations;
        private readonly IDrugTaxService drugTaxService;
        private readonly ILabTaxService labTaxService;
        public InvoiceController(IInvoice objIInvoice, IPatient objIPatient,
            IHospitalMaster objIHospitalMaster,
            IAdminOperations adminOperations,
            IDrugTaxService drugTaxService,
            ILabTaxService labTaxService)
        {
            _objIInvoice = objIInvoice;
            _objIPatient = objIPatient;
            _objIHospitalMaster = objIHospitalMaster;
            _adminOperations = adminOperations;
            this.drugTaxService = drugTaxService;
            this.labTaxService = labTaxService;
        }

        public ActionResult ViewMedicalBill(int MedicalBillId, string viewMessage = "")
        {
            var DrugList = _objIHospitalMaster.GetDrugsDdl();
            // var PatientList = _objIPatient.GetPatientDdl();
            ViewBag.DrugList = DrugList.GetDropDownList("DRUGID", "DRUGNAME"); // new SelectList(DrugList, "DRUGID", "DRUGNAME");
            //ViewBag.PatientList = PatientList.GetDropDownList("PATIENTID", "PATIENTNAME");
            var getMedicalBill = _objIInvoice.GetMedicalBillDetailsById(MedicalBillId);
            ViewBag.Message = viewMessage;
            return View(getMedicalBill);
        }
        public ActionResult GetDetailListByBillId(int medicalBillId)
        {
            var getMedicalBill = _objIInvoice.GetDetailListByBillId(medicalBillId);
            return Json(getMedicalBill, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetLaboratoryDetailListByBillId(int labBillId)
        {
            var getMedicalBill = _objIInvoice.GetLaboratoryDetailListByBillId(labBillId);
            return Json(getMedicalBill, JsonRequestBehavior.AllowGet);
        }
        public ActionResult SaveBillInfo(DrugBill objDrugBill, List<DrugBillDetails> objDrugBillDetails)
        {
            var medicalBilling = _objIInvoice.GetMedicalBillDetailsById(0);
            medicalBilling.BILLNAME = objDrugBill.BILLNAME;
            medicalBilling.CONTACT = objDrugBill.CONTACT;
            medicalBilling.BILLDATE = DateTime.Now;
            medicalBilling.CREATEDDATE = DateTime.Now;
            var totalTax = objDrugBillDetails.Select(x => x.TAXAMOUNT).Sum();
            medicalBilling.BILLAMOUNT = objDrugBillDetails.Select(x => x.COST).Sum() + totalTax;
            medicalBilling.BILLBY = LoginId.ToString();
            objDrugBillDetails.ForEach(x =>
            {
                medicalBilling.lmsMedicalBillingDetails.Add(new lmsMedicalBillingDetail
                {
                    DRUGID = x.DRUGID,
                    QUANTITY = x.QUANTITY,
                    ITEMCOST = x.COST,
                    TAXAMOUNT = x.TAXAMOUNT
                });
            });

            #region <<Update Drug Quantity>>

            objDrugBillDetails.ForEach(x =>
            {
                var drugInfo = _objIHospitalMaster.GetDrugDetailsById(x.DRUGID);

                drugInfo.ORDERCOUNT = drugInfo.ORDERCOUNT - x.QUANTITY;
                _objIHospitalMaster.SaveDrug(drugInfo);
            });

            #endregion <<Update Drug Quantity>>

            var saveMedicalBillDetails = _objIInvoice.SaveMedicalBill(medicalBilling);
            return Json(saveMedicalBillDetails, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetDrugDetailById(int drugId, int? quantity)
        {
            var drugInfo = _objIHospitalMaster.GetDrugDetailsById(drugId);
            var allTaxes = drugTaxService.GetTaxesPercentByDrugId(drugId);
            var resultIfo = new DrugPrice(allTaxes)
            {
                DRUGNAME = drugInfo.DRUGNAME,
                SELLINGPRICE = Math.Round((drugInfo.SELLINGPRICE.Value * (quantity == null || quantity == 0 ? 1 : quantity.Value)), 2)
            };
            resultIfo.CalculateTax();
            return Json(resultIfo, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ViewAllMedicalBill(string viewMessage = "", string filterDate = "")
        {
            var billFilterDate = (filterDate.stringIsNotNull() ? filterDate.ToLmsSystemDate() : DateTime.Now).ToShortDateString();
            var getAll = _objIInvoice.GetAllMedicalBill(filterDate: billFilterDate);
            var userDetail = UserInfo;
            ViewBag.Message = viewMessage;
            if (getAll != null && getAll.Count() > 0)
            {
                ViewBag.GrandTotal = getAll.Sum(x => Math.Round(Convert.ToDouble(x.BILLAMOUNT.Value), 2));
                return View(getAll);
            }
            ViewBag.GrandTotal = 0.00;

            return View(new List<lmsMedicalBilling>());
        }

        public ActionResult GenerateBill(int MedicalBillId)
        {
            var getMedicalBill = _objIInvoice.GetMedicalBillDetailsById(MedicalBillId);
            getMedicalBill.BILLAMOUNT = Math.Round(getMedicalBill.BILLAMOUNT.Value, 2);
            return View(getMedicalBill);
        }

        public ActionResult DeleteMedicalBill(int MedicalBillId)
        {
            var deletMedicalBill = _objIInvoice.DeleteMedicalBill(MedicalBillId);
            return RedirectToAction("ViewAllMedicalBill", new { viewMessage = "MedicalBill Detail Deleted Successfully" });
        }

        public ActionResult ViewLaboratoryBilling(int LaboratoryBillingId, string viewMessage = "")
        {
            var testList = _objIHospitalMaster.GetAllMedicalTest();
            foreach (var test in testList)
            {
                UpdateTestName(test);
            }
            ViewBag.TestList = new SelectList(testList, "TESTID", "TESTNAME");
            var getLaboratoryBilling = _objIInvoice.GetLaboratoryBillingDetailsById(LaboratoryBillingId);
            ViewBag.Message = viewMessage;
            return View(getLaboratoryBilling);
        }

        private void UpdateTestName(lmsMedicalTest lmsMedicalTest)
        {
            if (lmsMedicalTest.lmsMedicalTestFor != null && lmsMedicalTest.lmsMedicalTestGroup != null)
            {
                lmsMedicalTest.TESTNAME = $"{lmsMedicalTest.TESTNAME} - {lmsMedicalTest.lmsMedicalTestFor?.TESTFOR} - {lmsMedicalTest.lmsMedicalTestGroup?.GROUPNAME}";
            }
        }

        public ActionResult SaveMedicalTestBillInfo(TestBill objTestBill, List<TestBillDetails> objTestBillDetails)
        {
            var laboratoryBilling = _objIInvoice.GetLaboratoryBillingDetailsById(0);
            laboratoryBilling.BILLNAME = objTestBill.BILLNAME;
            laboratoryBilling.CONTACT = objTestBill.CONTACT;
            laboratoryBilling.BILLDATE = DateTime.Now;
            laboratoryBilling.CREATEDDATE = DateTime.Now;
            laboratoryBilling.BILLBY = LoginId.ToString();
            var totalTax = objTestBillDetails.Select(x => x.TAXAMOUNT).Sum();
            laboratoryBilling.BILLAMOUNT = objTestBillDetails.Select(x => x.COST).Sum() + totalTax;
            objTestBillDetails.ForEach(x =>
            {
                laboratoryBilling.lmsLaboratoryBillingDetails.Add(new lmsLaboratoryBillingDetail
                {
                    TESTID = x.TESTID,
                    ITEMCOST = x.COST,
                    TESTRESULT = x.TESTRESULT,
                    TAXAMOUNT = x.TAXAMOUNT
                });
            });

            var saveLaboratoryBillingDetails = _objIInvoice.SaveLaboratoryBilling(laboratoryBilling);
            return Json(saveLaboratoryBillingDetails, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetTestDetailById(int testId, string result)
        {
            var testInfo = _objIHospitalMaster.GetMedicalTestDetailsById(testId);
            var quantity = 1;
            var allTaxes = labTaxService.GetTaxesPercentByTestId(testId);
            var resultIfo = new TestPrice(allTaxes)
            {
                TESTNAME = testInfo.TESTNAME,
                SELLINGPRICE = Math.Round((testInfo.SELLIGPRICE.Value * quantity), 2)
            };
            resultIfo.CalculateTax();
            return Json(resultIfo, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ViewAllLaboratoryBilling(string viewMessage = "", string filterDate = "")
        {
            ViewBag.Message = viewMessage;
            var billFilterDate = (filterDate.stringIsNotNull() ? filterDate.ToLmsSystemDate() : DateTime.Now).ToShortDateString();
            var getAll = _objIInvoice.GetAllLaboratoryBilling(billFilterDate);
            if (getAll != null && getAll.Any())
            {
                ViewBag.GrandTotal = getAll.Sum(x => Math.Round(x.BILLAMOUNT.Value, 2));
                return View(getAll);
            }
            ViewBag.GrandTotal = 0.00;
            return View(new List<lmsLaboratoryBilling>());
        }

        public ActionResult GenerateLaboratoryBill(int LaboratoryBillingId)
        {
            var getLaboratoryBilling = _objIInvoice.GetLaboratoryBillingDetailsById(LaboratoryBillingId);

            getLaboratoryBilling.BILLAMOUNT = Math.Round(getLaboratoryBilling.BILLAMOUNT.Value, 2);

            return View(getLaboratoryBilling);
        }

        public ActionResult GenerateLaboratoryReport(int LaboratoryBillingId)
        {
            var getLaboratoryBilling = _objIInvoice.GetLaboratoryBillingDetailsById(LaboratoryBillingId);
            List<LaboratoryResultGroup> groupbyData = getLaboratoryBilling.lmsLaboratoryBillingDetails
                .GroupBy(x => x.lmsMedicalTest?.lmsMedicalTestGroup?.GROUPNAME)
                .Select(lbdt =>
           new LaboratoryResultGroup { GroupName = lbdt.Key, lmsLaboratoryBillingDetails = lbdt.Select(x => x) }).ToList();
            ViewBag.groupedDetails = groupbyData;
            return View(getLaboratoryBilling);
        }

        public ActionResult DeleteLaboratoryBilling(int LaboratoryBillingId)
        {
            var deletLaboratoryBilling = _objIInvoice.DeleteLaboratoryBilling(LaboratoryBillingId);
            return RedirectToAction("ViewAllLaboratoryBilling", new { viewMessage = "LaboratoryBilling Detail Deleted Successfully" });
        }

        public ActionResult ViewDischargeSummary(int ReportId, string viewMessage = "")
        {
            var getDischargeSummary = _objIInvoice.GetDischargeSummaryDetailsById(ReportId);
            // var PatientList = _objIPatient.GetPatientDdl();
            //    getDischargeSummary.PatientDdl = PatientList.GetDropDownList("PATIENTID", "PATIENTNAME");
            if (ReportId > 0 && getDischargeSummary.PATIENTID.HasValue)
            {
                getDischargeSummary.SelectedPatient = getDischargeSummary.PATIENTID.Value;
            }
            ViewBag.Message = viewMessage;
            return View(getDischargeSummary);
        }

        public ActionResult GenerateDischargeSummary(int ReportId, string viewMessage = "")
        {
            var getDischargeSummary = _objIInvoice.GetDischargeSummaryDetailsById(ReportId);
            ViewBag.Message = viewMessage;
            return View(getDischargeSummary);
        }

        public ActionResult ViewAllDischargeSummary(string viewMessage = "")
        {
            var getAll = _objIInvoice.GetAllDischargeSummary();
            ViewBag.Message = viewMessage;
            return View(getAll);
        }

        [HttpPost]
        public ActionResult EditDischargeSummary(lmsPatientDischargeSummary objlmsPatientDischargeSummary)
        {
            objlmsPatientDischargeSummary.PATIENTID = objlmsPatientDischargeSummary.SelectedPatient;
            objlmsPatientDischargeSummary.DDATE = Request["DDATE"] == null ? DateTime.Now : Request["DDATE"].ToLmsSystemDate();
            objlmsPatientDischargeSummary.DDATE2 = Request["DDATE2"] == null ? DateTime.Now : Request["DDATE2"].ToLmsSystemDate();
            var saveDischargeSummaryDetails = _objIInvoice.SaveDischargeSummary(objlmsPatientDischargeSummary);
            return RedirectToAction("ViewDischargeSummary", new { ReportId = saveDischargeSummaryDetails, viewMessage = "DischargeSummary Details Saved Successfully" });
        }

        public ActionResult DeleteDischargeSummary(int ReportId)
        {
            var deletDischargeSummary = _objIInvoice.DeleteDischargeSummary(ReportId);
            return RedirectToAction("ViewAllDischargeSummary", new { viewMessage = "DischargeSummary Detail Deleted Successfully" });
        }

        public ActionResult ViewUltraSonagramReportOne(int ReportId, string viewMessage = "")
        {
            var getUltraSonagramReportOne = _objIInvoice.GetUltraSonagramReportOneDetailsById(ReportId);
            ViewBag.Message = viewMessage;
            return View(getUltraSonagramReportOne);
        }

        public ActionResult ViewAllUltraSonagramReportOne(string viewMessage = "")
        {
            var getAll = _objIInvoice.GetAllUltraSonagramReportOne();
            ViewBag.Message = viewMessage;
            return View(getAll);
        }

        [HttpPost]
        public ActionResult EditUltraSonagramReportOne(lmsUltrSonogramReportOne objlmsUltrSonogramReportOne)
        {
            objlmsUltrSonogramReportOne.CREATEDDATE = DateTime.Now;
            var saveUltraSonagramReportOneDetails = _objIInvoice.SaveUltraSonagramReportOne(objlmsUltrSonogramReportOne);
            //ViewBag.Message = viewMessage;
            return RedirectToAction("ViewUltraSonagramReportOne", new { ReportId = saveUltraSonagramReportOneDetails, viewMessage = "UltraSonagramReportOne Details Saved Successfully" });
        }

        public ActionResult DeleteUltraSonagramReportOne(int ReportId)
        {
            var deletUltraSonagramReportOne = _objIInvoice.DeleteUltraSonagramReportOne(ReportId);
            return RedirectToAction("ViewAllUltraSonagramReportOne", new { viewMessage = "UltraSonagramReportOne Detail Deleted Successfully" });
        }

        public ActionResult GenerateUltraSonagramReportOne(int ReportId, string viewMessage = "")
        {
            var getSonography = _objIInvoice.GetUltraSonagramReportOneDetailsById(ReportId);
            ViewBag.Message = viewMessage;
            return View(getSonography);
        }

        public ActionResult GenerateUltraSonagramReportTwo(int ReportId, string viewMessage = "")
        {
            var getSonography = _objIInvoice.GetUltraSonagramReportTwoDetailsById(ReportId);
            ViewBag.Message = viewMessage;
            return View(getSonography);
        }

        public ActionResult ViewUltraSonagramReportTwo(int ReportId, string viewMessage = "")
        {
            var getUltraSonagramReportTwo = _objIInvoice.GetUltraSonagramReportTwoDetailsById(ReportId);
            ViewBag.Message = viewMessage;
            return View(getUltraSonagramReportTwo);
        }

        public ActionResult ViewAllUltraSonagramReportTwo(string viewMessage = "")
        {
            var getAll = _objIInvoice.GetAllUltraSonagramReportTwo();
            ViewBag.Message = viewMessage;
            return View(getAll);
        }

        [HttpPost]
        public ActionResult EditUltraSonagramReportTwo(lmsUltrSonogramReportTwo objlmsUltrSonogramReportTwo)
        {
            var saveUltraSonagramReportTwoDetails = _objIInvoice.SaveUltraSonagramReportTwo(objlmsUltrSonogramReportTwo);
            //ViewBag.Message = viewMessage;
            return RedirectToAction("ViewUltraSonagramReportTwo", new { ReportId = saveUltraSonagramReportTwoDetails, viewMessage = "UltraSonagramReportTwo Details Saved Successfully" });
        }

        public ActionResult DeleteUltraSonagramReportTwo(int ReportId)
        {
            var deletUltraSonagramReportTwo = _objIInvoice.DeleteUltraSonagramReportTwo(ReportId);
            return RedirectToAction("ViewAllUltraSonagramReportTwo", new { viewMessage = "UltraSonagramReportTwo Detail Deleted Successfully" });
        }

        public ActionResult ViewInvestigationReport(int ReportId, string viewMessage = "")
        {
            var patientList = _objIPatient.GetAllPatient(QueryFilterAttribute.none, "", "IN");
            ViewBag.PatientList = patientList.GetInPatientDropdowList();
            var getInvestigationReport = _objIInvoice.GetInvestigationReportDetailsById(ReportId);
            ViewBag.Message = viewMessage;
            return View(getInvestigationReport);
        }

        public ActionResult ViewAllInvestigationReport(string viewMessage = "")
        {
            var getAll = _objIInvoice.GetAllInvestigationReport();
            ViewBag.Message = viewMessage;
            return View(getAll);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditInvestigationReport(lmsInvestigationReport objlmsInvestigationReport)
        {
            var saveInvestigationReportDetails = _objIInvoice.SaveInvestigationReport(objlmsInvestigationReport);
            //ViewBag.Message = viewMessage;
            return RedirectToAction("ViewInvestigationReport", new { ReportId = saveInvestigationReportDetails, viewMessage = "InvestigationReport Details Saved Successfully" });
        }

        public ActionResult DeleteInvestigationReport(int ReportId)
        {
            var deletInvestigationReport = _objIInvoice.DeleteInvestigationReport(ReportId);
            return RedirectToAction("ViewAllInvestigationReport", new { viewMessage = "InvestigationReport Detail Deleted Successfully" });
        }

        public ActionResult GenerateInvestigationReport(int ReportId)
        {
            var getReport = _objIInvoice.GetInvestigationReportDetailsById(ReportId);
            return View(getReport);
        }

        public ActionResult ViewDischargeBill(int ReportId, string viewMessage = "")
        {
            var PatientList = _objIPatient.GetPatientDdl();
            var getReport = _objIInvoice.GetDischargeBillDetailsById(ReportId);
            getReport.PatientDdl = PatientList.GetDropDownList("PATIENTID", "PATIENTNAME");
            if (ReportId > 0 && getReport.PATIENTID.HasValue)
            {
                getReport.SelectedPatient = getReport.PATIENTID.Value;
            }
            ViewBag.Message = viewMessage;
            return View(getReport);
        }

        public ActionResult ViewAllDischargeBill(string viewMessage = "")
        {
            var getAll = _objIInvoice.GetAllDischargeBill();
            ViewBag.Message = viewMessage;
            return View(getAll);
        }

        [HttpPost]
        public ActionResult EditDischargeBill(lmsDischargeBill objlmsDischargeBill)
        {
            objlmsDischargeBill.PATIENTID = objlmsDischargeBill.SelectedPatient;
            var saveReportDetails = _objIInvoice.SaveDischargeBill(objlmsDischargeBill);
            return RedirectToAction("ViewDischargeBill", new { ReportId = saveReportDetails, viewMessage = "Discharge Bill Details Saved Successfully" });
        }

        public ActionResult DeleteDischargeBill(int ReportId)
        {
            var deletInvestigationReport = _objIInvoice.DeleteDischargeBill(ReportId);
            return RedirectToAction("ViewAllDischargeBill", new { viewMessage = "Discharge Bill Details Deleted Successfully" });
        }

        public ActionResult GenerateDischargeBill(int ReportId)
        {
            var getReport = _objIInvoice.GetDischargeBillDetailsById(ReportId);
            return View(getReport);
        }

        #region <<< Multi Delete>>>

        public ActionResult MultiDeleteBill(string deleteSelectedRows)
        {
            var deleteStatus = _objIInvoice.MultiDeleteRows(deleteSelectedRows);
            return Json(deleteStatus, JsonRequestBehavior.AllowGet);
        }

        #endregion <<< Multi Delete>>>

        #region <<Discharge Summary New>>

        public ActionResult ViewGenDischargeSummary(int ReportId, string viewMessage = "")
        {
            var PatientList = _objIPatient.GetPatientDdl();
            var getDischargeSummary = _objIInvoice.GetGenDischargeSummaryDetailsById(ReportId);
            getDischargeSummary.PatientDdl = PatientList.GetDropDownList("PATIENTID", "PATIENTNAME");
            if (ReportId > 0 && getDischargeSummary.PATIENTID.HasValue)
            {
                getDischargeSummary.SelectedPatient = getDischargeSummary.PATIENTID.Value;
            }
            ViewBag.Message = viewMessage;
            return View(getDischargeSummary);
        }

        public ActionResult GenerateGenDischargeSummary(int ReportId, string viewMessage = "")
        {
            var getDischargeSummary = _objIInvoice.GetGenDischargeSummaryDetailsById(ReportId);
            ViewBag.Message = viewMessage;
            return View(getDischargeSummary);
        }

        public ActionResult ViewAllGenDischargeSummary(string viewMessage = "")
        {
            var getAll = _objIInvoice.GetAllGenDischargeSummary();
            ViewBag.Message = viewMessage;
            return View(getAll);
        }

        [HttpPost]
        public ActionResult EditGenDischargeSummary(lmsGeneralDischargeSummary objlmsPatientDischargeSummary)
        {
            objlmsPatientDischargeSummary.PATIENTID = objlmsPatientDischargeSummary.SelectedPatient;
            objlmsPatientDischargeSummary.CREATEDATE = DateTime.Now;
            var saveDischargeSummaryDetails = _objIInvoice.SaveGenDischargeSummary(objlmsPatientDischargeSummary);
            return RedirectToAction("ViewGenDischargeSummary", new { ReportId = saveDischargeSummaryDetails, viewMessage = "DischargeSummary Details Saved Successfully" });
        }

        public ActionResult DeleteGenDischargeSummary(int ReportId)
        {
            var deletDischargeSummary = _objIInvoice.DeleteDischargeSummary(ReportId);
            return RedirectToAction("ViewAllGenDischargeSummary", new { viewMessage = "Discharge Summary Detail Deleted Successfully" });
        }

        public ActionResult ViewGynacDischargeSummary(int ReportId, string viewMessage = "")
        {
            var PatientList = _objIPatient.GetPatientDdl();
            var getDischargeSummary = _objIInvoice.GetGynacDischargeSummaryDetailsById(ReportId);
            getDischargeSummary.PatientDdl = PatientList.GetDropDownList("PATIENTID", "PATIENTNAME");
            if (ReportId > 0 && getDischargeSummary.PATIENTID.HasValue)
            {
                getDischargeSummary.SelectedPatient = getDischargeSummary.PATIENTID.Value;
            }
            ViewBag.Message = viewMessage;
            return View(getDischargeSummary);
        }

        public ActionResult GenerateGynacDischargeSummary(int ReportId, string viewMessage = "")
        {
            var getDischargeSummary = _objIInvoice.GetGynacDischargeSummaryDetailsById(ReportId);
            ViewBag.Message = viewMessage;
            return View(getDischargeSummary);
        }

        public ActionResult ViewAllGynacDischargeSummary(string viewMessage = "")
        {
            var getAll = _objIInvoice.GetAllGynacDischargeSummary();
            ViewBag.Message = viewMessage;
            return View(getAll);
        }

        [HttpPost]
        public ActionResult EditGynacDischargeSummary(lmsGynacDischargeSummary objlmsPatientDischargeSummary)
        {
            objlmsPatientDischargeSummary.PATIENTID = objlmsPatientDischargeSummary.SelectedPatient;
            objlmsPatientDischargeSummary.CREATEDATE = DateTime.Now;
            objlmsPatientDischargeSummary.DOS = Request["DOS"] == null ? DateTime.Now : Request["DOS"].ToLmsSystemDate();
            objlmsPatientDischargeSummary.DOD = Request["DOD"] == null ? DateTime.Now : Request["DOD"].ToLmsSystemDate();
            objlmsPatientDischargeSummary.DISCHARGEDON = Request["DISCHARGEDON"] == null ? DateTime.Now : Request["DISCHARGEDON"].ToLmsSystemDate();
            objlmsPatientDischargeSummary.DRESSINGCHANGEDON = Request["DRESSINGCHANGEDON"] == null ? DateTime.Now : Request["DRESSINGCHANGEDON"].ToLmsSystemDate();
            var saveDischargeSummaryDetails = _objIInvoice.SaveGynacDischargeSummary(objlmsPatientDischargeSummary);
            return RedirectToAction("ViewGynacDischargeSummary", new { ReportId = saveDischargeSummaryDetails, viewMessage = "DischargeSummary Details Saved Successfully" });
        }

        public ActionResult DeleteGynacDischargeSummary(int ReportId)
        {
            var deletDischargeSummary = _objIInvoice.DeleteDischargeSummary(ReportId);
            return RedirectToAction("ViewAllGynacDischargeSummary", new { viewMessage = "Discharge Summary Detail Deleted Successfully" });
        }

        #endregion <<Discharge Summary New>>

        #region <<Report TemplateStore>>

        public ActionResult ViewPatientReportStore(int reportId, string viewMessage = "")
        {
            var getReportSummary = _objIInvoice.GetPatientReportStoreById(reportId);
            ViewBag.TemlpateContent = getReportSummary.REPORTDETAIL ?? getReportSummary.REPORTDETAIL;
            if (reportId > 0 && getReportSummary.PATIENTID.HasValue)
            {
                getReportSummary.SelectedPatient = getReportSummary.PATIENTID.Value;
            }
            ViewBag.Message = viewMessage;
            return View(getReportSummary);
        }

        public ActionResult ViewAllPatientReportStore(string viewMessage = "", string filterDate = "")
        {
            var billFilterDate = (filterDate.stringIsNotNull() ? filterDate.ToLmsSystemDate() : DateTime.Now).ToShortDateString();
            var getAll = _objIInvoice.GetAllPatientReportStore(billFilterDate);
            ViewBag.Message = viewMessage;

            return View(getAll);
        }

        [HttpPost]
        public ActionResult SavePatientReportStore(lmsPatientReportStore lmsPatientReportStore)
        {
            lmsPatientReportStore.PATIENTID = lmsPatientReportStore.SelectedPatient;
            lmsPatientReportStore.CREATEDDATE = DateTime.Now;
            var saveReportDetails = _objIInvoice.SavePatientReportStore(lmsPatientReportStore);
            return Json(new { reportId = saveReportDetails, viewMessage = "Patient Report Details Saved Successfully" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeletePatientReportStore(int reportId)
        {
            var deletReportStore = _objIInvoice.DeletePatientReportStore(reportId);
            return RedirectToAction("ViewAllPatientReportStore", new { viewMessage = "Patient Report Detail Deleted Successfully" });
        }

        #endregion <<Report TemplateStore>>
    }
}

using Lab.Management.Common;
using Lab.Management.Engine.Models;
using Lab.Management.Engine.Service;
using Lab.Management.Engine.Utils;
using Lab.Management.Entities;
using Lab.Management.Utils.QrCode;
using LabManagement.System.Common;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace LabManagement.System.Controllers
{
    public class PatientController : BaseController
    {
        private readonly IHospitalMaster _objIHospitalMaster;
        private readonly IAdminOperations _objIAdminOperations;
        private readonly IPatient _objIPatient;
        private readonly IInvoice _objIInvoice;
        public PatientController(IPatient objIPatient, IAdminOperations objIAdminOperations,
            IHospitalMaster objIHospitalMaster, IInvoice objIInvoice)
        {
            _objIPatient = objIPatient;
            _objIAdminOperations = objIAdminOperations;
            _objIHospitalMaster = objIHospitalMaster;
            _objIInvoice = objIInvoice;
        }

        public ActionResult ViewPatient(int PatientId, string viewMessage = "")
        {
            var getPatient = _objIPatient.GetPatientDetailsById(PatientId);
            if (PatientId > 0)
            {
                getPatient.Sex = getPatient.GENDER.ToUpper().Equals("MALE") ? 1 : getPatient.GENDER.ToUpper().Equals("FEMALE") ? 2 : 0;
            }
            ViewBag.Message = viewMessage;
            return View(getPatient);
        }

        public ActionResult ViewAllPatient(string viewMessage = "")
        {
            var getAll = _objIPatient.GetAllPatient("IN");
            ViewBag.Message = viewMessage;
            return View(getAll);
        }

        [HttpPost]
        public ActionResult EditPatient(lmsPatientRegistration objPatientMaster)
        {
            var addmissionDate = Request["REGISTEREDATE"] == null ? DateTime.Now : Request["REGISTEREDATE"].ToLmsSystemDate();
            var qrCodeText = $"{ objPatientMaster.PATIENTNAME}-{ objPatientMaster.CONTACT}";
            objPatientMaster.GENDER = objPatientMaster.Sex == 1 ? "Male" : objPatientMaster.Sex == 2 ? "Female" : null;
            objPatientMaster.DOB = Request["DOB"] == null ? DateTime.Now : Request["DOB"].ToLmsSystemDate();
            objPatientMaster.CREATEDDATE = addmissionDate;
            objPatientMaster.QrCodeContent = qrCodeText;
            objPatientMaster.QrCodeBase64 = qrCodeText.GenerateQrCode();
            var savePatientDetails = _objIPatient.SavePatient(objPatientMaster);
            return RedirectToAction("ViewPatient", new { PatientId = savePatientDetails, viewMessage = "Patient Details Saved Successfully" });
        }

        public ActionResult DeletePatient(int PatientId)
        {
            var deletPatient = _objIPatient.DeletePatient(PatientId);
            return RedirectToAction("ViewAllPatient", new { viewMessage = "Patient Detail Deleted Successfully" });
        }

        public ActionResult PatientScanner(string imagePath = "")
        {
            var qrCodePath = $"{Server.MapPath("~/QrCodePath")}\\{imagePath}";
            var qrCodeReader = new QRCodeReader(qrCodePath);
            var decodeData = qrCodeReader.ReadQRCode();
            var patientId = _objIPatient.GetPatientIdByQrCode(decodeData.QRCodeText);
            return RedirectToAction("ViewPatient", new { PatientId = patientId, viewMessage = "" });
        }

        public ActionResult ViewBooking(int id, string viewMessage = "", int patientId = 0)
        {
            var diseaseDdl = _objIAdminOperations.GetAllDiseases();
            var bookingDetail = _objIPatient.GetPatientBookingById(id);

            if (patientId != 0)
            {
                var patientDetails = _objIPatient.GetPatientDetailsById(patientId);
                if (patientDetails != null)
                {
                    bookingDetail.PATIENTID = patientDetails.PATIENTID;
                }
            }

            var patientDdl = _objIPatient.GetPatientDdl();
            var bookingStatus = DropDownExtension.GetBookingStatus();
            bookingDetail.DiseaseDdl = new SelectList(diseaseDdl, "DISEASEID", "DISEASENAME");
            bookingDetail.PatientDdl = new SelectList(patientDdl, "PATIENTID", "PATIENTNAME");
            bookingDetail.BookingStatusDdl = new SelectList(bookingStatus, "Value", "Key");
            ViewBag.Message = viewMessage;
            return View(bookingDetail);
        }

        public ActionResult ViewAllBooking(string viewMessage = "", string filterDate = "")
        {
            var bookingDate = (filterDate.stringIsNotNull() ? filterDate.ToLmsSystemDate() : DateTime.Now).ToShortDateString();
            var getAll = _objIPatient.GetAllPatientBooking(date: bookingDate);
            ViewBag.Message = getAll == null ? "No Records Found" : viewMessage;
            return View(getAll);
        }

        [HttpPost]
        public ActionResult EditBooking(lmsPatientBooking objSaveData)
        {
            objSaveData.APPOINTMENTDATE = Request["APPOINTMENTDATE"] == null ? DateTime.Now : Request["APPOINTMENTDATE"].ToLmsSystemDate();
            objSaveData.DISCHARGEDATE = Request["DISCHARGEDATE"] == null ? DateTime.Now : Request["DISCHARGEDATE"].ToLmsSystemDate();
            var savePatientDetails = _objIPatient.SavePatientBooking(objSaveData);

            return RedirectToAction("ViewBooking", new { id = savePatientDetails, viewMessage = "Patient Booking Saved Successfully" });
        }

        public ActionResult DeleteBooking(int id)
        {
            var deletPatient = _objIPatient.DeletePatientBooking(id);
            return RedirectToAction("ViewAllBooking", new { viewMessage = "Patient Booking Deleted Successfully" });
        }

        public ActionResult ViewPrescription(int id, string viewMessage = "")
        {
            var drugList = _objIHospitalMaster.GetDrugsDdl();
            var dosageList = _objIAdminOperations.GetAllDrugDosage();
            var frequencyList = _objIAdminOperations.GetAllDrugFrequency();
            ViewBag.DrugList = drugList.GetDropDownList("DRUGID", "DRUGNAME");
            ViewBag.DosageList = dosageList.GetDropDownList("DOSAGEID", "DOSAGEPOWER");
            ViewBag.FrequencyList = frequencyList.GetDropDownList("FREQUENCYID", "FREQUENCY");
            var getPatientPrescription = _objIPatient.GetPatientPrescriptionById(id);
            SetPatientName(id);
            ViewBag.Message = viewMessage;
            return PartialView("_ViewPrescription", getPatientPrescription);
        }

        public ActionResult PrintPatientPrescription(int id)
        {
            var getAllPatientPrescription = _objIPatient.GetAllPatientPrescription(id);
            SetPatientName(id);
            return PartialView("_PrintPatientPrescription", getAllPatientPrescription);
        }

        public ActionResult ViewPatientHistory(int id, string viewMessage = "")
        {
            var getAllPatientPrescription = _objIPatient.GetAllPatientBooking(patientId: id, isHistory: true);
            ViewBag.Message = viewMessage;
            return PartialView("_ViewPatientHistory", getAllPatientPrescription);
        }

        public ActionResult SavePrescription(List<PrescriptionModel> prescriptionModels)
        {
            var prescriptionList = new List<lmsPatientPrescription>();
            prescriptionModels.ForEach(presc =>
            {
                prescriptionList.Add(new lmsPatientPrescription
                {
                    DRUGID = presc.DRUGID,
                    BOOKINGID = presc.BOOKINGID,
                    PATIENTID = presc.PATIENTID,
                    DOSAGEID = presc.DOSAGEID,
                    FREQUENCYID = presc.FREQUENCYID,
                    MEDICINECOUNT = presc.MEDICINECOUNT,
                    STRENGTH = presc.STRENGTH,
                    INSTRUCTIONS = presc.INSTRUCTIONS
                });
            });
            var saveResult = _objIPatient.SavePatientPrescription(prescriptionList);
            return Json(saveResult, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeletePrescription(int id)
        {
            var saveResult = _objIPatient.DeletePatientPrescription(id);
            return RedirectToAction("ViewAllBooking", new { viewMessage = "Patient Prescription Deleted Successfully" });
        }

        private void SetPatientName(int id)
        {
            var patientInfo = _objIPatient.GetPatientBookingById(id);
            if (patientInfo.lmsPatientRegistration != null)
            {
                ViewBag.Name = patientInfo.lmsPatientRegistration.PATIENTNAME;
                ViewBag.Contact = patientInfo.lmsPatientRegistration.CONTACT;
            }
            else
            {
                ViewBag.Name = "";
                ViewBag.Contact = "";
            }
        }
    }
}

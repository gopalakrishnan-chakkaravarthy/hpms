using Lab.Management.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab.Management.Entities;
using Lab.Management.Common;
namespace LabManagement.System.Controllers
{
    public class PatientController : BaseController
    {
        private readonly IPatient _objIPatient;
        private readonly IAdminOperations _objIAdminOperations;
        public PatientController(IPatient objIPatient, IAdminOperations objIAdminOperations)
        {
            _objIPatient = objIPatient;
            _objIAdminOperations = objIAdminOperations;
        }
        public ActionResult ViewPatient(int PatientId, string viewMessage = "")
        {

            var DiseaseList = _objIAdminOperations.GetAllDiseases();
            var getPatient = _objIPatient.GetPatientDetailsById(PatientId);
            getPatient.DiseaseDdl = new SelectList(DiseaseList, "DISEASEID", "DISEASENAME");
            if (PatientId > 0 && getPatient.DISEASEID.HasValue)
            {
                getPatient.SelectedDisease = getPatient.DISEASEID.Value;

            }

            if (PatientId > 0)
            {
                getPatient.Sex = getPatient.GENDER.ToUpper().Equals("MALE") ? 1 : getPatient.GENDER.ToUpper().Equals("FEMALE") ? 2 : 0;
            }
            getPatient.ISDISCHARGED = false;
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
            objPatientMaster.DISEASEID = objPatientMaster.SelectedDisease;
            objPatientMaster.PATIENTTYPE = "IN";
            objPatientMaster.GENDER = objPatientMaster.Sex == 1 ? "Male" : objPatientMaster.Sex == 2 ? "Female" : null;
            objPatientMaster.DOB = Request["DOB"] == null ? DateTime.Now : Request["DOB"].ToLmsSystemDate();
            objPatientMaster.REGISTEREDATE = addmissionDate;
            objPatientMaster.DOCTORTOCONSULT = Convert.ToString(Request["DOCTORTOCONSULT"]);
            objPatientMaster.CONSULTINGFEE = string.IsNullOrEmpty(Convert.ToString(Request["CONSULTINGFEE"])) ? 0 : Convert.ToDouble(Convert.ToString(Request["CONSULTINGFEE"]));
            objPatientMaster.CREATEDDATE = addmissionDate;

            var savePatientDetails = _objIPatient.SavePatient(objPatientMaster);

            return RedirectToAction("ViewPatient", new { PatientId = savePatientDetails, viewMessage = "Patient Details Saved Successfully" });
        }

        public ActionResult DeletePatient(int PatientId)
        {
            var deletPatient = _objIPatient.DeletePatient(PatientId);
            return RedirectToAction("ViewAllPatient", new { viewMessage = "Patient Detail Deleted Successfully" });
        }
        public ActionResult ViewOutPatient(int PatientId, string viewMessage = "")
        {

            var DiseaseList = _objIAdminOperations.GetAllDiseases();
            var getPatient = _objIPatient.GetOutPatientMasterById(PatientId);
            getPatient.DiseaseDdl = new SelectList(DiseaseList, "DISEASEID", "DISEASENAME");
            if (PatientId > 0 && getPatient.DISEASEID.HasValue)
            {
                getPatient.SelectedDisease = getPatient.DISEASEID.Value;
            }

            if (PatientId > 0 && getPatient.GENDER == 1)
                getPatient.Sex = 1;
            if (PatientId > 0 && getPatient.GENDER == 2)
                getPatient.Sex = 2;
            ViewBag.Message = viewMessage;
            return View(getPatient);
        }
        public ActionResult ViewAllOutPatient(string viewMessage = "", string filterDate = "")
        {
            var formatDate = "MM/dd/yyyy";
            var getAll = _objIPatient.GetAllOutPatient();
            if (!string.IsNullOrEmpty(filterDate))
            {
                getAll = getAll.Where(dt => dt.CREATEDATE != null & dt.CREATEDATE.Value.ToString(formatDate) == filterDate).ToList();
            }
            ViewBag.Message = viewMessage;
            var result = getAll.OrderByDescending(x => x.CREATEDATE.Value).ToList();
            return View(result);
        }
        [HttpPost]
        public ActionResult EditOutPatient(lmsOutPatientMaster objPatient)
        {
            objPatient.DISEASEID = objPatient.SelectedDisease;
            if (objPatient.Sex == 1 || objPatient.Sex == 2)
                objPatient.GENDER = objPatient.Sex;
            objPatient.CREATEDATE = DateTime.Now;
            objPatient.DOB = Request["DOB"] == null ? DateTime.Now : Request["DOB"].ToLmsSystemDate();
            objPatient.CONSULTINFEE = Convert.ToDouble(Request["CONSULTINFEE"]);
            objPatient.CONSULTINGDOCTOR = Convert.ToString(Request["CONSULTINGDOCTOR"]);
            objPatient.DISEASEID = objPatient.SelectedDisease;
            var savePatientDetails = _objIPatient.SaveOutPatient(objPatient);
            return RedirectToAction("ViewOutPatient", new { PatientId = savePatientDetails, viewMessage = "Patient Details Saved Successfully" });
        }
        public ActionResult DeleteOutPatient(int PatientId)
        {
            var deletPatient = _objIPatient.DeleteOutPatient(PatientId);
            return RedirectToAction("ViewAllOutPatient", new { viewMessage = "Patient Detail Deleted Successfully" });
        }
        public ActionResult ViewOutPatientDetail(string PatientId, string opMasterId = "0", string viewMessage = "")
        {
            ViewBag.OpMasterId = opMasterId;
            var getPatient = _objIPatient.GetOutPatientDetailsById(Convert.ToInt32(PatientId));
            ViewBag.Message = viewMessage;
            return View(getPatient);
        }
        public ActionResult ViewAllOutPatientDetail(int outPatientId, string viewMessage = "")
        {
            var getAll = _objIPatient.GetAllOutPatientDetails(outPatientId);
            ViewBag.OutPatientId = Convert.ToString(outPatientId);

            ViewBag.Message = viewMessage;
            return View(getAll);
        }
        [HttpPost]
        public ActionResult EditOutPatientDetail(lmsOutPatientDetail objPatient)
        {
            var hiddenMasterId = Convert.ToString(Request["OPMASTERID"]);
            objPatient.OPMASTERID = Convert.ToInt16(hiddenMasterId);
            objPatient.CREATEDDATE = DateTime.Now;
            var savePatientDetails = _objIPatient.SaveOutPatientDetail(objPatient);
            return RedirectToAction("ViewAllOutPatientDetail", new { outPatientId = hiddenMasterId, viewMessage = "Patient Details Saved Successfully" });
        }
        public ActionResult DeleteOutPatientDetail(int PatientId)
        {
            var deletPatient = _objIPatient.DeleteOutPatientDetail(PatientId);
            return RedirectToAction("ViewAllOutPatientDetail", new { viewMessage = "Patient Detail Deleted Successfully" });
        }


    }
}

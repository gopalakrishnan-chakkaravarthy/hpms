using Lab.Management.Common;
using Lab.Management.Engine.Service;
using Lab.Management.Entities;
using Lab.Management.Entities.Model;
using Lab.Management.Utils.QrCode;
using System;
using System.Web.Mvc;

namespace LabManagement.System.Controllers
{
    public class AdminController : BaseController
    {
        private readonly IAdminOperations _objIAdminOperations;

        public AdminController(IAdminOperations objIAdminOperations)
        {
            _objIAdminOperations = objIAdminOperations;
        }

        public ActionResult ViewCity(int cityId, string viewMessage = "")
        {
            var getCity = _objIAdminOperations.GetCityDetailsById(cityId);
            ViewBag.Message = viewMessage;
            return View(getCity);
        }

        public ActionResult ViewAllCity(string viewMessage = "")
        {
            var getAll = _objIAdminOperations.GetAllCity();
            ViewBag.Message = viewMessage;
            return View(getAll);
        }

        [HttpPost]
        public ActionResult EditCity(lmsCityMaster objcityMaster)
        {
            var saveCityDetails = _objIAdminOperations.SaveCity(objcityMaster);
            //ViewBag.Message = viewMessage;
            return RedirectToAction("ViewCity", new { cityId = saveCityDetails, viewMessage = "City Details Saved Successfully" });
        }

        public ActionResult DeleteCity(int cityId)
        {
            var deletCity = _objIAdminOperations.DeleteCity(cityId);
            return RedirectToAction("ViewAllCity", new { viewMessage = "City Detail Deleted Successfully" });
        }

        public ActionResult ViewState(int StateId, string viewMessage = "")
        {
            var getState = _objIAdminOperations.GetStateDetailsById(StateId);
            ViewBag.Message = viewMessage;
            return View(getState);
        }

        public ActionResult ViewAllState(string viewMessage = "")
        {
            var getAll = _objIAdminOperations.GetAllState();
            ViewBag.Message = viewMessage;
            return View(getAll);
        }

        [HttpPost]
        public ActionResult EditState(lmsStateMaster objStateMaster)
        {
            var saveStateDetails = _objIAdminOperations.SaveState(objStateMaster);
            //ViewBag.Message = viewMessage;
            return RedirectToAction("ViewState", new { StateId = saveStateDetails, viewMessage = "State Details Saved Successfully" });
        }

        public ActionResult DeleteState(int StateId)
        {
            var deletState = _objIAdminOperations.DeleteState(StateId);
            return RedirectToAction("ViewAllState", new { viewMessage = "State Detail Deleted Successfully" });
        }

        public ActionResult ViewRole(int RoleId, string viewMessage = "")
        {
            var getRole = _objIAdminOperations.GetRoleDetailsById(RoleId);
            ViewBag.Message = viewMessage;
            return View(getRole);
        }

        public ActionResult ViewAllRole(string viewMessage = "")
        {
            var getAll = _objIAdminOperations.GetAllRole();
            ViewBag.Message = viewMessage;
            return View(getAll);
        }

        [HttpPost]
        public ActionResult EditRole(lmsRoleMaster objRoleMaster)
        {
            var saveRoleDetails = _objIAdminOperations.SaveRole(objRoleMaster);
            //ViewBag.Message = viewMessage;
            return RedirectToAction("ViewRole", new { RoleId = saveRoleDetails, viewMessage = "Role Details Saved Successfully" });
        }

        public ActionResult DeleteRole(int RoleId)
        {
            var deletRole = _objIAdminOperations.DeleteRole(RoleId);
            return RedirectToAction("ViewAllRole", new { viewMessage = "Role Detail Deleted Successfully" });
        }

        public ActionResult ViewHospital(int HospitalId, string viewMessage = "")
        {
            var getHospital = _objIAdminOperations.GetHospitalDetailsById(HospitalId);
            var cityList = _objIAdminOperations.GetAllCity();
            var stateList = _objIAdminOperations.GetAllState();
            ViewBag.CityList = new SelectList(cityList, "CITYID", "CITYNAME");
            ViewBag.StateList = new SelectList(stateList, "STATEID", "STATENAME");
            ViewBag.Message = viewMessage;
            return View(getHospital);
        }

        public ActionResult ViewAllHospital(string viewMessage = "")
        {
            var getAll = _objIAdminOperations.GetAllHospital();
            ViewBag.Message = viewMessage;
            return View(getAll);
        }

        [HttpPost]
        public ActionResult EditHospital(lmsHospitalMaster objHospitalMaster)
        {
            var cityId = Convert.ToInt16(Request["cityddl"]);
            var stateId = Convert.ToInt16(Request["stateddl"]);
            objHospitalMaster.CITYID = cityId;
            objHospitalMaster.STATEID = stateId;
            var saveHospitalDetails = _objIAdminOperations.SaveHospital(objHospitalMaster);
            //ViewBag.Message = viewMessage;
            return RedirectToAction("ViewHospital", new { HospitalId = saveHospitalDetails, viewMessage = "Hospital Details Saved Successfully" });
        }

        public ActionResult DeleteHospital(int HospitalId)
        {
            var deletHospital = _objIAdminOperations.DeleteHospital(HospitalId);
            return RedirectToAction("ViewAllHospital", new { viewMessage = "Hospital Detail Deleted Successfully" });
        }

        public ActionResult ViewUser(int UserId, string viewMessage = "")
        {
            var cityList = _objIAdminOperations.GetAllCity();
            var stateList = _objIAdminOperations.GetAllState();
            var roleList = _objIAdminOperations.GetAllRole();
            var getUser = _objIAdminOperations.GetUserDetailsById(UserId);
            if (UserId > 0)
            {
                getUser.SelectedCity = getUser.CITYID.HasValue ? getUser.CITYID.Value : 0;
                getUser.SelectedState = getUser.STATEID.HasValue ? getUser.STATEID.Value : 0;
                getUser.SelectedRole = getUser.ROLEID.HasValue ? getUser.ROLEID.Value : 0;
            }
            getUser.CityDdl = new SelectList(cityList, "CITYID", "CITYNAME");
            getUser.StateDdl = new SelectList(stateList, "STATEID", "STATENAME");
            getUser.RoleDdl = new SelectList(roleList, "ROLEID", "ROLENAME");
            getUser.ISACTIVE = getUser.ISACTIVE.HasValue ? getUser.ISACTIVE.Value : true;
            ViewBag.Message = viewMessage;
            return View(getUser);
        }

        public ActionResult ViewAllUser(string viewMessage = "")
        {
            var getAll = _objIAdminOperations.GetAllUsers();
            ViewBag.Message = viewMessage;
            return View(getAll);
        }

        [HttpPost]
        public ActionResult EditUser(lmsLoginRegistration objUserMaster)
        {
            objUserMaster.CITYID = objUserMaster.SelectedCity;
            objUserMaster.STATEID = objUserMaster.SelectedState;
            objUserMaster.ROLEID = objUserMaster.SelectedRole;
            var saveUserDetails = _objIAdminOperations.SaveUser(objUserMaster);
            return RedirectToAction("ViewUser", new { UserId = saveUserDetails, viewMessage = "User Details Saved Successfully" });
        }

        public ActionResult DeleteUser(int UserId)
        {
            var deletUser = _objIAdminOperations.DeleteUser(UserId);
            return RedirectToAction("ViewAllUser", new { viewMessage = "User Detail Deleted Successfully" });
        }

        public ActionResult ViewDisease(int DiseaseId, string viewMessage = "")
        {
            var getDisease = _objIAdminOperations.GetDiseaseDetailsById(DiseaseId);
            ViewBag.Message = viewMessage;
            return View(getDisease);
        }

        public ActionResult ViewAllDisease(string viewMessage = "")
        {
            var getAll = _objIAdminOperations.GetAllDiseases();
            ViewBag.Message = viewMessage;
            return View(getAll);
        }

        [HttpPost]
        public ActionResult EditDisease(lmsDiseaseMaster objDiseaseMaster)
        {
            var saveDiseaseDetails = _objIAdminOperations.SaveDisease(objDiseaseMaster);
            //ViewBag.Message = viewMessage;
            return RedirectToAction("ViewDisease", new { DiseaseId = saveDiseaseDetails, viewMessage = "Disease Details Saved Successfully" });
        }

        public ActionResult DeleteDisease(int DiseaseId)
        {
            var deletDisease = _objIAdminOperations.DeleteDisease(DiseaseId);
            return RedirectToAction("ViewAllDisease", new { viewMessage = "Disease Detail Deleted Successfully" });
        }

        public ActionResult ViewTemplate(int templateId, string viewMessage = "")
        {
            var getTemplate = _objIAdminOperations.GetTemplateDetailsById(templateId);
            ViewBag.TemlpateContent = string.IsNullOrEmpty(getTemplate.TEMPLATEDETAILS) ? "" : getTemplate.TEMPLATEDETAILS;
            ViewBag.Message = viewMessage;
            return View(getTemplate);
        }

        public ActionResult ViewAllTemplate(string viewMessage = "")
        {
            var getAll = _objIAdminOperations.GetAllTemplate();
            ViewBag.Message = viewMessage;
            return View(getAll);
        }

        [HttpPost]
        [AllowAnonymous]
        //[AllowHtmlAttribute]
        public ActionResult EditTemplate(lmsTemplateMaster objTemplateModel)
        {
            var saveCityDetails = _objIAdminOperations.SaveTemplate(objTemplateModel);
            return Json(saveCityDetails, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteTemplate(int templateId)
        {
            var deletCity = _objIAdminOperations.DeleteTemplate(templateId);
            return RedirectToAction("ViewAllTemplate", new { viewMessage = "Template Detail Deleted Successfully" });
        }

        public ActionResult SaveDataArchival()
        {
            var selectedOption = Request["sltOption"];
            var fromDate = Request["fromDate"] == null ? DateTime.Now : Request["fromDate"].ToLmsSystemDate();
            var toDate = Request["toDate"] == null ? DateTime.Now : Request["toDate"].ToLmsSystemDate();
            _objIAdminOperations.DataArchival(selectedOption, fromDate, toDate);
            ViewBag.Message = "Data Archived successfully";
            return View("DataArchival");
        }

        [HttpPost]
        public ActionResult GenerateQrCode(QRCodeModel qRCodeModel)
        {
            qRCodeModel.QRCodeImagePath = qRCodeModel.QRCodeText.GenerateQrCode();
            return Json(qRCodeModel.QRCodeImagePath, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DataArchival()
        {
            return View();
        }

        public ActionResult ViewDrugDosage(int id, string viewMessage = "")
        {
            var getDrugDosage = _objIAdminOperations.GetDrugDosageById(id);
            ViewBag.Message = viewMessage;
            return View(getDrugDosage);
        }

        public ActionResult ViewAllDrugDosage(string viewMessage = "")
        {
            var getAll = _objIAdminOperations.GetAllDrugDosage();
            ViewBag.Message = viewMessage;
            return View(getAll);
        }

        [HttpPost]
        public ActionResult EditDrugDosage(lmsDrugDosage objDrugDosage)
        {
            var saveDrugDosageDetails = _objIAdminOperations.SaveDrugDosage(objDrugDosage);
            //ViewBag.Message = viewMessage;
            return RedirectToAction("ViewDrugDosage", new { id = saveDrugDosageDetails, viewMessage = "Drug Dosage Details Saved Successfully" });
        }

        public ActionResult DeleteDrugDosage(int id)
        {
            var deletDrugDosage = _objIAdminOperations.DeleteDrugDosage(id);
            return RedirectToAction("ViewAllDrugDosage", new { viewMessage = "Drug Dosage Detail Deleted Successfully" });
        }

        public ActionResult ViewDrugFrequency(int id, string viewMessage = "")
        {
            var getDrugFrequency = _objIAdminOperations.GetDrugFrequencyById(id);
            ViewBag.Message = viewMessage;
            return View(getDrugFrequency);
        }

        public ActionResult ViewAllDrugFrequency(string viewMessage = "")
        {
            var getAll = _objIAdminOperations.GetAllDrugFrequency();
            ViewBag.Message = viewMessage;
            return View(getAll);
        }

        [HttpPost]
        public ActionResult EditDrugFrequency(lmsDrugFrequency objDrugFrequency)
        {
            var saveDrugFrequencyDetails = _objIAdminOperations.SaveDrugFrequency(objDrugFrequency);
            //ViewBag.Message = viewMessage;
            return RedirectToAction("ViewDrugFrequency", new { id = saveDrugFrequencyDetails, viewMessage = "Drug Frequency Details Saved Successfully" });
        }

        public ActionResult DeleteDrugFrequency(int id)
        {
            var deletDrugFrequency = _objIAdminOperations.DeleteDrugFrequency(id);
            return RedirectToAction("ViewAllDrugFrequency", new { viewMessage = "Drug Frequency Detail Deleted Successfully" });
        }
    }
}

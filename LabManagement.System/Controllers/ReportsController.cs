using Lab.Management.Common;
using Lab.Management.Engine.Service;
using Lab.Management.Entities;
using LabManagement.System.Common;
using System;
using System.Web.Mvc;

namespace LabManagement.System.Controllers
{
    public class ReportsController : BaseController
    {
        private ISurgeryNotes surgeryNotes;
        private IOtherCaseSheets otherCaseSheets;
        private IObstericAdmissionSheetReports obstericAdmissionSheetReports;
        private ILabourNotes labourNotes;
        public ReportsController(ISurgeryNotes surgeryNotes,

            IOtherCaseSheets otherCaseSheets,
             IObstericAdmissionSheetReports obstericAdmissionSheetReports,
             ILabourNotes labourNotes)
        {
            this.surgeryNotes = surgeryNotes;
            this.otherCaseSheets = otherCaseSheets;
            this.obstericAdmissionSheetReports = obstericAdmissionSheetReports;
            this.labourNotes = labourNotes;
        }

        #region SurgeryNotes

        public ActionResult ViewSurgeryNotes(int id, string viewMessage = "")
        {
            var data = surgeryNotes.GetById(id);
            ViewBag.Message = viewMessage;
            return View(data);
        }

        public ActionResult ViewAllSurgeryNotes(string filterDate = "", string viewMessage = "")
        {
            var filterByData = (filterDate.stringIsNotNull() ? filterDate.ToLmsSystemDate() : DateTime.Now).ToShortDateString();
            var allData = surgeryNotes.GetAll(filterByData);
            ViewBag.Message = viewMessage;
            return View(allData);
        }

        [HttpPost]
        public ActionResult EditSurgeryNotes(lmsSurgeryNote data)
        {
            if (!data.CREDATEDDATE.HasValue)
            {
                data.CREDATEDDATE = DateTime.Now;
            }
            var saveData = surgeryNotes.Save(data);
            //ViewBag.Message = viewMessage;
            return RedirectToAction("ViewSurgeryNotes", new { id = saveData, viewMessage = "Surgery Notes Saved Successfully" });
        }

        public ActionResult DeleteSurgeryNotes(int id)
        {
            var deletData = surgeryNotes.Delete(id);
            return RedirectToAction("ViewAllSurgeryNotes", new { viewMessage = "Surgery Notes Deleted Successfully" });
        }

        public ActionResult GenerateSurgeryNotes(int id)
        {
            var data = surgeryNotes.GetById(id);
            return View(data);
        }

        #endregion SurgeryNotes

        #region ObstericAdmissionSheet

        public ActionResult ViewObstetricAdmissionSheet(int id, string viewMessage = "")
        {
            var data = obstericAdmissionSheetReports.GetById(id);
            ViewBag.Message = viewMessage;
            return View(data);
        }

        public ActionResult ViewAllObstetricAdmissionSheet(string filterDate = "", string viewMessage = "")
        {
            var filterByData = (filterDate.stringIsNotNull() ? filterDate.ToLmsSystemDate() : DateTime.Now).ToShortDateString();
            var allData = obstericAdmissionSheetReports.GetAll(filterByData);
            ViewBag.Message = viewMessage;
            return View(allData);
        }

        [HttpPost]
        public ActionResult EditObstetricAdmissionSheet(lmsObstericAdmissionSheet data)
        {
            if (!data.CREATEDDATE.HasValue)
            {
                data.CREATEDDATE = DateTime.Now;
            }
            var saveData = obstericAdmissionSheetReports.Save(data);
            //ViewBag.Message = viewMessage;
            return RedirectToAction("ViewObstetricAdmissionSheet", new { id = saveData, viewMessage = "Obstetric Admission Sheet Saved Successfully" });
        }

        public ActionResult DeleteObstetricAdmissionSheet(int id)
        {
            var deletData = obstericAdmissionSheetReports.Delete(id);
            return RedirectToAction("ViewAllObstetricAdmissionSheet", new { viewMessage = "Obstetric Admission Sheet Deleted Successfully" });
        }

        public ActionResult GenerateObstetricAdmissionSheet(int id)
        {
            var data = obstericAdmissionSheetReports.GetById(id);
            return View(data);
        }

        #endregion ObstericAdmissionSheet

        #region OtherCaseSheets

        public ActionResult ViewOtherCaseSheets(int id, string viewMessage = "")
        {
            var data = otherCaseSheets.GetById(id);
            ViewBag.Message = viewMessage;
            return View(data);
        }

        public ActionResult ViewAllOtherCaseSheets(string filterDate = "", string viewMessage = "")
        {
            var filterByData = (filterDate.stringIsNotNull() ? filterDate.ToLmsSystemDate() : DateTime.Now).ToShortDateString();
            var allData = otherCaseSheets.GetAll(filterByData);
            ViewBag.Message = viewMessage;
            return View(allData);
        }

        [HttpPost]
        public ActionResult EditOtherCaseSheets(lmsOtherCaseSheet data)
        {
            if (!data.CREDATEDDATE.HasValue)
            {
                data.CREDATEDDATE = DateTime.Now;
            }
            var saveData = otherCaseSheets.Save(data);
            //ViewBag.Message = viewMessage;
            return RedirectToAction("ViewOtherCaseSheets", new { id = saveData, viewMessage = "Case Sheet Saved Successfully" });
        }

        public ActionResult DeleteOtherCaseSheets(int id)
        {
            var deletData = otherCaseSheets.Delete(id);
            return RedirectToAction("ViewAllOtherCaseSheets", new { viewMessage = "Case Sheet Deleted Successfully" });
        }

        public ActionResult GenerateOtherCaseSheets(int id)
        {
            var data = otherCaseSheets.GetById(id);
            return View(data);
        }

        #endregion OtherCaseSheets

        #region LabourNotes

        public ActionResult ViewLabourNotes(int id, string viewMessage = "")
        {
            var data = labourNotes.GetById(id);
            ViewBag.Message = viewMessage;
            return View(data);
        }

        public ActionResult ViewAllLabourNotes(string filterDate = "", string viewMessage = "")
        {
            var filterByData = (filterDate.stringIsNotNull() ? filterDate.ToLmsSystemDate() : DateTime.Now).ToShortDateString();
            var allData = labourNotes.GetAll(filterByData);
            ViewBag.Message = viewMessage;
            return View(allData);
        }

        [HttpPost]
        public ActionResult EditLabourNotes(lmsLabourNote data)
        {
            if (!data.CREATEDATE.HasValue)
            {
                data.CREATEDATE = DateTime.Now;
            }
            var saveData = labourNotes.Save(data);
            //ViewBag.Message = viewMessage;
            return RedirectToAction("ViewLabourNotes", new { id = saveData, viewMessage = "Labour Notes Saved Successfully" });
        }

        public ActionResult DeleteLabourNotes(int id)
        {
            var deletData = labourNotes.Delete(id);
            return RedirectToAction("ViewAllLabourNotes", new { viewMessage = "Labour Notes Deleted Successfully" });
        }

        public ActionResult GenerateLabourNotes(int id)
        {
            var data = labourNotes.GetById(id);
            return View(data);
        }

        #endregion LabourNotes
    }
}

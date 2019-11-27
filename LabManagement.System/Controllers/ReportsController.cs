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

        private IObstericSurgeryNotes obstericSurgeryNotes;
        private IObstericAdmissionSheetReports obstericAdmissionSheetReports;
        private INotes notes;
        private IDeliveryIndication deliveryIndication;
        public ReportsController(ISurgeryNotes surgeryNotes,

            IOtherCaseSheets otherCaseSheets,
            IObstericSurgeryNotes obstericSurgeryNotes,
             IObstericAdmissionSheetReports obstericAdmissionSheetReports,
             INotes notes,
             IDeliveryIndication deliveryIndication)
        {
            this.surgeryNotes = surgeryNotes;
            this.otherCaseSheets = otherCaseSheets;
            this.obstericSurgeryNotes = obstericSurgeryNotes;
            this.obstericAdmissionSheetReports = obstericAdmissionSheetReports;
            this.notes = notes;
            this.deliveryIndication = deliveryIndication;
        }

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
    }
}

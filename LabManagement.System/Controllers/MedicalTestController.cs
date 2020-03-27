using Lab.Management.Engine.Service;
using Lab.Management.Engine.Service.Tax;
using Lab.Management.Entities;
using LabManagement.System.Common;
using LabManagement.System.Enums;
using System.Web.Mvc;

namespace LabManagement.System.Controllers
{
    public class MedicalTestController : Controller
    {
        private readonly IHospitalMaster _objIHospitalMaster;
        private readonly ITaxService taxService;
        public MedicalTestController(IHospitalMaster objIHospitalMaster,
            ITaxService taxService)
        {
            _objIHospitalMaster = objIHospitalMaster;
            this.taxService = taxService;
        }

        public ActionResult ViewMedicalTest(int MedicalTestId, string transactionType = "")
        {
            var getMedicalTest = _objIHospitalMaster.GetMedicalTestDetailsById(MedicalTestId);
            var testFor = _objIHospitalMaster.GetAllMedicalTestFor();
            if (testFor != null)
            {
                getMedicalTest.TestForForDdl = new SelectList(testFor, "TESTFORID", "TESTFOR");
            }
            var testGroup = _objIHospitalMaster.GetAllMedicalTestGroup();
            if (testGroup != null)
            {
                getMedicalTest.GroupForDdl = new SelectList(testGroup, "GROUPID", "GROUPNAME");
            }
            if (MedicalTestId > 0)
            {
                getMedicalTest.SelectedGroup = getMedicalTest.GROUPID.HasValue ? getMedicalTest.GROUPID.Value : 0;
                getMedicalTest.SelectedTestFor = getMedicalTest.TESTFORID.HasValue ? getMedicalTest.TESTFORID.Value : 0;
            }
            var taxDdl = taxService.GetTaxList();
            ViewBag.TaxDdl = taxDdl.GetDropDownList("Key", "Value");
            ViewBag.TransactionType = transactionType;
            return View(getMedicalTest);
        }

        public ActionResult ViewAllMedicalTest(string transactionType = "")
        {
            var getAll = _objIHospitalMaster.GetAllMedicalTest();
            ViewBag.TransactionType = transactionType;
            return View(getAll);
        }

        [HttpPost]
        public ActionResult EditMedicalTest(lmsMedicalTest objMedicalTestMaster)
        {
            objMedicalTestMaster.GROUPID = objMedicalTestMaster.SelectedGroup;
            objMedicalTestMaster.TESTFORID = objMedicalTestMaster.SelectedTestFor;
            var saveMedicalTestDetails = _objIHospitalMaster.SaveMedicalTest(objMedicalTestMaster);
            return RedirectToAction("ViewMedicalTest", new { MedicalTestId = saveMedicalTestDetails, transactionType = nameof(TransactionType.Save) });
        }

        public ActionResult DeleteMedicalTest(int MedicalTestId)
        {
            var deletMedicalTest = _objIHospitalMaster.DeleteMedicalTest(MedicalTestId);
            return RedirectToAction("ViewAllMedicalTest", new { transactionType = nameof(TransactionType.Remove) });
        }

        public ActionResult ViewMedicalTestFor(int id, string transactionType = "")
        {
            var result = _objIHospitalMaster.GetMedicalTestForById(id);

            ViewBag.TransactionType = transactionType;
            return View(result);
        }

        public ActionResult ViewAllMedicalTestFor(string transactionType = "")
        {
            var getAll = _objIHospitalMaster.GetAllMedicalTestFor();
            ViewBag.TransactionType = transactionType;
            return View(getAll);
        }

        [HttpPost]
        public ActionResult EditMedicalTestFor(lmsMedicalTestFor saveData)
        {
            var result = _objIHospitalMaster.SaveMedicalTestFor(saveData);
            return RedirectToAction("ViewMedicalTestFor", new { id = result, transactionType = nameof(TransactionType.Save) });
        }

        public ActionResult DeleteMedicalTestFor(int id)
        {
            var result = _objIHospitalMaster.DeleteMedicalTestFor(id);
            return RedirectToAction("ViewAllMedicalTestFor", new { transactionType = nameof(TransactionType.Remove) });
        }

        public ActionResult ViewMedicalTestGroup(int Id, string transactionType = "")
        {
            var result = _objIHospitalMaster.GetMedicalGroupById(Id);

            ViewBag.TransactionType = transactionType;
            return View(result);
        }

        public ActionResult ViewAllMedicalTestGroup(string transactionType = "")
        {
            var getAll = _objIHospitalMaster.GetAllMedicalTestGroup();
            ViewBag.TransactionType = transactionType;
            return View(getAll);
        }

        [HttpPost]
        public ActionResult EditMedicalTestGroup(lmsMedicalTestGroup saveData)
        {
            var result = _objIHospitalMaster.SaveMedicalTestGroup(saveData);
            return RedirectToAction("ViewMedicalTestGroup", new { id = result, transactionType = nameof(TransactionType.Save) });
        }

        public ActionResult DeleteMedicalTestGroup(int id)
        {
            var result = _objIHospitalMaster.DeleteMedicalTestGroup(id);
            return RedirectToAction("ViewAllMedicalTestGroup", new { transactionType = nameof(TransactionType.Remove) });
        }
    }
}

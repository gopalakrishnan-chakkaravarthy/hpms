using Lab.Management.Engine.Models;
using Lab.Management.Engine.Service.MedicalTest;
using System.Linq;
using System.Web.Mvc;

namespace LabManagement.System.Controllers
{
    public class LabTaxController : Controller
    {
        private ILabTaxService labTaxService;
        public LabTaxController(ILabTaxService labTaxService)
        {
            this.labTaxService = labTaxService;
        }

        public ActionResult Index(int testId)
        {
            var result = labTaxService.GetTaxForTest(testId);
            return PartialView("_Index", result);

        }
        [HttpPost]
        public ActionResult Edit(LabTaxRequest labTaxRequest)
        {
            labTaxService.Save(labTaxRequest);
            return RedirectToAction("Index", new { testId = labTaxRequest.TestId });

        }
        [HttpGet]
        public ActionResult Remove(int lTaxId, int testId)
        {
            labTaxService.Remove(lTaxId);
            return RedirectToAction("Index", new { testId });

        }
        [HttpGet]
        public ActionResult IsExists(int testId, int taxId)
        {
            var isExist = labTaxService.IsExists(testId, taxId);
            return Json(isExist, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult HasDataExists(int testId)
        {
            var taxData = labTaxService.GetTaxForTest(testId);
            var hasDataExists = taxData.Any();
            return Json(hasDataExists, JsonRequestBehavior.AllowGet);
        }

    }
}

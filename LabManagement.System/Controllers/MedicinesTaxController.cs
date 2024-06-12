using Lab.Management.Engine.Models;
using Lab.Management.Engine.Service.Drugs;
using System.Linq;
using System.Web.Mvc;

namespace LabManagement.System.Controllers
{
    public class MedicinesTaxController : BaseController
    {
        private IDrugTaxService drugTaxService;
        public MedicinesTaxController(IDrugTaxService drugTaxService)
        {
            this.drugTaxService = drugTaxService;
        }

        public ActionResult Index(int medicineId)
        {
            var result = drugTaxService.GetTaxForDrugs(medicineId);
            return PartialView("_Index", result);

        }
        [HttpPost]
        public ActionResult Edit(DrugTaxRequest drugTaxRequest)
        {
            drugTaxService.Save(drugTaxRequest);
            return RedirectToAction("Index", new { medicineId = drugTaxRequest.DrugId });

        }
        [HttpGet]
        public ActionResult Remove(int dTaxId, int medicineId)
        {
            drugTaxService.Remove(dTaxId);
            return RedirectToAction("Index", new { medicineId });

        }
        [HttpGet]
        public ActionResult IsExists(int medicineId, int taxId)
        {
            var isExist = drugTaxService.IsExists(medicineId, taxId);
            return Json(isExist, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult HasDataExists(int medicineId)
        {
            var taxData = drugTaxService.GetTaxForDrugs(medicineId);
            var hasDataExists = taxData.Any();
            return Json(hasDataExists, JsonRequestBehavior.AllowGet);
        }
    }
}

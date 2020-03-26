using Lab.Management.Engine.Models;
using Lab.Management.Engine.Service.Drugs;
using System.Linq;
using System.Web.Mvc;

namespace LabManagement.System.Controllers
{
    public class DrugTaxController : BaseController
    {
        private IDrugTaxService drugTaxService;
        public DrugTaxController(IDrugTaxService drugTaxService)
        {
            this.drugTaxService = drugTaxService;
        }

        public ActionResult Index(int drugId)
        {
            var result = drugTaxService.GetTaxForDrugs(drugId);
            return PartialView("_Index", result);

        }
        [HttpPost]
        public ActionResult Edit(DrugTaxRequest drugTaxRequest)
        {
            drugTaxService.Save(drugTaxRequest);
            return RedirectToAction("Index", new { drugId = drugTaxRequest.DrugId });

        }
        [HttpGet]
        public ActionResult Remove(int dTaxId, int drugId)
        {
            drugTaxService.Remove(dTaxId);
            return RedirectToAction("Index", new {  drugId });

        }
        [HttpGet]
        public ActionResult IsExists(int drugId, int taxId)
        {
            var isExist = drugTaxService.IsExists(drugId, taxId);
            return Json(isExist, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult HasDataExists(int drugId)
        {
            var taxData = drugTaxService.GetTaxForDrugs(drugId);
            var hasDataExists = taxData.Any();
            return Json(hasDataExists, JsonRequestBehavior.AllowGet);
        }
    }
}

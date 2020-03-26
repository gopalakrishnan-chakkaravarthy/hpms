using Lab.Management.Engine.Service.Tax;
using Lab.Management.Entities;
using LabManagement.System.Enums;
using System.Web.Mvc;

namespace LabManagement.System.Controllers
{
    public class TaxController : BaseController
    {
        private readonly ITaxService taxService;
        public TaxController(ITaxService taxService)
        {
            this.taxService = taxService;
        }

        public ActionResult Index(string transactionType)
        {
            var result = taxService.GetAll();
            ViewBag.TransactionType = transactionType;
            return View(result);
        }
        public ActionResult ViewTax(int id, string transactionType)
        {
            var result = taxService.Get(id);
            ViewBag.TransactionType = transactionType;
            return View(result);
        }
        [HttpPost]
        public ActionResult Edit(lmsTaxMaster entity)
        {
            entity.ISACTIVE = entity.IsActiveTax;
            taxService.Save(entity);
            var id = entity.TAXID == 0 ? taxService.GetIdByText(entity.TAXNAME) : entity.TAXID;
            return RedirectToAction("ViewTax", new { id , transactionType = nameof(TransactionType.Save) });
        }
        public ActionResult Delete(int id)
        {
            taxService.Remove(id);
            return RedirectToAction("Index", new { transactionType= nameof(TransactionType.Remove) });
        }
    }
}

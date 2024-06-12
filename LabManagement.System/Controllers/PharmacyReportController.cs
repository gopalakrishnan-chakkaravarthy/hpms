using Lab.Management.Common;
using Lab.Management.Engine.Service;
using LabManagement.System.Common;
using System;
using System.Web.Mvc;

namespace LabManagement.System.Controllers
{
    public class PharmacyReportController : BaseController
    {
        private readonly IInvoice objIInvoice;
        public PharmacyReportController(IInvoice objIInvoice)
        {
            this.objIInvoice = objIInvoice;
        }
        //
        // GET: /PharmacyReport/

        public ActionResult SalesReport(string filterFromDate = "", string filterToDate = "")
        {
            if (string.IsNullOrEmpty(filterFromDate) || string.IsNullOrEmpty(filterFromDate))
            {
                return View();
            }
            var billFilterDate = (filterFromDate.stringIsNotNull() ? filterFromDate.ToLmsSystemDate() : DateTime.Now).ToShortDateString();
            var billfilterToDate = (filterToDate.stringIsNotNull() ? filterToDate.ToLmsSystemDate() : DateTime.Now).ToShortDateString();
            var getAll = objIInvoice.GetAllMedicalSalesReport(billFilterDate, billfilterToDate);
            return View(getAll);
        }

    }
}

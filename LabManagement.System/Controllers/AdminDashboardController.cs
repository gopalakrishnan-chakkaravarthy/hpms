using Lab.Management.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabManagement.System.Controllers
{
    public class AdminDashboardController : BaseController
    {
        //
        // GET: /AdminDashboard/
        private readonly IAdminOperations _objIAdminOperations;
        public AdminDashboardController(IAdminOperations objIAdminOperations)
        {
            _objIAdminOperations = objIAdminOperations;
        }
        public ActionResult Index(string filterDate = "")
        {
            
            var resultModel = _objIAdminOperations.GetAdminDashboardInfo();
            return View(resultModel);
        }

    }
}

using Lab.Management.Engine.Service;
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

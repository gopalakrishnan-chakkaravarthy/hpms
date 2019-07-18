using LabManagement.System.Models;
using System.Web.Mvc;

namespace LabManagement.System.Controllers
{
    public class AppErrorController : Controller
    {
        //
        // GET: /AppError/

        public ActionResult Index(ErrorModel errorModel)
        {
            return View(errorModel);
        }
    }
}

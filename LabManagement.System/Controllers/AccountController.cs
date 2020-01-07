using Lab.Management.Common;
using Lab.Management.Engine.Service;
using Lab.Management.Entities;
using LabManagement.System.Common;
using LabManagement.System.Models;
using System.Web.Mvc;
using System.Web.Security;

namespace LabManagement.System.Controllers
{
    [Authorize]
    //[InitializeSimpleMembership]
    public class AccountController : BaseController
    {
        private readonly IAdminOperations _objIAdminOperations;
        //private string userRole;
        public AccountController(IAdminOperations objIAdminOperations)
        {
            _objIAdminOperations = objIAdminOperations;
        }

        // GET: /Account/Login

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (Request.IsAuthenticated && Session["UserInfo"] != null)
            {
                return LoadDefaultView();
            }
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        public ActionResult LoadDefaultView()
        {
            var userRole = Session["UserInfo"] as usp_ValidateUser_Result;

            if (userRole == null)
            {
                return RedirectToAction("Login", "Account");
            }
            return userRole.IsAdmin() || userRole.IsTestUser() ? RedirectToAction("Index", "AdminDashboard") :
            RedirectToAction("ViewAllMedicalBill", "Invoice");
        }

        //
        // POST: /Account/Login

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ConfigurationWrapper.BooleanSettigs(ConfigKey.UseBetaLogin))
            {
                return LoadDefaultView();
            }
            var userInfo = _objIAdminOperations.ValidateUser(model.UserName, model.Password);
            if (ModelState.IsValid && userInfo != null)
            {
                FormsAuthentication.SetAuthCookie(model.UserName, true);
                Session["UserInfo"] = userInfo;
                return LoadDefaultView();
            }

            // If we got this far, something failed, redisplay form
            ModelState.AddModelError("", "The user name or password provided is incorrect.");
            return View(model);
        }

        //
        // POST: /Account/LogOff

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login", "Account");
        }
    }
}

using Lab.Management.Entities;
using LabManagement.System.Models;
using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace LabManagement.System.Controllers
{
    public class BaseController : Controller
    {
        public int LoginId { get; set; }

        private usp_ValidateUser_Result userInfo;
        public usp_ValidateUser_Result UserInfo
        {
            get
            {
                if (userInfo == null && Session["UserInfo"] != null)
                {
                    userInfo = new usp_ValidateUser_Result();
                    userInfo = Session["UserInfo"] as usp_ValidateUser_Result;
                    LoginId = userInfo.LOGINID;
                }
                return userInfo;
            }
        }

        public string UserRole
        {
            get
            {
                if (Session["UserInfo"] != null)
                {
                    var userInfo = Session["UserInfo"] as usp_ValidateUser_Result;
                    return userInfo.ROLENAME;
                }
                return string.Empty;
            }
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var controller = filterContext.RouteData.Values["controller"].ToString();
            var action = filterContext.RouteData.Values["action"].ToString();
            if (controller.ToLower() == "account" && action.ToLower() == "login")
            {
                base.OnActionExecuting(filterContext);
                return;
            }
            if (filterContext.HttpContext.Session["UserInfo"] == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary {
                { "Controller", "Account" },
                { "Action", "Login" }
              });
            }
            base.OnActionExecuting(filterContext);
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            Exception exception = filterContext.Exception;
            filterContext.ExceptionHandled = true;
            var controller = filterContext.RouteData.Values["controller"].ToString();
            var action = filterContext.RouteData.Values["action"].ToString();
            var errorData = new ErrorModel
            {
                ErrorController = controller,
                ErrorAction = action,
                Message = exception.Message
            };
            filterContext.Result = RedirectToAction("Index", "AppError", errorData);
        }
    }
}

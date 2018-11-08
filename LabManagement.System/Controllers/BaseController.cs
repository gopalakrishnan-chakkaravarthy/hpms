using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab.Management.Entities;
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
            if (filterContext.HttpContext.Session["UserInfo"] == null)
            {
                filterContext.Result = new RedirectResult("~/Account/Login");
                return;
            }
            base.OnActionExecuting(filterContext);
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
        }

    }
}

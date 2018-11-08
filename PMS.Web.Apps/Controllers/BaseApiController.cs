using PMS.Web.Apps.Filters;
using PMS.Web.Apps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace PMS.Web.Apps.Controllers
{
    [AppAuthorization]
    public class BaseApiController : ApiController
    {
        private QueryStringModel appQueryFields { get; set; }
        public QueryStringModel AppQueryFields { get; set; }

        private void SetUserModel()
        {
            var requestHeaders = this.ControllerContext.Request.Headers;
        }
        
    }
}

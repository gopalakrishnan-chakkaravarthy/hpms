using LabManagement.System.DIResolver;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
namespace LabManagement.System
{
    public class MvcApplication : global::System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            //WebApiConfig.Register(GlobalConfiguration.Configuration);
            //FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //AuthConfig.RegisterAuth();
            StructuremapMvc.Start();
        }
    }
}
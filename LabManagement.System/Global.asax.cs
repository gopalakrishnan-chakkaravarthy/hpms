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
            log4net.Config.XmlConfigurator.Configure();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            StructuremapMvc.Start();
        }
    }
}

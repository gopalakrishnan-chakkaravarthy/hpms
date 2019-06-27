using Lab.Management.Engine;
using Lab.Management.Engine.StructureMapContainer;
using System.Web.Mvc;

namespace LabManagement.System.DIResolver
{
    public class StructuremapMvc
    {
        public static void Start()
        {
            var container = Ioc.Initialize();
            DependencyEngineResolver.ResolveDepedency();
            ControllerBuilder.Current.SetControllerFactory(typeof(StructureMapControllerFactory));
            //DependencyResolver.SetResolver(new StructureMapDependencyScope(container));
        }
    }
}

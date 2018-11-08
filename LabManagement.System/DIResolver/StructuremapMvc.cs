using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Dependencies;
using System.Web.Mvc;
using Microsoft.Practices.ServiceLocation;
using StructureMap;
using System.Linq;
using Lab.Management.Engine;
using Lab.Management.Engine.StructureMapContainer;
using LabManagement.System.DIResolver;

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
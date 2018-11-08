using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;

namespace LabManagement.System.DIResolver
{
    /// <summary>
    /// Wrapper for IDependencyResolver so that StructureMap plays nicely with built in mvc 4 dependency resolution. 
    /// </summary>
    public class StructureMapDependencyResolver : StructureMapDependencyScope
    {
        public StructureMapDependencyResolver(IContainer container)
            : base(container)
        {
        }

        public IDependencyScope BeginScope()
        {
            var child = Container.GetNestedContainer();
            return new StructureMapDependencyResolver(child);
        }
    }
}
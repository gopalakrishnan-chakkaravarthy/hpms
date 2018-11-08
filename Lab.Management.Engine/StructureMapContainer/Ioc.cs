using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StructureMap;
namespace Lab.Management.Engine.StructureMapContainer
{
    public static class Ioc
    {
        public static IContainer Initialize()
        {
            ObjectFactory.Initialize(
                x =>
                {
                    x.Scan(scan =>
                    {
                        scan.TheCallingAssembly();
                        scan.WithDefaultConventions();
                    });
                });
            return ObjectFactory.Container;
        }
    }
}

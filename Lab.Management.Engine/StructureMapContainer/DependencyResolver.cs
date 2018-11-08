using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StructureMap;
using Lab.Management.Logger;
using System.Data.Entity;
using Lab.Management.Entities;
namespace Lab.Management.Engine
{
    public static class DependencyEngineResolver
    {
        public static void ResolveDepedency()
        {

            ObjectFactory.Initialize(x =>
            {
                x.Scan(y =>
                {
                    y.TheCallingAssembly();
                    y.WithDefaultConventions();
                });
                x.For<DbContext>().Use<LabManagementEntities>();
                x.For<IAppLogger>().Use<AppLogger>();
                x.For<IAdminOperations>().Use<AdminOperations>();
                x.For<IPatient>().Use<Patient>();
                x.For<IInvoice>().Use<Invoice>();
                x.For<IHospitalMaster>().Use<HospitalMaster>();
            });
        }
    }
}

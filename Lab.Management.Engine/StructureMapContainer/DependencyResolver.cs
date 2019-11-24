using Lab.Management.Engine.Infrastructure;
using Lab.Management.Engine.Service;
using Lab.Management.Entities;
using Lab.Management.Logger;
using StructureMap;
using System.Data.Entity;

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
                x.For<IObstericAdmissionSheetReports>().Use<ObstericAdmissionSheetReports>();
                x.For<IObstericSurgeryNotes>().Use<ObstericSurgeryNotes>();
                x.For<IDeliveryIndication>().Use<DeliveryIndication>();
                x.For<ISurgeryNotes>().Use<ISurgeryNotes>();
                x.For<IOtherCaseSheets>().Use<OtherCaseSheets>();
                x.For<INotes>().Use<Notes>();
            });
        }
    }
}

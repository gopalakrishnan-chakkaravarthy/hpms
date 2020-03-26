using Lab.Management.Engine.Infrastructure;
using Lab.Management.Engine.Infrastructure.Drugs;
using Lab.Management.Engine.Infrastructure.Tax;
using Lab.Management.Engine.Reporsitory.Interface;
using Lab.Management.Engine.Reporsitory.Service;
using Lab.Management.Engine.Service;
using Lab.Management.Engine.Service.Drugs;
using Lab.Management.Engine.Service.Tax;
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

                x.For<ISurgeryNotes>().Use<SurgeryNotes>();
                x.For<IOtherCaseSheets>().Use<OtherCaseSheets>();
                x.For<ILabourNotes>().Use<LabourNotes>();
                x.For<ITaxRepository>().Use<TaxRepository>();
                x.For<ITaxService>().Use<TaxService>();
                x.For<IDrugDetailsRepository>().Use<DrugDetailsRepository>();
                x.For<IDrugDetailService>().Use<DrugDetailService>();
                x.For<ITaxRepository>().Use<TaxRepository>();
                x.For<IDrugTaxService>().Use<DrugTaxService>();
                

            });
        }
    }
}

﻿

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace Lab.Management.Entities
{

using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

using System.Data.Entity.Core.Objects;
using System.Linq;


public partial class LabManagementEntities : DbContext
{
    public LabManagementEntities()
        : base("name=LabManagementEntities")
    {

    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }


    public virtual DbSet<lmsBed> lmsBeds { get; set; }

    public virtual DbSet<lmsCityMaster> lmsCityMasters { get; set; }

    public virtual DbSet<lmsDischargeSummary> lmsDischargeSummaries { get; set; }

    public virtual DbSet<lmsDiseaseMaster> lmsDiseaseMasters { get; set; }

    public virtual DbSet<lmsDrug> lmsDrugs { get; set; }

    public virtual DbSet<lmsHospitalMaster> lmsHospitalMasters { get; set; }

    public virtual DbSet<lmsInPatientBilling> lmsInPatientBillings { get; set; }

    public virtual DbSet<lmsInventory> lmsInventories { get; set; }

    public virtual DbSet<lmsLoginRegistration> lmsLoginRegistrations { get; set; }

    public virtual DbSet<lmsMedicalBilling> lmsMedicalBillings { get; set; }

    public virtual DbSet<lmsMedicalTest> lmsMedicalTests { get; set; }

    public virtual DbSet<lmsPatientRegistration> lmsPatientRegistrations { get; set; }

    public virtual DbSet<lmsRoleMaster> lmsRoleMasters { get; set; }

    public virtual DbSet<lmsScanReportDetail> lmsScanReportDetails { get; set; }

    public virtual DbSet<lmsScanReportMaster> lmsScanReportMasters { get; set; }

    public virtual DbSet<lmsScan> lmsScans { get; set; }

    public virtual DbSet<lmsStateMaster> lmsStateMasters { get; set; }

    public virtual DbSet<lmsVendorBilling> lmsVendorBillings { get; set; }

    public virtual DbSet<lmsVendor> lmsVendors { get; set; }

    public virtual DbSet<lmsWard> lmsWards { get; set; }

    public virtual DbSet<lmsDischargeBill> lmsDischargeBills { get; set; }

    public virtual DbSet<lmsInvestigationReport> lmsInvestigationReports { get; set; }

    public virtual DbSet<lmsLaboratoryBilling> lmsLaboratoryBillings { get; set; }

    public virtual DbSet<lmsLaboratoryBillingDetail> lmsLaboratoryBillingDetails { get; set; }

    public virtual DbSet<lmsMedicalBillingDetail> lmsMedicalBillingDetails { get; set; }

    public virtual DbSet<lmsPatientDischargeSummary> lmsPatientDischargeSummaries { get; set; }

    public virtual DbSet<lmsPatientTemplate> lmsPatientTemplates { get; set; }

    public virtual DbSet<lmsSignatureMaster> lmsSignatureMasters { get; set; }

    public virtual DbSet<lmsTemplateMaster> lmsTemplateMasters { get; set; }

    public virtual DbSet<lmsUltrSonogramReportOne> lmsUltrSonogramReportOnes { get; set; }

    public virtual DbSet<lmsUltrSonogramReportTwo> lmsUltrSonogramReportTwoes { get; set; }

    public virtual DbSet<lmsGeneralDischargeSummary> lmsGeneralDischargeSummaries { get; set; }

    public virtual DbSet<lmsGynacDischargeSummary> lmsGynacDischargeSummaries { get; set; }

    public virtual DbSet<lmsMedicalTestFor> lmsMedicalTestFors { get; set; }

    public virtual DbSet<lmsMedicalTestGroup> lmsMedicalTestGroups { get; set; }

    public virtual DbSet<lmsDrugDosage> lmsDrugDosages { get; set; }

    public virtual DbSet<lmsDrugFrequency> lmsDrugFrequencies { get; set; }

    public virtual DbSet<lmsPatientBooking> lmsPatientBookings { get; set; }

    public virtual DbSet<lmsPatientPrescription> lmsPatientPrescriptions { get; set; }

    public virtual DbSet<lmsPatientReportStore> lmsPatientReportStores { get; set; }

    public virtual DbSet<lmsObstericAdmissionSheet> lmsObstericAdmissionSheets { get; set; }

    public virtual DbSet<lmsOtherCaseSheet> lmsOtherCaseSheets { get; set; }

    public virtual DbSet<lmsSurgeryNote> lmsSurgeryNotes { get; set; }

    public virtual DbSet<lmsLabourNote> lmsLabourNotes { get; set; }

    public virtual DbSet<lmsDrugDetail> lmsDrugDetails { get; set; }


    [DbFunction("LabManagementEntities", "SplitToTable")]
    public virtual IQueryable<string> SplitToTable(string iNPUT, string sPLITBY)
    {

        var iNPUTParameter = iNPUT != null ?
            new ObjectParameter("INPUT", iNPUT) :
            new ObjectParameter("INPUT", typeof(string));


        var sPLITBYParameter = sPLITBY != null ?
            new ObjectParameter("SPLITBY", sPLITBY) :
            new ObjectParameter("SPLITBY", typeof(string));


        return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<string>("[LabManagementEntities].[SplitToTable](@INPUT, @SPLITBY)", iNPUTParameter, sPLITBYParameter);
    }


    public virtual int usp_DeleteDrugs(string drugIds)
    {

        var drugIdsParameter = drugIds != null ?
            new ObjectParameter("DrugIds", drugIds) :
            new ObjectParameter("DrugIds", typeof(string));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_DeleteDrugs", drugIdsParameter);
    }


    public virtual int usp_DeleteLaboratoryBilling(string tESTIds)
    {

        var tESTIdsParameter = tESTIds != null ?
            new ObjectParameter("TESTIds", tESTIds) :
            new ObjectParameter("TESTIds", typeof(string));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_DeleteLaboratoryBilling", tESTIdsParameter);
    }


    public virtual int usp_DeleteMedicalBilling(string drugIds)
    {

        var drugIdsParameter = drugIds != null ?
            new ObjectParameter("DrugIds", drugIds) :
            new ObjectParameter("DrugIds", typeof(string));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_DeleteMedicalBilling", drugIdsParameter);
    }


    public virtual ObjectResult<usp_GetDrugDdl_Result> usp_GetDrugDdl()
    {

        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<usp_GetDrugDdl_Result>("usp_GetDrugDdl");
    }


    public virtual ObjectResult<usp_GetDrugStocks_Result> usp_GetDrugStocks()
    {

        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<usp_GetDrugStocks_Result>("usp_GetDrugStocks");
    }


    public virtual ObjectResult<usp_GetExpiryDrugsByDays_Result> usp_GetExpiryDrugsByDays(Nullable<int> days)
    {

        var daysParameter = days.HasValue ?
            new ObjectParameter("Days", days) :
            new ObjectParameter("Days", typeof(int));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<usp_GetExpiryDrugsByDays_Result>("usp_GetExpiryDrugsByDays", daysParameter);
    }


    public virtual ObjectResult<usp_GetInPatientDetails_Result> usp_GetInPatientDetails(string filterDate)
    {

        var filterDateParameter = filterDate != null ?
            new ObjectParameter("filterDate", filterDate) :
            new ObjectParameter("filterDate", typeof(string));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<usp_GetInPatientDetails_Result>("usp_GetInPatientDetails", filterDateParameter);
    }


    public virtual ObjectResult<usp_GetMedicalBillsByDate_Result> usp_GetMedicalBillsByDate(string filterDate)
    {

        var filterDateParameter = filterDate != null ?
            new ObjectParameter("filterDate", filterDate) :
            new ObjectParameter("filterDate", typeof(string));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<usp_GetMedicalBillsByDate_Result>("usp_GetMedicalBillsByDate", filterDateParameter);
    }


    public virtual ObjectResult<usp_GetMedicalProfitLoss_Result> usp_GetMedicalProfitLoss(string filterDate)
    {

        var filterDateParameter = filterDate != null ?
            new ObjectParameter("filterDate", filterDate) :
            new ObjectParameter("filterDate", typeof(string));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<usp_GetMedicalProfitLoss_Result>("usp_GetMedicalProfitLoss", filterDateParameter);
    }


    public virtual ObjectResult<usp_GetOutPatients_Result> usp_GetOutPatients(string filterDate)
    {

        var filterDateParameter = filterDate != null ?
            new ObjectParameter("filterDate", filterDate) :
            new ObjectParameter("filterDate", typeof(string));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<usp_GetOutPatients_Result>("usp_GetOutPatients", filterDateParameter);
    }


    public virtual ObjectResult<usp_GetPatientDdlForBilling_Result> usp_GetPatientDdlForBilling()
    {

        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<usp_GetPatientDdlForBilling_Result>("usp_GetPatientDdlForBilling");
    }


    public virtual ObjectResult<usp_ValidateUser_Result> usp_ValidateUser(string userEmail)
    {

        var userEmailParameter = userEmail != null ?
            new ObjectParameter("userEmail", userEmail) :
            new ObjectParameter("userEmail", typeof(string));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<usp_ValidateUser_Result>("usp_ValidateUser", userEmailParameter);
    }


    public virtual int USP_DATAARCHIVAL(string aRCHIVETYPE, Nullable<System.DateTime> fROMDATE, Nullable<System.DateTime> tODATE)
    {

        var aRCHIVETYPEParameter = aRCHIVETYPE != null ?
            new ObjectParameter("ARCHIVETYPE", aRCHIVETYPE) :
            new ObjectParameter("ARCHIVETYPE", typeof(string));


        var fROMDATEParameter = fROMDATE.HasValue ?
            new ObjectParameter("FROMDATE", fROMDATE) :
            new ObjectParameter("FROMDATE", typeof(System.DateTime));


        var tODATEParameter = tODATE.HasValue ?
            new ObjectParameter("TODATE", tODATE) :
            new ObjectParameter("TODATE", typeof(System.DateTime));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("USP_DATAARCHIVAL", aRCHIVETYPEParameter, fROMDATEParameter, tODATEParameter);
    }

}

}


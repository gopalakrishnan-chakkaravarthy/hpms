using Lab.Management.Engine.Models;
using Lab.Management.Entities;
using System.Collections.Generic;

namespace Lab.Management.Engine.Service
{
    public interface IInvoice
    {
        lmsMedicalBilling GetMedicalBillDetailsById(int BillId);

        IEnumerable<BillPrintModel> GetDetailListByBillId(int billId);

        IList<lmsMedicalBilling> GetAllMedicalBill(int patientId = 0, string filterDate = "");

        int SaveMedicalBill(lmsMedicalBilling objlmsMedicalBilling);

        int DeleteMedicalBill(int BillId);

        lmsLaboratoryBilling GetLaboratoryBillingDetailsById(int BillId);

        IList<lmsLaboratoryBilling> GetAllLaboratoryBilling(string filterDate = "");

        int SaveLaboratoryBilling(lmsLaboratoryBilling objlmsLaboratoryBilling);

        int DeleteLaboratoryBilling(int BillId);

        lmsPatientDischargeSummary GetDischargeSummaryDetailsById(int ReportId);

        IList<lmsPatientDischargeSummary> GetAllDischargeSummary();

        int SaveDischargeSummary(lmsPatientDischargeSummary objlmsPatientDischargeSummary);

        int DeleteDischargeSummary(int ReportId);

        lmsUltrSonogramReportOne GetUltraSonagramReportOneDetailsById(int ReportId);

        IList<lmsUltrSonogramReportOne> GetAllUltraSonagramReportOne();

        int SaveUltraSonagramReportOne(lmsUltrSonogramReportOne objlmsUltrSonogramReportOne);

        int DeleteUltraSonagramReportOne(int ReportId);

        lmsUltrSonogramReportTwo GetUltraSonagramReportTwoDetailsById(int ReportId);

        IList<lmsUltrSonogramReportTwo> GetAllUltraSonagramReportTwo();

        int SaveUltraSonagramReportTwo(lmsUltrSonogramReportTwo objlmsUltrSonogramReportTwo);

        int DeleteUltraSonagramReportTwo(int ReportId);

        lmsInvestigationReport GetInvestigationReportDetailsById(int ReportId);

        IList<lmsInvestigationReport> GetAllInvestigationReport();

        int SaveInvestigationReport(lmsInvestigationReport objlmsInvestigationReport);

        int DeleteInvestigationReport(int ReportId);

        lmsDischargeBill GetDischargeBillDetailsById(int BillId);

        IList<lmsDischargeBill> GetAllDischargeBill();

        int SaveDischargeBill(lmsDischargeBill objlmsInvestigationReport);

        int DeleteDischargeBill(int BillId);

        int MultiDeleteRows(string deleteSelectedRows);

        lmsGeneralDischargeSummary GetGenDischargeSummaryDetailsById(int ReportId);

        IList<lmsGeneralDischargeSummary> GetAllGenDischargeSummary();

        int SaveGenDischargeSummary(lmsGeneralDischargeSummary objlmsPatientDischargeSummary);

        int DeleteGenDischargeSummary(int ReportId);

        lmsGynacDischargeSummary GetGynacDischargeSummaryDetailsById(int ReportId);

        IList<lmsGynacDischargeSummary> GetAllGynacDischargeSummary();

        int SaveGynacDischargeSummary(lmsGynacDischargeSummary objlmsPatientDischargeSummary);

        int DeleteGynacDischargeSummary(int ReportId);

        lmsPatientReportStore GetPatientReportStoreById(int ReportId);

        IList<lmsPatientReportStore> GetAllPatientReportStore(string filterDate = "");

        int SavePatientReportStore(lmsPatientReportStore lmsPatientReportStore);

        int DeletePatientReportStore(int ReportId);
    }
}

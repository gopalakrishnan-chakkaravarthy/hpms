﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab.Management.Entities;
namespace Lab.Management.Engine
{
    public interface IInvoice
    {
        lmsMedicalBilling GetMedicalBillDetailsById(int BillId);
        IList<lmsMedicalBilling> GetAllMedicalBill(int patientId = 0, string filterDate="");
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
    }
}
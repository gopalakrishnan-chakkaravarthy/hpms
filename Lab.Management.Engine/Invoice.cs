using Lab.Management.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab.Management.Logger;
using Lab.Management.Engine.Utils;
using System.Data.Entity;
using Lab.Management.Common;
namespace Lab.Management.Engine
{
    public class Invoice : IInvoice
    {
        private LabManagementEntities _objLabManagementEntities;
        private readonly IAppLogger _objIAppLogger;
        public Invoice(LabManagementEntities objLabManagementEntities, IAppLogger objIAppLogger)
        {
            _objLabManagementEntities = objLabManagementEntities;
            _objIAppLogger = objIAppLogger;
        }
        public lmsMedicalBilling GetMedicalBillDetailsById(int BillId)
        {
            try
            {

                if (BillId == 0)
                {
                    return new lmsMedicalBilling();
                }
                var resultDetails = _objLabManagementEntities.lmsMedicalBillings.FirstOrDefault(dt => dt.BILLID == BillId);
                return resultDetails;
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
                return null;
            }
            finally
            {

            }

        }
        public IList<lmsMedicalBilling> GetAllMedicalBill(int patientId = 0, string filterDate = "")
        {
            try
            {
                var filterFromDateVal = filterDate.ToLmsSystemDate().AddBeginTime();
                var filterToDateVal = filterDate.ToLmsSystemDate().AddEndTime();

                var resultDetails = _objLabManagementEntities.lmsMedicalBillings.Where(bt => bt.CREATEDDATE.HasValue && (bt.CREATEDDATE.Value >= filterFromDateVal && bt.CREATEDDATE.Value <= filterToDateVal));
                return resultDetails.Any() ? resultDetails.OrderByDescending(x => x.BILLID).ToList() : new List<lmsMedicalBilling>();
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
                return null;
            }
            finally
            {

            }
        }
        public int SaveMedicalBill(lmsMedicalBilling objlmsMedicalBillings)
        {
            var resultId = 0;
            try
            {
                if (objlmsMedicalBillings.BILLID > 0)
                {
                    _objLabManagementEntities.lmsMedicalBillings.Attach(objlmsMedicalBillings);
                    _objLabManagementEntities.Entry(objlmsMedicalBillings).State = EntityState.Modified;
                }
                else
                {
                    _objLabManagementEntities.lmsMedicalBillings.Add(objlmsMedicalBillings);
                }
                _objLabManagementEntities.SaveChanges();
                var result = _objLabManagementEntities.lmsMedicalBillings.AsEnumerable().LastOrDefault();
                resultId = result.BILLID;
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
            }
            finally
            {

            }
            return resultId;
        }
        public int DeleteMedicalBill(int BillId)
        {
            var resultFlag = 0;
            try
            {
                var billObject = _objLabManagementEntities.lmsMedicalBillings.FirstOrDefault(x => x.BILLID == BillId);
                var medicalbilldetails = _objLabManagementEntities.lmsMedicalBillingDetails.Where(x => x.BILLID == BillId);
                _objLabManagementEntities.lmsMedicalBillingDetails.RemoveRange(medicalbilldetails);
                _objLabManagementEntities.lmsMedicalBillings.Remove(billObject);
                _objLabManagementEntities.SaveChanges();
            }
            catch (Exception ex)
            {
                resultFlag = -1;
                _objIAppLogger.LogError(ex);
            }
            finally
            {

            }
            return resultFlag;
        }

        public lmsLaboratoryBilling GetLaboratoryBillingDetailsById(int BillId)
        {
            try
            {
                if (BillId == 0)
                {
                    return new lmsLaboratoryBilling();
                }
                var resultDetails = _objLabManagementEntities.lmsLaboratoryBillings.FirstOrDefault(dt => dt.BILLID == BillId);
                return resultDetails;
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
                return null;
            }
            finally
            {

            }

        }
        public IList<lmsLaboratoryBilling> GetAllLaboratoryBilling(string filterDate = "")
        {
            try
            {
                var filterFromDateVal = filterDate.ToLmsSystemDate().AddBeginTime();
                var filterToDateVal = filterDate.ToLmsSystemDate().AddEndTime();
                var resultDetails = _objLabManagementEntities.lmsLaboratoryBillings.Where(bt => bt.CREATEDDATE.HasValue && (bt.CREATEDDATE.Value >= filterFromDateVal && bt.CREATEDDATE.Value <= filterToDateVal));
                return resultDetails.Any() ? resultDetails.OrderByDescending(x => x.BILLID).ToList() : new List<lmsLaboratoryBilling>();
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
                return null;
            }
            finally
            {

            }
        }
        public int SaveLaboratoryBilling(lmsLaboratoryBilling objlmsLaboratoryBillings)
        {
            var resultId = 0;
            try
            {
                if (objlmsLaboratoryBillings.BILLID > 0)
                {
                    _objLabManagementEntities.lmsLaboratoryBillings.Attach(objlmsLaboratoryBillings);
                    _objLabManagementEntities.Entry(objlmsLaboratoryBillings).State = EntityState.Modified;
                }
                else
                {
                    _objLabManagementEntities.lmsLaboratoryBillings.Add(objlmsLaboratoryBillings);
                }
                _objLabManagementEntities.SaveChanges();
                resultId = _objLabManagementEntities.lmsLaboratoryBillings.AsEnumerable().LastOrDefault().BILLID;
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
            }
            finally
            {

            }
            return resultId;
        }
        public int DeleteLaboratoryBilling(int BillId)
        {
            var resultFlag = 0;
            try
            {
                var billObject = _objLabManagementEntities.lmsLaboratoryBillings.FirstOrDefault(x => x.BILLID == BillId);
                _objLabManagementEntities.lmsLaboratoryBillings.Remove(billObject);
                _objLabManagementEntities.SaveChanges();
            }
            catch (Exception ex)
            {
                resultFlag = -1;
                _objIAppLogger.LogError(ex);
            }
            finally
            {

            }
            return resultFlag;
        }
        public lmsPatientDischargeSummary GetDischargeSummaryDetailsById(int ReportId)
        {
            try
            {
                if (ReportId == 0)
                {
                    return new lmsPatientDischargeSummary();
                }
                var resultDetails = _objLabManagementEntities.lmsPatientDischargeSummaries.FirstOrDefault(dt => dt.SUMMARYID == ReportId);
                return resultDetails;
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
                return null;
            }
            finally
            {

            }

        }
        public IList<lmsPatientDischargeSummary> GetAllDischargeSummary()
        {
            try
            {

                var resultDetails = _objLabManagementEntities.lmsPatientDischargeSummaries.Select(x => x);
                return resultDetails.OrderByDescending(x => x.SUMMARYID).ToList();
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
                return null;
            }
            finally
            {

            }
        }
        public int SaveDischargeSummary(lmsPatientDischargeSummary objlmsPatientDischargeSummary)
        {
            var resultId = 0;
            try
            {
                if (objlmsPatientDischargeSummary.SUMMARYID > 0)
                {
                    _objLabManagementEntities.lmsPatientDischargeSummaries.Attach(objlmsPatientDischargeSummary);
                    _objLabManagementEntities.Entry(objlmsPatientDischargeSummary).State = EntityState.Modified;

                }
                else
                {
                    _objLabManagementEntities.lmsPatientDischargeSummaries.Add(objlmsPatientDischargeSummary);

                }

                _objLabManagementEntities.SaveChanges();
                resultId = _objLabManagementEntities.lmsPatientDischargeSummaries.AsEnumerable().LastOrDefault().SUMMARYID;
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
            }
            finally
            {

            }
            return resultId;
        }
        public int DeleteDischargeSummary(int ReportId)
        {
            var resultFlag = 0;
            try
            {

                var billObject = _objLabManagementEntities.lmsPatientDischargeSummaries.FirstOrDefault(x => x.SUMMARYID == ReportId);
                _objLabManagementEntities.lmsPatientDischargeSummaries.Remove(billObject);
                _objLabManagementEntities.SaveChanges();
            }
            catch (Exception ex)
            {
                resultFlag = -1;
                _objIAppLogger.LogError(ex);
            }
            finally
            {

            }
            return resultFlag;
        }
        public lmsUltrSonogramReportOne GetUltraSonagramReportOneDetailsById(int ReportId)
        {
            try
            {
                if (ReportId == 0)
                {
                    return new lmsUltrSonogramReportOne();
                }
                var resultDetails = _objLabManagementEntities.lmsUltrSonogramReportOnes.FirstOrDefault(dt => dt.REPORTID == ReportId);
                return resultDetails;
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
                return null;
            }
            finally
            {

            }

        }
        public IList<lmsUltrSonogramReportOne> GetAllUltraSonagramReportOne()
        {
            try
            {

                var resultDetails = _objLabManagementEntities.lmsUltrSonogramReportOnes.Select(x => x);
                return resultDetails.OrderByDescending(x => x.REPORTID).ToList();
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
                return null;
            }
            finally
            {

            }
        }
        public int SaveUltraSonagramReportOne(lmsUltrSonogramReportOne objlmsUltrSonogramReportOne)
        {
            var resultId = 0;
            try
            {
                if (objlmsUltrSonogramReportOne.REPORTID > 0)
                {
                    _objLabManagementEntities.lmsUltrSonogramReportOnes.Attach(objlmsUltrSonogramReportOne);
                    _objLabManagementEntities.Entry(objlmsUltrSonogramReportOne).State = EntityState.Modified;
                }
                else
                {
                    _objLabManagementEntities.lmsUltrSonogramReportOnes.Add(objlmsUltrSonogramReportOne);
                }
                _objLabManagementEntities.SaveChanges();
                resultId = _objLabManagementEntities.lmsUltrSonogramReportOnes.AsEnumerable().LastOrDefault().REPORTID;
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
            }
            finally
            {

            }
            return resultId;
        }
        public int DeleteUltraSonagramReportOne(int ReportId)
        {
            var resultFlag = 0;
            try
            {
                var billObject = _objLabManagementEntities.lmsUltrSonogramReportOnes.FirstOrDefault(x => x.REPORTID == ReportId);
                _objLabManagementEntities.lmsUltrSonogramReportOnes.Remove(billObject);
                _objLabManagementEntities.SaveChanges();
            }
            catch (Exception ex)
            {
                resultFlag = -1;
                _objIAppLogger.LogError(ex);
            }
            finally
            {

            }
            return resultFlag;
        }
        public lmsUltrSonogramReportTwo GetUltraSonagramReportTwoDetailsById(int ReportId)
        {
            try
            {
                if (ReportId == 0)
                {
                    return new lmsUltrSonogramReportTwo();
                }
                var resultDetails = _objLabManagementEntities.lmsUltrSonogramReportTwoes.FirstOrDefault(dt => dt.REPORTID == ReportId);
                return resultDetails;
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
                return null;
            }
            finally
            {

            }

        }
        public IList<lmsUltrSonogramReportTwo> GetAllUltraSonagramReportTwo()
        {
            try
            {

                var resultDetails = _objLabManagementEntities.lmsUltrSonogramReportTwoes.Select(x => x);
                return resultDetails.OrderByDescending(x => x.REPORTID).ToList();
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
                return null;
            }
            finally
            {

            }
        }
        public int SaveUltraSonagramReportTwo(lmsUltrSonogramReportTwo objlmsUltrSonogramReportTwo)
        {
            var resultId = 0;
            try
            {
                if (objlmsUltrSonogramReportTwo.REPORTID > 0)
                {
                    _objLabManagementEntities.lmsUltrSonogramReportTwoes.Attach(objlmsUltrSonogramReportTwo);
                    _objLabManagementEntities.Entry(objlmsUltrSonogramReportTwo).State = EntityState.Modified;
                }
                else
                {
                    _objLabManagementEntities.lmsUltrSonogramReportTwoes.Add(objlmsUltrSonogramReportTwo);
                }
                _objLabManagementEntities.SaveChanges();
                resultId = _objLabManagementEntities.lmsUltrSonogramReportTwoes.AsEnumerable().LastOrDefault().REPORTID;
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
            }
            finally
            {

            }
            return resultId;
        }
        public int DeleteUltraSonagramReportTwo(int ReportId)
        {
            var resultFlag = 0;
            try
            {
                var billObject = _objLabManagementEntities.lmsUltrSonogramReportTwoes.FirstOrDefault(x => x.REPORTID == ReportId);
                _objLabManagementEntities.lmsUltrSonogramReportTwoes.Remove(billObject);
                _objLabManagementEntities.SaveChanges();
            }
            catch (Exception ex)
            {
                resultFlag = -1;
                _objIAppLogger.LogError(ex);
            }
            finally
            {

            }
            return resultFlag;
        }

        public lmsInvestigationReport GetInvestigationReportDetailsById(int ReportId)
        {
            try
            {
                if (ReportId == 0)
                {
                    return new lmsInvestigationReport();
                }
                var resultDetails = _objLabManagementEntities.lmsInvestigationReports.FirstOrDefault(dt => dt.REPORTID == ReportId);
                return resultDetails;
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
                return null;
            }
            finally
            {

            }

        }
        public IList<lmsInvestigationReport> GetAllInvestigationReport()
        {
            try
            {

                var resultDetails = _objLabManagementEntities.lmsInvestigationReports.Select(x => x);
                return resultDetails.OrderByDescending(x => x.REPORTID).ToList();
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
                return null;
            }
            finally
            {

            }
        }
        public int SaveInvestigationReport(lmsInvestigationReport objlmsInvestigationReport)
        {
            var resultId = 0;
            try
            {
                if (objlmsInvestigationReport.REPORTID > 0)
                {
                    _objLabManagementEntities.lmsInvestigationReports.Attach(objlmsInvestigationReport);
                    _objLabManagementEntities.Entry(objlmsInvestigationReport).State = EntityState.Modified;
                }
                else
                {
                    _objLabManagementEntities.lmsInvestigationReports.Add(objlmsInvestigationReport);
                }
                _objLabManagementEntities.SaveChanges();
                resultId = _objLabManagementEntities.lmsInvestigationReports.AsEnumerable().LastOrDefault().REPORTID;
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
            }
            finally
            {

            }
            return resultId;
        }
        public int DeleteInvestigationReport(int ReportId)
        {
            var resultFlag = 0;
            try
            {
                var billObject = _objLabManagementEntities.lmsInvestigationReports.FirstOrDefault(x => x.REPORTID == ReportId);
                _objLabManagementEntities.lmsInvestigationReports.Remove(billObject);
                _objLabManagementEntities.SaveChanges();
            }
            catch (Exception ex)
            {
                resultFlag = -1;
                _objIAppLogger.LogError(ex);
            }
            finally
            {

            }
            return resultFlag;
        }

        public lmsDischargeBill GetDischargeBillDetailsById(int BillId)
        {
            try
            {
                if (BillId == 0)
                {
                    return new lmsDischargeBill();
                }
                var resultDetails = _objLabManagementEntities.lmsDischargeBills.FirstOrDefault(dt => dt.DBILLID == BillId);
                return resultDetails;
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
                return null;
            }


        }
        public IList<lmsDischargeBill> GetAllDischargeBill()
        {
            try
            {

                var resultDetails = _objLabManagementEntities.lmsDischargeBills.Select(x => x);
                return resultDetails.OrderByDescending(x => x.DBILLID).ToList();
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
                return null;
            }

        }
        public int SaveDischargeBill(lmsDischargeBill objlmsDischargeBill)
        {
            var resultId = 0;
            try
            {
                if (objlmsDischargeBill.DBILLID > 0)
                {
                    _objLabManagementEntities.lmsDischargeBills.Attach(objlmsDischargeBill);
                    _objLabManagementEntities.Entry(objlmsDischargeBill).State = EntityState.Modified;
                }
                else
                {
                    _objLabManagementEntities.lmsDischargeBills.Add(objlmsDischargeBill);
                }
                _objLabManagementEntities.SaveChanges();
                resultId = _objLabManagementEntities.lmsDischargeBills.AsEnumerable().LastOrDefault().DBILLID;
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
            }

            return resultId;
        }
        public int DeleteDischargeBill(int BillId)
        {
            var resultFlag = 0;
            try
            {
                var billObject = _objLabManagementEntities.lmsDischargeBills.FirstOrDefault(x => x.DBILLID == BillId);
                _objLabManagementEntities.lmsDischargeBills.Remove(billObject);
                _objLabManagementEntities.SaveChanges();
            }
            catch (Exception ex)
            {
                resultFlag = -1;
                _objIAppLogger.LogError(ex);
            }

            return resultFlag;
        }

        public int MultiDeleteRows(string deleteSelectedRows)
        {
            var resultFlag = 0;
            try
            {
                resultFlag = _objLabManagementEntities.usp_DeleteMedicalBilling(deleteSelectedRows);

            }
            catch (Exception ex)
            {
                resultFlag = -1;
                _objIAppLogger.LogError(ex);
            }

            return resultFlag;
        }
        public lmsGeneralDischargeSummary GetGenDischargeSummaryDetailsById(int ReportId)
        {
            try
            {
                if (ReportId == 0)
                {
                    return new lmsGeneralDischargeSummary();
                }
                var resultDetails = _objLabManagementEntities.lmsGeneralDischargeSummaries.FirstOrDefault(dt => dt.SUMMARYID == ReportId);
                return resultDetails;
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
                return null;
            }


        }
        public IList<lmsGeneralDischargeSummary> GetAllGenDischargeSummary()
        {
            try
            {

                var resultDetails = _objLabManagementEntities.lmsGeneralDischargeSummaries.Select(x => x);
                return resultDetails.OrderByDescending(x => x.SUMMARYID).ToList();
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
                return null;
            }

        }
        public int SaveGenDischargeSummary(lmsGeneralDischargeSummary objlmsPatientDischargeSummary)
        {
            var resultId = 0;
            try
            {
                if (objlmsPatientDischargeSummary.SUMMARYID > 0)
                {
                    _objLabManagementEntities.lmsGeneralDischargeSummaries.Attach(objlmsPatientDischargeSummary);
                    _objLabManagementEntities.Entry(objlmsPatientDischargeSummary).State = EntityState.Modified;

                }
                else
                {
                    _objLabManagementEntities.lmsGeneralDischargeSummaries.Add(objlmsPatientDischargeSummary);
                }

                _objLabManagementEntities.SaveChanges();
                resultId = _objLabManagementEntities.lmsGeneralDischargeSummaries.AsEnumerable().LastOrDefault().SUMMARYID;
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
            }

            return resultId;
        }
        public int DeleteGenDischargeSummary(int ReportId)
        {
            var resultFlag = 0;
            try
            {

                var billObject = _objLabManagementEntities.lmsGeneralDischargeSummaries.FirstOrDefault(x => x.SUMMARYID == ReportId);
                _objLabManagementEntities.lmsGeneralDischargeSummaries.Remove(billObject);
                _objLabManagementEntities.SaveChanges();
            }
            catch (Exception ex)
            {
                resultFlag = -1;
                _objIAppLogger.LogError(ex);
            }

            return resultFlag;
        }

        public lmsGynacDischargeSummary GetGynacDischargeSummaryDetailsById(int ReportId)
        {
            try
            {
                if (ReportId == 0)
                {
                    return new lmsGynacDischargeSummary();
                }
                var resultDetails = _objLabManagementEntities.lmsGynacDischargeSummaries.FirstOrDefault(dt => dt.SUMMARYID == ReportId);
                return resultDetails;
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
                return null;
            }


        }
        public IList<lmsGynacDischargeSummary> GetAllGynacDischargeSummary()
        {
            try
            {

                var resultDetails = _objLabManagementEntities.lmsGynacDischargeSummaries.Select(x => x);
                return resultDetails.OrderByDescending(x => x.SUMMARYID).ToList();
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
                return null;
            }

        }
        public int SaveGynacDischargeSummary(lmsGynacDischargeSummary objlmsPatientDischargeSummary)
        {
            var resultId = 0;
            try
            {
                if (objlmsPatientDischargeSummary.SUMMARYID > 0)
                {
                    _objLabManagementEntities.lmsGynacDischargeSummaries.Attach(objlmsPatientDischargeSummary);
                    _objLabManagementEntities.Entry(objlmsPatientDischargeSummary).State = EntityState.Modified;

                }
                else
                {
                    _objLabManagementEntities.lmsGynacDischargeSummaries.Add(objlmsPatientDischargeSummary);
                }

                _objLabManagementEntities.SaveChanges();
                resultId = _objLabManagementEntities.lmsGynacDischargeSummaries.AsEnumerable().LastOrDefault().SUMMARYID;
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
            }

            return resultId;
        }
        public int DeleteGynacDischargeSummary(int ReportId)
        {
            var resultFlag = 0;
            try
            {

                var billObject = _objLabManagementEntities.lmsGynacDischargeSummaries.FirstOrDefault(x => x.SUMMARYID == ReportId);
                _objLabManagementEntities.lmsGynacDischargeSummaries.Remove(billObject);
                _objLabManagementEntities.SaveChanges();
            }
            catch (Exception ex)
            {
                resultFlag = -1;
                _objIAppLogger.LogError(ex);
            }

            return resultFlag;
        }
    }
}

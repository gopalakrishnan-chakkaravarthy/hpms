using Lab.Management.Engine.Enum;
using Lab.Management.Engine.Models;
using Lab.Management.Engine.QueryBuilder;
using Lab.Management.Engine.Service;
using Lab.Management.Entities;
using Lab.Management.Logger;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Linq.Expressions;

namespace Lab.Management.Engine.Infrastructure
{
    public class Patient : IPatient
    {
        private LabManagementEntities _objLabManagementEntities;

        private readonly IAppLogger _objIAppLogger;

        public Patient(LabManagementEntities objLabManagementEntities, IAppLogger objIAppLogger)
        {
            _objLabManagementEntities = objLabManagementEntities;
            _objIAppLogger = objIAppLogger;
        }

        public int GetPatientIdByQrCode(string qrCode)
        {
            try
            {
                var resultDetails = _objLabManagementEntities.lmsPatientRegistrations.Where(dt => dt.QrCodeContent == qrCode);
                return resultDetails.Any() ? resultDetails.FirstOrDefault().PATIENTID : 0;
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
                return -1;
            }
        }

        public IEnumerable<usp_GetPatientDdlForBilling_Result> GetPatientDdl()
        {
            var patientList = _objLabManagementEntities.usp_GetPatientDdlForBilling().ToList();
            return patientList;
        }

        public lmsPatientRegistration GetPatientDetailsById(int PatientId)
        {
            try
            {
                if (PatientId == 0)
                {
                    return new lmsPatientRegistration();
                }
                var resultDetails = _objLabManagementEntities.lmsPatientRegistrations.FirstOrDefault(dt => dt.PATIENTID == PatientId);

                return resultDetails;
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
                return null;
            }
        }

        public IEnumerable<lmsPatientRegistration> GetAllPatient(QueryFilterAttribute queryFilterAttribute, string filterValue, string patientType, bool includeAll = false)
        {
            try
            {
                if (queryFilterAttribute == QueryFilterAttribute.none || string.IsNullOrEmpty(filterValue))
                {
                    return new List<lmsPatientRegistration>();
                }
                var filterLastThreeMonths = DateTime.Now.AddMonths(-3);
                var resultDetails = _objLabManagementEntities.lmsPatientRegistrations.
                    Where(bt => bt.CREATEDDATE.HasValue && EntityFunctions.TruncateTime(bt.CREATEDDATE.Value) == filterLastThreeMonths.Date).Select(x => x);
                if (!string.IsNullOrEmpty(filterValue))
                {
                    var predicate = GetWhereClass(queryFilterAttribute, filterValue);
                    resultDetails = resultDetails.Where(predicate);
                    return resultDetails.ToList();
                }
                var finalResult = includeAll ? resultDetails : resultDetails.Where(x => x.PATIENTTYPE == patientType);
                return finalResult.OrderByDescending(x => x.PATIENTNAME).ToList();
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
                return null;
            }
        }

        public int SavePatient(lmsPatientRegistration objlmsPatientRegistrations)
        {
            var resultId = 0;
            try
            {
                if (objlmsPatientRegistrations.PATIENTID > 0)
                {
                    _objLabManagementEntities.lmsPatientRegistrations.Attach(objlmsPatientRegistrations);
                    _objLabManagementEntities.Entry(objlmsPatientRegistrations).State = EntityState.Modified;
                    _objLabManagementEntities.SaveChanges();
                    return objlmsPatientRegistrations.PATIENTID;
                }
                _objLabManagementEntities.lmsPatientRegistrations.Add(objlmsPatientRegistrations);
                _objLabManagementEntities.SaveChanges();
                resultId = objlmsPatientRegistrations.PATIENTID;
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
            }

            return resultId;
        }

        public int DeletePatient(int PatientId)
        {
            var resultFlag = 0;
            try
            {
                var PatientObject = _objLabManagementEntities.lmsPatientRegistrations.FirstOrDefault(x => x.PATIENTID == PatientId);
                _objLabManagementEntities.lmsPatientRegistrations.Remove(PatientObject);
                _objLabManagementEntities.SaveChanges();
            }
            catch (Exception ex)
            {
                resultFlag = -1;
                _objIAppLogger.LogError(ex);
            }
            return resultFlag;
        }

        public lmsPatientBooking GetPatientBookingById(int id)
        {
            try
            {
                if (id == 0)
                {
                    return new lmsPatientBooking();
                }
                var resultDetails = _objLabManagementEntities.lmsPatientBookings.Where(dt => dt.BOOKINGID == id);
                return resultDetails.Any() ? resultDetails.FirstOrDefault() : null;
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
                return null;
            }
        }

        public IEnumerable<lmsPatientBooking> GetAllPatientBooking(string date = "",
            int patientId = 0, string status = "CONFIRMED", bool isHistory = false)
        {
            try
            {
                if (isHistory && patientId > 0)
                {
                    var history = _objLabManagementEntities.lmsPatientBookings.Where(x =>
             x.PATIENTID == patientId);
                    return history.Any() ? history.ToList() : new List<lmsPatientBooking>();
                }
                var filterDate = Convert.ToDateTime(date).Date;
                var result = _objLabManagementEntities.lmsPatientBookings.Where(x =>
                EntityFunctions.TruncateTime(x.APPOINTMENTDATE.Value) == filterDate
                && x.BOOKINGSTATUS == status);
                return result.Any() ? result.ToList() : new List<lmsPatientBooking>();
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
                return null;
            }
        }

        public int SavePatientBooking(lmsPatientBooking objSaveData)
        {
            var resultId = 0;
            try
            {
                if (objSaveData.BOOKINGID > 0)
                {
                    _objLabManagementEntities.lmsPatientBookings.Attach(objSaveData);
                    _objLabManagementEntities.Entry(objSaveData).State = EntityState.Modified;
                    _objLabManagementEntities.SaveChanges();
                    return objSaveData.BOOKINGID;
                }
                _objLabManagementEntities.lmsPatientBookings.Add(objSaveData);
                _objLabManagementEntities.SaveChanges();
                resultId = _objLabManagementEntities.lmsPatientBookings.Where(x => x.PATIENTID == objSaveData.PATIENTID).ToList().LastOrDefault().BOOKINGID;
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
            }

            return resultId;
        }

        public int DeletePatientBooking(int id)
        {
            var resultFlag = 0;
            try
            {
                var bookingInfo = _objLabManagementEntities.lmsPatientBookings.FirstOrDefault(x => x.BOOKINGID == id);
                _objLabManagementEntities.lmsPatientBookings.Remove(bookingInfo);
                _objLabManagementEntities.SaveChanges();
            }
            catch (Exception ex)
            {
                resultFlag = -1;
                _objIAppLogger.LogError(ex);
            }
            return resultFlag;
        }

        public lmsPatientPrescription GetPatientPrescriptionById(int bookingId)
        {
            try
            {
                if (bookingId == 0)
                {
                    return new lmsPatientPrescription();
                }
                var resultDetails = _objLabManagementEntities.lmsPatientPrescriptions.Where(dt => dt.BOOKINGID == bookingId);
                return resultDetails.Any() ? resultDetails.FirstOrDefault() : null;
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
                return null;
            }
        }

        public IEnumerable<lmsPatientPrescription> GetAllPatientPrescription(int bookingId)
        {
            try
            {
                if (bookingId < 0)
                {
                    return new List<lmsPatientPrescription>();
                }
                var result = _objLabManagementEntities.lmsPatientPrescriptions.Where(x => x.BOOKINGID == bookingId);
                return result.Any() ? result.ToList() : new List<lmsPatientPrescription>();
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
                return null;
            }
        }

        public int SavePatientPrescription(List<lmsPatientPrescription> objSaveData)
        {
            var resultId = 0;
            try
            {
                if (objSaveData.Count() > 0)
                {
                    objSaveData.ForEach(presc => _objLabManagementEntities.lmsPatientPrescriptions.Add(presc));
                    _objLabManagementEntities.SaveChanges();
                    return 1;
                }
                resultId = 0;
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
            }

            return resultId;
        }

        public int DeletePatientPrescription(int bookingId)
        {
            var resultFlag = 0;
            try
            {
                var deleteResult = _objLabManagementEntities.lmsPatientPrescriptions.Where(x => x.BOOKINGID == bookingId);
                _objLabManagementEntities.lmsPatientPrescriptions.RemoveRange(deleteResult);
                _objLabManagementEntities.SaveChanges();
            }
            catch (Exception ex)
            {
                resultFlag = -1;
                _objIAppLogger.LogError(ex);
            }
            return resultFlag;
        }
        public IEnumerable<QueryFilterModel> GetFilterList()
        {
            var filterList = new List<QueryFilterModel>() {
            new QueryFilterModel { Text="Name",Value=QueryFilterAttribute.firstname},
            new QueryFilterModel { Text="Id",Value=QueryFilterAttribute.customId},
            new QueryFilterModel { Text="Date of Birth",Value=QueryFilterAttribute.dob},
            new QueryFilterModel { Text="Mobile",Value=QueryFilterAttribute.mobileno},
            new QueryFilterModel { Text="Email",Value=QueryFilterAttribute.email}
            };
            return filterList;
        }
        private Expression<Func<lmsPatientRegistration, bool>> GetWhereClass(QueryFilterAttribute filterBy, string value)
        {
            var predicate = PredicateBuilder.True<lmsPatientRegistration>();
            switch (filterBy)
            {
                case QueryFilterAttribute.firstname:
                    return predicate.And(x => x.PATIENTNAME.Contains(value));

                case QueryFilterAttribute.customId:
                    return predicate.And(x => x.CUSTOMID == value);

                case QueryFilterAttribute.dob:
                    var dob = Convert.ToDateTime(value).Date;
                    return predicate.And(x => x.DOB.HasValue && EntityFunctions.TruncateTime(x.DOB.Value) == dob);

                case QueryFilterAttribute.mobileno:
                    return predicate.And(x => x.CONTACT.Contains(value));

                case QueryFilterAttribute.email:
                    return predicate = predicate.And(x => x.PATIENTEMAILID == value);
            }
            return predicate;
        }
    }
}

using Lab.Management.Engine.Service;
using Lab.Management.Entities;
using Lab.Management.Logger;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;

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

        public IList<usp_GetPatientDdlForBilling_Result> GetPatientDdl()
        {
            return _objLabManagementEntities.usp_GetPatientDdlForBilling().ToList();
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

        public IList<lmsPatientRegistration> GetAllPatient(string patientType, bool includeAll = false)
        {
            try
            {
                var resultDetails = _objLabManagementEntities.lmsPatientRegistrations.Select(x => x);
                return includeAll ? resultDetails.OrderByDescending(x => x.PATIENTID).ToList() : resultDetails.Where(x => x.PATIENTTYPE == patientType).OrderByDescending(x => x.PATIENTID).ToList();
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
                resultId = _objLabManagementEntities.lmsPatientRegistrations.LastOrDefault().PATIENTID;
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

        public IList<lmsPatientBooking> GetAllPatientBooking(string date = "",
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

        public IList<lmsPatientPrescription> GetAllPatientPrescription(int bookingId)
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
    }
}

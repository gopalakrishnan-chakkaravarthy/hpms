using Lab.Management.Entities;
using System.Collections.Generic;

namespace Lab.Management.Engine.Service
{
    public interface IPatient
    {
        IList<usp_GetPatientDdlForBilling_Result> GetPatientDdl();

        int GetPatientIdByQrCode(string qrCode);

        lmsPatientRegistration GetPatientDetailsById(int PatientId);

        IList<lmsPatientRegistration> GetAllPatient(string patientType, bool includeAll = false);

        int SavePatient(lmsPatientRegistration objPatientMaster);

        int DeletePatient(int PatientId);

        lmsPatientBooking GetPatientBookingById(int id);

        IList<lmsPatientBooking> GetAllPatientBooking(string date = "",
            int patientId = 0, string status = "CONFIRMED", bool isHistory = false);

        int SavePatientBooking(lmsPatientBooking objPatientMaster);

        int DeletePatientBooking(int id);

        lmsPatientPrescription GetPatientPrescriptionById(int bookingId);

        IList<lmsPatientPrescription> GetAllPatientPrescription(int bookingId);

        int SavePatientPrescription(List<lmsPatientPrescription> objPatientMaster);

        int DeletePatientPrescription(int bookingId);
    }
}

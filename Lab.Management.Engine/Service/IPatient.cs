using Lab.Management.Engine.Enum;
using Lab.Management.Engine.Models;
using Lab.Management.Entities;
using System.Collections.Generic;

namespace Lab.Management.Engine.Service
{
    public interface IPatient
    {
        IEnumerable<usp_GetPatientDdlForBilling_Result> GetPatientDdl();

        int GetPatientIdByQrCode(string qrCode);

        lmsPatientRegistration GetPatientDetailsById(int PatientId);

        IEnumerable<lmsPatientRegistration> GetAllPatient( QueryFilterAttribute queryFilterAttribute, string filterValue, string patientType, bool includeAll = false);

        int SavePatient(lmsPatientRegistration objPatientMaster);

        int DeletePatient(int PatientId);

        lmsPatientBooking GetPatientBookingById(int id);

        IEnumerable<lmsPatientBooking> GetAllPatientBooking(string date = "",
            int patientId = 0, string status = "CONFIRMED", bool isHistory = false);

        int SavePatientBooking(lmsPatientBooking objPatientMaster);

        int DeletePatientBooking(int id);

        lmsPatientPrescription GetPatientPrescriptionById(int bookingId);

        IEnumerable<lmsPatientPrescription> GetAllPatientPrescription(int bookingId);

        int SavePatientPrescription(List<lmsPatientPrescription> objPatientMaster);

        int DeletePatientPrescription(int bookingId);
        IEnumerable<QueryFilterModel> GetFilterList();
    }
}

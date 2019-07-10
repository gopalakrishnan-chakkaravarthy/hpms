using Lab.Management.Entities;
using System.Collections.Generic;

namespace Lab.Management.Engine.Service
{
    public interface IPatient
    {
        lmsPatientRegistration GetPatientDetailsById(int PatientId);

        IList<lmsPatientRegistration> GetAllPatient(string patientType, bool includeAll = false);

        int SavePatient(lmsPatientRegistration objPatientMaster);

        int DeletePatient(int PatientId);

        lmsOutPatientMaster GetOutPatientMasterById(int PatientId);

        IList<lmsOutPatientMaster> GetAllOutPatient();

        int SaveOutPatient(lmsOutPatientMaster objPatientMaster);

        int DeleteOutPatient(int PatientId);

        lmsOutPatientDetail GetOutPatientDetailsById(int PatientId);

        IList<lmsOutPatientDetail> GetAllOutPatientDetails(int patientDetailsId);

        int SaveOutPatientDetail(lmsOutPatientDetail objPatientMaster);

        int DeleteOutPatientDetail(int PatientId);

        IList<usp_GetPatientDdlForBilling_Result> GetPatientDdl();
    }
}

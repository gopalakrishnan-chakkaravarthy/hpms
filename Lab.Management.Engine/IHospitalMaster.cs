using Lab.Management.Engine.Utils;
using Lab.Management.Entities;
using System.Collections.Generic;

namespace Lab.Management.Engine
{
    public interface IHospitalMaster
    {
        lmsDrug GetDrugDetailsById(int DrugId);

        IList<lmsDrug> GetAllDrug();

        int SaveDrug(lmsDrug objDrugMaster);

        int DeleteDrug(int DrugId);

        lmsMedicalTest GetMedicalTestDetailsById(int MTestId);

        IEnumerable<lmsMedicalTest> GetAllMedicalTest();

        int SaveMedicalTest(lmsMedicalTest objMedicalTestMaster);

        int DeleteMedicalTest(int MTestId);

        lmsScan GetScanDetailsById(int ScanId);

        IList<lmsScan> GetAllScan();

        int SaveScan(lmsScan objScanMaster);

        int DeleteScan(int ScanId);

        lmsVendor GetVendorDetailsById(int VendorId);

        IList<lmsVendor> GetAllVendor();

        int SaveVendor(lmsVendor objVendorMaster);

        int DeleteVendor(int VendorId);

        lmsInventory GetInventoryDetailsById(int InventoryId);

        IList<lmsInventory> GetAllInventory();

        int SaveInventory(lmsInventory objInventoryMaster);

        int DeleteInventory(int InventoryId);

        lmsBed GetBedDetailsById(int BedId);

        IList<lmsBed> GetAllBed();

        int SaveBed(lmsBed objBedMaster);

        int DeleteBed(int BedId);

        lmsWard GetWardDetailsById(int WardId);

        IList<lmsWard> GetAllWard();

        int SaveWard(lmsWard objWardMaster);

        int DeleteWard(int WardId);

        List<DownLoadFileInformation> GetFiles(string downloadfor);

        IList<usp_GetDrugDdl_Result> GetDrugsDdl();

        lmsMedicalTestFor GetMedicalTestForById(int Id);

        IList<lmsMedicalTestFor> GetAllMedicalTestFor();

        IList<string> GetAllMedicalTestForNames(List<int> ids);

        int SaveMedicalTestFor(lmsMedicalTestFor objSaveData);

        int DeleteMedicalTestFor(int Id);

        lmsMedicalTestGroup GetMedicalGroupById(int Id);

        IList<lmsMedicalTestGroup> GetAllMedicalTestGroup();

        int SaveMedicalTestGroup(lmsMedicalTestGroup objSaveData);

        int DeleteMedicalTestGroup(int Id);
    }
}

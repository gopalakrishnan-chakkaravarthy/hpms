using Lab.Management.Common;
using Lab.Management.Engine.Utils;
using Lab.Management.Entities;
using Lab.Management.Logger;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;

namespace Lab.Management.Engine
{
    public class HospitalMaster : IHospitalMaster
    {
        private LabManagementEntities _objLabManagementEntities;
        private readonly IAppLogger _objIAppLogger;
        public HospitalMaster(LabManagementEntities objLabManagementEntities, IAppLogger objIAppLogger)
        {
            _objLabManagementEntities = objLabManagementEntities;
            _objIAppLogger = objIAppLogger;
        }

        public lmsDrug GetDrugDetailsById(int DrugId)
        {
            try
            {
                if (DrugId == 0)
                {
                    var newDrug = new lmsDrug();
                    newDrug.ISEXPIRED = false;
                    return newDrug;
                }
                var resultDetails = _objLabManagementEntities.lmsDrugs.FirstOrDefault(x => x.DRUGID == DrugId);
                resultDetails.ISEXPIRED = resultDetails.ISEXPIRED == null ? false : resultDetails.ISEXPIRED.Value;
                return resultDetails;
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
                return null;
            }
        }

        public IList<lmsDrug> GetAllDrug()
        {
            try
            {
                var resultDetails = _objLabManagementEntities.lmsDrugs.Select(x => x);
                return resultDetails.OrderByDescending(x => x.DRUGID).ToList();
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
                return null;
            }
        }

        public int SaveDrug(lmsDrug objDrugMaster)
        {
            var resultId = 0;
            try
            {
                if (objDrugMaster.DRUGID > 0)
                {
                    _objLabManagementEntities.lmsDrugs.Attach(objDrugMaster);
                    _objLabManagementEntities.Entry(objDrugMaster).State = EntityState.Modified;
                }
                else
                {
                    _objLabManagementEntities.lmsDrugs.Add(objDrugMaster);
                }
                _objLabManagementEntities.SaveChanges();
                resultId = _objLabManagementEntities.lmsDrugs.AsEnumerable().LastOrDefault().DRUGID;
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
            }

            return resultId;
        }

        public int DeleteDrug(int DrugId)
        {
            var resultFlag = 0;
            try
            {
                var DrugObject = _objLabManagementEntities.lmsDrugs.FirstOrDefault(x => x.DRUGID == DrugId);
                _objLabManagementEntities.lmsDrugs.Remove(DrugObject);
                _objLabManagementEntities.SaveChanges();
            }
            catch (Exception ex)
            {
                resultFlag = -1;
                _objIAppLogger.LogError(ex);
            }

            return resultFlag;
        }

        public lmsMedicalTest GetMedicalTestDetailsById(int MTestId)
        {
            try
            {
                if (MTestId == 0)
                {
                    return new lmsMedicalTest();
                }
                var resultDetails = _objLabManagementEntities.lmsMedicalTests.FirstOrDefault(x => x.TESTID == MTestId);
                return resultDetails;
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
                return null;
            }
        }

        public IList<lmsMedicalTest> GetAllMedicalTest()
        {
            try
            {
                var resultDetails = _objLabManagementEntities.lmsMedicalTests.Select(x => x);
                resultDetails.Include("lmsMedicalTestFor").
                    Include("lmsMedicalTestGroup");
                return resultDetails.OrderByDescending(x => x.TESTID).ToList();
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
                return null;
            }
        }

        public int SaveMedicalTest(lmsMedicalTest objMedicalTestMaster)
        {
            var resultId = 0;
            try
            {
                if (objMedicalTestMaster.TESTID > 0)
                {
                    _objLabManagementEntities.lmsMedicalTests.Attach(objMedicalTestMaster);
                    _objLabManagementEntities.Entry(objMedicalTestMaster).State = EntityState.Modified;
                }
                else
                {
                    _objLabManagementEntities.lmsMedicalTests.Add(objMedicalTestMaster);
                }
                _objLabManagementEntities.SaveChanges();
                resultId = _objLabManagementEntities.lmsMedicalTests.AsEnumerable().LastOrDefault().TESTID;
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
            }

            return resultId;
        }

        public int DeleteMedicalTest(int MTestId)
        {
            var resultFlag = 0;
            try
            {
                var MedicalTestObject = _objLabManagementEntities.lmsMedicalTests.FirstOrDefault(x => x.TESTID == MTestId);
                _objLabManagementEntities.lmsMedicalTests.Remove(MedicalTestObject);
                _objLabManagementEntities.SaveChanges();
            }
            catch (Exception ex)
            {
                resultFlag = -1;
                _objIAppLogger.LogError(ex);
            }

            return resultFlag;
        }

        public lmsScan GetScanDetailsById(int ScanId)
        {
            try
            {
                if (ScanId == 0)
                {
                    return new lmsScan();
                }
                var resultDetails = _objLabManagementEntities.lmsScans.FirstOrDefault(x => x.SCANID == ScanId);
                return resultDetails;
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
                return null;
            }
        }

        public IList<lmsScan> GetAllScan()
        {
            try
            {
                var resultDetails = _objLabManagementEntities.lmsScans.Select(x => x);
                return resultDetails.OrderByDescending(x => x.SCANID).ToList();
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
                return null;
            }
        }

        public int SaveScan(lmsScan objScanMaster)
        {
            var resultId = 0;
            try
            {
                if (objScanMaster.SCANID > 0)
                {
                    _objLabManagementEntities.lmsScans.Attach(objScanMaster);
                    _objLabManagementEntities.Entry(objScanMaster).State = EntityState.Modified;
                }
                else
                {
                    _objLabManagementEntities.lmsScans.Add(objScanMaster);
                }
                _objLabManagementEntities.SaveChanges();
                resultId = _objLabManagementEntities.lmsScans.AsEnumerable().LastOrDefault().SCANID;
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
            }

            return resultId;
        }

        public int DeleteScan(int ScanId)
        {
            var resultFlag = 0;
            try
            {
                var ScanObject = _objLabManagementEntities.lmsScans.FirstOrDefault(x => x.SCANID == ScanId);
                _objLabManagementEntities.lmsScans.Remove(ScanObject);
                _objLabManagementEntities.SaveChanges();
            }
            catch (Exception ex)
            {
                resultFlag = -1;
                _objIAppLogger.LogError(ex);
            }

            return resultFlag;
        }

        public lmsVendor GetVendorDetailsById(int VendorId)
        {
            try
            {
                if (VendorId == 0)
                {
                    var newVendor = new lmsVendor();
                    newVendor.ISACTIVE = true;
                    return newVendor;
                }
                var resultDetails = _objLabManagementEntities.lmsVendors.FirstOrDefault(x => x.VENDORID == VendorId);
                resultDetails.ISACTIVE = resultDetails.ISACTIVE == null ? true : resultDetails.ISACTIVE.Value;
                return resultDetails;
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
                return null;
            }
        }

        public IList<lmsVendor> GetAllVendor()
        {
            try
            {
                var resultDetails = _objLabManagementEntities.lmsVendors.Select(x => x);
                return resultDetails.OrderByDescending(x => x.VENDORID).ToList();
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
                return null;
            }
        }

        public int SaveVendor(lmsVendor objVendorMaster)
        {
            var resultId = 0;
            try
            {
                if (objVendorMaster.VENDORID > 0)
                {
                    _objLabManagementEntities.lmsVendors.Attach(objVendorMaster);
                    _objLabManagementEntities.Entry(objVendorMaster).State = EntityState.Modified;
                }
                else
                {
                    _objLabManagementEntities.lmsVendors.Add(objVendorMaster);
                }
                _objLabManagementEntities.SaveChanges();
                resultId = _objLabManagementEntities.lmsVendors.AsEnumerable().LastOrDefault().VENDORID;
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
            }

            return resultId;
        }

        public int DeleteVendor(int VendorId)
        {
            var resultFlag = 0;
            try
            {
                var VendorObject = _objLabManagementEntities.lmsVendors.FirstOrDefault(x => x.VENDORID == VendorId);
                _objLabManagementEntities.lmsVendors.Remove(VendorObject);
                _objLabManagementEntities.SaveChanges();
            }
            catch (Exception ex)
            {
                resultFlag = -1;
                _objIAppLogger.LogError(ex);
            }

            return resultFlag;
        }

        public lmsInventory GetInventoryDetailsById(int InventoryId)
        {
            try
            {
                if (InventoryId == 0)
                {
                    var newInventory = new lmsInventory();
                    newInventory.ISWORKING = true;
                    return newInventory;
                }
                var resultDetails = _objLabManagementEntities.lmsInventories.FirstOrDefault(x => x.INVENTORYID == InventoryId);
                resultDetails.ISWORKING = resultDetails.ISWORKING == null ? true : resultDetails.ISWORKING.Value;
                return resultDetails;
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
                return null;
            }
        }

        public IList<lmsInventory> GetAllInventory()
        {
            try
            {
                var resultDetails = _objLabManagementEntities.lmsInventories.Select(x => x);
                return resultDetails.OrderByDescending(x => x.INVENTORYID).ToList();
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
                return null;
            }
        }

        public int SaveInventory(lmsInventory objInventoryMaster)
        {
            var resultId = 0;
            try
            {
                if (objInventoryMaster.INVENTORYID > 0)
                {
                    _objLabManagementEntities.lmsInventories.Attach(objInventoryMaster);
                    _objLabManagementEntities.Entry(objInventoryMaster).State = EntityState.Modified;
                }
                else
                {
                    _objLabManagementEntities.lmsInventories.Add(objInventoryMaster);
                }
                _objLabManagementEntities.SaveChanges();
                resultId = _objLabManagementEntities.lmsInventories.AsEnumerable().LastOrDefault().INVENTORYID;
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
            }

            return resultId;
        }

        public int DeleteInventory(int InventoryId)
        {
            var resultFlag = 0;
            try
            {
                var InventoryObject = _objLabManagementEntities.lmsInventories.FirstOrDefault(x => x.INVENTORYID == InventoryId);
                _objLabManagementEntities.lmsInventories.Remove(InventoryObject);
                _objLabManagementEntities.SaveChanges();
            }
            catch (Exception ex)
            {
                resultFlag = -1;
                _objIAppLogger.LogError(ex);
            }

            return resultFlag;
        }

        public lmsBed GetBedDetailsById(int BedId)
        {
            try
            {
                if (BedId == 0)
                {
                    var newBed = new lmsBed();
                    newBed.ISACTIVE = true;
                    return newBed;
                }
                var resultDetails = _objLabManagementEntities.lmsBeds.FirstOrDefault(x => x.BEDID == BedId);
                resultDetails.ISACTIVE = resultDetails.ISACTIVE == null ? true : resultDetails.ISACTIVE.Value;
                return resultDetails;
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
                return null;
            }
        }

        public IList<lmsBed> GetAllBed()
        {
            try
            {
                var resultDetails = _objLabManagementEntities.lmsBeds.Select(x => x);
                return resultDetails.OrderByDescending(x => x.BEDID).ToList();
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
                return null;
            }
        }

        public int SaveBed(lmsBed objBedMaster)
        {
            var resultId = 0;
            try
            {
                if (objBedMaster.BEDID > 0)
                {
                    _objLabManagementEntities.lmsBeds.Attach(objBedMaster);
                    _objLabManagementEntities.Entry(objBedMaster).State = EntityState.Modified;
                }
                else
                {
                    _objLabManagementEntities.lmsBeds.Add(objBedMaster);
                }
                _objLabManagementEntities.SaveChanges();
                resultId = _objLabManagementEntities.lmsBeds.AsEnumerable().LastOrDefault().BEDID;
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
            }

            return resultId;
        }

        public int DeleteBed(int BedId)
        {
            var resultFlag = 0;
            try
            {
                var BedObject = _objLabManagementEntities.lmsBeds.FirstOrDefault(x => x.BEDID == BedId);
                _objLabManagementEntities.lmsBeds.Remove(BedObject);
                _objLabManagementEntities.SaveChanges();
            }
            catch (Exception ex)
            {
                resultFlag = -1;
                _objIAppLogger.LogError(ex);
            }

            return resultFlag;
        }

        public lmsWard GetWardDetailsById(int WardId)
        {
            try
            {
                if (WardId == 0)
                {
                    var newWard = new lmsWard();
                    newWard.ISACTIVE = true;
                    return newWard;
                }
                var resultDetails = _objLabManagementEntities.lmsWards.FirstOrDefault(x => x.WARDID == WardId);
                resultDetails.ISACTIVE = resultDetails.ISACTIVE == null ? true : resultDetails.ISACTIVE.Value;
                return resultDetails;
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
                return null;
            }
        }

        public IList<lmsWard> GetAllWard()
        {
            try
            {
                var resultDetails = _objLabManagementEntities.lmsWards.Select(x => x);
                return resultDetails.OrderByDescending(x => x.WARDID).ToList();
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
                return null;
            }
        }

        public int SaveWard(lmsWard objWardMaster)
        {
            var resultId = 0;
            try
            {
                if (objWardMaster.WARDID > 0)
                {
                    _objLabManagementEntities.lmsWards.Attach(objWardMaster);
                    _objLabManagementEntities.Entry(objWardMaster).State = EntityState.Modified;
                }
                else
                {
                    _objLabManagementEntities.lmsWards.Add(objWardMaster);
                }
                _objLabManagementEntities.SaveChanges();
                resultId = _objLabManagementEntities.lmsWards.AsEnumerable().LastOrDefault().WARDID;
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
            }

            return resultId;
        }

        public int DeleteWard(int WardId)
        {
            var resultFlag = 0;
            try
            {
                var WardObject = _objLabManagementEntities.lmsWards.FirstOrDefault(x => x.WARDID == WardId);
                _objLabManagementEntities.lmsWards.Remove(WardObject);
                _objLabManagementEntities.SaveChanges();
            }
            catch (Exception ex)
            {
                resultFlag = -1;
                _objIAppLogger.LogError(ex);
            }

            return resultFlag;
        }

        public List<DownLoadFileInformation> GetFiles(string dowloadType)
        {
            var filePath = dowloadType == "TEMPLATE" ? ConfigurationWrapper.StringSettings(ConfigKey.TemplateUploadPath) : ConfigurationWrapper.StringSettings(ConfigKey.PatientUploadPath);
            var lstFiles = new List<DownLoadFileInformation>();
            var dirInfo = new DirectoryInfo(filePath);

            int i = 0;
            foreach (var item in dirInfo.GetFiles())
            {
                lstFiles.Add(new DownLoadFileInformation()
                {
                    FileId = i + 1,
                    FileName = item.Name,
                    FilePath = dirInfo.FullName + @"\" + item.Name
                });
                i = i + 1;
            }
            return lstFiles;
        }

        public IList<usp_GetDrugDdl_Result> GetDrugsDdl()
        {
            return _objLabManagementEntities.usp_GetDrugDdl().ToList();
        }

        public lmsMedicalTestFor GetMedicalTestForById(int Id)
        {
            try
            {
                if (Id == 0)
                {
                    var newItem = new lmsMedicalTestFor();

                    return newItem;
                }
                var resultDetails = _objLabManagementEntities.lmsMedicalTestFors.FirstOrDefault(x => x.TESTFORID == Id);
                return resultDetails;
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
                return null;
            }
        }

        public IList<lmsMedicalTestFor> GetAllMedicalTestFor()
        {
            try
            {
                var resultDetails = _objLabManagementEntities.lmsMedicalTestFors.Select(x => x);
                return resultDetails.OrderBy(x => x.TESTFORID).ToList();
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
                return null;
            }
        }

        public IList<string> GetAllMedicalTestForNames(List<int> ids)
        {
            try
            {
                var resultDetails = _objLabManagementEntities.lmsMedicalTestFors.Where(x => ids.Contains(x.TESTFORID));
                return resultDetails.Any() ? resultDetails.Select(x => x.TESTFOR).ToList() : null;
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
                return null;
            }
        }

        public int SaveMedicalTestFor(lmsMedicalTestFor objSaveData)
        {
            var resultId = 0;
            try
            {
                if (objSaveData.TESTFORID > 0)
                {
                    _objLabManagementEntities.lmsMedicalTestFors.Attach(objSaveData);
                    _objLabManagementEntities.Entry(objSaveData).State = EntityState.Modified;
                }
                else
                {
                    _objLabManagementEntities.lmsMedicalTestFors.Add(objSaveData);
                }
                _objLabManagementEntities.SaveChanges();
                var result = _objLabManagementEntities.lmsMedicalTestFors.Where(x => x.TESTFOR == objSaveData.TESTFOR);
                resultId = result.Any() ? result.Single().TESTFORID : 0;
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
            }

            return resultId;
        }

        public int DeleteMedicalTestFor(int Id)
        {
            var resultFlag = 0;
            try
            {
                var deleteObject = _objLabManagementEntities.lmsMedicalTestFors.FirstOrDefault(x => x.TESTFORID == Id);
                _objLabManagementEntities.lmsMedicalTestFors.Remove(deleteObject);
                _objLabManagementEntities.SaveChanges();
            }
            catch (Exception ex)
            {
                resultFlag = -1;
                _objIAppLogger.LogError(ex);
            }

            return resultFlag;
        }

        public lmsMedicalTestGroup GetMedicalGroupById(int Id)
        {
            try
            {
                if (Id == 0)
                {
                    var newItem = new lmsMedicalTestGroup();

                    return newItem;
                }
                var resultDetails = _objLabManagementEntities.lmsMedicalTestGroups.FirstOrDefault(x => x.GROUPID == Id);
                return resultDetails;
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
                return null;
            }
        }

        public IList<lmsMedicalTestGroup> GetAllMedicalTestGroup()
        {
            try
            {
                var resultDetails = _objLabManagementEntities.lmsMedicalTestGroups.Select(x => x);
                return resultDetails.OrderBy(x => x.GROUPID).ToList();
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
                return null;
            }
        }

        public int SaveMedicalTestGroup(lmsMedicalTestGroup objSaveData)
        {
            var resultId = 0;
            try
            {
                if (objSaveData.GROUPID > 0)
                {
                    _objLabManagementEntities.lmsMedicalTestGroups.Attach(objSaveData);
                    _objLabManagementEntities.Entry(objSaveData).State = EntityState.Modified;
                }
                else
                {
                    _objLabManagementEntities.lmsMedicalTestGroups.Add(objSaveData);
                }
                _objLabManagementEntities.SaveChanges();
                var result = _objLabManagementEntities.lmsMedicalTestGroups.Where(x => x.GROUPNAME == objSaveData.GROUPNAME);
                resultId = result.Any() ? result.Single().GROUPID : 0;
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
            }

            return resultId;
        }

        public int DeleteMedicalTestGroup(int Id)
        {
            var resultFlag = 0;
            try
            {
                var deleteObject = _objLabManagementEntities.lmsMedicalTestGroups.FirstOrDefault(x => x.GROUPID == Id);
                _objLabManagementEntities.lmsMedicalTestGroups.Remove(deleteObject);
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

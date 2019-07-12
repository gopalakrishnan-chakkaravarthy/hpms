using System.IO;
using Excel;
using Excel.Core;
using Excel.Log;
using System.Data;
using System;
namespace Lab.Management.Utils
{
    public class LMSExcelDataReader : ILMSExcelDataReader
    {
        DataSet dsResult;
        public DataSet ProcessFile(string InFilePath)
        {
            var stream = File.Open(InFilePath, FileMode.Open, FileAccess.Read);
            dsResult = new DataSet();
            try
            {
                var fileExtension = Path.GetExtension(InFilePath);
                //1.CreateBinaryReader for 97 and 2003 excel reader
                //2. Reading from a OpenXml Excel file (2007 format; *.xlsx)
                var excelReader = fileExtension.Equals(".xls") ? ExcelReaderFactory.CreateBinaryReader(stream) :
                    ExcelReaderFactory.CreateOpenXmlReader(stream);
                //4. DataSet - Create column names from first row
                excelReader.IsFirstRowAsColumnNames = true;
                dsResult = excelReader.AsDataSet();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                //stream.Flush();
                stream.Dispose();
            }
            return dsResult;
        }
    }
}

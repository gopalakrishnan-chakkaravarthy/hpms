using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Management.Utils
{
    public interface ILMSExcelDataReader
    {
        DataSet ProcessFile(string InFilePath);

    }
}

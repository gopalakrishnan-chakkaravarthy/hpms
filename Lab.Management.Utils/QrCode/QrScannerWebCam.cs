using System;
using System.IO;

namespace Lab.Management.Utils.QrCode
{
    public class QrScannerWebCam
    {
        public void ReadFromStream(Stream InputStream, string path)
        {
            string dump = "";
            using (var reader = new StreamReader(InputStream))
            {
                dump = reader.ReadToEnd();
                File.WriteAllBytes(path, String_To_Bytes2(dump));
            }
        }

        private byte[] String_To_Bytes2(string strInput)
        {
            int numBytes = (strInput.Length) / 2;
            byte[] bytes = new byte[numBytes];
            for (int x = 0; x < numBytes; ++x)
            {
                bytes[x] = Convert.ToByte(strInput.Substring(x * 2, 2), 16);
            }
            return bytes;
        }
    }
}

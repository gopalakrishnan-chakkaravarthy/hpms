using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Lab.Management.Common;
using AutoMapper;
namespace Lab.Management.Common
{
    public static class CryptoManager
    {
        
        public static string passwordEncrypt(this string inText)
        {
            byte[] bytesBuff = Encoding.Unicode.GetBytes(inText);
            using (Aes aes = Aes.Create())
            {
                var crypto = new Rfc2898DeriveBytes(ConfigurationWrapper.StringSettings(ConfigKey.LMSSaltValue), new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                aes.Key = crypto.GetBytes(32);
                aes.IV = crypto.GetBytes(16);
                using (var mStream = new MemoryStream())
                {
                    using (var cStream = new CryptoStream(mStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cStream.Write(bytesBuff, 0, bytesBuff.Length);
                        cStream.Close();
                    }
                    inText = Convert.ToBase64String(mStream.ToArray());
                }
            }
            return inText;
        }
        //Decrypting a string
        public static string passwordDecrypt(this string cryptTxt)
        {
            cryptTxt = cryptTxt.Replace(" ", "+");
            byte[] bytesBuff = Convert.FromBase64String(cryptTxt);
            using (var aes = Aes.Create())
            {
                var crypto = new Rfc2898DeriveBytes(ConfigurationWrapper.StringSettings(ConfigKey.LMSSaltValue), new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                aes.Key = crypto.GetBytes(32);
                aes.IV = crypto.GetBytes(16);
                using (var mStream = new MemoryStream())
                {
                    using (var cStream = new CryptoStream(mStream, aes.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cStream.Write(bytesBuff, 0, bytesBuff.Length);
                        cStream.Close();
                    }
                    cryptTxt = Encoding.Unicode.GetString(mStream.ToArray());
                }
            }
            return cryptTxt;
        }
    }
}

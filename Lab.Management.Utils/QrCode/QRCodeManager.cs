namespace Lab.Management.Utils.QrCode
{
    using System;
    using System.Drawing.Imaging;
    using System.IO;
    using ZXing;
    using ZXing.Common;

    public static class QRCodeManager
    {
        public static string GenerateQrCode(this string content, int height = 100, int width = 100, int margin = 0)
        {
            string imgeUrl = "";
            var qrWriter = new BarcodeWriter
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new EncodingOptions() { Height = height, Width = width, Margin = margin }
            };

            using (var q = qrWriter.Write(content))
            {
                using (var ms = new MemoryStream())
                {
                    q.Save(ms, ImageFormat.Png);
                    imgeUrl = String.Format("data:image/png;base64,{0}", Convert.ToBase64String(ms.ToArray()));
                }
            }
            return imgeUrl;
        }
    }
}

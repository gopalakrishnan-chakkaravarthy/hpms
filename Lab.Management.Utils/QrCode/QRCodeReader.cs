using Lab.Management.Entities.Model;
using System.Drawing;
using ZXing;

namespace Lab.Management.Utils.QrCode
{
    public class QRCodeReader
    {
        private string _imagePath;
        public QRCodeReader(string imagePath)
        {
            _imagePath = imagePath;
        }

        public QRCodeModel ReadQRCode()
        {
            var barcodeReader = new BarcodeReader();
            string barcodeText = "";
            var result = barcodeReader.Decode(GetBitmap());
            if (result != null)
            {
                barcodeText = result.Text;
            }
            return new QRCodeModel() { QRCodeText = barcodeText, QRCodeImagePath = _imagePath };
        }

        private Bitmap GetBitmap()
        {
            return new Bitmap(_imagePath);
        }
    }
}

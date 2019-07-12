using System.ComponentModel.DataAnnotations;

namespace Lab.Management.Entities.Model
{
    public class QRCodeModel
    {
        [Display(Name = "QRCode Text")]
        public string QRCodeText { get; set; }

        [Display(Name = "QRCode Image")]
        public string QRCodeImagePath { get; set; }

        public QRCodeModel()
        {
            QRCodeText = string.Empty;
            QRCodeImagePath = string.Empty;
        }
    }
}

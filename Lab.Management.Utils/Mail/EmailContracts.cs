
namespace Lab.Management.Utils
{
    public class EmailContracts
    {
        public string emailFrom { get; set; }
        public string emailTo { get; set; }
        public string emailCc { get; set; }
        public string emailBcc { get; set; }
        public string emailSubject { get; set; }
        public string emailBody { get; set; }
        public bool isBodyHtml { get; set; }
        public bool hasAttachement { get; set; }
        public string attachmentType { get; set; }
        public string attachmentName { get; set; }
        public byte[] attachement { get; set; }
    }
}


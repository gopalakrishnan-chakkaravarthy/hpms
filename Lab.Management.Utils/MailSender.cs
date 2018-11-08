using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.IO;
using System;
using Lab.Management.Common;
namespace Lab.Management.Utils
{
    public static class MailSender
    {
        public static int SendMail(EmailContracts objEmailContracts)
        {
            var _objMailMessage = new MailMessage();
            try
            {

                if (objEmailContracts != null)
                {
                    if (string.IsNullOrEmpty(objEmailContracts.emailFrom))
                        return 2;
                    if (string.IsNullOrEmpty(objEmailContracts.emailTo))
                        return 3;
                    var _mailAddress = new MailAddress(objEmailContracts.emailFrom);
                    _objMailMessage.From = _mailAddress;
                    _objMailMessage.To.Add(objEmailContracts.emailTo);
                    if (!string.IsNullOrEmpty(objEmailContracts.emailCc))
                        _objMailMessage.CC.Add(objEmailContracts.emailCc);
                    if (!string.IsNullOrEmpty(objEmailContracts.emailBcc))
                        _objMailMessage.Bcc.Add(objEmailContracts.emailBcc);

                    _objMailMessage.Subject = !string.IsNullOrEmpty(objEmailContracts.emailSubject) ? objEmailContracts.emailSubject :
                        "No Subject";
                    _objMailMessage.Body = !string.IsNullOrEmpty(objEmailContracts.emailBody) ? objEmailContracts.emailBody : "N/A";
                    if (objEmailContracts.hasAttachement)
                    {
                        var _attachement = new Attachment(new MemoryStream(objEmailContracts.attachement), objEmailContracts.attachmentName, objEmailContracts.attachmentType);
                        _objMailMessage.Attachments.Add(_attachement);
                    }
                    _objMailMessage.IsBodyHtml = objEmailContracts.isBodyHtml;

                    var smtpclientDetails = new SmtpClient(ConfigurationWrapper.StringSettings(ConfigKey.SmtpHost));
                    var netWorkCredential = new NetworkCredential(ConfigurationWrapper.StringSettings(ConfigKey.SmtpUserName), ConfigurationWrapper.StringSettings(ConfigKey.SmtpPassword));
                    smtpclientDetails.Port = ConfigurationWrapper.IntegerSettings(ConfigKey.SmtpPort);
                    smtpclientDetails.Credentials = netWorkCredential;
                    smtpclientDetails.SendAsync(_objMailMessage, string.Format("lms_{0}", DateTime.Now.ToString("MM-dd-yyyy")));

                }
                return 1;
            }
            catch
            {
                return 0;
            }
        }
    }
}

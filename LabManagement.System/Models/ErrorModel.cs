using System;

namespace LabManagement.System.Models
{
    public class ErrorModel
    {
        public string Controller { get; set; }
        public string Action { get; set; }
        public Exception Exception { get; set; }
    }
}

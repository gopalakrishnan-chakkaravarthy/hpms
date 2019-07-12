using log4net;
using System;
//[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace Lab.Management.Logger
{
    public class AppLogger : IAppLogger
    {
        protected static readonly ILog log = LogManager.GetLogger(typeof(IAppLogger));
        public void Loginfo(string logMessage)
        {
            log.InfoFormat("Log Date : {0},Log Message {1}{2}", DateTime.Now, logMessage, Environment.NewLine);
        }

        public void LogError(Exception exMessage)
        {
            log.ErrorFormat("Exception Date {0},Exception Message{1}{2}", DateTime.Now, exMessage, Environment.NewLine);
        }
    }
}

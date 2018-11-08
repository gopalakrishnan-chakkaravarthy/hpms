using System;
namespace Lab.Management.Logger
{
    public interface IAppLogger
    {
        void Loginfo(string logMessage);
        void LogError(Exception exMessage);
    }
}

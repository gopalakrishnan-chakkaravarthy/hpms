using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace Lab.Management.Common
{
    public static class ConfigurationWrapper
    {
        public static string StringSettings(ConfigKey key, string defaultValue = "")
        {
            return !string.IsNullOrEmpty(ReturnConfigKey(key)) ? Convert.ToString(ConfigurationManager.AppSettings[ReturnConfigKey(key)]) : defaultValue;
        }
        public static bool BooleanSettigs(ConfigKey key, bool defaultValue = false)
        {
            return !string.IsNullOrEmpty(ReturnConfigKey(key)) ? Convert.ToBoolean(ConfigurationManager.AppSettings[ReturnConfigKey(key)]) : defaultValue;
        }
        public static double DoubleSettings(ConfigKey key, double defaultValue = 0)
        {
            return !string.IsNullOrEmpty(ReturnConfigKey(key)) ? Convert.ToDouble(ConfigurationManager.AppSettings[ReturnConfigKey(key)]) : defaultValue;
        }
        public static int IntegerSettings(ConfigKey key, int defaultValue = 0)
        {
            return !string.IsNullOrEmpty(ReturnConfigKey(key)) ? Convert.ToInt16(ConfigurationManager.AppSettings[ReturnConfigKey(key)]) : defaultValue;
        }
        public static IList<string> StringListSetting(ConfigKey key, char seperator = ',')
        {
            return !string.IsNullOrEmpty(ReturnConfigKey(key)) ? Convert.ToString(ConfigurationManager.AppSettings[ReturnConfigKey(key)]).Split(seperator).ToList() : null;
        }
        public static string DateSettings(ConfigKey key, string format = "MM/dd/yyyy")
        {
            return !string.IsNullOrEmpty(ReturnConfigKey(key)) ? Convert.ToDateTime(ConfigurationManager.AppSettings[ReturnConfigKey(key)]).ToString(format) : DateTime.Now.ToString(format);
        }

        
        private static string ReturnConfigKey(ConfigKey key)
        {
            return Convert.ToString(key);
        }
        public static string[] SplitString(string value, char seperator = ',')
        {
            return value.Split(seperator);
        }

    }
}

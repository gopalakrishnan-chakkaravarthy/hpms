using PMS.Web.Apps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.Web.Apps.Common
{
    public static class WebExtension
    {
        public static Array GetCssBundleEnum()
        {
            return Enum.GetValues(typeof(BundleCssPath));

        }
        public static Array GetJsBundleEnum()
        {
            return Enum.GetValues(typeof(BundlePath));

        }
        public static string GetEnumName<T>(this object value)
        {

            return Enum.GetName(typeof(T), value);

        }
        public static string[] BuldleFilesToCsv(this List<string> inValue, string relativePath)
        {
            var resultArray = inValue.Select(name => string.Format("{0}/{1}", relativePath, name)).ToArray();

            return resultArray;
        }
    }
}
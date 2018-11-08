using PMS.Web.Apps.Models;
using System;
using System.IO;
using System.Web;
using System.Web.Hosting;
using System.Web.Optimization;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using PMS.Web.Apps.Common;
namespace PMS.Web.Apps
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            var bundleType = typeof(BundleCssPath);
            var bundleEnums = WebExtension.GetCssBundleEnum();
            var relativePath = string.Empty;
            foreach (var bundleEnum in bundleEnums)
            {
                var filePath = GetCssPath((BundleCssPath)bundleEnum, out relativePath);
                if (relativePath == string.Empty)
                    break;
                var bundlingFiles = new DirectoryInfo(filePath).GetFiles().Select(x => x.Name).ToList();
                bundles.Add(new StyleBundle(string.Format("~/Content/css/{0}", bundleEnum.GetEnumName<BundleCssPath>()))
                        .Include(bundlingFiles.BuldleFilesToCsv(relativePath)));


            }
            var bundlejsType = typeof(BundlePath);
            var bundlejsEnums = WebExtension.GetJsBundleEnum();
            foreach (var bundleEnum in bundlejsEnums)
            {

                var filePath = GetScriptPath((BundlePath)bundleEnum, out relativePath);
                if (relativePath == string.Empty)
                    break;
                var bundlingFiles = new DirectoryInfo(filePath).GetFiles().Where(x => x.Name.EndsWith("js")).Select(x => x.Name).ToList();
                bundles.Add(new ScriptBundle(string.Format("~/bundles/{0}",
                     bundleEnum.GetEnumName<BundlePath>()))
                     .Include(bundlingFiles.BuldleFilesToCsv(relativePath)));

            }
        }
        private static string GetCssPath(BundleCssPath toolName, out string relativePath)
        {
            var bundlePath = "";
            relativePath = string.Empty;
            switch (toolName)
            {

                case BundleCssPath.Bootstrap:
                    relativePath = "~/Content/UI.Tools/bootstrap/css/";
                    break;
                //case BundleCssPath.Bootstrapsocial:
                //    relativePath = "~/Content/UI.Tools/bootstrap-social/css/";
                //    break;
                case BundleCssPath.datatables:
                    relativePath = "~/Content/UI.Tools/datatables/css/";
                    break;
                default:
                    relativePath = "~/Content/";
                    break;

            }
            if (relativePath != string.Empty)
                bundlePath = HostingEnvironment.MapPath(relativePath);
            return bundlePath;
        }

        private static string GetScriptPath(BundlePath toolName, out string relativePath)
        {
            var bundlePath = "";
            relativePath = string.Empty;
            switch (toolName)
            {
                case BundlePath.Jquery:
                    relativePath = "~/Content/UI.Tools/Jquery/";
                    break;
                case BundlePath.Bootstrapjs:
                    relativePath = "~/Content/UI.Tools/bootstrap/js/";
                    break;

                case BundlePath.datatablesjs:
                    relativePath = "~/Content/UI.Tools/datatables/js/";
                    break;
                //case BundlePath.datatablesbuttons:
                //    relativePath = "~/Content/UI.Tools/datatables/js/buttons/";
                //    break;
                //case BundlePath.Require:
                //    relativePath = "~/Content/UI.Tools/Require/";
                //    break;
                case BundlePath.UIGrid:
                    relativePath = "~/Content/UI.Tools/UI.Grid/";
                    break;

                case BundlePath.Angularjs:
                    relativePath = "~/Content/UI.Tools/Angular/Angularjs/";
                    break;
                case BundlePath.UIBootstrap:
                    relativePath = "~/Content/UI.Tools/Angular/UI.Bootstrap/";
                    break;
            }
            if (relativePath != string.Empty)
                bundlePath = HostingEnvironment.MapPath(relativePath);
            return bundlePath;
        }
    }
}
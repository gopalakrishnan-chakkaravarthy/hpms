using System.Web.Optimization;

namespace LabManagement.System
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                                 "~/Content/js/bootstrap.js",
                                 "~/Content/js/jquery.dataTables.js",
                                 "~/Content/js/dataTables.bootstrap.js",
                                 "~/Content/js/bootstrap-datepicker.js"
                                 , "~/Content/js/bootstrap-select.js",
                                 "~/Content/js/html2canvas.js",
                                 "~/Content/js/base64.js",
                                 "~/Content/js/canvas2image.js",
                                  "~/Content/js/ckeditor.js",
                                   "~/Content/js/jquery.webcam.js",
                                    "~/Content/js/jscam.swf",
                                     "~/Content/js/jscam_canvas_only.swf",
                                 "~/Scripts/AppScripts/Common.js"
                                ));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/Site.css",
                "~/Content/css/bootstrap.css",
                 "~/Content/css/bootstrap-theme.css",
                "~/Content/css/carousel.css",
                "~/Content/css/dataTables.bootstrap.css",
                "~/Content/css/responsive.bootstrap.css",
                "~/Content/css/bootstrap-datepicker.css",
                "~/Content/css/bootstrap-select.css",
                "~/Content/css/bootstrap-wysihtml5.css"
                ));
        }
    }
}

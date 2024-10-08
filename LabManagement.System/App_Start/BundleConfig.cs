﻿using System.Web.Optimization;

namespace LabManagement.System
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
#if DEBUG
            RegisterDebugBundle(bundles);
#else
            RegisterDebugBundle(bundles);
#endif
        }

        private static void RegisterReleaseBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/Ajquery").Include(
                        "~/Scripts/jquery-1.8.2.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/Bbootstrap").Include(
                      "~/Content/js/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/CjquerydataTables").Include(
                     "~/Content/js/jquery.dataTables.js"));
            bundles.Add(new ScriptBundle("~/bundles/DdataTablesbootstrap").Include(
                     "~/Content/js/dataTables.bootstrap.js"));
            bundles.Add(new ScriptBundle("~/bundles/Edatepicker").Include(
                     "~/Content/js/bootstrap-datepicker.js"));
            bundles.Add(new ScriptBundle("~/bundles/Fbootstrapselect").Include(
                     "~/Content/js/bootstrap-select.js"));

            bundles.Add(new ScriptBundle("~/bundles/Ghtml2canvas").Include(
                  "~/Content/js/html2canvas.js"));
            bundles.Add(new ScriptBundle("~/bundles/Hbase64").Include(
                  "~/Content/js/base64.js"));
            bundles.Add(new ScriptBundle("~/bundles/Icanvas2image").Include(
                  "~/Content/js/canvas2image.js"));
            bundles.Add(new ScriptBundle("~/bundles/jjspdf").Include(
                  "~/Content/js/jspdf.min.js", "~/Content/js/jspdf.plugin.autotable.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/Kjquerywebcam").Include(
                "~/Content/js/jquery.webcam.js"));
            bundles.Add(new ScriptBundle("~/bundles/Ljscam").Include(
                "~/Content/js/jscam.js"));
            bundles.Add(new ScriptBundle("~/bundles/Mjscamcanvasonly").Include(
                "~/Content/js/jscam_canvas_only.swf"));
            bundles.Add(new ScriptBundle("~/bundles/NCommon").Include(
              "~/Scripts/AppScripts/Common.js"));
            bundles.Add(new ScriptBundle("~/bundles/OBillPdf").Include(
            "~/Scripts/AppScripts/pdfexport/bill-pdf.js"));
            bundles.Add(new ScriptBundle("~/bundles/PExcleExport").Include(
           "~/Scripts/jquery.table2excel.js"));

            bundles.Add(new StyleBundle("~/Content/cssBndl").Include("~/Content/Site.css",
                "~/Content/css/bootstrap.css",
                 "~/Content/css/bootstrap-theme.css",
                "~/Content/css/carousel.css",
                "~/Content/css/dataTables.bootstrap.css",
                "~/Content/css/responsive.bootstrap.css",
                "~/Content/css/bootstrap-datepicker.css",
                "~/Content/css/bootstrap-select.css",
                "~/Content/css/bootstrap-wysihtml5.css",
                "~/Content/css/ckEditorStyle.css"
                ));
            // BundleTable.EnableOptimizations = false;
        }

        private static void RegisterDebugBundle(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/Ajquery").Include(
                        "~/Scripts/jquery-1.8.2.js"));
            bundles.Add(new ScriptBundle("~/bundles/Bbootstrap").Include(
                      "~/Content/js/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/CjquerydataTables").Include(
                     "~/Content/js/jquery.dataTables.js"));
            bundles.Add(new ScriptBundle("~/bundles/DdataTablesbootstrap").Include(
                     "~/Content/js/dataTables.bootstrap.js"));
            bundles.Add(new ScriptBundle("~/bundles/Edatepicker").Include(
                     "~/Content/js/bootstrap-datepicker.js"));
            bundles.Add(new ScriptBundle("~/bundles/Fbootstrapselect").Include(
                     "~/Content/js/bootstrap-select.js"));

            bundles.Add(new ScriptBundle("~/bundles/Ghtml2canvas").Include(
                  "~/Content/js/html2canvas.js"));
            bundles.Add(new ScriptBundle("~/bundles/Hbase64").Include(
                  "~/Content/js/base64.js"));
            bundles.Add(new ScriptBundle("~/bundles/Icanvas2image").Include(
                  "~/Content/js/canvas2image.js"));

            bundles.Add(new ScriptBundle("~/bundles/jjspdf").Include(
             "~/Content/js/jspdf.debug.js", "~/Content/js/jspdf.plugin.autotable.js"));

            bundles.Add(new ScriptBundle("~/bundles/Kjquerywebcam").Include(
                "~/Content/js/jquery.webcam.js"));
            bundles.Add(new ScriptBundle("~/bundles/Ljscam").Include(
                "~/Content/js/jscam.js"));
            bundles.Add(new ScriptBundle("~/bundles/Mjscamcanvasonly").Include(
                "~/Content/js/jscam_canvas_only.swf"));
            bundles.Add(new ScriptBundle("~/bundles/cckeditor").Include(
                    "~/Content/js/ckeditor/ckeditor.js"));
            bundles.Add(new ScriptBundle("~/bundles/PExcleExport").Include(
          "~/Scripts/jquery.table2excel.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/NCommon").Include(
              "~/Scripts/AppScripts/Common.js"));

            bundles.Add(new ScriptBundle("~/bundles/OBillPdf").Include(
           "~/Scripts/AppScripts/pdfexport/bill-pdf.js"));
            bundles.Add(new ScriptBundle("~/bundles/PExcleExport").Include(
          "~/Scripts/jquery.table2excel.js"));


            bundles.Add(new StyleBundle("~/Content/cssBndl").Include("~/Content/Site.css",
                "~/Content/css/bootstrap.css",
                 "~/Content/css/bootstrap-theme.css",
                "~/Content/css/carousel.css",
                "~/Content/css/dataTables.bootstrap.css",
                "~/Content/css/responsive.bootstrap.css",
                "~/Content/css/bootstrap-datepicker.css",
                "~/Content/css/bootstrap-select.css",
                "~/Content/css/bootstrap-wysihtml5.css",
                "~/Content/css/ckEditorStyle.css"
                ));
            BundleTable.EnableOptimizations = false;
        }
    }
}

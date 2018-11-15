using System.Web;
using System.Web.Optimization;

namespace MapWeb
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                         "~/Scripts/Highcharts-4.0.1/js/highcharts.js",
                         "~/Content/Dash/bower_components/jquery-slimscroll/jquery.slimscroll.min.js",
                         "~/Content/Dash/bower_components/fastclick/lib/fastclick.js",
                         "~/Content/Dash/dist/js/adminlte.min.js",
                         "~/Content/Dash/dist/js/demo.js"
                         ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/Dash/dist/css/AdminLTE.min.css",
                      "~/Content/Dash/dist/css/skins/_all-skins.min.css"
                      ));

            BundleTable.EnableOptimizations = true;
        }
    }
}

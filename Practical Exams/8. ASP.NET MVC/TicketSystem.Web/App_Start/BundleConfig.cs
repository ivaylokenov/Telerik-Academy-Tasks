using System.Web;
using System.Web.Optimization;

namespace TicketSystem.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/Kendo/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryajax").Include(
                        "~/Scripts/jquery.unobtrusive-ajax.min.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new
               ScriptBundle("~/bundles/kendo").Include(
                    "~/Scripts/Kendo/kendo.all.min.js",
                    "~/Scripts/Kendo/kendo.aspnetmvc.min.js"));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/bootstrap-responsive.css"));

            bundles.Add(new
               StyleBundle("~/Content/kendo").Include(
                    "~/Content/Kendo/kendo.common.min.css",
                    "~/Content/Kendo/kendo.default.min.css",
                    "~/Content/Kendo/kendo.black.min.css"));

        }
    }
}

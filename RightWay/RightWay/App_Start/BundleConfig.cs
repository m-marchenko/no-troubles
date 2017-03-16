﻿using System.Web;
using System.Web.Optimization;

namespace RightWay
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                      //"~/Scripts/jssor.js",
                      //"~/Scripts/jssor.slider.js",
                      "~/dist/photoswipe.js",
                      "~/dist/photoswipe-ui-default.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap-slate.css",
                      "~/Content/site.css",
                      "~/dist/photoswipe.css",
                      "~/dist/default-skin/default-skin.css"));
        }
    }
}

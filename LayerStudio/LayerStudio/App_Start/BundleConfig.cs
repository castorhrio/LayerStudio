using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace LayerStudio
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/basecss")
                .Include("~/Content/base.css")
                .Include("~/Content/forms.css"));

            bundles.Add(new ScriptBundle("~/bundles/jquery")
           .Include("~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval")
           .Include("~/Scripts/jquery.unobtrusive*", "~/Scripts/jquery.validate*"));
        }
    }
}
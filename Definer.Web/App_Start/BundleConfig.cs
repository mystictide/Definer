﻿using System.Web;
using System.Web.Optimization;

namespace Definer.Web
{
    public class BundleConfig
    {

        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/style")
              .Include("~/Content/plugin/jqueryui/css/jquery-ui.min.css", new CssRewriteUrlTransform())
              .Include("~/Content/plugin/fontawesome/css/font-awasome.css", new CssRewriteUrlTransform())
              .Include("~/Content/plugin/jqueryconfirm/css/jquery-confirm.css", new CssRewriteUrlTransform())
              .Include("~/Content/css/Style.min.css", new CssRewriteUrlTransform()));


            bundles.Add(new ScriptBundle("~/bundles/scripts")
                .Include("~/Content/plugin/jquery/js/jquery-3.3.1.min.js")
                .Include("~/Content/plugin/jqueryui/js/jquery-ui.js")
                .Include("~/Content/plugin/jqueryconfirm/js/jquery-confirm.js"));

            #region Validate 

            bundles.Add(new ScriptBundle("~/bundles/scripts/validate")
               .Include("~/content/plugin/validate/js/jquery.validate.min.js")
               .Include("~/content/plugin/validate/js/jquery.validate.unobtrusive.js")
               .Include("~/content/plugin/validate/js/jquery.validate.hooks.js")
               .Include("~/content/plugin/validate/js/customMethod.js"));

            #endregion
        }
    }
}

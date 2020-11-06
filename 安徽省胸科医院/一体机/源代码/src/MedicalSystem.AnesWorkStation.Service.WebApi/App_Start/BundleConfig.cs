using System.Web;
using System.Web.Optimization;

namespace MedicalSystem.AnesWorkStation.Service.WebApi
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // 使用要用于开发和学习的 Modernizr 的开发版本。然后，当你做好
            // 生产准备时，请使用 http://modernizr.com 上的生成工具来仅选择所需的测试。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            //EasyUI Style
            bundles.Add(new StyleBundle("~/Content/easyui/css").Include(
                      "~/Content/easyui/themes/bootstrap/easyui.css",
                      "~/Content/easyui/themes/icon.css"
                ));

            //EasyUI jquery
            bundles.Add(new ScriptBundle("~/Content/easyui/jquery").Include(
                      "~/Content/easyui/jquery.min.js",
                      "~/Content/easyui/jquery.easyui.min.js",
                      "~/Content/easyui/locale/easyui-lang-zh_CN.js"
                ));

            //bootstrap css
            bundles.Add(new StyleBundle("~/Content/bootstrap/css").Include(
                      "~/Content/bootstrap/css/bootstrap.min.css",
                      "~/Content/EasyUI11/static/plugins/font-awesome/css/font-awesome.min.css"
                ));

            //bootstrap scrpit
            bundles.Add(new ScriptBundle("~/Content/bootstrap/scrpit").Include(
                      "~/Content/bootstrap/js/bootstrap.min.js"
                ));
            BundleTable.EnableOptimizations = false;
        }
    }
}

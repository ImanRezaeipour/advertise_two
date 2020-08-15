using System.Collections.Generic;
using System.Web.Optimization;
using Advertise.Core.Configuration;
using Advertise.Core.Infrastructure.DependencyManagement;

namespace Advertise.Web.Framework.Configs
{

    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region Styles

            bundles.Add(PanelStyle());
            bundles.Add(LandingStyle());

            #endregion

            #region Scripts

            bundles.Add(PanelScript());
            bundles.Add(LandingScript());

            #endregion

            #region Settings

            var bundleEnabled = ContainerManager.Container.GetInstance<IConfigurationManager>().BundleEnabled;
            BundleTable.EnableOptimizations = bundleEnabled;

            #endregion
        }


        private static Bundle PanelStyle()
        {
            return new StyleBundle("~/bundles/panelstyles/css")

                //  FontAwesome
                .Include("~/Bundles/Vendors/FontAwesome/css/font-awesome.min.css", new CssRewriteUrlTransform())

                //jsPersianDatePicker
                .Include("~/Bundles/Vendors/jsPersianDatePicker/Content/PersianDatePicker.min.css")

                //  Noty
                .Include("~/Bundles/Vendors/Noty/noty.css")

                //  Tooltipster
                .Include("~/Bundles/Vendors/Tooltipster/tooltipster.bundle.min.css")
                .Include("~/Bundles/Vendors/Tooltipster/plugins/tooltipster/sideTip/themes/tooltipster-sideTip-light.min.css")

                //  FineUploader
                .Include("~/Bundles/Vendors/FineUploader/fine-uploader-gallery.css")

                //  JSTree
                .Include("~/Bundles/Vendors/JSTree/themes/default/style.min.css", new CssRewriteUrlTransform())

                //  Plyr
                .Include("~/Bundles/Vendors/Plyr/plyr.css", new CssRewriteUrlTransform())

                //  ICheck
                .Include("~/Bundles/Vendors/ICheck/skins/flat/red.css", new CssRewriteUrlTransform())

                //  Select2
                .Include("~/Bundles/Vendors/Select2/css/select2.min.css")
                //.Include("~/Bundles/Vendors/Select2ToTree/select2totree.css")

                //  TinyMCE
                .Include("~/Bundles/Vendors/TinyMCE/skins/novinak/content.inline.min.css", new CssRewriteUrlTransform())
                .Include("~/Bundles/Vendors/TinyMCE/skins/novinak/content.min.css", new CssRewriteUrlTransform())
                .Include("~/Bundles/Vendors/TinyMCE/skins/novinak/skin.min.css", new CssRewriteUrlTransform())

                //  Croppie
                .Include("~/Bundles/Vendors/Croppie/croppie.css", new CssRewriteUrlTransform())

                //  Font
                .Include("~/Bundles/Vendors/Fonts/iransans.css")

                //  Custom
                .Include("~/Bundles/Styles/novinakdb.css", new CssRewriteUrlTransform())
                .Include("~/Bundles/Styles/novinak.css", new CssRewriteUrlTransform())
                .Include("~/Bundles/Styles/dashboard.css")
                .Include("~/Bundles/Styles/gridView.css")
                .Include("~/Bundles/Styles/itemView.css")
                .Include("~/Bundles/Styles/site.css");
        }


        private static Bundle LandingStyle()
        {
            return new StyleBundle("~/bundles/landingstyles/css")

                //  FontAwesome
                .Include("~/Bundles/Vendors/FontAwesome/css/font-awesome.min.css", new CssRewriteUrlTransform())

                //  Noty
                .Include("~/Bundles/Vendors/Noty/noty.css")

                //  Tooltipster
                .Include("~/Bundles/Vendors/Tooltipster/tooltipster.bundle.min.css")
                .Include("~/Bundles/Vendors/Tooltipster/plugins/tooltipster/sideTip/themes/tooltipster-sideTip-light.min.css")
                
                //  OwlCarousel
                .Include("~/Bundles/Vendors/OwlCarousel/owl.carousel.min.css")
                .Include("~/Bundles/Vendors/OwlCarousel/owl.theme.default.min.css")

                //  Plyr
                .Include("~/Bundles/Vendors/Plyr/plyr.css", new CssRewriteUrlTransform())

                //  RangeSlider
                .Include("~/Bundles/Vendors/IonRangeSlider/css/ion.rangeSlider.css", new CssRewriteUrlTransform())
                .Include("~/Bundles/Vendors/IonRangeSlider/css/ion.rangeSlider.skinNice.css", new CssRewriteUrlTransform())

                //  ICheck
                .Include("~/Bundles/Vendors/ICheck/skins/flat/red.css", new CssRewriteUrlTransform())

                //  Animate
                .Include("~/Bundles/Vendors/Animate/animate.css")

                //  JSTree
                .Include("~/Bundles/Vendors/JSTree/themes/default/style.min.css", new CssRewriteUrlTransform())

                // EasyZoom
                .Include("~/Bundles/Vendors/EasyZoom/easyzoom.css")

                //  Font
                .Include("~/Bundles/Vendors/Fonts/iransans.css")

                //  Custom
                .Include("~/Bundles/Styles/novinakdb.css", new CssRewriteUrlTransform())
                .Include("~/Bundles/Styles/novinak.css", new CssRewriteUrlTransform())
                .Include("~/Bundles/Styles/dashboard.css")
                .Include("~/Bundles/Styles/gridView.css")
                .Include("~/Bundles/Styles/itemView.css")
                .Include("~/Bundles/Styles/site.css");
        }


        private static Bundle PanelScript()
        {
            return new ScriptBundle("~/bundles/panelscripts/js")

                //  JQuery
                .Include("~/Bundles/Vendors/JQuery/jquery-3.1.1.min.js")

                //  JQueryValidate
                .Include("~/Bundles/Vendors/JQueryValidate/jquery.validate.min.js")

                //  Noty
                .Include("~/Bundles/Vendors/Noty/noty.min.js")

                // jsPersianDatePicker
                .Include("~/Bundles/Vendors/jsPersianDatePicker/Scripts/PersianDatePicker.min.js")
                .Include("~/Bundles/Vendors/jsPersianDatePicker/Scripts/index.js")


                //  Tooltipster
                .Include("~/Bundles/Vendors/Tooltipster/tooltipster.bundle.min.js")

                //  FineUploader
                .Include("~/Bundles/Vendors/FineUploader/fine-uploader.min.js")

                //  Plyr
                .Include("~/Bundles/Vendors/Plyr/plyr.js", new CssRewriteUrlTransform())

                //  TinyMCE
                .Include("~/Bundles/Vendors/TinyMCE/tinymce.min.js")
                .Include("~/Bundles/Vendors/TinyMCE/langs/fa_IR.js")
                .Include("~/Bundles/Vendors/TinyMCE/themes/modern/theme.min.js")

                //  JSTree
                .Include("~/Bundles/Vendors/JSTree/jstree.min.js")

                //  ICheck
                .Include("~/Bundles/Vendors/ICheck/icheck.min.js")

                //  GoogleMap
                .Include("~/Bundles/Vendors/GoogleMap/google.maps.markerclusterer.js")
                
                //  Select2
                .Include("~/Bundles/Vendors/Select2/js/select2.full.min.js")
                .Include("~/Bundles/Vendors/Select2/js/i18n/fa.js")

                //  LazySizes
                .Include("~/Bundles/Vendors/LazySizes/lazysizes.min.js")

                //  Croppie
                .Include("~/Bundles/Vendors/Croppie/croppie.min.js")

                //  XmTab
                .Include("~/Bundles/Vendors/XmTab/jquery.xmtab.min.js")

                .Include("~/Bundles/Scripts/Frameworks/ajax.framework.js")
                .Include("~/Bundles/Scripts/Frameworks/fineuploader.framework.js")
                .Include("~/Bundles/Scripts/Frameworks/googlemap.framework.js")
                .Include("~/Bundles/Scripts/Frameworks/jstree.framework.js")
                .Include("~/Bundles/Scripts/Frameworks/noty.framework.js")
                .Include("~/Bundles/Scripts/Frameworks/tinymce.framework.js")
                .Include("~/Bundles/Scripts/Frameworks/tooltipster.framework.js")
                .Include("~/Bundles/Scripts/Frameworks/select2.framework.js")
                .Include("~/Bundles/Scripts/Frameworks/validate.framework.js")
                .Include("~/Bundles/Scripts/Frameworks/navigate.framework.js")
                .Include("~/Bundles/Scripts/Frameworks/icheck.framework.js")
                .Include("~/Bundles/Scripts/Frameworks/croppie.framework.js")

                .Include("~/Bundles/Scripts/Builders/ajax.builder.js")
                .Include("~/Bundles/Scripts/Builders/fineuploader.builder.js")
                .Include("~/Bundles/Scripts/Builders/googlemap.builder.js")
                .Include("~/Bundles/Scripts/Builders/jstree.builder.js")
                .Include("~/Bundles/Scripts/Builders/noty.builder.js")
                .Include("~/Bundles/Scripts/Builders/tinymce.builder.js")
                .Include("~/Bundles/Scripts/Builders/tooltipster.builder.js")
                .Include("~/Bundles/Scripts/Builders/select2.builder.js")
                .Include("~/Bundles/Scripts/Builders/validate.builder.js")
                .Include("~/Bundles/Scripts/Builders/navigate.builder.js")
                .Include("~/Bundles/Scripts/Builders/icheck.builder.js")
                .Include("~/Bundles/Scripts/Builders/croppie.builder.js")

                .Include("~/Bundles/Scripts/Methods/jquery.method.js")
                .Include("~/Bundles/Scripts/Methods/slide.method.js")
                .Include("~/Bundles/Scripts/Methods/store.method.js")
                .Include("~/Bundles/Scripts/Methods/url.method.js")

                .Include("~/Bundles/Scripts/app.loader.js");
        }


        private static Bundle LandingScript()
        {
            return new ScriptBundle("~/bundles/landingscripts/js")

                //  JQuery
                .Include("~/Bundles/Vendors/JQuery/jquery-3.1.1.min.js")

                //  JQueryValidate
                .Include("~/Bundles/Vendors/JQueryValidate/jquery.validate.min.js")
                .Include("~/Bundles/Vendors/JQueryValidate/jquery.validate.unobtrusive.min.js")

                //  Noty
                .Include("~/Bundles/Vendors/Noty/noty.min.js")

                //  Tooltipster
                .Include("~/Bundles/Vendors/Tooltipster/tooltipster.bundle.min.js")
                
                //  GoogleMap
                .Include("~/Bundles/Vendors/GoogleMap/google.maps.markerclusterer.js")

                //  OwlCarousel
                .Include("~/Bundles/Vendors/OwlCarousel/owl.carousel.min.js")

                //  JSTree
                .Include("~/Bundles/Vendors/JSTree/jstree.min.js")


                //  RangeSlider
                .Include("~/Bundles/Vendors/IonRangeSlider/js/ion.rangeSlider.js", new CssRewriteUrlTransform())

                //  Plyr
                .Include("~/Bundles/Vendors/Plyr/plyr.js", new CssRewriteUrlTransform())

                //  ICheck
                .Include("~/Bundles/Vendors/ICheck/icheck.min.js")

                // LazySizes
                .Include("~/Bundles/Vendors/LazySizes/lazysizes.min.js")

                // EasyZoom
                .Include("~/Bundles/Vendors/EasyZoom/easyzoom.min.js")

                // XmTab
                .Include("~/Bundles/Vendors/XmTab/jquery.xmtab.min.js")

                .Include("~/Bundles/Scripts/Frameworks/ajax.framework.js")
                .Include("~/Bundles/Scripts/Frameworks/googlemap.framework.js")
                .Include("~/Bundles/Scripts/Frameworks/noty.framework.js")
                .Include("~/Bundles/Scripts/Frameworks/tooltipster.framework.js")
                .Include("~/Bundles/Scripts/Frameworks/plyr.framework.js")
                .Include("~/Bundles/Scripts/Frameworks/owlcarousel.framework.js")
                .Include("~/Bundles/Scripts/Frameworks/validate.framework.js")
                .Include("~/Bundles/Scripts/Frameworks/navigate.framework.js")
                .Include("~/Bundles/Scripts/Frameworks/icheck.framework.js")
                .Include("~/Bundles/Scripts/Frameworks/jstree.framework.js")
                .Include("~/Bundles/Scripts/Frameworks/ionrangeslider.framework.js")
                .Include("~/Bundles/Scripts/Frameworks/easyzoom.framework.js")

                .Include("~/Bundles/Scripts/Builders/ajax.builder.js")
                .Include("~/Bundles/Scripts/Builders/googlemap.builder.js")
                .Include("~/Bundles/Scripts/Builders/noty.builder.js")
                .Include("~/Bundles/Scripts/Builders/tooltipster.builder.js")
                .Include("~/Bundles/Scripts/Builders/plyr.builder.js")
                .Include("~/Bundles/Scripts/Builders/owlcarousel.builder.js")
                .Include("~/Bundles/Scripts/Builders/validate.builder.js")
                .Include("~/Bundles/Scripts/Builders/navigate.builder.js")
                .Include("~/Bundles/Scripts/Builders/icheck.builder.js")
                .Include("~/Bundles/Scripts/Builders/jstree.builder.js")
                .Include("~/Bundles/Scripts/Builders/ionrangeslider.builder.js")
                .Include("~/Bundles/Scripts/Builders/easyzoom.builder.js")

                .Include("~/Bundles/Scripts/Methods/jquery.method.js")
                .Include("~/Bundles/Scripts/Methods/slide.method.js")
                .Include("~/Bundles/Scripts/Methods/store.method.js")
                .Include("~/Bundles/Scripts/Methods/url.method.js")

                .Include("~/Bundles/Scripts/app.loader.js");
        }
    }


    internal class NonOrderingBundleOrderer : IBundleOrderer
    {
        public IEnumerable<BundleFile> OrderFiles(BundleContext context, IEnumerable<BundleFile> files)
        {
            return files;
        }
    }
}
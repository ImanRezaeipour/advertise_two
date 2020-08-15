;(function($) {
    $.fn.appEditor = function($options) {

        var $self = this;
        var $elem = $(this);

        var $defaults = {
            isSimpleEditor: false
        }

        var $settings = $.extend({}, $defaults, $options);

        function $roxyFileBrowser(fieldName, url, type, win) {
            var roxyFileman = "/bundles/vendors/RoxyFileman/index.html";
            if (roxyFileman.indexOf("?") < 0) {
                roxyFileman += "?type=" + type;
            }
            else {
                roxyFileman += "&type=" + type;
            }
            roxyFileman += "&input=" + fieldName + "&value=" + win.document.getElementById(fieldName).value;
            if (tinyMCE.activeEditor.settings.language) {
                roxyFileman += "&langCode=" + tinyMCE.activeEditor.settings.language;
            }
            tinyMCE.activeEditor.windowManager.open({
                    file: roxyFileman,
                    title: "مدیریت فایل ها",
                    width: 850,
                    height: 650,
                    resizable: "yes",
                    plugins: "media",
                    inline: "yes",
                    close_previous: "no"
                },
                {
                    window: win,
                    input: fieldName
                });
            return false;
        }

        var $tinymceOptions = {
            target: $self[0],
            directionality: "rtl",
            language: "fa_IR",
            language_url: "/Bundles/Vendors/TinyMCE/langs/fa_IR.js",
            branding: false,
            min_height: 440,
            min_width: 400,
            entity_encoding: "raw",
            skin: "novinak",
            skin_url: "/Bundles/Vendors/TinyMCE/skins/novinak",
            content_css: "/Bundles/Vendors/TinyMCE/skins/novinak/content.min.css",
            theme: "modern",
            menubar: false,
            statusbar: false,
            theme_advanced_fonts : "Arial=arial,helvetica,sans-serif;Courier New=courier new,courier,monospace;AkrutiKndPadmini=Akpdmi-n",
            toolbar:
                "bold italic underline strikethrough | alignleft aligncenter alignright alignjustify alignnone | " +
                "forecolor styleselect formatselect fontselect fontsizeselect | cut copy paste | outdent indent blockquote undo redo |" +
                "bullist numlist | image media",
            plugins: [
                "autolink link image lists charmap preview hr anchor pagebreak",
                "searchreplace wordcount visualblocks visualchars insertdatetime media nonbreaking",
                "table contextmenu directionality paste textcolor"
            ],
            image_advtab: true,
            init_instance_callback: function(editor) {},
            setup: function(editor) {
                editor.on("click", function(e) {
                    });
            },
            color_picker_callback: function(callback, value) {
            },

            //  File & Image Upload
            file_browser_callback: $roxyFileBrowser,

            //  URL Handling
            relative_urls: false,
            convert_urls: false
        };

        var $tinymceSimpleOptions = {
            target: $self[0],
            directionality: "rtl",
            language: "fa_IR",
            language_url: "/Bundles/Vendors/TinyMCE/langs/fa_IR.js",
            branding: false,
            min_height: 220,
            min_width: 200,
            entity_encoding: "raw",
            skin: "novinak",
            skin_url: "/Bundles/Vendors/TinyMCE/skins/novinak",
            content_css: "/Bundles/Vendors/TinyMCE/skins/novinak/content.min.css",
            theme: "modern",
            menubar: false,
            statusbar: false,
            theme_advanced_fonts: "Arial=arial,helvetica,sans-serif;Courier New=courier new,courier,monospace;AkrutiKndPadmini=Akpdmi-n",
            toolbar: "bold italic underline strikethrough | styleselect fontsizeselect | outdent indent blockquote undo redo"
        }

        if ($settings.isSimpleEditor) {
            tinymce.init($tinymceSimpleOptions);
        } else {
            var $resultTinymce = tinymce.init($tinymceOptions);
        }

        //  return element
        return $elem;
    }
}(jQuery));





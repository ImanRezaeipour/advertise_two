; (function ($) {
    $.fn.appCombobox = function (options) {

        // capture this element
        var self = this;
        var elem = $(this);

        // define defaults
        var defaults = {
            dataSourceUrl: ""
        }

        var settings = $.extend({}, defaults, options);

        // do work on element
        var comboboxOptions = {
            dataTextField: "Text",
            dataValueField: "Value",
            filter: "contains",
            suggest: true,
            index: 0
        };

        var ajaxOptions = {
            url: settings.dataSourceUrl,
            complete: function(xhr, status) {
                comboboxOptions.dataSource = xhr.responseJSON.Data;
                $(self).kendoComboBox(comboboxOptions);
            }
        }

        $.ajax(ajaxOptions);

    }
}(jQuery))
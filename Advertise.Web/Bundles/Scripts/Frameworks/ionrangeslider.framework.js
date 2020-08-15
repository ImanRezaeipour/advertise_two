; (function ($) {
    $.fn.appIonRangeSlider = function ($options) {

        var $self = this;
        var $elem = $(this);

        var $valueObject;

        var $defaults = {
            min: 10,
            max: 100,
            from: 10,
            to: 100,
            prefix: null,
            postfix: null,
            values_separator: " - "
        }

        var $settings = $.extend({}, $defaults, $options);
        
        var $rangesliderOptions = {
            min: $settings.min,
            max: $settings.max,
            from: $settings.from,
            to: $settings.to,
            prefix: $settings.prefix,
            postfix: $settings.postfix,
            values_separator: $settings.values_separator,
            decorate_both: false,
            prettify_separator: ",",

            type: "double",

            onStart: function(obj) {
                
            },
            onChange: function (obj) {
                
            },
            onUpdate: function (obj) {
                
            },
            onFinish: function (obj) {
                $valueObject = obj;
            }
        };

        $($self).ionRangeSlider($rangesliderOptions);

        $($self).on("changeValue", function() {
                var key = "price";
                var value = $valueObject.from + '-' + $valueObject.to;
                addQueryStringParameter(key, value);
            });

      
        return $elem;
    }
}(jQuery))
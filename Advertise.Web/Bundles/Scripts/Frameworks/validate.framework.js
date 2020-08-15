;(function($) {
    $.fn.appValidate = function(options) {
        var self = this;
        var elem = $(this);

        var defaults = {
            rules: {},
            messages: {}
        }

        var settings = $.extend({}, defaults, options);

        var validateOptions = {
            rules: settings.rules,
            messages: settings.messages,
            success: function(label) {
            },
            submitHandler: function(form) {
                form.submit();
            },
            errorClass: "novinak-validation-error"
        };
        $(self).validate(validateOptions);

        return elem;
    }
}(jQuery));

jQuery.validator.addMethod("isNumber", function (value, element) {
    return $.isNumeric(value);
}, "value is not numeric");

jQuery.validator.addMethod("regex", function (value, element, regexp) {
    var re = new RegExp(regexp);
    return this.optional(element) || re.test(value);
}, "Please check your input.");
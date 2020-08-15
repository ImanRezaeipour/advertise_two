; (function ($) {
    $.fn.appZoom = function ($options) {

        var $self = this;
        var $elem = $(this);

        var $defaults = {}

        var $settings = $.extend({}, $defaults, $options);

        var $easyzoomOptions = {};

        $($self).easyZoom($easyzoomOptions);
        
        return $elem;
    }
}(jQuery))
;(function($) {
    $.fn.appTooltip = function(options) {
        var self = this;
        var elem = $(this);

        var defaults = {
            position: "bottom"
        }

        var settings = $.extend({}, defaults, options);

        var tooltipsterOptions = {
            animation: "grow",
            delay: 100,
            theme: 'tooltipster-light',
            interactive: true,
            position: settings.position
        }

        $(self).tooltipster(tooltipsterOptions);

        return elem;
    }
}(jQuery))
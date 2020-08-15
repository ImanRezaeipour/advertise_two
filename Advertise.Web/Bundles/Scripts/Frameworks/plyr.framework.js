; (function ($) {
    $.fn.appVideo = function (options) {

        var self = this;
        var elem = $(this);

        var defaults = {

        }

        var settings = $.extend({}, defaults, options);

        var plyrOptions = {
            autoplay: false,
            controls: ["play-large", "play", "progress", "current-time", "mute", "volume", "captions", "fullscreen"]
        };

        var resultPlyr = plyr.setup(self, plyrOptions);

        return elem;
    }
}(jQuery))
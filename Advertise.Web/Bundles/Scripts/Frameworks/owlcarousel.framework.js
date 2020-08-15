; (function ($) {
    $.fn.appCarousel = function(options) {

        // capture this element
        var self = this;
        var elem = $(this);

        // define defaults
        var defaults = {
            nav: true,
            dots: false,
            rtl: true,
            autoWidth: false,
            margin: 0,
            navText: ["<i class='fa fa-angle-right'></i>", "<i class='fa fa-angle-left'></i>"],
            navSpeed: false,
            autoplay: false,
            autoplayHoverPause: false,
            autoplayTimeout: 5000,
            autoplaySpeed: false,
            dragEndSpeed:false,
            lazyLoad: false,
            loop: false,
            center: false,
            items: 3,
            animateOut: false,
            animateIn: false,
            responsiveClass: true,
            responsive: {},
            rtlClass: "owl-rtl"
        }

        var settings = $.extend({}, defaults, options);

        // do work on element
        var owlCarouselOptions = {

            //  OPTIONS
            nav: settings.nav,
            dots: settings.dots,
            rtl: settings.rtl,
            autoWidth: settings.autoWidth,
            margin: settings.margin,
            navText: settings.navText,
            navSpeed: settings.navSpeed,
            autoplay: settings.autoplay,
            autoplayHoverPause: settings.autoplayHoverPause,
            autoplayTimeout: settings.autoplayTimeout,
            autoplaySpeed: settings.autoplaySpeed,
            dragEndSpeed: settings.dragEndSpeed,
            lazyLoad: settings.lazyLoad,
            loop: settings.loop,
            center: settings.center,
            items: settings.items,
            animateOut: settings.animateOut,
            animateIn: settings.animateIn,
            responsive: settings.responsive,

            //  CLASSES
            rtlClass: settings.rtlClass,
            responsiveClass: settings.responsiveClass,

            //  EVENTS
            onInitialized: function() {
            }
        };

        $(self).owlCarousel(owlCarouselOptions);

        return elem;
    }
}(jQuery))
; (function ($) {
    $.fn.appCrop = function ($options) {

        var $self = this;
        var $elem = $(this);

        var $defaults = {
            boundaryWidth: parseInt($elem.width()),
            boundaryHeight: parseInt($elem.height()),
            customClass: '',
            enableZoom: true,
            enforceBoundary: true,
            mouseWheelZoom: true,
            showZoomer: true,
            viewportWidth: 100,
            viewportHeight: 100,
            viewportType: "square",
            onBindOptions: {},
            onResultOptions: {},
            onResultFunction: function(input){}
        }

        var $settings = $.extend({}, $defaults, $options);

        var $croppieOptions = {
        	boundary: { width: $settings.boundaryWidth, height: $settings.boundaryHeight },
        	customClass: $settings.customClass,
        	enableZoom: $settings.enableZoom,
        	enforceBoundary: $settings.enforceBoundary,
        	mouseWheelZoom: $settings.mouseWheelZoom,
        	showZoomer: $settings.showZoomer,
        	viewport: { width: $settings.viewportWidth, height: $settings.viewportHeight, type: $settings.viewportType },
        	onBindOptions: $settings.onBindOptions,
        	onResultOptions: $settings.onResultOptions,
        	onResultFunction: $settings.onResultFunction

        };


        if (!$.isEmptyObject($settings.onBindOptions)) {
        	$($self).croppie('bind', $settings.onBindOptions);
        }
        else if (!$.isEmptyObject($settings.onResultOptions)) {
        	$($self).croppie('result', $croppieOptions.onResultOptions)
	            .then(function (result) {
	                $settings.onResultFunction(result);
	            });
        }
        else {
            $($self).croppie($croppieOptions);
        }

        return $elem;
    }
}(jQuery))
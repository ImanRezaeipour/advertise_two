; (function ($) {
    $.fn.appMap = function(options) {
        var self = this;
        var elem = $(this);

        var defaults = {
            elementId: "",
            defaultLatitude: $("#Address_Latitude").val(),
            defaultLongitude: $("#Address_Longitude").val(),
            latitudeSelector: "#Address_Latitude",
            longitudeSelector: "#Address_Longitude",
            showMarker: true
        }

        var settings = $.extend({}, defaults, options);
        var marker;
        var map;

        function addMarker(event) {
            marker.setMap(null);

            var markerOptions = {
                position: event.latLng,
                map: map,
                icon: "/Files/Assets/Icons/novinak-marker.png"
            }

            marker = new google.maps.Marker(markerOptions);

            $(settings.latitudeSelector).val(event.latLng.lat);
            $(settings.longitudeSelector).val(event.latLng.lng);
        }

        var defaultLocation = new google.maps.LatLng(settings.defaultLatitude, settings.defaultLongitude);

        if (settings.defaultLatitude === 0 || settings.defaultLongitude === 0) {
            if (navigator.geolocation) {
                navigator.geolocation.getCurrentPosition(function(position) {
                    defaultLocation = new google.maps.LatLng(position.coords.latitude, position.coords.longitude);

                    $(settings.latitudeSelector).val(position.coords.latitude);
                    $(settings.longitudeSelector).val(position.coords.longitude);
                });
            }
        }

        var mapOptions = {
            center: defaultLocation,
            zoom: 18
        }

        map = new google.maps.Map(document.getElementById(settings.elementId), mapOptions);

        if (settings.showMarker === true) {
            var markerOptions = {
                position: defaultLocation,
                map: map,
                icon: "/Files/Assets/Icons/novinak-marker.png"
            }

            marker = new google.maps.Marker(markerOptions);

            map.addListener("click", function(event) {
                    addMarker(event);
                });
        }

        $(self).on('setLocation', {},
            function(event, lat, long) {
                var newLocation = new google.maps.LatLng(lat, long);
                map.setCenter(newLocation);
                var markerOptions = {
                    position: newLocation,
                    map: map,
                    icon: "/Files/Assets/Icons/novinak-marker.png"
                }
                marker = new google.maps.Marker(markerOptions);
            });

        return elem;
    }
}(jQuery));


(function ($) {
    $.fn.appMapCluster = function (options) {

        // catch this element
        var self = this;
        var elem = $(this);

        // default variables
        var defaults = {
            elementId: ""
        }

        var settings = $.extend({}, defaults, options);

        function castToSlug(slug) {
            var replace = slug.replace(/ /g, "-");
            return replace;
        };

        // define functions
        function getMarkers(locations) {
            var markers = locations.map(function (location, i) {
                var infowindowOptions = {
                    content: "<br>"+"<b>فروشگاه:</b>" +
                                '<a href="/fa/company/nco-' + location.Alias + '/' + castToSlug(location.Title) + '">' + location.Title + "</a>" +
                                "<br>" +
                                "<b>نوع فعالیت:</b>" +
                                '<a href="/fa/category/nca-' + location.CategoryAlias + '/' + castToSlug(location.CategoryMetaTitle) + '">' + location.CategoryTitle + "</a>" +
                                "<br>" + "<br>",
                    maxWidth :500
                }

                var markerOptions = {
                    position: {
                        lat: parseFloat(location.Latitude),
                        lng: parseFloat(location.Longitude)
                    },
                    title: location.Title,
                    info: new google.maps.InfoWindow(infowindowOptions),
                    icon: "/Files/Assets/Icons/novinak-marker.png"
                }

                var marker = new google.maps.Marker(markerOptions);

                marker.addListener("click", function () {
                    marker.info.open(map, marker);
                });

                return marker;
            });

            return markers;
        }

        function drawMarkers(locations) {
            var markerCluster = new MarkerClusterer(map, getMarkers(locations), {imagePath: "/Bundles/Vendors/GoogleMap/m"});
        }

        function getCurrentLocation() {
            if (navigator.geolocation) {
                navigator.geolocation.getCurrentPosition(function(position) {
                    var defaultLocation = new google.maps.LatLng(position.coords.latitude, position.coords.longitude);
                    return defaultLocation;
                });
            }

            var tehranLocation = {
                lat: parseFloat(35.694390),
                lng: parseFloat(51.421510)
            };
            return tehranLocation;
        }
        
        // do work on element
        var defaultLocation = getCurrentLocation();

        var mapOptions = {
            center: defaultLocation,
            zoom: 12
        }

        var map = new google.maps.Map(document.getElementById(settings.elementId), mapOptions);

        var ajaxOptions = {
            url: "/Company/GetAllCompaniesAjax",
            complete: function (xhr, status) {
                drawMarkers(xhr.responseJSON.Data);
            }
        }

        $.appAjax(ajaxOptions);
        
        // return element
        return elem;
    }
}(jQuery))
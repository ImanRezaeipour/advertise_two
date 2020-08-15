var marker;
var markers = [];
var map;
var isMapInitial = false;
var isAddressInitial = false;
var isCommentsInitial = false;
var isSpecificationInitial = false;

$(function () {

    $('.slider-for').slick({
        slidesToShow: 1,
        slidesToScroll: 1,
        arrows: false,
        fade: true,
        asNavFor: '.slider-nav',
        accessibility: !1,
        rtl: !0,
        infinite: !1,
        speed: 500,
        cssEase: "linear",
        autoplay: !1
    });
    $('.slider-nav').slick({
        slidesToShow: 5,
        prevArrow: "<span class='prev'><i class='fa fa-angle-right'><\/i><\/span>",
        nextArrow: "<span class='next'><i class='fa fa-angle-left'><\/i><\/span>",
        slidesToScroll: 1,
        asNavFor: '.slider-for',
        dots: false,
        centerMode: true,
        focusOnSelect: true,
        infinite: false,
        rtl: true,
        accessibility: false
    });


    $('a[href="#tab_Address"]').click(function (e) {
        if (!isAddressInitial) {
            setTimeout(initMap, 500);
            isAddressInitial = true;
        }
    });
    $('a[href="#tab_Comments"]').click(function (e) {
        if (!isCommentsInitial) {
            setTimeout(initMap, 500);
            isCommentsInitial = true;
        }
    });

    $('a[href="#tab_Specification"]').click(function (e) {
        if (!isSpecificationInitial) {
            setTimeout(initMap, 500);
            isSpecificationInitial = true;
        }
    });
});

function initSpecification() {
    $.ajax({
        type: "GET",
        url: "/Product/GetCategorySpecifications/" + id,
        cache: false,
        success: function (result) {
            $("#Specification").html(result);
            $('form').removeData("validator");
            $('form').removeData("unobtrusiveValidation");
            $.validator.unobtrusive.parse($('form'));
        }
    });
}

function initAddress() {
}

function initComments() {
}

function initMap() {

    google.maps.visualRefresh = true;
    var Iran = new google.maps.LatLng(35.714849, 51.3990455);
    var mapOptions = {
        zoom: 10,
        center: Iran,
        mapTypeId: google.maps.MapTypeId.G_NORMAL_MAP,
        minZoom: 13,
        streetViewControl: false,
        mapTypeControl: false,
        fullscreenControl: false
    };

    map = new google.maps.Map(document.getElementById("map_canvas"), mapOptions);
    marker = new google.maps.Marker({
        map: map,
        position: event.latLng,
        draggable: true,
        animation: google.maps.Animation.DROP,
    });

    markers.push(marker);
    map.setCenter(marker.getPosition());
}
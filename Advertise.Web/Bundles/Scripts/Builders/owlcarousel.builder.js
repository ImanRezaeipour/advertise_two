/**
 * 
 * @param {} elem 
 * @returns {} 
 * for responsive : values are 1px more than those in CSS
 */
var $carouselLandingPage_OnLoad = function (elem) {
    var owlCarouselOptions = {
        navSpeed: 700,
        dragEndSpeed: 700,
        responsive: {
            0: {
                items: 1
            },
            393: {
                items: 2
            },
            583: {
                items: 3
            },
            773: {
                items: 4
            },
            873: {
                items: 3
            },
            1055: {
                items: 4
            },
            1261: {
                items: 5
            }
        }
    }
    $(elem).appCarousel(owlCarouselOptions);
}


/**
 * 
 * @param {} elem 
 * @returns {} 
 */
var $carouselLandingSlider_OnLoad = function (elem) {
    var owlCarouselOptions = {
        nav: true,
        dots: true,
        navSpeed: 700,
        autoplay: true,
        autoplayTimeout: 5000,
        autoplaySpeed: 1,
        dragEndSpeed: 700,
        animateOut: 'fadeOut',
        animateIn: 'fadeIn',
        loop:true,
        items:1
    }
    $(elem).appCarousel(owlCarouselOptions);
}



/**
 * 
 * @param {} elem 
 * @returns {} 
 * for responsive : values are 1px more than those in CSS
 */
var $carouselSideAds_OnLoad = function (elem) {
    var owlCarouselOptions = {
        navSpeed: 700,
        dragEndSpeed: 700,
        margin: 5,
        autoWidth: true,
        responsive: {
            0: {
                items: 1
            },
            565: {
                items: 2
            },
            840: {
                items: 3
            },
            873: {
                items: 0,
                margin: 0
            }
        }
    }
    $(elem).appCarousel(owlCarouselOptions);
}



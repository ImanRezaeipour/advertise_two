/**
 * 
 * @returns {} 
 */
var $ionRangeSlider_OnLoad = function (elem) {
    var price = $(elem).val();
    var min = $(elem).data('min');
    var max = $(elem).data('max');
    var $ionRangeSliderOptions = {
        min: min,
        max: max,
        from :price.split('-')[0],
        to: price.split('-')[1],
        postfix: " تومان",
        values_separator: " تا "
    }
    $(elem).appIonRangeSlider($ionRangeSliderOptions);
};
/**
 * 
 * @param {} elem 
 * @returns {} 
 */
var getBackgroundShadow = function (elem) {
    var bgShadow = $(elem).parents('.landing-items').children('.bg-shadow');
    return bgShadow;
}

/**
 * 
 * @param {} elem 
 * @returns {} 
 */
var getShadow = function (elem) {
    var shadow = $(elem).parents('.landing-items').children('.slider-shadow');
    return shadow;
}

/**
 * 
 * @param {} shadowElem 
 * @returns {} 
 */
var totalSlidesCount = function (shadowElem) {
    var count = shadowElem.children('.slide-files-wrapper').data('count');
    return count;
}

/**
 * 
 * @param {} shadowElem 
 * @returns {} 
 */
var getSaveElem = function (shadowElem) {
    var saveElem = shadowElem.children('.slide-file-preview').children('.slide-files-actions').children('.slide-file-save').children('a');
    return saveElem;
}

/**
 * 
 * @param {} shadowElem 
 * @returns {} 
 */
var getIteration = function (shadowElem) {
    var currentIteartion = shadowElem.children('.slide-file-preview').children('.slide-file-count').children('.slide-file-number').text();
    return currentIteartion;
}

/**
 * 
 * @param {} shadowElem 
 * @returns {} 
 */
var getNames = function (shadowElem) {
    var parent = $(shadowElem).parents('.landing-items');
    var company = parent.children('.product-item').children('.nov-item-footer').children('.overview-section').children('.caption-part').children('a').children('p').text();
    var album = parent.children('.product-item').children('.nov-item-body').children('.caption-section').children('.novinak-title-link').children('p').text();
    return ('novinak' + '-' + company + '-' + album + '-');
}

/**
 * 
 * @param {} shadowElem 
 * @param {} iteration 
 * @returns {} 
 */
var changeSlide = function (shadowElem, iteration) {
    var url = shadowElem.children('.slide-files-wrapper').children("input[data-iteration='0']").val();
    var fileName = shadowElem.children('.slide-files-wrapper').children("input[data-iteration=" + iteration + "]").val();
    var link = url + fileName;
    shadowElem.children('.slide-file-preview').children('figure').children('img').attr('src', link);
    shadowElem.children('.slide-file-preview').children('.slide-file-count').children('.slide-file-number').text(iteration);
    var saveElem = getSaveElem(shadowElem);
    saveElem.attr('href', link);
    var name = getNames(shadowElem);
    var saveName = name + iteration;
    saveElem.attr('download', saveName);
}

/**
 * 
 * @param {} elem 
 * @returns {} 
 */
var openSlideLoader = function (elem) {
    var bgShadow = getBackgroundShadow(elem);
    var shadow = getShadow(elem);
    var total = totalSlidesCount(shadow);
    shadow.children('.slide-file-preview').children('.slide-file-count').children('.slide-file-total').text(total + " / ");
    changeSlide(shadow, 1);
    bgShadow.show();
    shadow.show();
}

/**
 * 
 * @param {} elem 
 * @returns {} 
 */
var rightSlideButton = function (elem) {
    var shadow = getShadow(elem);
    var total = parseInt(totalSlidesCount(shadow));
    var number = parseInt(getIteration(shadow));
    if (number === total) {
        number = 1;
    }
    else {
        number += 1;
    }
    changeSlide(shadow, number);
}

/**
 * 
 * @param {} elem 
 * @returns {} 
 */
var leftSlideButton = function (elem) {
    var shadow = getShadow(elem);
    var total = parseInt(totalSlidesCount(shadow));
    var number = parseInt(getIteration(shadow));
    if (number === 1) {
        number = total;
    }
    else {
        number -= 1;
    }
    changeSlide(shadow, number);
}

/**
 * 
 * @param {} elem 
 * @returns {} 
 */
var closeSlideButton = function (elem) {
    var bgShadow = getBackgroundShadow(elem);
    var shadow = getShadow(elem);
    bgShadow.hide();
    shadow.hide();
}

/**
 * 
 * @param {} elem 
 * @returns {} 
 */
var openItemModal = function (elem) {
    var bgShadow = getBackgroundShadow(elem);
    var shadow = getShadow(elem);
    bgShadow.show();
    shadow.show();
}

/**
 *
 * @param {} tag
 * @returns {}
 */
var $editorNews_OnLoad = function (elem) {
    var editorOptions = {
        
    }

    $(elem).appEditor(editorOptions);
}

/**
 * 
 * @param {} elem 
 * @returns {} 
 */
var $editorCategoryReview_OnLoad = function($elem) {
    var $editorOptions = {
        
    }

    $($elem).appEditor($editorOptions);
}

/**
 * 
 * @param {} $elem 
 * @returns {} 
 */
var $editorCompanyReview_OnLoad = function($elem) {
    var $editorOptions = {
        
    }

    $($elem).appEditor($editorOptions);
}

/**
 * 
 * @param {} $elem 
 * @returns {} 
 */
var $editorProductReview_OnLoad = function($elem) {
    var $editorOptions = {
    }

    $($elem).appEditor($editorOptions);
}

/**
 * 
 * @param {} $elem 
 * @returns {} 
 */
var $editorProductDescription_OnLoad = function ($elem) {
    var $editorOptions = {
        isSimpleEditor: true
    }

    $($elem).appEditor($editorOptions);
} 

/**
 * 
 * @param {} $elem 
 * @returns {} 
 */
var $editorCompanyDescription_OnLoad = function($elem) {
    var $editorOptions = {
        isSimpleEditor: true
    }

    $($elem).appEditor($editorOptions);
}
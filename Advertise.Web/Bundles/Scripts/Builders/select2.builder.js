/**
 * 
 * @returns {} 
 */
var $dropdownSimple_OnLoad = function ($elem) {
    var $select2Options = {
        value: $($elem).attr("value")
    }
   
    $($elem).appDropdown($select2Options);
};

var $dropdownAdsOption_OnLoad = function ($elem) {
    var $select2Options = {
        onChanged: function (e) {
            if ($($($elem).select2()[0].selectedOptions[0]).hasClass('has-category'))
                $("#CategoryId").parent().removeClass("hide-none").prev().removeClass("hide-none");
            else
                $("#CategoryId").parent().addClass("hide-none").prev().addClass("hide-none");
        }
    }

    $($elem).appDropdown($select2Options);
};

/**
 * 
 * @returns {} 
 */
var $dropdownMulti_OnLoad = function ($elem) {
    var $select2Options = {
        multiple: true,
        tags: true
    }

    $($elem).appDropdown($select2Options);
};

var $dropdownSimpleCategoryList_OnLoad = function ($elem) {
    var $select2Options = {
        data: categoryListJson,
        value: $($elem).attr("value")
    }

    $($elem).appDropdown($select2Options);
}

/**
 * 
 * @param {} $elem 
 * @returns {} 
 */
var $dropdownCategoryList_OnLoad = function ($elem) {
    var $select2Options = {
        data: categoryListJson,
        value: $($elem).attr("value"),
        onChanged: function (e) {
            var $index = $($elem).closest(".catalogItem").data("index");
            var $selector = "ProductBulks_" + $index + "_.CatalogId";
            $dropdownCatalogList_OnLoad(document.getElementById($selector));
        }
    }
    $($elem).appDropdown($select2Options);
    $($elem).attr("value", $("#categoryDefault").val());
}

/**
 * 
 * @param {} $elem 
 * @returns {} 
 */
var $dropdownCatalogList_OnLoad = function ($elem) {
    var $index = $($elem).closest(".catalogItem").data("index");
    var $selector = "#ProductBulks_" + $index + "_\\.CategoryId";

    var $select2Options = {
        data: catalogListJson,
        value: $($elem).attr("value"),
        relatedId: $($selector).val()
    }

    $($elem).appDropdown($select2Options);
}


var $dropdownGuaranteeList_OnLoad = function($elem) {
    var $index = $($elem).closest(".catalogItem").data("index");
    var $categoryId = $("#ProductBulks_" + $index + "_\\.CategoryId").val();
    var $selectOptions = {
        data: guaranteeListJson,
        value: $($elem).attr("value"),
        relatedId: $categoryId

    }
    $($elem).appDropdown($selectOptions);
}

var $dropdownProductBulk_OnLoad = function ($elem) {
    var $select2Options = {
        multiple: true,
        tags: true,
        max: 1
    }

    $($elem).appDropdown($select2Options);
};
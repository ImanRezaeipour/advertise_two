/**
 * 
 * @param {} viewTypeParameter 
 * @returns {} 
 */
var $switchViewType = function (viewTypeParameter) {
    switch (viewTypeParameter) {
        case "grid":
            $(".landing-items-wrapper").addClass("landing-grids-wrapper");
            $(".landing-grids-wrapper").removeClass("landing-items-wrapper");
            $(".item-view-holder").css("background-color", "#f6f6f6");
            $(".item-view-holder i").css("color", "#b0b0b0");
            $(".grid-view-holder").css("background-color", "#ebebeb");
            $(".grid-view-holder i").css("color", "#999");
            break;
        case "item":
            $(".landing-grids-wrapper").addClass("landing-items-wrapper");
            $(".landing-items-wrapper").removeClass("landing-grids-wrapper");
            $(".grid-view-holder").css("background-color", "#f6f6f6");
            $(".grid-view-holder i").css("color", "#b0b0b0");
            $(".item-view-holder").css("background-color", "#ebebeb");
            $(".item-view-holder i").css("color", "#999");
            break;
    }
}


var $showMoreSpecOption_OnClick = function (elem) {
    var $moreOptionsCount = $(elem).find("#moreOptionCount");
    var $moreOptionsText = $(elem).find("#moreOptionText");
    var $moreLessIcon = $(elem).find(".fa");
    $(elem).toggleClass("expanded");
    if ($(elem).hasClass("expanded")) {
        $moreLessIcon.removeClass("fa-plus-circle").addClass("fa-minus-circle");
        $moreOptionsCount.hide();
        $moreOptionsText.html("نمایش کمتر");
    } else {
        $moreLessIcon.removeClass("fa-minus-circle").addClass("fa-plus-circle");
        $moreOptionsCount.show();
        $moreOptionsText.html("مورد بیشتر");
    }
    $(elem).closest(".search-filter").find('*[data-toggle=""]').toggleClass("hide-none-imp");
}

/**
 * 
 * @param {} elem 
 * @returns {} 
 */
var $renderView_OnClick = function (elem) {
    var currentViewType = $(elem).data("param");
    $switchViewType(currentViewType);
    buildPageLS(currentViewType);
}

/**
 * 
 * @returns {} 
 */
var $showList = function () {
    $(".landing-items-wrapper").show();
    $(".landing-grids-wrapper").show();
}

/**
 *
 * @param {} e
 * @param {} elem
 * @returns {}
 */
var $refreshCaptcha_OnClick = function (elem, e) {
    var d = new Date();
    var ticks = ((d.getTime() * 10000) + 621355968000000000);
    $("#imageCaptcha").attr("src", window.appCultureRoute + "/home/CaptchaImage/" + ticks);
}

var $removeQueryString_OnClick = function (elem) {
    debugger;
    var key = $(elem).attr("name");
    var value = $(elem).attr("value");
    removeQuryStringParameters(key, value);

}

/**
 * function that gathers IDs of checked nodes
 * @param {} nodes
 * @param {} checkedNodes
 * @returns {}
 */
var $checkedNodeIds = function (nodes, checkedNodes) {
    for (var i = 0; i < nodes.length; i++) {
        if (nodes[i].checked) {
            checkedNodes.push(nodes[i].id);
        }

        if (nodes[i].hasChildren) {
            $checkedNodeIds(nodes[i].children.view(), checkedNodes);
        }
    }
}

/**
 *
 * @param {} event
 * @param {} elem
 * @returns {}
 */
var $addSpecificationoption_OnClick = function (elem) {
    var index = $("#items #item").last().data("index");

    $("#items #item").first().clone().appendTo("#items");
    $("#items #item").last().attr("data-index", (parseInt(index) + 1));

    $("#items #item").last().find("*").each(function (key, value) {
        if ($(this).attr("value") != null)
            $(this).val("");
        if ($(this).attr("name") != null)
            $(this).attr("name", $(this).attr("name").replace("[0]", "[" + (parseInt(index) + 1) + "]"));
        if ($(this).attr("id") != null)
            $(this).attr("id", $(this).attr("id").replace("_0_", "_" + (parseInt(index) + 1) + "_"));
        if ($(this).attr("for") != null)
            $(this).attr("for", $(this).attr("for").replace("_0_", "_" + (parseInt(index) + 1) + "_"));
        if ($(this).attr("data-valmsg-for") != null)
            $(this).attr("data-valmsg-for", $(this).attr("data-valmsg-for").replace("[0]", "[" + (parseInt(index) + 1) + "]"));
        if ($(this).attr("data-param") != null)
            $(this).attr("data-param", $(this).attr("data-param").replace("0", (parseInt(index) + 1)));
        if ($(this).attr("value") != null)
            $(this).val(parseInt(index) + 1);
        if ($(this).attr("data-on-click") != null)
            $(this).click(function () { $removeSpecificationOption_OnClick(this); });
    });

    $("#items #item").last().find("input[type=text]").val("");
}

/**
 *
 * @param {} event
 * @param {} elem
 * @returns {}
 */
var $removeSpecificationOption_OnClick = function (elem) {
    var index = $(elem).data("param");
    if (index !== 0)
        $("#items #item").remove("[data-index='" + index + "']");
}

/**
 * 
 * @param {} elem 
 * @returns {} 
 */
var $disableEntity_OnChange = function () {
    var $elem = $("#EntityId")[0] !== undefined ? $("#EntityId") : $("#ProductId");
    $elem.parent().addClass("hide-none").prev().addClass("hide-none");
}

var $enableEntity_OnChange = function () {
    debugger;
    var t = $("#EntityId")[0];
    var $elem = $("#EntityId")[0] !== undefined ? $("#EntityId") : $("#ProductId");
    $elem.parent().removeClass("hide-none").prev().removeClass("hide-none");
}

/**
 *
 * @param {} elem
 * @returns {}
 */
var $findTotalBagPrice = function (elem) {
    var final = 0;
    $(elem).each(function () {
        final = final + parseInt($(this).attr("data-val"));
    });
    return (final);
}

/**
 * 
 * @param {} tag 
 * @returns {} 
 */
var redirect = function (tag) {
    var id = $(tag).data("param");
    var url = $(tag).data("url");
    window.open(url + "?id=" + id);
}

/**
 * 
 * @param {} elem 
 * @returns {} 
 */
var checkNumber = function (elem, e) {
    // Allow: backspace, delete, tab, escape, enter and .
    if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
        // Allow: Ctrl+A, Command+A
        (e.keyCode === 65 && (e.ctrlKey === true || e.metaKey === true)) ||
        // Allow: home, end, left, right, down, up
        (e.keyCode >= 35 && e.keyCode <= 40)) {
        // let it happen, don't do anything
        return;
    }
    // Ensure that it is a number and stop the keypress
    if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
        e.preventDefault();
    }
};



/**
 *
 * @param {} elem
 * @returns {}
 */
var $startSearchTerm = function($elem) {
    var $term = $($elem).val();
    if (document.location === window.appCultureRoute + "/product/search") {
        document.location = setUrlEncodedKey("term", $term);
    } else {
        document.location = window.appCultureRoute + "/product/search";
        document.location = window.appCultureRoute + "/product/search" + setUrlEncodedKey("term", $term);
    }
}

/**
 *
 * @param {} e
 * @param {} elem
 * @returns {}
 */
var $searchTerm_OnKeypress = function ($elem, e) {
    e = e || window.event;
    if (e.keyCode === 13) {
        $startSearchTerm($elem);
        return false;
    }
    return true;
}

/**
 *
 * @param {} elem
 * @returns {}
 */
var $searchInputTerm_OnClick = function ($elem) {
    var $searchInput = $($elem).parents("ul").find("input[name='term']");
    $startSearchTerm($searchInput);
}

/**
 *
 * @param {} e
 * @param {} elem
 * @returns {}
 */
var $startChangeSearchTerm = function ($elem) {
    var $term = $($elem).val();
    addQueryStringParameter("term", $term);
}

/**
 *
 * @param {} elem
 * @returns {}
 */
var $changeSearchTerm_OnKeypress = function ($elem,e) {
    e = e || window.event;
    if (e.keyCode === 13) {
        $startChangeSearchTerm($elem);
    }
    return;
}

/**
 *
 * @param {} elem
 * @returns {}
 */
var $changeSearchInputTerm_OnClick = function ($elem) {
        var $searchInput = $($elem).parents("#searchboxContainer").find("input[name='term']");
        $startChangeSearchTerm($searchInput);
    }


/**
 *
 * @param {} elem
 * @returns {}
 */
var searchOnLanding = function (elem) {
    var term = $("#navSearchProduct").val();
    var cat = $("#navCategories").val();
    var newLink = window.appCultureRoute + "/product/search" + "?term=" + term + "&c=" + cat;
    $(elem).attr("href", newLink);
}

/**
 *
 * @returns {}
 */
var goUp = function () {
    $("#goUpBtn").click(function (e) {
        $("body,html").animate({ scrollTop: 0 }, 600);
    });
    $(window).scroll(function () {
        if ($(this).scrollTop() > 140) {
            $("#goUpBtn").addClass("goUpAnimate");
        } else {
            $("#goUpBtn").removeClass("goUpAnimate");
        }
    });
};

/**
 *
 * @returns {}
 */
var navMove = function () {
    var $mainMenu = $(".main-menu-wrap");
    var $breadcrumb = $("#SiteMap");
    var $body = $(".rendered-body");
    var $isManMenuFixed;
    $(window).scroll(function () {
        $isManMenuFixed = false;
        if ($(this).scrollTop() > 100) {
            $isManMenuFixed = true;
        }
        if ($isManMenuFixed === true && $(window).width() > 1243) {
            $mainMenu.addClass("navMenuFixed");
            if ($breadcrumb.length)
                $breadcrumb.css("margin-top", "44px");
            else
                $body.css("margin-top", "54px");
        } else {
            $mainMenu.removeClass("navMenuFixed");
            $breadcrumb.css("margin-top", "0");
            $body.css("margin-top", "0");
        }
    });
};

/**
 *
 * @param {} elem
 * @returns {}
 */
var openModal = function (elem) {
    var img = $(elem).children().attr("src");
    $(".company-modal").show();
    $(".modal-img-wrapper").show();
    $(".modal-img-wrapper").children().attr("src", img);
    var h = $(window).height() * .8;
    var ih = $("#modal-image").height();
    var marg = (h - ih) / 2;
    $("#modal-image").css("margin-top", marg);
}

/**
 *
 * @param {} elem
 * @returns {}
 */
var closeModal = function (elem) {
    $(".company-modal").hide();
    $(".modal-img-wrapper").hide();
}

/**
 *
 * @param {} elem
 * @returns {}
 */
var showCompanyTab = function (elem) {
    $(".activated").removeClass("activated");
    var sectionClass = "." + $(elem).data("section");
    $(sectionClass).addClass("activated");
}

/**
 *
 * @param {} event
 * @param {} elem
 * @returns {}
 */
var $addFeatures_OnClick = function (elem) {
    var index = $("#items #item").last().data("index");

    $("#items #item").first().clone().appendTo("#items");
    $("#items #item").last().attr("data-index", (parseInt(index) + 1));

    $("#items #item").last().find("*").each(function (key, value) {
        if ($(this).attr("value") != null)
            $(this).val("");
        if ($(this).attr("name") != null)
            $(this).attr("name", $(this).attr("name").replace("[0\]", "[" + (parseInt(index) + 1) + "]"));
        if ($(this).attr("id") != null)
            $(this).attr("id", $(this).attr("id").replace("[0]", "[" + (parseInt(index) + 1) + "]"));
        if ($(this).attr("for") != null)
            $(this).attr("for", $(this).attr("for").replace("_0_", "_" + (parseInt(index) + 1) + "_"));
        if ($(this).attr("data-valmsg-for") != null)
            $(this).attr("data-valmsg-for", $(this).attr("data-valmsg-for").replace("[0]", "[" + (parseInt(index) + 1) + "]"));
        if ($(this).attr("data-param") != null)
            $(this).attr("data-param", $(this).attr("data-param").replace("0", (parseInt(index) + 1)));
        if ($(this).attr("value") != null)
            $(this).val(parseInt(index) + 1);
        if ($(this).attr("data-on-click") != null)
            $(this).click(function () { $removeFeatures_OnClick(this); });
    });

    $("#items #item").last().find("input[type=text]").val("");
}

/**
 *
 * @param {} event
 * @param {} elem
 * @returns {}
 */
var $removeFeatures_OnClick = function (elem) {
    var index = $(elem).data("param");
    if (index !== 0)
        $("#items #item").remove("[data-index='" + index + "']");
}

/**
 *
 * @param {} elem
 * @returns {}
 */
var selectSubCategory = function (elem) {
    var id = $(elem).closest("li").attr("value");
    $("#categoryId").val(id);
    $(elem).closest("ul").children().removeClass("active");
    $(elem).closest("li").addClass("active");
    window.history.pushState(null, null, setUrlEncodedKey("c", id));
    fillSearchProducts();
}

/**
 *
 * @param {} elem
 * @returns {}
 */
var loadCategory = function (elem) {
    var categoryId = getUrlParameterByName("c");
    if (categoryId === null || categoryId === "") {
        categoryId = $("#categoryId").val();
    }
    else {
        $("#categoryId").val(categoryId);
        $(elem).val(categoryId);
    }
}

/**
 *
 * @param {} elem
 * @returns {}
 */
var selectSortMemberFilter = function (elem) {
    var value = $(elem).find(":selected").val();
    $("#sortmember").val(value);
    window.history.pushState(null, null, setUrlEncodedKey("m", value));
    fillSearchProducts();
}

/**
 *
 * @param {} elem
 * @returns {}
 */
var selectSortDirectionFilter = function (elem) {
    var value = $(elem).find(":selected").val();
    $("#sortDirection").val(value);
    window.history.pushState(null, null, setUrlEncodedKey("d", value));
    fillSearchProducts();
}

/**
 *
 * @param {} elem
 * @returns {}
 */
var selectPageSizeFilter = function (elem) {
    var value = $(elem).find(":selected").val();
    $("#pageSize").val(value);
    window.history.pushState(null, null, setUrlEncodedKey("ps", value));
    fillSearchProducts();
}

/**
 *
 * @param {} elem
 * @returns {}
 */
var selectPageFilter = function (elem) {
    var page = parseInt($(elem).text());
    $(".pager").children().removeClass("active");
    $(elem).parent().addClass("active");
    $("#page").val(page);
    fillSearchProducts();
}

/**
 *
 * @param {} elem
 * @returns {}
 */
var productSearchPagination = function () {
    var totalCount = $("#total").val();
    var pageSize = $("#pageSize").val();
    var totalPage = parseInt((totalCount / pageSize) + 1);

    var initPage = getUrlParameterByName("p");
    if (initPage === null || initPage === "") {
        initPage = $("#page").val();
    }
    else if (initPage > totalPage) {
        initPage = totalPage;
        $("#page").val(initPage);
    }
    else {
        $("#page").val(initPage);
    }

    if ($("#productSearchPager").data("twbs-pagination")) {
        $("#productSearchPager").twbsPagination("destroy");
    }

    $("#productSearchPager").twbsPagination({
        totalPages: totalPage,
        visiblePages: 5,
        startPage: parseInt(initPage),
        first: "<< اولین",
        prev: "< قبلی",
        next: "بعدی >",
        last: "آخرین >>",
        href: false,
        initiateStartPageClick: false,
        onPageClick: function (event, page) {
            $("#page").val(page);
            window.history.pushState(null, null, setUrlEncodedKey("p", page));
            fillSearchProducts();
        }
    });
}

/**
 *
 * @param {} elem
 * @returns {}
 */
var loadCity = function (elem) {
    var stateId = getUrlParameterByName("s");
    if (stateId === null || stateId === "") {
        stateId = $("#stateId").val();
    }
    else {
        $("#stateId").val(stateId);
        $(elem).val(stateId);
    }
}

/**
 *
 * @param {} elem
 * @returns {}
 */
var selectSearchCity = function (elem) {
    var selectedId = $(elem).find(":selected").val();
    if (selectedId === "-1") {
        $("#stateId").val("");
        window.history.pushState(null, null, setUrlEncodedKey("s", ""));
    }
    else {
        $("#stateId").val(selectedId);
        window.history.pushState(null, null, setUrlEncodedKey("s", selectedId));
    }
    var id = $("#stateId").val();
    fillSearchProducts();
}

/**
 *
 * @returns {}
 */
var $slideSize_OnLoad = function () {
    var count = parseInt($("#imgCount").data("param")) + parseInt($("#previewCheck").data("param"));
    $("#imgCount").attr("data-number", (count - 4).toString());
    var percent = (100 / count).toString() + "%";
    $(".slide-holder").css("width", percent);
    if (count < 5) {
        $(".sliders-container").css("width", "100%");
        $(".slide-controller-right").children().addClass("slide-deactivated");
        $(".slide-controller-left").children().addClass("slide-deactivated");
    } else {
        var w = ((count - 4) * 25 + 100).toString() + "%";
        $(".sliders-container").css("width", w);
    }
}

/**
 *
 * @returns {}
 */
var $nextSlideImg_OnClick = function () {
    var count = parseInt($("#imgCount").data("param")) + parseInt($("#previewCheck").data("param"));
    var no = parseInt($("#imgCount").attr("data-number"));
    var w = parseInt($(".sliders-wrapper").css("width"));
    var left = parseInt($(".sliders-container").css("left"));
    var remain = count - 4;
    if (remain > 0 && no > 0) {
        var newLeft = (left - (w / 4)).toString() + "px";
        $(".sliders-container").css("left", newLeft);
        $("#imgCount").attr("data-number", (no - 1).toString());
        --no;
    } else if (remain > 0 && no === 0) {
        $(".sliders-container").css("left", "0");
        $("#imgCount").attr("data-number", (remain).toString());
        no = remain;
    }
}

/**
 *
 * @returns {}
 */
var $prevSlideImg_OnClick = function () {
    var count = parseInt($("#imgCount").data("param")) + parseInt($("#previewCheck").data("param"));
    var no = parseInt($("#imgCount").attr("data-number"));
    var w = parseInt($(".sliders-wrapper").css("width"));
    var left = parseInt($(".sliders-container").css("left"));
    var remain = count - 4;
    if (remain > 0 && no < remain) {
        var newLeft = (left + (w / 4)).toString() + "px";
        $(".sliders-container").css("left", newLeft);
        $("#imgCount").attr("data-number", (parseInt(no) + 1).toString());
        ++no;
    } else if (remain > 0 && no === remain) {
        $(".sliders-container").css("left", (-(remain * 25)).toString() + "%");
        $("#imgCount").attr("data-number", "0");
        no = 0;
    }
}

/**
 *
 * @param {} elem
 * @returns {}
 */
var $resizeSlide_OnClick = function ($elem) {
    var $src = $($elem).attr("src");
    $("#slideBgImg").attr("src", $src);
    var $bigImageZoomableElem = $("#zoomContainer");
    $productZoom_OnLoad($bigImageZoomableElem, $src);
}

/**
 * 
 * @returns {} 
 */
var enableSubmitButton = function () {
    $(":submit").removeClass("disabled-btn-link");
    $(":submit").prop("disabled", false);
}

/**
 * 
 * @param {} event 
 * @param {} tag 
 * @returns {} 
 */
var addSpecOption = function (tag) {
    var items = $(tag).data("items");
    var item = $(tag).data("item");
    var index = $(item).last().data("index");

    $(item).first().clone().appendTo(items);
    $(item).last().attr("data-index", (parseInt(index) + 1));

    $(item).last().find("*").each(function (key, value) {
        if ($(this).attr("value") != null)
            $(this).val("");
        if ($(this).attr("name") != null)
            $(this).attr("name", $(this).attr("name").replace("\[0\]", "\[" + (parseInt(index) + 1) + "\]"));
        if ($(this).attr("id") != null)
            $(this).attr("id", $(this).attr("id").replace("_0_", "_" + (parseInt(index) + 1) + "_"));
        if ($(this).attr("for") != null)
            $(this).attr("for", $(this).attr("for").replace("_0_", "_" + (parseInt(index) + 1) + "_"));
        if ($(this).attr("data-valmsg-for") != null)
            $(this).attr("data-valmsg-for", $(this).attr("data-valmsg-for").replace("\[0\]", "\[" + (parseInt(index) + 1) + "\]"));
        if ($(this).attr("onclick") != null)
            $(this).attr("onclick", $(this).attr("onClick").replace("0", (parseInt(index) + 1)));
    });
}

/**
 * 
 * @param {} event 
 * @param {} index 
 * @param {} selector 
 * @returns {} 
 */
var deleteTag = function (index, selector) {
    if (index != 0)
        $(selector).remove("[data-index='" + index + "']");
}

/**
 * 
 * @param {} elem 
 * @returns {} 
 */
var $removeConfirm_OnClick = function (elem) {
    messageConfirmDialog("آیا برای حذف اطمینان دارید؟", true, function() {
        $ajaxRemoveItem_OnClick(elem);
    });
}

/**
 * 
 * @param {} elem 
 * @returns {} 
 */
var $navigate_OnClick = function (elem) {
    debugger;
    var key = $(elem).attr("name");
    var value = $(elem).val();
    if (value === null || value === "" || value === "undefined")
        removeQuryStringParameter(key);
    setQuryStringParameter(key, value);
}

/**
 * 
 * @param {} elem 
 * @returns {} 
 */
var $navigate_OnChange = function (elem) {
    var key = $(elem).attr("name");
    var value = $(elem).val();
    if (value === null || value === "" || value === "undefined")
        removeQuryStringParameter(key);
    else
    setQuryStringParameter(key, value);
}

var $navigateSearch_OnChange = function(elem) {
    var key = $(elem).attr("name");
    var value = $(elem).val();
    if (value === null || value === "" || value === "undefined" || $(elem).prop("checked") === false || value === "off")
    {
        removeQuryStringParameters(key, value);
    }
    else
        addQueryStringParameter(key, value);
}
var $navigateSearch_OnClick = function (elem) {
    var key = $(elem).attr("name");
    var value = $(elem).val() || $(elem).attr("value");
    if (value === null || value === "" || value === "undefined" || $(elem).hasClass("hasSelected"))
    {
        $(elem).removeClass("hasSelected");
        removeQuryStringParameters(key, value);
    }
    else
    {
        $(elem).addClass("hasSelected");
        addQueryStringParameter(key, value);
    }
}

var $navigateRemoveSearch_OnChange = function (elem) {
    var key = $(elem).attr("name");
        removeQuryStringParameter(key);
    }

/**
 * 
 * @param {} e 
 * @param {} elem 
 * @returns {} 
 */
var $searchGrid_OnKeypress = function (elem, e) {
    //e.preventDefault();
    var key = $(elem).attr("name");
    var value = $(elem).val();
    
    e = e || window.event;
    if (e.keyCode === 13) {
        if (value === null || value === "" || value === "undefined")
            removeQuryStringParameter(key);
        else
            setQuryStringParameter(key, value);
    }
    return true;
}

/**
 * 
 * @returns {} 
 */
var startUp = function () {
    navMove();
    goUp();
}

/**
 * 
 * @param {} elem 
 * @returns {} 
 */
var $openShadow_OnClick = function (elem) {
    var shadowType = $(elem).data("type");
    switch (shadowType) {
        case "gallery":
            openSlideLoader(elem);
            break;
        case "modal":
            openItemModal(elem);
            break;
    }
}

/**
 * 
 * @param {} elem 
 * @returns {} 
 */
var $rightGalleryFiles_OnClick = function (elem) {
    rightSlideButton(elem);
}

/**
 * 
 * @param {} elem 
 * @returns {} 
 */
var $leftGalleryFiles_OnClick = function (elem) {
    leftSlideButton(elem);
}

/**
 * 
 * @param {} elem 
 * @returns {} 
 */
var $closeShadow_OnClick = function (elem) {
    closeSlideButton(elem);
}

/**
 * 
 * @param {} elem 
 * @returns {} 
 */
var $sliderTabs_OnLoad = function (elem) {
    var n = parseInt($(elem).data("tabs"));
    var i = 0;
    $(elem).parent().find(".owl-dot").each(function () {
        ++i;
        var title = $(elem).parent().find(".slider-tabs-title").children("[data-tab=" + i + "]");
        $(this).css("width", (100 / n) + "%");
        $(this).children("span").append(title.text());
    });
}

/**
 * 
 * @param {} elem 
 * @returns {} 
 */
var $calcPlanInvoice_OnClick = function (elem) {
    var price = $(elem).parent().children(".plan-pre-price").text();
    var finalPrice = $(elem).parent().children(".plan-price").text();
    var intPrice = parseInt(price.split(" ", 1));
    var intFinalPrice = parseInt(finalPrice.split(" ", 1));
    var discountPrice = intPrice - intFinalPrice;
    var discountPercent = $(elem).parent().children(".plan-discount-tag").text();
    var planSelector = $(elem).parents(".outer-month").find(".plan-order-radio").val();
    var plan;
    var duration;
    switch (planSelector) {
        case "Bronze12":
            plan = $("#planFundamental").text();
            duration = $("#durationOneYear").text();
            break;
        case "Silver6":
            plan = $("#planEconomical").text();
            duration = $("#durationSixMonths").text();
            break;
        case "Silver12":
            plan = $("#planEconomical").text();
            duration = $("#durationOneYear").text();
            break;
        case "Gold6":
            plan = $("#planSpecial").text();
            duration = $("#durationSixMonths").text();
            break;
        case "Gold9":
            plan = $("#planSpecial").text();
            duration = $("#durationNineMonths").text();
            break;
        case "Gold12":
            plan = $("#planSpecial").text();
            duration = $("#durationOneYear").text();
            break;
    }
    $("#PlanTitle").text("").append(plan);
    $("#PlanValidity").text("").append(duration);
    $("#PlanPrice").text("").append(price);
    $("#PlanDiscountPercent").text("").append(discountPercent);
    $("#PlanDiscountPrice").text("").append(discountPrice + ",000");
    $("#PlanFinalPrice").text("").append(finalPrice);
}

/**
 * 
 * @returns {} 
 */
var $loadVideoCarousel_OnLoad = function () {
    var videoCarouselOptions = {
        nav: true,
        rtl: true,
        navText: ["<i class='fa fa-chevron-right'></i>", "<i class='fa fa-chevron-left'></i>"],
        navSpeed: 700,
        dragEndSpeed: 1000,
        responsiveClass: true,
        responsive: {
            0: {
                items: 1
            },
            422: {
                items: 2
            },
            554: {
                items: 3
            },
            686: {
                items: 4
            },
            818: {
                items: 5
            },
            951: {
                items: 4
            },
            1014: {
                items: 5
            },
            1146: {
                items: 6
            },
            1278: {
                items: 7
            }
        }
    }
    $(".owl-carousel").owlCarousel(videoCarouselOptions);
}

/**
 * 
 * @param {} elem 
 * @returns {} 
 */
var $selectVideoFile_OnClick = function(elem) {
    $(elem).parents(".videos-carousel-container").find(".current-thumb").removeClass("current-thumb").addClass("alternative-thumb");
    $(elem).addClass("current-thumb").removeClass("alternative-thumb");
    var number = $(elem).data("param");
    var previousVideo = $(elem).parents(".gallery-container").children(".main-video-container").children(".main-video");
    var currentVideo = $(elem).parents(".gallery-container").children(".main-video-container").children("[data-param=" + number + "]");
    $(previousVideo)[0].pause();
    $(previousVideo).removeClass("main-video").addClass("alternative-video");
    $(currentVideo).addClass("main-video").removeClass("alternative-video");
}

/**
 * 
 * @param {} elem 
 * @returns {} 
 */
var $mainMenuExpand_OnMouseenter = function (elem) {
    var expand = $(elem).parent(".main-menu-categories").children(".sub-cat-expand");
    expand.hide();
    var h = $(".main-menu-categories").css("height");
    $(elem).parent(".main-menu-categories").css("height", h);
    expand.css("height", h);
    var currentExpand = $(elem).next(0);
    var subListCount = $(currentExpand).children().children("li").length;
    var corners;
    var expandWidth = -200;
    if (subListCount !== 0) {
        corners = "0 5px 5px 0";
        currentExpand.css("display", "block");
        var sumHeight = 0;
        var columnCount = 1;
        for (var i = 0; i < subListCount; ++i) {
            var subCategoryBox = $(currentExpand).children().children("li")[i];
            var strBoxHeight = $(subCategoryBox).css("height");
            var boxHeight = parseInt(strBoxHeight.split("px"));
            var columnHeight = sumHeight + boxHeight;
            if (columnHeight > parseInt(h.split("px"))) {
                sumHeight = boxHeight;
                columnCount += 1;
            } else {
                sumHeight = columnHeight;
            }
            expandWidth = (columnCount - 1) * 200;
            $(subCategoryBox).css("right", expandWidth);
            $(subCategoryBox).css("top", (sumHeight - boxHeight));
        }
        $(currentExpand).css("width", (columnCount * 200));
    } else {
        corners = "5px";
    }
    expand.css("width", (expandWidth + 200));
    changeBorderRadius(corners);
}

/**
 * 
 * @param {} borderRadius 
 * @returns {} 
 */
var changeBorderRadius = function (borderRadius) {
    $(".main-menu-categories").css("border-radius", borderRadius);
    $(".main-menu-categories").css("-webkit-border-radius", borderRadius);
    $(".main-menu-categories").css("-moz-border-radius", borderRadius);
    $(".main-menu-categories").css("-o-border-radius", borderRadius);
    $(".main-menu-categories").css("-ms-border-radius", borderRadius);
    $(".main-menu-categories").css("-khtml-border-radius", borderRadius);
}

/**
 * 
 * @param {} elem 
 * @returns {} 
 */
var $mainMenuCollapse_OnMouseleave = function (elem) {
    $(elem).children("ul").children(".sub-cat-expand").hide();
    $(elem).children("ul").children(".sub-cat-expand").css("width", "0");
}

/**
 * 
 * @param {} elem 
 * @returns {} 
 */
var $listSearchbarFilterToggle_OnClick = function (elem) {
    $(elem).parent().parent().toggleClass("filter-toggle");
}

/**
 * 
 * @param {} elem 
 * @returns {} 
 */
var $positionCompanyMenu_OnLoad = function (elem) {
    var menuTop = $(elem)[0].getBoundingClientRect().top + $(window)["scrollTop"]() - 66;
    var footerTop = $("footer")[0].getBoundingClientRect().top + $(window)["scrollTop"]() - 150;
    var h = $(elem).height();
    var footerTopScroll = footerTop - h - 76;
    $(window).scroll(function () {
        if (($(this).scrollTop() > menuTop) && ($(this).scrollTop() > footerTopScroll)) {
            $(elem).removeClass("fixedMenu");
            $(elem).addClass("fixedMenuFooter");
            $(elem).css("bottom", ($(window).height() - $("footer")[0].getBoundingClientRect().top + 170));
        } else if ($(this).scrollTop() > (menuTop)) {
            $(elem).removeClass("fixedMenuFooter");
            $(elem).addClass("fixedMenu");
            $(elem).css("bottom", "");
        } else {
            $(elem).removeClass("fixedMenuFooter");
            $(elem).removeClass("fixedMenu");
        }
    });
};
/**
 * 
 * @param {} elem 
 * @returns {} 
 */

var $companyTabTransition_OnClick = function (elem) {
    var sectionId = "#" + $(elem).data("section");
    var sectionH = $(sectionId)[0].getBoundingClientRect().top + $(window)["scrollTop"]();
    $("body,html").animate({ scrollTop: (sectionH - 50) }, 400);
}

/**
 * 
 * @returns {} 
 */
var productDetailRank = function() {
    $("#productDetailRank").children(".pr-chart-ctrl").each(function () {
        var elementPos = $(this).offset().top;
        var topOfWindow = $(window).scrollTop();
        var animate = $(this).data("animate");
        var rate = parseInt($("#productDetailRank").children(".pr-chart-ctrl").children(".pr-chart").data("percent"));
        var brColor;
        if (rate === 0) {
            brColor = "#000";
        } else if (rate < 30 || rate === 30) {
            brColor = "#f44336";
        } else if (rate < 70 || rate === 70) {
            brColor = "#ff9800";
        } else {
            brColor = "#4caf50";
        }
        if (elementPos < topOfWindow + $(window).height() - 30 && !animate) {
            $(this).data("animate", true);
            $(this).find(".pr-chart").easyPieChart({
                size: 150,
                barColor: brColor,
                trackColor: "#f1f1f1",
                scaleColor: "#fff",
                scaleLength: 0,
                lineWidth: 16,
                lineCap: "round",
                onStep: function (from, to, percent) {
                    $(this.el).find("i").text(Math.round(percent) + "%");
                }
            }).stop();
        }
    });
}

/**
 * 
 * @param {} elem 
 * @returns {} 
 */
var changeAdsType = function(elem) {
    var value = $(elem).val();
    if (value === "1") {
        $('#AdsLocation').empty();
        $('#AdsLocation').append("<option selected disabled>-----</option>");
        $('#AdsLocation').append("<option value='1'>صفحه اصلی</option>");
        $('#AdsLocation').append("<option value='2'>دسته بندی ها</option>");
       
        $('#adsLocationContainer').removeClass('hide-none');
        //$('#AdsType').disable();
    }
    else if (value === "2") {
        $('#AdsLocation').empty();
        $('#AdsLocation').append("<option selected disabled>-----</option>");
        $('#AdsLocation').append("<option value='1'>صفحه اصلی</option>");
        $('#AdsLocation').append("<option value='2'>دسته بندی ها</option>");
        $('#AdsLocation').append("<option value='3'>صفحه شخصی</option>");
        $('#adsLocationContainer').removeClass('hide-none');
        //$('#AdsType').disable();

    }
}
/**
 * 
 * @param {} elem 
 * @returns {} 
 */
var changeAdsOptionLocation = function (elem) {
   $('#PositionTitle').removeClass('hide-none');
    $('#Position').removeClass('hide-none');
    $('#Order').removeClass('hide-none');
    $('#Price').removeClass('hide-none');
 
}

/**
 * Rating Stars
 * @param {} elem 
 * @returns {} 
 */
  var emptyStar = function (elem) {
    $(elem).removeClass("fa-star");
    $(elem).removeClass("fa-star-half-o");
    $(elem).addClass("fa-star-o");
  }
/**
 * 
 * @param {} elem 
 * @returns {} 
 */
var halfStar = function (elem) {
    $(elem).removeClass("fa-star");
    $(elem).removeClass("fa-star-o");
    $(elem).addClass("fa-star-half-o");
}
/**
 * 
 * @param {} elem 
 * @returns {} 
 */
var fullStar = function (elem) {
    $(elem).removeClass("fa-star-o");
    $(elem).removeClass("fa-star-half-o");
    $(elem).addClass("fa-star");
}
/**
 * 
 * @param {} number 
 * @returns {} 
 */
var newStarsArrange = function (number) {
    emptyStar($(".star-first"));
    emptyStar($(".star-second"));
    emptyStar($(".star-third"));
    emptyStar($(".star-fourth"));
    emptyStar($(".star-fifth"));
    if (number > 0 && number <= 0.5) {
        halfStar($(".star-first"));
    } else if (number > 0.5 && number <= 1) {
        fullStar($(".star-first"));
    } else if (number > 1 && number <= 1.5) {
        fullStar($(".star-first"));
        halfStar($(".star-second"));
    } else if (number > 1.5 && number <= 2) {
        fullStar($(".star-first"));
        fullStar($(".star-second"));
    } else if (number > 2 && number <= 2.5) {
        fullStar($(".star-first"));
        fullStar($(".star-second"));
        halfStar($(".star-third"));
    } else if (number > 2.5 && number <= 3) {
        fullStar($(".star-first"));
        fullStar($(".star-second"));
        fullStar($(".star-third"));
    } else if (number > 3 && number <= 3.5) {
        fullStar($(".star-first"));
        fullStar($(".star-second"));
        fullStar($(".star-third"));
        halfStar($(".star-fourth"));
    } else if (number > 3.5 && number <= 4) {
        fullStar($(".star-first"));
        fullStar($(".star-second"));
        fullStar($(".star-third"));
        fullStar($(".star-fourth"));
    } else if (number > 4 && number <= 4.5) {
        fullStar($(".star-first"));
        fullStar($(".star-second"));
        fullStar($(".star-third"));
        fullStar($(".star-fourth"));
        halfStar($(".star-fifth"));
    } else if (number > 4.5 && number <= 5) {
        fullStar($(".star-first"));
        fullStar($(".star-second"));
        fullStar($(".star-third"));
        fullStar($(".star-fourth"));
        fullStar($(".star-fifth"));
    }
}

/**
 * 
 * @param {} elem 
 * @returns {} 
 */
var $addCatalogCreate_OnClick = function (elem) {
    var index = $(".catalogContainer .catalogItem").last().data("index");

    $(".catalogItemTemplate").children().clone().appendTo(".catalogContainer");
    $(".catalogContainer .catalogItem").last().attr("data-index", (parseInt(index) + 1));
    $(".catalogContainer .catalogItem").last().find(".nov-col-1").find("select").attr("value", $("#categoryDefault").val());

    $(".catalogContainer .catalogItem").last().find("*").each(function (key, value) {
        if ($(this).attr("name") != null)
            $(this).attr("name", $(this).attr("name").replace("[*]", "[" + (parseInt(index) + 1) + "]"));
        if ($(this).attr("id") != null)
            $(this).attr("id", $(this).attr("id").replace("_*_", "_" + (parseInt(index) + 1) + "_"));
        if ($(this).attr("value") != null)
            $(this).attr("value", $(this).attr("value").replace("*", (parseInt(index) + 1)));
        if ($(this).attr("for") != null)
            $(this).attr("for", $(this).attr("for").replace("_*_", "_" + (parseInt(index) + 1) + "_"));
        if ($(this).attr("data-on-load") != null)
            $(this).attr("data-on-load", $(this).attr("data-on-load").replace("*", ""));
        if ($(this).attr("data-on-click") != null)
            $(this).attr("data-on-click", $(this).attr("data-on-click").replace("*", ""));
        if ($(this).attr("data-on-change") != null)
            $(this).attr("data-on-change", $(this).attr("data-on-change").replace("*", ""));
        if ($(this).attr("type") != null)
            $(this).attr("type", $(this).attr("type").replace("*", ""));
    });

    $(".catalogContainer .catalogItem").last().appNavigate();
    $validateProductBulk_OnLoad(document.getElementById("newProductBulk"));
    $validateProductBulk_OnLoad(document.getElementById("editProductBulk"));
}

/**
 * 
 * @param {} elem 
 * @returns {} 
 */
var $removeCatalogCreate_OnClick = function (elem) {
    $(elem).closest(".catalogItem").remove();
}

var $toggleCatalogSecondHand_OnChange = function ($elem) {
    var $index = $($elem).closest(".catalogItem").data("index");
    if ($($elem).val() === "1") {
        var $extraTemplate = $(".catalogItemExtra").html();
        $($elem).closest(".catalogItem").append($extraTemplate);
        $(".catalogItem[data-index='" + $index + "'] .catalogExtra").find("*").each(function (key, value) {
            if ($(this).attr("name") != null)
                $(this).attr("name", $(this).attr("name").replace("[*]", "[" + $index + "]"));
            if ($(this).attr("id") != null)
                $(this).attr("id", $(this).attr("id").replace("_*_", "_" + $index + "_"));
            if ($(this).attr("value") != null)
                $(this).attr("value", $(this).attr("value").replace("*", $index));
            if ($(this).attr("for") != null)
                $(this).attr("for", $(this).attr("for").replace("_*_", "_" + $index + "_"));
            if ($(this).attr("data-on-load") != null)
                $(this).attr("data-on-load", $(this).attr("data-on-load").replace("*", ""));
        });
        $(".catalogItem[data-index='" + $index + "'] .catalogExtra").appNavigate();
    }
    else {
        $(".catalogItem[data-index='" + $index + "'] .catalogExtra").remove();
    }
}

/**
 * 
 * @returns {} 
 */
var sideMenuDashboard = function () {
    var $shadow_film = $('.shadow-film'),
		$mobile_menu_handler = $('.mobile-menu-handler'),
		$mobile_menu = $('#mobile-menu'),
		$side_list_handler = $('.dropdown.interactive'),
		$mobile_account_options_handler = $('.mobile-account-options-handler'),
		$account_options_menu = $('#account-options-menu'),
		$db_sidemenu_handler = $('.db-side-menu-handler'),
		$dashboard_options_menu = $('#dashboard-options-menu');

    $mobile_menu_handler.on('click', { id: '#mobile-menu' }, showSideMenu);
    $mobile_menu.children('.svg-plus').on('click', { id: '#mobile-menu' }, showSideMenu);

    $mobile_account_options_handler.on('click', { id: '#account-options-menu' }, showSideMenu);
    $account_options_menu.children('.svg-plus').on('click', { id: '#account-options-menu' }, showSideMenu);

    $db_sidemenu_handler.on('click', { id: '#dashboard-options-menu' }, showSideMenu);
    $dashboard_options_menu.children('.svg-plus').on('click', { id: '#dashboard-options-menu' }, showSideMenu);

    function showSideMenu(e) {
        var $menu = $(e.data.id);

        toggleVisibility($menu);
        toggleVisibility($shadow_film);
    }

    function toggleVisibility(togglableItem) {
        if (togglableItem.hasClass('closed')) {
            togglableItem
				.removeClass('closed')
				.addClass('open');
        } else {
            togglableItem
				.removeClass('open')
				.addClass('closed');
        }
    }

    $side_list_handler
		.children('.dropdown-item.interactive')
		.on('click', toggleInnerMenu)
		.children('a').click(function (e) {
		    e.preventDefault();
		});


    function toggleInnerMenu(e) {
        var $this = $(this);
        if (!$this.hasClass('active')) {
            $this.parent().children('.dropdown-item.interactive.active').each(function () {
                $(this).toggleClass('active')
                .children('.inner-dropdown')
                .slideToggle(600);
            });
            $this
			.toggleClass('active')
			.children('.inner-dropdown')
			.slideToggle(600);
        } else {
            $this.parent().children('.dropdown-item.interactive.active').each(function () {
                $(this).toggleClass('active')
                .children('.inner-dropdown')
                .slideToggle(600);
            });
        }
    }
}

/**
 * 
 * @returns {} 
 */

var sideMenuNovinak = function () {
    var $shadow_film = $('.shadow-film'),
		$mobile_menu_handler = $('.mobile-menu-handler'),
		$mobile_menu = $('#mobile-menu'),
		$side_list_handler = $('.dropdown.interactive'),
		$mobile_account_options_handler = $('.mobile-account-options-handler'),
		$account_options_menu = $('#account-options-menu'),
        $open_menu;

    $mobile_menu_handler.unbind('click').bind('click', { id: '#mobile-menu' }, showSideMenu);

    $mobile_menu.children('.svg-plus').unbind('click').bind('click', { id: '#mobile-menu' }, showSideMenu);

    $mobile_account_options_handler.unbind('click').bind('click', { id: '#account-options-menu' }, showSideMenu);

    $account_options_menu.children('.svg-plus').unbind('click').bind('click', { id: '#account-options-menu' }, showSideMenu);
    $account_options_menu.children('.close-me').unbind('click').bind('click', { id: '#account-options-menu' }, showSideMenu);

    $shadow_film.unbind('click').bind('click', function () {
        if ($account_options_menu.hasClass('open')) {
            $open_menu = $account_options_menu;
        } else if ($mobile_menu.hasClass('open')) {
            $open_menu = $mobile_menu;
        }
        toggleVisibility($open_menu);
        toggleVisibility($shadow_film);
    });

    function showSideMenu(e) {
        var $menu = $(e.data.id);

        toggleVisibility($menu);
        toggleVisibility($shadow_film);
    }

    function toggleVisibility(togglableItem) {
        if (togglableItem.hasClass('closed')) {
            togglableItem
				.removeClass('closed')
				.addClass('open');
        } else {
            togglableItem
				.removeClass('open')
				.addClass('closed');
        }
    }

    $side_list_handler
		.children('.dropdown-item.interactive')
        .unbind('click')
		.bind('click', toggleInnerMenu)
		.children('a').click(function (e) {
		    e.preventDefault();
		});

    function toggleInnerMenu(e) {
        var $this = $(this);
        if (!$this.hasClass('active')) {
            $this.parent().children('.dropdown-item.interactive.active').each(function () {
                $(this).toggleClass('active')
                .children('.inner-dropdown')
                .slideToggle(600);
            });
            $this
			.toggleClass('active')
			.children('.inner-dropdown')
			.slideToggle(600);
        } else {
            $this.parent().children('.dropdown-item.interactive.active').each(function () {
                $(this).toggleClass('active')
                .children('.inner-dropdown')
                .slideToggle(600);
            });
        }
    }
}

/**
 * 
 * @returns {} 
 */
var dashboardHeader = function() {
   var $db_options_handler = $('.db-options-button'),

        // Sina:
		$closeIcon = $db_options_handler.children('.dashboard-close-icon'),
		$optionsIcon = $db_options_handler.children('.dashboard-left-menu-icon'),
        // Original:
		//$closeIcon = $db_options_handler.children('img[alt="close-icon"]'),
		//$optionsIcon = $db_options_handler.children('img[alt="db-list-right"]'),

        $header = $('.dashboard-header'),
		visibleHeight = $header.height(),
		totalHeight = getElementHeight($header);

    $db_options_handler.on('click', toggleDashboardOptions);

    function toggleDashboardOptions() {
        if ($header.hasClass('retracted')) {
            // TODO: Remove this when page is going to production
            // This is here just for live preview responsive auto update
            $header = $('.dashboard-header'); // X Remove on production
            visibleHeight = $header.height(); // X Remove on production
            totalHeight = getElementHeight($header); // X Remove on production

            $header
				.removeClass('retracted')
				.addClass('unretracted')
				.css({
				    'max-height': totalHeight + 'px'
				});
            $closeIcon.show();
            $optionsIcon.hide();
        } else {
            $header
				.removeClass('unretracted')
				.addClass('retracted')
				.css({
				    'max-height': visibleHeight + 'px'
				});
            $closeIcon.hide();
            $optionsIcon.show();
        }
    }

    function getElementHeight($element) {
        // clone element to measure it
        var $clonedElement = $element.clone(),
			height = 0;

        $clonedElement.css({
            'max-height': '1000px',
            'position': 'absolute',
            'top': '-10000px',
            'left': '-10000px'
        });

        $clonedElement = $clonedElement.appendTo($('body'));
        height = $clonedElement.height();
        // remove cloned element from DOM
        $clonedElement.remove();

        return height;
    }
}



/**
 * 
 * @returns {} 
 */
var $changeExpandState = function (elem) {
    var $filterItem = $(elem).parent();
    var $state = $filterItem.attr("data-expand");
    var $icon = $(elem).children(".left-angle-icon");
    $icon.toggleClass("rotate180");
    if ($state === "expand") {
        $filterItem.attr("data-expand", "collapse");
    } else {
        $filterItem.attr("data-expand", "expand");
    }
}



/**
 * 
 * @returns {} 
 */
var $searchFilterToggleExpand_OnLoad = function (elem) {
    $(elem).children(".search-filter-item").children(".search-filter-title").each(function () {
        $(this).bind("click",
            function () {
                $changeExpandState(this);
            });
    });
}


$addPriceToQueryString_OnClick = function (elem) {
    debugger;
    $("#price").trigger("changeValue");
}



/**
 * 
 * @returns {} 
 */
var $searchFilterButtonToggle_OnClick = function (elem) {
    $changeExpandState(elem);
    $(elem).parent().find("[data-expand='expand']").each(function() {
        $(this).attr("data-expand", "collapse");
        $(this).find(".left-angle-icon").toggleClass("rotate180");
    });
}


/*
*
*
*/
var $getCategory_OnChange = function(elem) {
    var $category = $(elem).val();
    var $categoryHolder = document.getElementById("categoryDefault");
    console.log($category);
    $($categoryHolder).attr("value", $category);
}





var $adsOptions_OnChange = function (elem) {
    var type = $('#AdsOptionType').val();
    var position = $('#AdsOptionPositionType').val();
    var ajaxOptions = {
        url: '/adsoption/getoptionajax',
        data: { type: type, position: position },
        complete: function (xhr, status) {
            if (status === 'success') {
                if (xhr.responseJSON.Success === true) {
                    if (type !== null && position !== null) {
                        $('#adsOptionContainer').removeClass('hide-none');
                        $('#adsOptionContainer').prev('.msg-container').removeClass('hide-none');
                        $('#AdsOptionId').empty();
                        $('#AdsOptionId').append("<option  selected disabled>-- انتخاب کنید --</option>");
                        $.each(xhr.responseJSON.Data,
                            function (index, item) {
                                $('#AdsOptionId')
                                    .append("<option value='" + item.Value + "'>" + item.Text + "</option>");
                            });
                        $('#AdDateRelease').empty();
                        $('#Title1').removeClass('hide-none');
                        $('#Title1').prev('.msg-container').removeClass('hide-none');
                        $('#EntityName1').removeClass('hide-none');
                        $('#EntityName1').prev('.msg-container').removeClass('hide-none');
                        $('#DurationType1').removeClass('hide-none');
                        $('#DurationType1').prev('.msg-container').removeClass('hide-none');
                        $('#AdPrice').empty().html("0");
                        $('#Image1').removeClass('hide-none');
                        $('#Image1').prev('.msg-container').removeClass('hide-none');
                        if (position === "2") {
                            $('#CategoryTree1').removeClass('hide-none');
                            $('#CategoryTree1').prev('.msg-container').removeClass('hide-none');
                        } else {
                            $('#CategoryTree1').addClass('hide-none');
                            $('#CategoryTree1').prev('.msg-container').addClass('hide-none');
                        }
                    }
                } else {
                    messageError('');
                }
            } else {
                messageError('');
            }
        }
    }
    $.appAjax(ajaxOptions);
    var $ajaxDateofRelease_OnChange = function (elem) {
        var ajaxOptions = {
            url: "/AdsReserve/DateofReleaseAjax",
            data: {
                optionId: $('#AdsOptionId').val()
            },
            complete: function (xhr, statuse) {
                if (statuse === "success") {
                    if (xhr.responseJSON.Success === true) {
                        console.log(xhr.responseJSON.Data);
                        $("#AdDateRelease").html(xhr.responseJSON.Data);
                        $ajaxSelectDurationType_OnChange();
                    }
                }
            }
        }
        $.appAjax(ajaxOptions);
    }
}



var $showDatePicker_OnClick = function (elem) {
    debugger;
    var jalaliToday = toJalaali(new Date());
    var normalTodat = jalaliToday.jy + "/" + jalaliToday.jm + "/" + jalaliToday.jd;
    PersianDatePicker.Show(elem, normalTodat);
}



/* Company Slide Methods */

/*
*
*
*/
var $bindButtons_OnLoad = function($elem) {
    $($elem).find(".slide-active").each(function () {
        $(this).find(".slide-item").bind("click",
            function () {
                $convertThumbToSelectedThumb($(this));
            });
    });
    $($elem).find(".slide-add").each(function () {
        $(this).find(".slide-item").bind("click",
            function() {
                $convertAddThumbToWaitThumb($(this));
            });
    });
    $($elem).find(".slide-active").each(function () {
        $(this).find(".slide-delete").bind("click",
            function() {
                $convertThumbToAddThumb($(this));
            });
    });
    $showInputItem($elem, $index);
}

var $convertThumbToSelectedThumb = function ($elem) {
    var $index = parseInt($($elem).parent().data("index"));
    var $thumbsWrapper = $($elem).parents(".slide-thumb-wrapper");
    var $currentThumb = $($elem).parent();
    $thumbsWrapper.find(".slide-selected")
        .each(function () { $(this).removeClass("slide-selected") });
    $($currentThumb).addClass("slide-selected");
    $showInputItem($elem, $index);
}

var $convertAddThumbToWaitThumb = function ($elem) {
    var $index = parseInt($($elem).parent().data("index"));
    var $thumbsWrapper = $($elem).parents(".slide-thumb-wrapper");
    var $currentThumb = $($elem).parent();
    $thumbsWrapper.find(".slide-selected")
        .each(function () { $(this).removeClass("slide-selected") });
    $($currentThumb).attr("class", "slide-wait slide-selected");
    $currentThumb.prepend("<a href='javascript:void(0)' class='slide-delete round-corners-three'><i class='fa fa-trash'></i> <span>حذف</span></a>");
    $currentThumb.find(".slide-delete").unbind("click").bind("click",
        function () {
            $convertThumbToAddThumb($(this));
        });
    $currentThumb.find(".inner-circle").empty().append(++$index);
    $addInputItem($elem);
    $elem.unbind("click").bind("click",
        function () {
            $convertThumbToSelectedThumb($(this));
        });
}

var $convertThumbToAddThumb = function ($elem) {
    var $currentThumb = $($elem).parent();
    $($currentThumb).attr("class", "slide-add");
    $currentThumb.find(".inner-circle").empty().append("<i class='fa fa-plus'></i>");
    $currentThumb.find(".slide-item").unbind("click").bind("click",
        function () {
            $convertAddThumbToWaitThumb($(this));
        });
    $removeInputItem($elem);
    $elem.remove();
}

var $addInputItem = function ($elem) {
    var $index = parseInt($($elem).parent().data("index"));
    var $form = $("#editCompanySlide");
    var $inputTemplate = $(".InputItemTemplate");
    $inputTemplate.children().clone().appendTo($form);
    var $currentNewInputItem = $($form).children(".input-form").last();
    $currentNewInputItem.attr("data-index", $index);
    $currentNewInputItem.find("*").each(function (key, value) {
        if ($(this).attr("name") != null)
            $(this).attr("name", $(this).attr("name").replace("[*]", "[" + $index + "]"));
        if ($(this).attr("id") != null)
            $(this).attr("id", $(this).attr("id").replace("_*_", "_" + $index + "_"));
        if ($(this).attr("value") != null)
            $(this).attr("value", $(this).attr("value").replace("*", $index));
        if ($(this).attr("for") != null)
            $(this).attr("for", $(this).attr("for").replace("_*_", "_" + $index + "_"));
        if ($(this).attr("data-on-load") != null)
            $(this).attr("data-on-load", $(this).attr("data-on-load").replace("*", ""));
        if ($(this).attr("data-on-click") != null)
            $(this).attr("data-on-click", $(this).attr("data-on-click").replace("*", ""));
        if ($(this).attr("data-on-change") != null)
            $(this).attr("data-on-change", $(this).attr("data-on-change").replace("*", ""));
        if ($(this).attr("type") != null)
            $(this).attr("type", $(this).attr("type").replace("*", ""));
    });
    $showInputItem($elem, $index);
    $currentNewInputItem.appNavigate();
    //$validateCompanySlide_OnLoad(document.getElementById("editCompanySlide"));
}

var $removeInputItem = function ($elem) {
    var $index = parseInt($($elem).parent().data("index"));
    var $form = $("#editCompanySlide");
    $($form).children("[data-index=" + $index + "]").remove();
    //$validateCompanySlide_OnLoad(document.getElementById("editCompanySlide"));
}

var $showInputItem = function ($elem, $index) {
    var $form = $("#editCompanySlide");
    var $currentInputItem = $($form).children("[data-index=" + $index + "]");
    $($form).children(".input-form").each(function () {
        $(this).addClass("hide-none-imp");
    });
    $currentInputItem.removeClass("hide-none-imp");
}

/* Company Slide Methods */

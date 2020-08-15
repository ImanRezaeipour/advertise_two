var selectedNode = null;

function isNumeric(n) {
    return !isNaN(parseFloat(n)) && isFinite(n);
}

function formatCurrency(number) {
    return number.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
}

(function ($) {
    $.fn.SearchProducts = function (options) {
        var defaults = {
            resultDiv: '#resultDiv',
            progressDiv: '#progress',
            sourceUrl: '/',
            loginUrl: '/login',
            errorHandler: null,
            completeHandler: null,
            noMoreInfoHandler: null,
            priceRangeInputId: null,
            categoryTreeId: null,
            categoryDivId: null,
            specificationDivId: null,
            searchInputId: null,
            btnSearchId: null,
            pagerSortById: null,
            pagerSortOrderId: null,
            pageSizeId: null,
            paginationId: null,
            mainNonAjaxContentDivId: "#mainNonAjaxContent",
            paramName: "",
            pageName: "صفحه"
        };

        var page = 0;
        var inCallback = false;
        var hasReachedEndOfInfiniteScroll = false;

        options = $.extend(defaults, options);
        var showProgress = function () {
            $(options.progressDiv).fadeIn();
        }
        var hideProgress = function () {
            $(options.progressDiv).fadeOut();
        }
        var clearArea = function () {
            $(options.moreInfoDiv).html("");
            $(options.mainNonAjaxContentDivId).html("");
            window.scrollTo(0, 0);
        }

        return this.each(function () {
            //$(window).scroll(scrollHandler);
            $(window).scroll(function () {
                scrollHandler();
            })
            var title = document.title;
            var updatePath = function () {
                if (!$(options.pagerSortById).val()) { return; }

                var selectedSpec = "";

                $(options.specificationDivId + " input:checked").each(function () { selectedSpec += $(this).val() + "_"; });

                selectedSpec = selectedSpec.substr(0, selectedSpec.length - 1);

                //must be ordered by path map : #/filter(/:category)(/:specifications)(/:searchTerm)(/:page)(/:sortby)(/:order)(/:pageSize)(/:minPrice)(/:maxPrice)
                var path = "#/filter/" +
                    ($(options.categoryDivId).val() || "all") + "/"
                    + (selectedSpec || "all") + "/"
                    + ($(options.searchInputId).val() || "empty") + "/"
                    + (currentPage) + "/" + $(options.pagerSortById).val() + "/"
                    + $(options.pagerSortOrderId).val() + "/"
                    + "6/" //+ $(options.pageSizeId).val() + "/"
                    + $(options.priceRangeInputId).slider("values", 0) + "/"
                    + $(options.priceRangeInputId).slider("values", 1);

                try { history.pushState({}, "", path); } catch (ex) { window.location.hash = path; }
                document.title = title + " / " + options.pageName + " " + (page);
            }

            var currentPage = 1;
            var inCallback = false;

            var submitData = function (pageNumber) {

                if (currentPage > -1 && !inCallback) {
                    if (pageNumber == null) {
                        pageNumber = currentPage;
                    }
                    else {
                        currentPage = pageNumber;
                    }
                    showProgress();

                    var pagerSortBy = $(options.pagerSortById).val();
                    var pagerSortOrder = $(options.pagerSortOrderId).val();
                    var pagerPageSize = 6;// $(options.pageSizeId).val()
                    var minPrice = $(options.priceRangeInputId).slider("values", 0);
                    var maxPrice = $(options.priceRangeInputId).slider("values", 1);
                    var searchTerm = $(options.searchInputId).val();
                    var selectedCategory = $(options.categoryDivId).val();
                    if (selectedCategory == "all") selectedCategory = null;
                    var selectedSpecifications = [];
                    $(options.specificationDivId + " input:checked").each(function () { selectedSpecifications.push($(this).val()); });
                    if (minPrice == values[0] && maxPrice == values[values.length - 1]) { minPrice = maxPrice = null; }

                    updatePath();

                    inCallback = true;
                    $.ajax({
                        type: "POST",
                        url: options.sourceUrl,
                        data: JSON.stringify(
                            {
                                pageNumber: pageNumber,
                                pageSize: pagerPageSize,
                                sortBy: pagerSortBy,
                                sortOrder: pagerSortOrder,
                                minPrice: minPrice,
                                maxPrice: maxPrice,
                                selectedCategory: selectedCategory,
                                SelectedSpecifications: selectedSpecifications,
                                searchTerm: searchTerm,
                                name: options.paramName
                            }
                        ),
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        complete: function (xhr, status) {
                            var data = xhr.responseText;
                            if (xhr.status == 403) { window.location = options.loginUrl; }
                            else if (status === 'error' || !data) { if (options.errorHandler) options.errorHandler(this); }
                            else {
                                var appendEl;
                                debugger;
                                if (currentPage > 1 && data == "no-more-info") {
                                    /*if no more data find in paging*/
                                    currentPage = -1;
                                    if (options.noMoreInfoHandler)
                                        options.noMoreInfoHandler(this);
                                }
                                else if (currentPage == 1 && data == "no-more-info") {
                                    /*if not data find in filtering*/
                                    currentPage = -1;
                                    appendEl = $(options.resultDiv).html("");
                                    if (options.noMoreInfoHandler)
                                        options.noMoreInfoHandler(this);
                                }
                                else {
                                    /*if data find*/
                                    var $boxes = $(data);
                                    $(options.resultDiv).fadeOut(function () {
                                        if (currentPage > 1) {
                                            /*if data find on paging*/
                                            appendEl = $(options.resultDiv).append(data);
                                        }
                                        else {
                                            /*if data find on filtering */
                                            appendEl = $(options.resultDiv).html(data);
                                        }

                                        $(options.resultDiv).fadeIn();
                                    });

                                    if (options.completeHandler) options.completeHandler(appendEl, $boxes);
                                }
                                hideProgress();
                                inCallback = false;
                            }
                        }
                    });
                }
            }

            Path.map("#/filter(/:category)(/:specifications)(/:searchTerm)(/:page)(/:sortby)(/:order)(/:pageSize)(/:minPrice)(/:maxPrice)").to(function () {

                var sortBy = this.params['sortby'] || 'CreatedOn';
                var order = this.params['order'] || 'desc';
                var pageSize = this.params['pageSize'] || 6;
                var searchTerm = (this.params['searchTerm'] === "empty") ? "" : this.params['searchTerm'];
                var minPrice = this.params['minPrice'];
                var maxPrice = this.params['maxPrice'];

                var urlPage = 1;
                if (isNumeric(this.params['page'])) { urlPage = parseInt(this.params['page'], 10); }

                $(options.pagerSortById).val(sortBy);
                $(options.pagerSortOrderId).val(order);
                //$(options.pageSizeId).val(pageSize);
                $(options.searchInputId).val(decodeURIComponent(searchTerm || ""));

                var $slider = $(options.priceRangeInputId);
                if (isNumeric(minPrice) && isNumeric(maxPrice)) {
                    $slider.slider("values", 0, minPrice);
                    $slider.slider("values", 1, maxPrice);
                    $("#priceMinVal").html(formatCurrency($slider.slider('values', 0)));
                    $("#priceMaxVal").html(formatCurrency($slider.slider('values', 1)));
                }
                /*--------------------------------------------------------------------------------*/
                var categoryId = this.params['category'];
                var $category = $(options.categoryDivId);
                $category.val(categoryId);
                expandAndSelectNode(categoryId, options.categoryTreeId);
                /*--------------------------------------------------------------------------------*/
                var specifications = this.params['specifications'] || 'all';
                var specificationsList = [];
                specificationsList = specifications.split("_");
                $(options.specificationDivId + " input[type='checkbox']").each(function () {
                    for (var i = 0; i < specificationsList.length; i++) {
                        if (specificationsList[i] === $(this).val()) {
                            $(this).attr('checked', 'checked');
                            break;
                        }
                    }
                });
                /*--------------------------------------------------------------------------------*/
                page = urlPage;
                submitData(page);
            });

            Path.root("#/filter");

            if ($(options.pagerSortById).val()) {
                Path.listen();
            }

            //define Listeners
            $(options.categoryDivId).change(function () {
                currentPage = 1; submitData();
                $.ajax({
                    type: "GET",
                    url: "/Category/GetSpecificationFilter/" + selectedNode.id,
                    cache: false,
                    success: function (result) {
                        $("#SpecificationFilters").html(result);
                        $('.icheck input').iCheck({
                            checkboxClass: 'icheckbox_minimal-blue',
                            radioClass: 'iradio_minimal-blue'
                        });
                        $(options.specificationDivId + " input[type='checkbox']").on('ifChecked', function (event) {
                            currentPage = 1; submitData();
                        });
                        $(options.specificationDivId + " input[type='checkbox']").on('ifUnchecked', function (event) {
                            currentPage = 1; submitData();
                        });

                    }
                });
            })
            $(options.specificationDivId + " input[type='checkbox']").change(function () { currentPage = 1; submitData(); });
            $(options.pagerSortById + "," + options.pagerSortOrderId).change(function () { currentPage = 1; submitData(); });
            //$(options.pageSizeId).change(function () { submitData(1); });
            $(options.priceRangeInputId).on("slidechange", function (event, ui) { currentPage = 1; submitData(); });
            $(options.btnSearchId).on("click", function (event) { currentPage = 1; submitData(); });
            //this is for pagerList if exist
            $(document).on("click", options.paginationId + " a", function (event) {
                event.preventDefault(event);
                var $this = $(this);
                var href = $this.attr("href");
                if (href === null || href === undefined) return;
                var pageNumber = getParameterByName(href, "page");
                $('html,body').animate({ scrollTop: 0 });
                submitData(pageNumber);
            });

            function getParameterByName(url, name) {
                name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
                var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
                    results = regex.exec(url);
                return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
            }

            function expandAndSelectNode(id, treeViewName) {
                if (id == "all" || id == undefined)
                    return;

                var treeView = $(treeViewName).data('kendoTreeView');

                treeView.dataSource.read();

                // find node with data-id = id
                var item = $(treeViewName).find("li[data-id='" + id + "']").find(".k-in");
                // expand all parent nodes
                $(item).parentsUntil('.k-treeview').filter('.k-item').each(
                            function (index, element) {
                                $(treeViewName).data('kendoTreeView').expand($(this));
                            }
                        );
                // get DataSourceItem by given id
                var nodeDataItem = treeView.dataSource.get(id);
                if (nodeDataItem == undefined)
                    return;
                //get node within treeview widget by uid
                var node = treeView.findByUid(nodeDataItem.uid);
                treeView.select(node);
            }

            function showNoMoreRecords() {
                hasReachedEndOfInfiniteScroll = true;
            }

            function scrollHandler() {
                if (hasReachedEndOfInfiniteScroll == false && ($(window).scrollTop() == $(document).height() - $(window).height())) {
                    submitData(currentPage + 1);
                }
            }
        });
    };
})(jQuery);

$(function () {

    //------------------------------------------------------------------------------
    $('#products .item').addClass('grid-group-item');

    $('#list').click(function (event) {
        event.preventDefault(event);
        $('#products .item').addClass('list-group-item');
    });
    $('#grid').click(function (event) {
        event.preventDefault(event);
        $('#products .item').removeClass('list-group-item');
        $('#products .item').addClass('grid-group-item');
    });
    //------------------------------------------------------------------------------

    //لود بازه قیمت محصولات-------------------------------------------------------
    function findNearest(includeLeft, includeRight, value) {
        var nearest = null;
        var diff = null;
        for (var i = 0; i < values.length; i++) {
            if ((includeLeft && values[i] <= value) || (includeRight && values[i] >= value)) {
                var newDiff = Math.abs(value - values[i]);
                if (diff == null || newDiff < diff) {
                    nearest = values[i];
                    diff = newDiff;
                }
            }
        }
        return nearest;
    }
    debugger;
    $("#priceMinVal").html(formatCurrency(values[0]));
    $("#priceMaxVal").html(formatCurrency(values[values.length - 1]));
    var slider = $("#priceRange").slider({
        orientation: 'horizontal',
        range: true,
        isRTL: true,
        animate: false,
        min: values[0],
        max: values[values.length - 1],
        values: [values[0], values[values.length - 1]],
        slide: function (event, ui) {
            var includeLeft = event.keyCode != $.ui.keyCode.RIGHT;
            var includeRight = event.keyCode != $.ui.keyCode.LEFT;

            var value = findNearest(includeRight, includeLeft, ui.value);

            if (ui.value == ui.values[0]) {
                slider.slider('values', 0, value);
            } else {
                slider.slider('values', 1, value);
            }

            $("#priceMinVal").html(formatCurrency(slider.slider('values', 0)));
            $("#priceMaxVal").html(formatCurrency(slider.slider('values', 1)));

            return false;
        },
        change: function (event, ui) {
            //getHomeListings();
        }
    });
    //------------------------------------------------------------------------------

    //لود دسته بندی محصولات-------------------------------------------------------
    kendo.culture("fa-IR");
    var getCategoryList = new kendo.data.HierarchicalDataSource({
        transport: {
            read: {
                url: treeSourceUrl,
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                type: "GET",
                async: false
            }
        },
        schema: { model: { id: "Id", hasChildren: true } }
    });

    $("#CategoryList").kendoTreeView({
        dataSource: getCategoryList,
        dataTextField: "Title",
        dataValueField: "Id",
        animation: {
            expand: { effects: "fadeIn expandVertical" },
            collapse: { effects: "fadeOut collapseVertical" }
        },
        messages: {
            retry: "سعی مجدد", requestFailed: "درخواست نامعتبر", loading: "بارگذاری..."
        },
        select:
            function (e) {
                var node = $("#CategoryList").getKendoTreeView().dataItem(e.node);
                selectedNode = node;
                $("#CategoryId").val(selectedNode.Code).trigger('change');
            }
    });
    //-----------------------------------------------------------------------------

    //ماژول جستجوی محصولات
    $("#searchProductFrm").SearchProducts({
        resultDiv: '#products',
        progressDiv: '#ProgressDiv',
        sourceUrl: sourceUrl,
        loginUrl: '/login',
        errorHandler: null,
        completeHandler: null,
        noMoreInfoHandler: null,
        priceRangeInputId: "#priceRange",
        categoryTreeId: "#CategoryList",
        categoryDivId: "#CategoryId",
        specificationDivId: "#SpecificationFilters",
        searchInputId: "#searchTerm",
        btnSearchId: "#btnSearchProdcut",
        pagerSortById: "#pagerSortBy",
        pagerSortOrderId: "#pagerSortOrder",
        pageSizeId: "#pagerPageSize",
        paginationId: "#paginationDiv",
        mainNonAjaxContentDivId: "#mainNonAjaxContent",
        paramName: "",
        pageName: "صفحه"
    });
});

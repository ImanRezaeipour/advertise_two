/**
 * 
 * @param {} elem 
 * @returns {} 
 */
var $treeCategory_OnLoad = function (elem, isEdit) {
    var treeOptions = {
        actionUrl: "/Category/GetTreeAjax",
        parentSelector: "#ParentId",
        onlyCanSelectLeafNode: false
    }

    $(elem).appTree(treeOptions);
}


var $treeReport_OnLoad = function (elem) {
    debugger;
    var treeOptions = {
        actionUrl: "/Report/GetListAjax",
        parentSelector: "#ParentId",
        onlyCanSelectLeafNode: true,
        onSelectNode: function (node, selected, event) {
            console.log(node);
            console.log(selected.node.id);
            console.log(event);
           var ajaxOption= {
               url: "/report/FromDateToDateajax",
               data: { id: selected.node.id },
               complete : function(xhr,status) {
                   console.log(xhr);
                   $('#dialog').empty();
                   $('#dialog').append(xhr.responseJSON.Data);
                   $("Body").appNavigate();
               }
           }
            $.appAjax(ajaxOption);
        }
    }

    $(elem).appTree(treeOptions);
}

/**
 * 
 * @param {} elem 
 * @returns {} 
 */
var $treeRole_OnLoad = function (elem) {
    var treeOptions;
    var isEdit = $(elem).data('param');
    if (isEdit === "edit") {
        treeOptions = {
            actionUrl: "/Permission/GetListByRoleIdAjax",
            actionParams: { id: $('#Id').val() },
            parentSelector: "#ParentId",
            HasCheckbox: true,
            checkedListSelector: "#permissions"
        }
    }
    else {
        treeOptions = {
            actionUrl: "/Permission/GetPermissionsAjax",
            parentSelector: "#ParentId",
            HasCheckbox: true,
            checkedListSelector: "#permissions"
        }
    }

    $(elem).appTree(treeOptions);
}

/**
 * 
 * @param {} elem 
 * @returns {} 
 */
var $treeCategoryProduct_OnLoad = function (elem, isEdit) {
    var treeOptions = {
        actionUrl: "/Category/GetSubCatergoriesWithRootAjax",
        actionParams: {
             id: $('#CategoryId').val()
        },
        parentSelector: "#CategoryId",
        onlyCanSelectLeafNode: true,
        isFindSpec: $(elem).data("param") === "edit" ? false : true
    }

    $(elem).appTree(treeOptions);
}


/**
 * 
 * @param {} elem 
 * @returns {} 
 */
var $treeCategoryCompany_OnLoad = function (elem, isEdit) {
    var treeOptions = {
        actionUrl: "/Category/GetTreeAjax",
        parentSelector: "#CategoryId",
        onlyCanSelectLeafNode: false
    }

    $(elem).appTree(treeOptions);
}


/**
 * 
 * @param {} elem 
 * @returns {} 
 */
var $treeCategoryReview_OnLoad = function (elem, isEdit) {
    var treeOptions = {
        actionUrl: "/Category/GetTreeAjax",
        parentSelector: "#CategoryId",
        onlyCanSelectLeafNode: false
    }

    $(elem).appTree(treeOptions);
}

/**
 * 
 * @param {} elem 
 * @returns {} 
 */
var $treeCategorySpecification_OnLoad = function (elem, isEdit) {
    var treeOptions = {
        actionUrl: "/Category/GetTreeAjax",
        parentSelector: "#CategoryId",
        onlyCanSelectLeafNode: false
    }

    $(elem).appTree(treeOptions);
}

/**
 * 
 * @param {} elem 
 * @returns {} 
 */
var $treeCategorySpecificationOption_OnLoad = function (elem, isEdit) {
    var treeOptions = {
        actionUrl: "/Category/GetTreeAjax",
        parentSelector: "#CategoryId",
        onlyCanSelectLeafNode: false,
        onSelectNode: function() {
            var ajaxOptions = {
                url: "/Specification/GetListByCategoryAjax",
                data: {
                    id: $("#CategoryId").val()
                },
                complete: function (xhr, statuse) {
                    if (statuse === "success") {
                        if (xhr.responseJSON.Success === true) {
                            $("#SpecificationId").empty();
                            $.each(xhr.responseJSON.Data, function(index, item) {
                                $("#SpecificationId").append("<option value='" + item.Id + "'>" + item.Title + "</option>");
                            });
                        }
                    }
                }
            }

            $.appAjax(ajaxOptions);
        }
    }

    $(elem).appTree(treeOptions);
}

/**
 * 
 * @param {} elem 
 * @param {} isEdit 
 * @returns {} 
 */
var $treeSearch_OnLoad = function (elem) {
    var treeOptions = {
        actionUrl: "/Category/GetRelatedCategoriesAjax",
        actionParams: {
            alias: $(elem).data('param')
        },
        isSearch: true
    }
    console.log(treeOptions);

    $(elem).appTree(treeOptions);
}

/**
 * 
 * @param {} elem 
 * @param {} isEdit 
 * @returns {} 
 */
var $treePermission_OnLoad = function (elem, isEdit) {
    var treeOptions = {
        actionUrl: "/Category/GetRelatedCategoriesAjax",
        parentSelector: "#ParentId"
    }

    $(elem).appTree(treeOptions);
}

/**
 * 
 * @param {} elem 
 * @returns {} 
 */
var $treeCategoryCatalog_OnLoad = function (elem, isEdit) {
    var treeOptions = {
        actionUrl: "/Category/GetTreeAjax",
        parentSelector: "#CategoryId",
        onlyCanSelectLeafNode: true,
        isFindSpec: true
    }

    $(elem).appTree(treeOptions);
}
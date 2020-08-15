; (function ($) {
    $.fn.appTree = function (options) {

        // catch this element
        var self = this;
        var elem = $(this);

        // default options
        var defaults = {
            actionUrl: "",
            actionParams: {},
            actionType: "GET",
            actionDataType: "json",
            parentSelector: "",
            checkedListSelector: "",
            HasCheckbox: false,
            onlyCanSelectLeafNode: false,
            isSearch: false,
            isFindSpec: false,
            afterCompleted: function () { },
            onSelectNode: function(node, selected, event) { }
        };

        var settings = $.extend({}, defaults, options);

        // define events
        function onCompleted(xhr, status) {
            var jstreeOptions = {
                plugins: [
                    "search", "sort", "types", "unique", "wholerow", "changed", "conditionalselect"
                ],
                types: {
                    "None": {
                        "icon": "fa fa-sitemap"
                    },
                    "Service": {
                        "icon": "fa fa-coffee"
                    },
                    "Salable": {
                        "icon": "fa fa-shopping-bag"
                    }
                }
            }

            if (status === "success") {
                var dataText = JSON.stringify(xhr.responseJSON.Data);
                var dataSource = toJsTreeCheckBoxFlatDataSource(dataText);
                dataSource = JSON.parse(dataSource);
                jstreeOptions.core = {
                    data: dataSource
                };
            }

            if (settings.HasCheckbox === true) {
                jstreeOptions.plugins.push("checkbox");
                jstreeOptions.checkbox = {
                    "keep_selected_style": false
                };
                jstreeOptions.core.expand_selected_onload = false;
            }

            if (settings.onlyCanSelectLeafNode === true) {
                jstreeOptions.conditionalselect = function (node, event) {
                    if (node.children.length > 0)
                        return false;
                    return true;
                }
            }

            function onClickSetCategory(node, selected, event) {
                var categoryId = selected.node.id;
                $(settings.parentSelector).val(categoryId);
            }

            function onClickSetCategorySpecification(node, selected, event) {
                var categoryId = selected.node.id;

                $.ajax({
                    url: window.appCultureRoute + '/ProductSpecification/CreateAjax',
                    data: {
                         categoryId: categoryId
                    },
                    type: 'GET',
                    dataType: 'json',
                    complete: function (xhr, status) {
                        if (status === 'success') {
                            $('#specificationContainer').html(xhr.responseJSON.Data);
                        }
                    }
                });
            }

            function onClickRouteToSearch(node, selected, event) {
                var href = window.appCultureRoute + "/product/search/" + selected.node.data;
                window.location.href = href;
            }

            function onLoad() {
                if (settings.HasCheckbox !== true) {
                    var selectNode = '#' + $(settings.parentSelector).val();
                    $(self).jstree('deselect_all');
                    $(self).jstree('close_all');
                    $(self).jstree("open_node", selectNode);
                    $(self).jstree("select_node", selectNode);
                }
            }

            function onLoadExpandAllNodes() {
                if (settings.isSearch === true) {
                    $(self).jstree('open_all');
                }
            }

            function onChange(e, data) {
                if (settings.HasCheckbox === true) {
                    var checkedNodes = $(self).jstree("get_checked", false);
                    $(settings.checkedListSelector).val(checkedNodes.join(","));
                }
            }

            $(self)
                .on('select_node.jstree', function (node, selected, event) {
                    
                    if (settings.isSearch === true) {
                        onClickRouteToSearch(node, selected, event);
                    } else {
                        onClickSetCategory(node, selected, event);
                    }

                    if (settings.isFindSpec === true) {
                        onClickSetCategorySpecification(node, selected, event);
                    }

                    settings.onSelectNode(node, selected, event);
                })
                .on('loaded.jstree', function () {
                    onLoad();
                    onLoadExpandAllNodes();
                })
                .on('changed.jstree', function (e, data) {
                    onChange(e, data);
                })
                .jstree(jstreeOptions);

            $(self).jstree("open_node", '#' + $(settings.parentSelector).val());
        }

        function toJsTreeCheckBoxFlatDataSource(data) {
            data = JSON.parse(data);
            var temp = JSON.parse('[]');
            $.each(data, function (key, value) {
                if (value.ParentId === null) {
                    temp.push({
                        id: value.Id,
                        text: value.Title,
                        type: value.Type,
                        parent: "#",
                        state: {
                            opened: false,
                            disabled: false,
                            selected: value.IsSelect
                        },
                        li_attr: {},
                        a_attr: {},
                        data: value.Alias
                    });
                } else {
                    temp.push({
                        id: value.Id,
                        text: value.Title,
                        type: value.Type,
                        parent: value.ParentId,
                        state: {
                            opened: false,
                            disabled: false,
                            selected: value.IsSelect
                        },
                        li_attr: {},
                        a_attr: {},
                        data: value.Alias
                    });
                }

            });
            return JSON.stringify(temp);
        }

        function toHierarchicalDataSource(data, idField, foreignKey, rootLevel) {
            var hash = {};
            for (var i = 0; i < data.length; i++) {
                var item = data[i];
                var id = item[idField];
                var parentId = item[foreignKey];
                hash[id] = hash[id] || [];
                hash[parentId] = hash[parentId] || [];
                item.children = hash[id];
                hash[parentId].push(item);
            }
            return hash[rootLevel];
        }

        // do work and process on element
        var ajaxOptions = {
            url: window.appCultureRoute + settings.actionUrl,
            data: settings.actionParams,
            type: settings.actionType,
            dataType: settings.actionDataType,
            complete: function (xhr, status) {
                onCompleted(xhr, status);
                settings.afterCompleted();
            }
        };

        $.ajax(ajaxOptions);

        // return element
        return elem;
    };
}(jQuery));
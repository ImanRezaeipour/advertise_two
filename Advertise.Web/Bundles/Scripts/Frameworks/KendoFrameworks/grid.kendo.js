;
(function($) {
    $.fn.appGrid = function(options) {

        // capture this element
        var self = this;
        var elem = $(this);

        // default settings
        var defaults = {

            //  CONFIGURATION
            allowCopy: {
                delimeter: ","
            },
            autoBind: true,
            filterable: {
                extra: true,
                mode: "menu"
            },
            groupable: {
                enabled: true,
                showFooter: true
            },
            height: 550,
            pageable: {
                refresh: true,
                pageSizes: true,
                previousNext: true,
                numeric: true,
                buttonCount: 5,
                info: true,
                input: false
            },
            scrollable: {
                virtual: true
            },
            selectable: "row",
            sortable: {
                allowUnsort: false,
                showIndexes: false,
                initialDirection: "desc",
                mode: "single"
            },

            //  FIELDS
            columns: [],
            dataSourceUrl: '',
            dataSourceFields: {},

            //  EVENTS
            onChange: function(e) {
            },
            createEventHandler: '',
            editEventHandler: '',
            deleteEventHandler: ''
        }

        var settings = $.extend({}, defaults, options);

        // declare events


        // do work on element
        var kendoGridOptions = {

            //  CONFIGURATION
            allowCopy: settings.allowCopy,
            autoBind: settings.autoBind,
            filterable: settings.filterable,
            groupable: settings.groupable,
            height: settings.height,
            pageable: settings.pageable,
            scrollable: settings.scrollable,
            selectable: settings.selectable,
            sortable: settings.sortable,
            toolbar: [
                {
                    name: "create",
                    template: "<button class='k-button' onclick='" +
                        settings.createEventHandler +
                        "(event)'>افزودن</button>",
                    text: "افزودن"
                },
                {
                    name: "edit",
                    template: "<button class='k-button' onclick='" +
                        settings.editEventHandler +
                        "(event)'>ویرایش</button>",
                    text: "ویرایش"
                },
                {
                    name: "delete",
                    template: "<button class='k-button' onclick='" +
                        settings.deleteEventHandler +
                        "(event)'>حذف</button>",
                    text: "حذف"
                }
                ,
                {
                    name: "detail",
                    template: "<button class='k-button' onclick='" +
                        settings.detailEventHandler +
                        "(event)'>جزئیات</button>",
                    text: "جزئیات"
                }
            ],

            //  FIELDS
            columns: settings.columns,
            dataSource: new kendo.data.DataSource({
                transport: {
                    read: {
                        url: settings.dataSourceUrl,
                        data: {},
                        dataType: "json",
                        contentType: "application/json; charset=utf-8",
                        type: "GET"
                    },
                    parameterMap: function(options, type) {
                        return JSON.stringify(options);
                    }
                },
                schema: {
                    data: "Data",
                    total: "Total",
                    model: {
                        fields: settings.dataSourceFields
                    }
                },
                error: function(e) {
                    alert(e.errorThrown);
                },
                pageSize: 10,
                sort: {
                    field: "CreatedOn",
                    dir: "desc"
                },
                serverPaging: true,
                serverFiltering: true,
                serverSorting: true
            }),

            //  EVENTS
            change: function(e) {
                settings.onChange(e);
            }
        }

        $(self).kendoGrid(kendoGridOptions);

        // return element
        return elem;
    }
}(jQuery));

/**
 * 
 * @returns {} 
 */
var refreshGrid = function() {
    $(".k-pager-refresh.k-link").click();
}

/**
 * 
 * @returns {} 
 */
var multipelid = function () {
    var entityGrid = $("#EntitesGrid").data("kendoGrid");
    var rows = entityGrid.select();
    rows.each(function (index, row) {
        var selectedItem = entityGrid.dataItem(row);
        // selectedItem has EntityVersionId and the rest of your model
    });
}
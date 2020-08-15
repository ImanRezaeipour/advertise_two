; (function ($) {
    $.appAjax = function (options) {

        var defaults = {
            url: "",
            data: {},
            type: "GET",
            culture: true,
            complete: function(jqXhr, textStatus) {},
            error: function(jqXhr, textStatus, errorThrown) {},
            success: function(data, textStatus, jqXhr) {},
            beforeSend: function (jqXhr, configs) { }
        }

        var settings = $.extend({}, defaults, options);

        var ajaxOptions = {
            async: true,
            url: (settings.culture ? window.appCultureRoute : "") + settings.url,
            data: settings.data,
            type: settings.type,
            method: settings.type,
            dataType: "json",
            beforeSend: function (jqXhr, configs) {
                settings.beforeSend(jqXhr, configs);
            },
            cache: true,
            complete: function (jqXhr, textStatus) {
                switch (jqXhr.status) {
                case 200:
                    if (jqXhr.responseJSON.Success) {
                        settings.complete(jqXhr, textStatus);
                    }
                    else {
                        switch (jqXhr.responseJSON.ErrorCode) {
                        case 1008:
                            var errorMessages = JSON.parse(jqXhr.responseJSON.ErrorMessage);
                            $.each(errorMessages,function(index, value) {
                                    messageError(value, true);
                                });
                        default:
                        }
                    }

                default:
                }
            },
            contentType: "application/x-www-form-urlencoded; charset=UTF-8",
            error: function(jqXhr, textStatus, errorThrown) {
                settings.error(jqXhr, textStatus, errorThrown);
            },
            //timeout: 5000,
            global: true,
            headers: {},
            statusCode: {
                404: function() {
                    alert("Method Not Allowed.");
                }
            },
            success: function(data, textStatus, jqXhr) {
                settings.success(data, textStatus, jqXhr);
            }
        };

        $.ajax(ajaxOptions);
    }
}(jQuery))
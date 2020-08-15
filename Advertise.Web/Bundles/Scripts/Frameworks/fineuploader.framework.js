;(function($) {
    $.fn.appUploader = function(options) {
        var self = this;
        var elem = $(this);
        
        var defaults = {
            elementId: "files",
            modelId: "",
            initializeUrl: "",
            modelField: "",
            modelFieldIndex: "",
            isEditable: false,
            isMultiple: true,
            requestParams: {},
            fileType : "image" // image, video, doc
        }

        var settings = $.extend({}, defaults, options);

        function onCompleted(id, fileName, responseJSON) {
            if (responseJSON.success) {
                if (settings.isMultiple === false) {
                    if ($("#" + settings.elementId).find('input[data-index="0"]').length !== 0) {
                        $("#" + settings.elementId).find(':hidden').last().remove();
                    }
                }
                if ($("#" + settings.elementId).find('input[data-index="0"]').length === 0) {
                    $("#" + settings.elementId).append('<input type="hidden" name="' + settings.modelFieldIndex + '" value="0">');
                    $("#" + settings.elementId).append('<input type="hidden" data-index="0" name="' + settings.modelField.replace('*', '0') + '" id="' + id + '" value="' + responseJSON.result[0].Name + '">');
                }
                else {
                    var lastIndex = $("#" + settings.elementId).find(':hidden').last().data('index');
                    var index = parseInt(lastIndex) + 1;
                    $("#" + settings.elementId).append('<input type="hidden" name="' + settings.modelFieldIndex + '" value="' + index + '">');
                    $("#" + settings.elementId).append('<input type="hidden" data-index="' + index + '" name="' + settings.modelField.replace('*', index) + '" id="' + id + '" value="' + responseJSON.result[0].Name + '">');
                }
            }
        };

        function onDeleted(id, xhr, isError) {
            if (isError === false) {
                $("#" + settings.elementId).find('input[data-index="' + id + '"]').prev().remove();
                $("#" + settings.elementId).find('input[data-index="' + id + '"]').remove();
            }
        };

        function onStarted(response, success, xhrOrXdr) {
            $.each(response, function (key, value) {
                    $("#" + settings.elementId).append('<input type="hidden" name="' + settings.modelFieldIndex + '" value="' + key + '">');
                    $("#" + settings.elementId).append('<input type="hidden" data-index="' + key + '" name="' + settings.modelField.replace('*', key) + '" id="' + value.uuid + '" value="' + value.name + '">');
                });
        };

        var request = {
           params: settings.requestParams
        };

        var fineuploaderOptions = {
            request : request,
            element: document.getElementById(settings.elementId),
            template: 'qq-template-gallery',
            itemLimit: 1,
            multiple: settings.isMultiple,
            messages: {
                emptyError: "{file} is empty, please select files again without it.",
                maxHeightImageError: "Image is too tall.",
                maxWidthImageError: "Image is too wide.",
                minHeightImageError: "Image is not tall enough.",
                minWidthImageError: "Image is not wide enough.",
                minSizeError: "{file} is too small, minimum file size is {minSizeLimit}.",
                noFilesError: "No files to upload.",
                onLeave: "The files are being uploaded, if you leave now the upload will be canceled.",
                retryFailTooManyItemsError: "Retry failed - you have reached your file limit.",
                sizeError: "{file} is too large, maximum file size is {sizeLimit}.",
                tooManyItemsError: "Too many items ({netItems}) would be uploaded. Item limit is {itemLimit}.",
                typeError: "{file} has an invalid extension. Valid extension(s): {extensions}.",
                unsupportedBrowserIos8Safari: "Unrecoverable error - this browser does not permit file uploading of any kind due to serious bugs in iOS8 Safari. Please use iOS8 Chrome until Apple fixes these issues."
            },
            deleteFile: {
                enabled: true,
                endpoint: window.appCultureRoute + "/upload/remove-image"
            },
            callbacks: {
                onComplete: function (id, fileName, responseJSON) {
                    onCompleted(id, fileName, responseJSON);
                },
                onDeleteComplete: function(id, xhr, isError) {
                    onDeleted(id, xhr, isError);
                }
            }
        }


        if (settings.isEditable === true) {
            fineuploaderOptions.session = {
                endpoint: window.appCultureRoute + settings.initializeUrl,
                params: {
                     id: settings.modelId
                }
            };
            fineuploaderOptions.callbacks.onSessionRequestComplete = function (response, success, xhrOrXdr) {
                onStarted(response, success, xhrOrXdr);
            }
        }

        if (settings.fileType === "image") {
            fineuploaderOptions.validation = {
                allowExtensions: ["jpeg", 'jpg', 'png']
            }
            fineuploaderOptions.request.endpoint = window.appCultureRoute + "/upload/save-image";

        };

        if (settings.fileType === "catalog") {
            fineuploaderOptions.validation = {
                allowExtensions: ["jpeg", 'jpg', 'png']
            }
            fineuploaderOptions.request.endpoint = window.appCultureRoute + "/upload/save-imageCatalog";
        };

        if (settings.fileType === "doc") {
            fineuploaderOptions.validation = {
                allowExtensions: ["rar", "zip", "pdf"]
            }
            fineuploaderOptions.request.endpoint = window.appCultureRoute + "/upload/save-image";
        }

        if (settings.fileType === "video") {
            fineuploaderOptions.validation = {
                allowExtensions: [
                    "wmv", "mov", "qt", "ts", "3gp", "3gpp", "3g2", "3gp2", "mpg", "mpeg", "mp1",
                    "mp2", "m1v", "m1a", "m2a", "mpa", "mpv", "mpv2", "mpe", "mp4", "m4a", "m4p", "m4b", "m4r",
                    "m4v", "avi", "flv", "f4v", "f4p", "f4a", "f4b", "vob", "lsf", "lsx", "asf", "asr", "asx", "webm",
                    "mkv"
                ],
                minSizeLimit: 5,
                sizeLimit : 100000000
            }
            fineuploaderOptions.request.endpoint = window.appCultureRoute + "/upload/save-video";
        };

        var fineuploaderResult = new qq.FineUploader(fineuploaderOptions);

        return elem;
    }
}(jQuery))
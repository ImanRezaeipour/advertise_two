$.validator.setDefaults({ ignore: [] });
var marker;
var markers = [];
var map;
var isMapInitial = false;
function initMap() {

    google.maps.visualRefresh = true;
    var Iran = new google.maps.LatLng(35.714849, 51.3990455);
    var mapOptions = {
        zoom: 13,
        center: Iran,
        mapTypeId: google.maps.MapTypeId.G_NORMAL_MAP,
        minZoom: 10,
        streetViewControl: false,
        mapTypeControl: false,
        fullscreenControl: false
    };

    var markerLatLng = {
        lat: parseFloat($("#Address_latitude").val()),
        lng: parseFloat($("#Address_longitude").val())
    };

    map = new google.maps.Map(document.getElementById("map_canvas"), mapOptions);
    marker = new google.maps.Marker({
        map: map,
        position: markerLatLng,
        draggable: true,
        animation: google.maps.Animation.DROP,
    });

    markers.push(marker);

    map.setCenter(marker.getPosition());

    marker.addListener("dragend", function (event) {
        fillModelAddressFields(event.latLng);
    });
}

function fillModelAddressFields(latLng) {
    var lat = latLng.lat();
    var lng = latLng.lng();


    var $form = $("form");
    var $validator = $form.validate();

    var $errors = $("#Address_latitude").next(".field-validation-error").find("span");
    $errors.each(function () {
        $validator.settings.success($(this));
    });
}

function createGuid() {
    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
        var r = Math.random() * 16 | 0, v = c === 'x' ? r : (r & 0x3 | 0x8);
        return v.toString(16);
    });
}

function AddNewProductFeature() {
    var uuid = createGuid();
    var feature = "<div class='form-group'> \
                        <label class='col-sm-2 control-label' for='ProductFeatures_" + uuid + "__Title'>ویژگی</label> \
                        <div class='col-sm-8'> \
                            <input type='hidden' name='ProductFeatures[" + uuid + "].Id' value='' /> \
                            <input type='hidden' name='ProductFeatures.Index' value='" + uuid + "' /> \
                            <div class='input-group'> \
                                <input class='form-control' id='ProductFeatures_" + uuid + "__Title' name='ProductFeatures[" + uuid + "].Title' type='text' data-val='true' data-val-required='ویژگی را وارد نمایید' /> \
                                <span class='input-group-btn'> \
                                    <button class='btn btn-danger' onclick='RemoveFeature(this)'><i class='fa fa-trash-o'></i></button> \
                                </span> \
                            </div> \
                            <span class='field-validation-valid text-danger' data-valmsg-for='ProductFeatures[" + uuid + "].Title' data-valmsg-replace='true'></span> \
                        </div> \
                    </div>";

    $("#Features").append(feature);
    $('form').removeData("validator");
    $('form').removeData("unobtrusiveValidation");
    $.validator.unobtrusive.parse($('form'));
}

function RemoveFeature(element) {
    $(element).parent().parent().parent().parent().remove();
    $('form').removeData("validator");
    $('form').removeData("unobtrusiveValidation");
    $.validator.unobtrusive.parse($('form'));
    return false;
}

function AddProductImage(id, filename, size) {
    var content = "<div id='" + filename + "'>" +
                  "<input type='hidden' name='ProductImages.Index' value='" + id + "' />" +
                  "<input data-val='true' id='ProductImages_" + id + "__Title' name='ProductImages[" + id + "].Title' type='hidden' value='" + filename + "'>" +
                  "<input data-val='true' id='ProductImages_" + id + "__FileName' name='ProductImages[" + id + "].FileName' type='hidden' value='" + filename + "'>" +
                  "<input data-val='true' id='ProductImages_" + id + "__FileSize' name='ProductImages[" + id + "].FileSize' type='hidden' value='" + size + "'>"
    "</div>";
    $("#images").append(content);
}

function RemoveProductImageByName(id) {
    debugger;
    $("#" + id).remove();
}

$(function () {

    $('.colorpicker-component').colorpicker({ align: 'left' });

    kendo.culture("fa-IR");
    $("#imgPicker").click(function () {
        openCustomRoxy2();
    });


    //init TAB Validation
    new $.tabValidator({
        formElement: $($("form")[0]),
        tabBadges: $(".badge.badge-danger")
    });

    $('a[href="#Address"]').click(function (e) {
        if (!isMapInitial) {
            setTimeout(initMap, 500);
            isMapInitial = true;
        }
    });

    /*init fileUploader */
    var uploader = new qq.FineUploader({
        template: 'qq-template-s3',
        debug: !1,
        element: document.getElementById('file-uploader'),
        request: {
            method: "POST",
            endpoint: "/users/File/Upload/"
        },
        deleteFile: {
            enabled: true,
            method: "POST",
            endpoint: "/users/File/RemoveFake"
        },
        callbacks: {
            onDeleteComplete: function (id, xhr, isError) {
                if (xhr.status == 200) {
                    var result = jQuery.parseJSON(xhr.response);
                    if (result.success) {
                        RemoveProductImageByName(this.getUuid(id));
                    }
                }
            },
            onComplete: function (id, name, responseJSON, xhr) {
                if (xhr.status == 200) {
                    if (responseJSON.success) {
                        var fileName = responseJSON.fileName;
                        var newId = responseJSON.newId;
                        this.setName(id, fileName);
                        this.setUuid(id, newId);
                        var size = this.getSize(id);
                        AddProductImage(newId, fileName, size);
                    }
                }
            }
        },
        validation: {
            sizeLimit: 102400, // 50 kB = 50 * 1024 bytes, 102400
            itemLimit: 5,
            acceptFiles: "image/*",
            allowedExtensions: ["jpg", "jpeg", "gif", "png", "bmp"]
            //image.maxWidth
            //image.maxHeight
            //image.minHeight
            //image.minWidth
        },
        messages: {
            emptyError: "{file} is empty, please select files again without it.",
            maxHeightImageError: "Image is too tall.",
            maxWidthImageError: "Image is too wide.",
            minHeightImageError: "Image is not tall enough.",
            minWidthImageError: "Image is not wide enough.",
            minSizeError: "{file} is too small, minimum file size is {minSizeLimit}.",
            noFilesError: "حداقل یک تصویر انتخاب نمایید",
            onLeave: "The files are being uploaded, if you leave now the upload will be canceled.",
            retryFailTooManyItemsError: "Retry failed - you have reached your file limit.",
            sizeError: "حجم فایل ({file}) بیش از حد مجاز می باشد. حداکثر حجم مجاز {sizeLimit} می باشد",
            tooManyItemsError: "تعداد فایل بارگذاری شده بیش از حد مجاز می باشد. شما فقط قادر به بارگذاری {itemLimit} فایل می باشید",
            typeError: "فایل انتخاب شده {file} مجاز نمی باشد.فرمت های {extensions} جهت بارگذاری مجاز می باشد",
            unsupportedBrowserIos8Safari: "Unrecoverable error - this browser does not permit file uploading of any kind due to serious bugs in iOS8 Safari. Please use iOS8 Chrome until Apple fixes these issues."
        }

    });


    var initialFiles = [];
    jQuery.each($("input[name='ProductImages.Index']"), function (index, element) {
        var fileName = $("#ProductImages_" + index + "__FileName").val();
        var fileSize = $("#ProductImages_" + index + "__FileSize").val();
        obj = {};
        obj["name"] = fileName
        obj["uuid"] = fileName.split(".")[0];
        obj["size"] = fileSize;
        obj["thumbnailUrl"] = "/temp2/" + fileName;

        initialFiles.push(obj);
    });

    uploader.addInitialFiles(initialFiles);
});
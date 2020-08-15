var $cropAdsImage_OnLoad = function (elem) {
    var croppieOptions = {
        boundaryWidth: 360,
        boundaryHeight: 172.5,
        viewportWidth: 300,
        viewportHeight: 112.5
    }
    $(elem).appCrop(croppieOptions);
}

var $changeCropperImage_OnChange = function (elem) {
    var input = document.getElementById("CropUploadInput");
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            var croppieOptions = {
                onBindOptions: {
                    url: e.target.result
                }
            };
            $("#CropperContainer").appCrop(croppieOptions);
        }
        reader.readAsDataURL(input.files[0]);
    }
}

var $showPreviewCropped_OnClick = function(elem) {
    var croppieOptions = {
        onResultOptions: {
            type: 'canvas',
            format: 'jpeg',
            quality: '1',
            size: {
                width: 960,
                height: 360
            }
        },
        onResultFunction: function(imgSrc) {
            $('#CroppedImage').attr("src", imgSrc);
        }
    };
    $("#CropperContainer").appCrop(croppieOptions);
}


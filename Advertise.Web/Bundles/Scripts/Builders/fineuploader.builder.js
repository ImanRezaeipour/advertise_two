/**
 *
 * @param {} elem
 * @returns {}
 */
var $uploaderCompanyImage_OnLoad= function (elem) {
    var actionParam = $(elem).data("param");
    var isEdit = false;
    if (actionParam != null)
        isEdit = true;
    var uploaderOptions = {
        elementId: $(elem).attr('name'),
        modelId: $("#Id").val(),
        initializeUrl: "/CompanyImage/GetFilesAjax",
        modelField: "CompanyImageFile[*].FileName",
        modelFieldIndex: "CompanyImageFile.Index",
        isEditable: isEdit,
        requestParams: {
             imageType: "CompanyImages"
        }
    }

    $(elem).appUploader(uploaderOptions);
}

/**
 * 
 * @param {} elem 
 * @param {} isEdit 
 * @returns {} 
 */
var $uploaderCompanyAttachment_OnLoad = function (elem) {
    var actionParam = $(elem).data("param");
    var isEdit = false;
    if (actionParam != null)
        isEdit = true;
    var uploaderOptions = {
        elementId: $(elem).attr('name'),
        modelId: $("#Id").val(),
        initializeUrl: "/CompanyAttachment/GetFilesAjax",
        modelField: "CompanyAttachmentFile[*].FileName",
        modelFieldIndex: "CompanyAttachmentFile.Index",
        isEditable: isEdit,
        requestParams: {
             imageType: "Attachment"
        },
        fileType: "doc"

    }

    $(elem).appUploader(uploaderOptions);
}

/**
 * 
 * @param {} elem 
 * @param {} isEdit 
 * @returns {} 
 */
var $uploaderCompanyVideo_OnLoad = function (elem) {
    var actionParam = $(elem).data("param");
    var isEdit = false;
    if (actionParam != null)
        isEdit = true;
    var uploaderOptions = {
        elementId: $(elem).attr('name'),
        modelId: $("#Id").val(),
        initializeUrl: "/CompanyVideo/GetFilesAjax",
        modelField: "CompanyVideoFile[*].FileName",
        modelFieldIndex: "CompanyVideoFile.Index",
        isEditable: isEdit,
        requestParams: {
             imageType: "Nan"
        },
        fileType :"video"
    }

    $(elem).appUploader(uploaderOptions);
}

/**
 * 
 * @param {} elem 
 * @returns {} 
 */
var $uploaderCategory_OnLoad = function (elem) {
    var actionParam = $(elem).data("param");
    var isEdit = false;
    if (actionParam != null)
        isEdit = true;
    var uploaderOptions = {
        elementId: $(elem).attr('name'),
        modelId: $("#Id").val(),
        initializeUrl: "/category/GetFileAjax",
        modelField: "ImageFileName",
        modelFieldIndex: "ImageFileName.Index",
        isEditable: isEdit,
        isMultiple: false,
        requestParams: {
             imageType: "Nan"
        }
    }

    $(elem).appUploader(uploaderOptions);
}

/**
 * 
 * @param {} elem 
 * @returns {} 
 */
var $uploaderBanner_OnLoad = function (elem) {
    var actionParam = $(elem).data("param");
    var isEdit = false;
    if (actionParam != null)
        isEdit = true;
    var uploaderOptions = {
        elementId: $(elem).attr('name'),
        modelId: $("#Id").val(),
        initializeUrl: "/ads/GetFileAjax",
        modelField: "ImageFileName",
        modelFieldIndex: "ImageFileName.Index",
        isEditable: isEdit,
        isMultiple: false,
        requestParams: {
             imageType: "Nan"
        }
    }

    $(elem).appUploader(uploaderOptions);
}

var $uploaderCompanyBalance_OnLoad = function (elem) {
    var actionParam = $(elem).data("param");
    var isEdit = false;
    if (actionParam != null)
        isEdit = true;
    var uploaderOptions = {
        elementId: $(elem).attr('name'),
        modelId: $("#Id").val(),
        initializeUrl: "/CompanyBalance/GetFileAjax",
        modelField: "AttachmentFile",
        modelFieldIndex: "AttachmentFile.Index",
        isEditable: isEdit,
        isMultiple: false,
        requestParams: {
             imageType: "Nan"
        }
    }

    $(elem).appUploader(uploaderOptions);
}

/**
 *
 * @param {} elem
 * @returns {}
 */
var $uploaderCompany_OnLoad = function (elem) {
    var actionParam = $(elem).data("param");
    var isEdit = false;
    if (actionParam != null)
        isEdit = true;
    var uploaderOptions = {
        elementId: $(elem).attr('name'),
        modelId: $("#Id").val(),
        initializeUrl: "/Company/GetFileAjax",
        modelField: "LogoFileName",
        modelFieldIndex: "LogoFileName.Index",
        isEditable: isEdit,
        isMultiple: false,
        requestParams: {
             imageType: "LogoFileName"
        }
    }

    $(elem).appUploader(uploaderOptions);
}



/**
 *
 * @param {} elem
 * @returns {}
 */
var $uploaderBusinessLicense_OnLoad = function (elem) {
    var actionParam = $(elem).data("param");
    var isEdit = false;
    if (actionParam != null)
        isEdit = true;
    var uploaderOptions = {
        elementId: $(elem).attr('name'),
        modelId: $("#Id").val(),
        initializeUrl: "/CompanyOfficial/GetFileBusinessLicenseFileNameAjax",
        modelField: "BusinessLicenseFileName",
        modelFieldIndex: "BusinessLicenseFileName.Index",
        isEditable: isEdit,
        isMultiple: false,
        requestParams: {
            imageType: "nan"
        }
    }

    $(elem).appUploader(uploaderOptions);
}


/**
 *
 * @param {} elem
 * @returns {}
 */
var $uploaderNationalCard_OnLoad = function (elem) {
    var actionParam = $(elem).data("param");
    var isEdit = false;
    if (actionParam != null)
        isEdit = true;
    var uploaderOptions = {
        elementId: $(elem).attr('name'),
        modelId: $("#Id").val(),
        initializeUrl: "/CompanyOfficial/GetFileNationalCardFileNameAjax",
        modelField: "NationalCardFileName",
        modelFieldIndex: "NationalCardFileName.Index",
        isEditable: isEdit,
        isMultiple: false,
        requestParams: {
            imageType: "nan"
        }
    }

    $(elem).appUploader(uploaderOptions);
}


/**
 *
 * @param {} elem
 * @returns {}
 */
var $uploaderOfficialNewspaperAddress_OnLoad = function (elem) {
    var actionParam = $(elem).data("param");
    var isEdit = false;
    if (actionParam != null)
        isEdit = true;
    var uploaderOptions = {
        elementId: $(elem).attr('name'),
        modelId: $("#Id").val(),
        initializeUrl: "/CompanyOfficial/GetFileOfficialNewspaperAddressAjax",
        modelField: "OfficialNewspaperAddress",
        modelFieldIndex: "OfficialNewspaperAddress.Index",
        isEditable: isEdit,
        isMultiple: false,
        requestParams: {
            imageType: "nan"
        }
    }

    $(elem).appUploader(uploaderOptions);
}

/**
 *
 * @param {} elem
 * @returns {}
 */
var $uploaderCompanyCover_OnLoad = function (elem) {
    var actionParam = $(elem).data("param");
    var isEdit = false;
    if (actionParam != null)
        isEdit = true;
    var uploaderOptions = {
        elementId: $(elem).attr('name'),
        modelId: $("#Id").val(),
        initializeUrl: "/Company/GetFileCoverAjax",
        modelField: "CoverFileName",
        modelFieldIndex: "CoverFileName.Index",
        isEditable: isEdit,
        isMultiple: false,
        requestParams: {
             imageType: "CompanyCoverFileName"
        }
    }

    $(elem).appUploader(uploaderOptions);
}

/**
 *
 * @param {} elem
 * @returns {}
 */
var $uploaderProductImages_OnLoad = function (elem) {
    var actionParam = $(elem).data("param");
    var isEdit = false;
    if (actionParam != null)
        isEdit = true;
    var uploaderOptions = {
        elementId: $(elem).attr('name'),
        modelId: $("#Id").val(),
        initializeUrl: "/Product/GetFilesAjax",
        modelField: "Images[*].FileName",
        modelFieldIndex: "Images.Index",
        isEditable: isEdit,
        requestParams: {
             imageType: "ProductImage"
        }
    }

    $(elem).appUploader(uploaderOptions);
}

/**
 *
 * @param {} elem
 * @returns {}
 */
var $uploaderProductImage_OnLoad = function (elem) {
    var actionParam = $(elem).data("param");
    var isEdit = false;
    if (actionParam != null)
        isEdit = true;

    var uploaderOptions = {
        elementId: $(elem).attr('name'),
        modelId: $("#Id").val(),
        initializeUrl: "/Product/GetFileAjax",
        modelField: "ImageFileName",
        modelFieldIndex: "ImageFileName.Index",
        isEditable: isEdit,
        isMultiple: false,
        requestParams: {
             imageType: "ProductImage"
        }

    }

    $(elem).appUploader(uploaderOptions);
}

/**
 * 
 * @param {} elem 
 * @returns {} 
 */
var $uploaderTag_OnLoad = function (elem) {
    var actionParam = $(elem).data("param");
    var isEdit = false;
    if (actionParam != null)
        isEdit = true;
    var uploaderOptions = {
        elementId: $(elem).attr('name'),
        modelId: $("#Id").val(),
        initializeUrl: "/Tag/GetFilesAjax",
        modelField: "LogoFileName",
        modelFieldIndex: "LogoFileName.Index",
        isEditable: isEdit,
        requestParams: {
             imageType: "LogoFileName"
        }
    }

    $(elem).appUploader(uploaderOptions);
}

/**
 * 
 * @param {} elem 
 * @returns {} 
 */
var $uploaderUser_OnLoad = function (elem) {

    var actionParam = $(elem).data("param");
    var isEdit = false;
    if (actionParam != null)
        isEdit = true;
    var uploaderOptions = {
        elementId: $(elem).attr('name'),
        modelId: $("#Id").val(),
        initializeUrl: "/user/GetFileAjax",
        modelField: "AvatarFileName",
        modelFieldIndex: "AvatarFileName.Index",
        isEditable: isEdit,
        isMultiple: false,
        requestParams: {
             imageType: "LogoFileName"
        }
    }

    $(elem).appUploader(uploaderOptions);
}

/**
 *
 * @param {} elem
 * @returns {}
 */
var $uploaderCatalogImages_OnLoad = function (elem) {
    var actionParam = $(elem).data("param");
    var isEdit = false;
    if (actionParam != null)
        isEdit = true;

    var uploaderOptions = {
        elementId: $(elem).attr('name'),
        modelId: $("#Id").val(),
        initializeUrl: "/Catalog/GetFilesAjax",
        modelField: "Images[*].FileName",
        modelFieldIndex: "Images.Index",
        isEditable: isEdit,
        requestParams: {
            imageType: "ProductImages"
        },
        fileType: "catalog"
    }

    $(elem).appUploader(uploaderOptions);
}

/**
 *
 * @param {} elem
 * @returns {}
 */
var $uploaderCatalogImage_OnLoad = function (elem) {
    var actionParam = $(elem).data("param");
    var isEdit = false;
    if (actionParam != null)
        isEdit = true;

    var uploaderOptions = {
        elementId: $(elem).attr('name'),
        modelId: $("#Id").val(),
        initializeUrl: "/Catalog/GetFileAjax",
        modelField: "ImageFileName",
        modelFieldIndex: "ImageFileName.Index",
        isEditable: isEdit,
        isMultiple: false,
        requestParams: {
            imageType: "ProductImage"
        },
        fileType: "catalog"
    }

    $(elem).appUploader(uploaderOptions);
}

var $uploaderCompanySlide_OnLoad = function (elem) {
    var uploaderOptions = {
        elementId: $(elem).attr('name'),
        modelId: $("#Id").val(),
        initializeUrl: "/CompanySlide/GetFileAjax",
        modelField: "ImageFileName",
        modelFieldIndex: "ImageFileName.Index",
        isEditable: $(elem).data("param") === "edit" ? true : false,
        isMultiple: false,
        requestParams: {
            imageType: "Nan"
        }
    }
    
    $(elem).appUploader(uploaderOptions);
}
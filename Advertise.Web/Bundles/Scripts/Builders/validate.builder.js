/**
 *
 * @param {} elem
 * @returns {}
 */
var $validateUser_OnLoad = function ($elem) {
    var $validateOptions = {
        onsubmit: true,
        rules: {
            "NationalCode": {
                digits: true,
                minlength: 10,
                maxlength: 10
            },
            "UserName": {
                required: true,
                regex: "^([A-Za-z]{1}[A-Za-z0-9\-]{1,}[A-Za-z0-9]{1,})$",
                minlength: 6,
                maxlength: 50
            },
            "HomeNumber": {
                digits: true,
                minlength: 11,
                maxlength: 11
            },
            "PhoneNumber": {
                digits: true,
                minlength: 11,
                maxlength: 11
            },
            "Address.City.ParentId": {
                required: true
            },
            "Address.City.Id": {
                required: true
            },
            "PostalCode": {
                digits: true,
                minlength: 10,
                maxlength: 10
            },
        },
        messages: {
            "NationalCode": {
                digits: "عدد وارد شود",
                minlength: "کمتر از 10 کاراکتر است",
                maxlength: "بیشتر از 10 کاراکتر است"
            },
            "UserName":
            {
                required: "نام کاربری را وارد کنید",
                regex: "شما می‌بایست تنها از حروف الفبای انگلیسی، خط‌فاصله و اعداد در نام دامنه استفاده نمایید که این نام الزاما با حروف الفبای انگلیسی آغاز می‌شود و حرف آخر نمی‌تواند خط‌فاصله باشد",
                minlength: "کمتر از 6 کاراکتر است",
                maxlength: "بیشتر از 50 کاراکتر است"
            },
            "HomeNumber": {
                digits: "عدد وارد شود",
                minlength: "کمتر از 11 کاراکتر است",
                maxlength: "بیشتر از 11 کاراکتر است"
            },
            "PhoneNumber": {
                digits: "عدد وارد شود",
                minlength: "کمتر از 11 کاراکتر است",
                maxlength: "بیشتر از 11 کاراکتر است"
            },
            "Address.City.ParentId": {
                required: "لطفا استان محل سکونت خود را تعیین نمایید"
            },
            "Address.City.Id": {
                required: "لطفا شهر محل سکونت خود را تعیین نمایید"
            },
            "PostalCode": {
                digits: "عدد وارد شود",
                minlength: "کمتر از 10 رقم است",
                maxlength: "بیشتر از 10 رقم است"
            },
        }
    }

    $($elem).appValidate($validateOptions);
}

var $validateBag_OnLoad = function ($elem) {
    var $validateOptions = {
        onsubmit: true,
        rules: {
            "province": {
                required: true
            },
            "city": {
                required: true
            },
            "address": {
                required: true
            },
            "firstName": {
                required: true
            },
            "lastName": {
                required: true
            },
            "NationalCode": {
                required: true,
                digits: true,
                minlength: 10,
                maxlength: 10
            },
            "PostalCode": {
                required: true,
                digits: true,
                minlength: 10,
                maxlength: 10
            },
            "PhoneNumber": {
                required: true,
                digits: true,
                minlength: 11,
                maxlength: 11
            },
            "MobileNumber": {
                required: true,
                digits: true,
                minlength: 11,
                maxlength: 11
            },
        },
        messages: {
            "province": "لطفا استان محل سکونت خود را تعیین نمایید",

            "city": "لطفا شهر خود را مشخص نمایید",
            "firstName": "لطفا نام خود را مشخص نمایید",
            "lastName": "لطفا نام خانوادگی خود را مشخص نمایید",
            "address": "لطفا نشانی خود را وارد نمایید",
            "PostalCode": {
                required: "لطفا کد پستی خود را وارد نمایید",
                digits: "عدد وارد شود",
                minlength: "کمتر از 10 کاراکتر است",
                maxlength: "بیشتر از 10 کاراکتر است"
            },
            "NationalCode": {
                required: "کد ملی را وارد کنید",
                digits: "عدد وارد شود",
                minlength: "کمتر از 10 کاراکتر است",
                maxlength: "بیشتر از 10 کاراکتر است"
            },
            "PhoneNumber": {
                required: "شماره ثابت را وارد کنید",
                digits: "عدد وارد شود",
                minlength: "کمتر از 11 کاراکتر است",
                maxlength: "بیشتر از 11 کاراکتر است"
            },
            "MobileNumber": {
                required: "شماره همراه را وارد کنید",
                digits: "عدد وارد شود",
                minlength: "کمتر از 11 کاراکتر است",
                maxlength: "بیشتر از 11 کاراکتر است"
            },
        }
    }

    $($elem).appValidate($validateOptions);
}

var $validateAdsOption_OnLoad = function ($elem) {
    var $validateOptions = {
        onsubmit: true,
        rules: {
            "Title": { required: true },
            "Order": { required: true, digits: true },
            "Price": { required: true, digits: true },
            "Type": { required: true },
            "PositionType": { required: true }
        },
        messages: {
            "Title": "عنوان جایگاه قرارگیری را وارد کنید",
            "Order": {
                required: "الویت را وارد کنید",
                digits: "عدد وارد شود"
            },
            "Price": {
                required: "مبلغ را وارد کنید",
                digits: "عدد وارد شود"
            },
            "Type": "نوع تبلیغ را وارد کنید",
            "PositionType": "مکان نمایش را وارد کنید"
        }
    }
    $($elem).appValidate($validateOptions);
}

var $validateAds_OnLoad = function ($elem) {
    var $validateOptions = {
        onsubmit: true,
        rules: {
            "AdsOptionType": { required: true },
            "AdsOptionPositionType": { required: true },
            "AdsOptionId": { required: true },
            "Title": { required: true },
            "Order": { digits: true },
            "DurationType": { required: true }
        },
        messages: {
            "Title": "عنوان را وارد کنید",
            "AdsOptionType": "نوع تبلیغ را وارد کنید",
            "AdsOptionPositionType": "مکان نمایش را وارد کنید",
            "AdsOptionId": "یک گزینه را انتخاب کنید",
            "Order":{digits:"عدد وارد شود"} ,
            "DurationType": "یک روز را انتخاب کنید"
        }
    }
    $($elem).appValidate($validateOptions);
}

var $validateCategory_OnLoad = function ($elem) {
    var $validateOptions = {
        onsubmit: true,
        rules: {
            "Title": { required: true },
            "ParentId": { required: true },
            "Description": {maxlength: 1000000},
            "Order": { required: true, digits: true },
           "MetaTitle": { required: true },
            "Alias": { required: true, regex: "^([A-Za-z]{1}[A-Za-z\-]{1,}[A-Za-z]{1,})$" },
            "CategoryOption": { required: true }
        },
        messages: {
            "Title": "عنوان را وارد کنید",
            "ParentId": "لطفا یک دسته را انتخاب نمایید",
            "Description": "حداکثر 1000000 کارکتر",
            "Order": {
                required: "لطفا عدد اولویت را وارد نمایید",
                digits: "عدد وارد شود"
            },
            "MetaTitle": "لطفا عنوان مستعار را وارد نمایید",
            "CategoryOption": "لطفا گروه دسته‌بندی را مشخص کنید",
            "Alias": {
                required: "لطفا Url مستعار را وارد نمایید",
                regex: "شما می‌بایست تنها از حروف الفبای انگلیسی و خط‌فاصله استفاده نمایید که این نام الزاماً با حروف الفبای انگلیسی آغاز می‌شود و حرف آخر نمی‌تواند خط ‌فاصله باشد"
            }
        }
    }
    $($elem).appValidate($validateOptions);
}

var $validateCategoryReview_OnLoad = function ($elem) {
    var $validateOptions = {
        onsubmit: true,
        rules: {
            "Title": {
                required: true,
                minlength: 2,
                maxlength: 30
            },
            "CategoryId": { required: true },
            "Body": { required: true }
        },
        messages: {
            "Title": {
                required: "عنوان را وارد کنید",
                minlength: "کمتر از 2 رقم است",
                maxlength: "بیشتر از 30 رقم است"
            },
            "CategoryId": "لطفا یک دسته را انتخاب نمایید",
            "Body": "لطفا نقد و بررسی خود را بنویسید"
        }
    }
    $($elem).appValidate($validateOptions);
}

var $validateCompany_OnLoad = function ($elem) {
    var $validateOptions = {
        onsubmit: true,
        rules: {
            "Title": {
                required: true,
                minlength: 2,
                maxlength: 50
            },
            "Alias": {
                required: true,
                minlength: 6,
                maxlength: 50,
                regex: "^([A-Za-z]{1}[A-Za-z0-9\-]{1,}[A-Za-z0-9]{1,})$"
            },
            "WebSite": { url: true },
            "EmployeeCount": { digits: true },
            "PhoneNumber": {
                digits: true,
                minlength: 11,
                maxlength: 11
            },
            "Email": { email: true },
            "Clearing": { required: true },
            "CategoryId": { required: true },
            "Description": { maxlength: 1000000 },
            "ProvinceId": { required: true },
            "CityId": { required: true },
            "MobileNumber": {
                digits: true,
                minlength: 11,
                maxlength: 11
            },
            "Address.PostalCode": {
                digits: true,
                minlength: 10,
                maxlength: 10
            }
        },
        messages: {
            "Title": {
                required: "عنوان را وارد کنید",
                minlength: "کمتر از 2 کاراکتر است",
                maxlength: "بیشتر از 50 کاراکتر است"
            },
            "Alias": {
                required: "لطفا یک نام دامنه انتخاب نمایید",
                minlength: "کمتر از 6 کاراکتر است",
                maxlength: "بیشتر از 50 کاراکتر است",
                regex: "شما می‌بایست تنها از حروف الفبای انگلیسی، خط‌فاصله و اعداد در نام دامنه استفاده نمایید که این نام الزاما با حروف الفبای انگلیسی آغاز می‌شود و حرف آخر نمی‌تواند خط‌فاصله باشد"
            },
            "Email": "ایمیل شما معتبر نمی باشد",
            "PhoneNumber": {
                digits: "عدد وارد شود",
                minlength: "کمتر از 11 رقم است",
                maxlength: "بیشتر از 11 رقم است"
            },
            "MobileNumber": {
                digits: "عدد وارد شود",
                minlength: "کمتر از 11 رقم است",
                maxlength: "بیشتر از 11 رقم است"
            },
            "WebSite": "لطفا آدرس وب‌سایت معتبر وارد نمایید",
            "EmployeeCount": "عدد وارد شود",
            "Clearing": "روش تسویه حساب را انتخاب کنید",
            "CategoryId": "لطفا یک دسته را انتخاب نمایید",
            "Description": "توضیحات بیش از حد مجاز است",
            "ProvinceId": "لطفا استان محل سکونت خود را تعیین نمایید.",
            "Address.PostalCode": {
                digits: "عدد وارد شود",
                minlength: "کمتر از 10 رقم است",
                maxlength: "بیشتر از 10 رقم است"
            },
            "CityId": "لطفا شهر محل سکونت خود را تعیین نمایید."
        }
    }
    $($elem).appValidate($validateOptions);
}

var $validateCompanyAttachment_OnLoad = function ($elem) {
    var $validateOptions = {
        onsubmit: true,
        rules: {
            "Title": {
                required: true,
                minlength: 2,
                maxlength: 30
            },
            "Order": { digits: true }
        },
        messages: {
            "Title": {
                required: "عنوان را وارد کنید",
                minlength: "کمتر از 2 رقم است",
                maxlength: "بیشتر از 30 رقم است"
            },
            "Order": "عدد وارد کنید"
        }
    }
    $($elem).appValidate($validateOptions);
}

var $validateCompanyVideo_OnLoad = function ($elem) {
    var $validateOptions = {
        onsubmit: true,
        rules: {
            "Title": {
                required: true,
                minlength: 2,
                maxlength: 30
            },
            "Order": { digits: true }
        },
        messages: {
            "Title": {
                required: "عنوان را وارد کنید",
                minlength: "کمتر از 2 رقم است",
                maxlength: "بیشتر از 30 رقم است"
            },
            "Order": "عدد وارد کنید"
        }
    }
    $($elem).appValidate($validateOptions);
}

var $validateCompanyImage_OnLoad = function ($elem) {
    var $validateOptions = {
        onsubmit: true,
        rules: {
            "Title": {
                required: true,
                minlength: 2,
                maxlength: 30
            },
            "Order": { digits: true }
        },
        messages: {
            "Title": {
                required: "عنوان را وارد کنید",
                minlength: "کمتر از 2 رقم است",
                maxlength: "بیشتر از 30 رقم است"
            },
            "Order": "عدد وارد کنید"
        }
    }
    $($elem).appValidate($validateOptions);
}

var $validateCompanyReview_OnLoad = function ($elem) {
    var $validateOptions = {
        onsubmit: true,
        rules: {
            "Title": {
                required: true,
                minlength: 2,
                maxlength: 30
            },
            "CompanyId": { required: true },
            "Body": { required: true }
        },
        messages: {
            "Title": {
                required: "عنوان را وارد کنید",
                minlength: "کمتر از 2 رقم است",
                maxlength: "بیشتر از 30 رقم است"
            },
            "CompanyId": "لطفا شرکت را انتخاب نمایید",
            "Body": "لطفا نقد و بررسی خود را بنویسید"
        }
    }
    $($elem).appValidate($validateOptions);
}

var $validateCompanyBalance_OnLoad = function ($elem) {
    var $validateOptions = {
        onsubmit: true,
        rules: {
            "SettingTransactionId": { required: true },
            "CompanyId": { required: true },
            "IssueTracking": { required: true, digits: true },
            "DocumentNumber": { required: true, digits: true },
            "Depositor": { required: true },
            "Amount": { required: true, digits: true },
            "TransactionedOn": { required: true }
        },
        messages: {
            "SettingTransactionId": { required: "شماره حساب را انتخاب کنید" },
            "CompanyId": { required: "شرکت را انتخاب کنید" },
            "IssueTracking": {
                required: "شماره پیگیری را وارد کنید",
                digits: "عدد وارد شود"
            },
            "DocumentNumber": {
                required: "شماره سند را وارد کنید",
                digits: "عدد وارد شود"
            },
            "Depositor": { required: "نام واریز کننده را وارد کنید" },
            "Amount": {
                required: "مبلغ تراکنش را وارد کنید",
                digits: "عدد وارد شود"
            },
            "TransactionedOn": "تاریخ تراکنش را وارد کنید"
        }
    }
    $($elem).appValidate($validateOptions);
}

var $validateComplaint_OnLoad = function ($elem) {
    var $validateOptions = {
        onsubmit: true,
        rules: {
            "Title": {
                required: true,
                minlength: 2,
                maxlength: 30
            },
            "Body": {
                required: true,
                minlength: 10,
                maxlength: 200
            }
        },
        messages: {
            "Title": {
                required: "عنوان را وارد کنید",
                minlength: "کمتر از 2 کاراکتر است",
                maxlength: "بیشتر از 30 کاراکتر است"
            },
            "Body": {
                required: "متن را وارد کنید",
                minlength: "کمتر از 10 کاراکتر است",
                maxlength: "بیشتر از 200 کاراکتر است"
            }
        }
    }
    $($elem).appValidate($validateOptions);
}

var $validateNewsletter_OnLoad = function ($elem) {
    var $validateOptions = {
        onsubmit: true,
        rules: {
            "Email": {
                required: true,
                email: true
            },
            "Meet": {
                required: true
            }
        },
        messages: {
            "Email": {
                required: "ایمیل را وارد کنید",
                email : "فرمت ایمل نادرست است"
            },
            "Meet": {
                required: "نحوه آشنایی را وارد کنید"
            }
        }
    }

    $($elem).appValidate($validateOptions);
}

var $validateNews_OnLoad = function ($elem) {
    var $validateOptions = {
        onsubmit: true,
        rules: {
            "Title": {
                required: true,
                minlength: 2,
                maxlength: 30
            },
            "Body": {
                required: true
            }
        },
        messages: {
            "Title": {
                required: "عنوان را وارد کنید",
                minlength: "کمتر از 2 کاراکتر است",
                maxlength: "بیشتر از 30 کاراکتر است"
            },
            "Body": {
                required: "متن را وارد کنید"
            }
        }
    }

    $($elem).appValidate($validateOptions);
}

var $validatePermission_OnLoad = function ($elem) {
    var $validateOptions = {
        onsubmit: true,
        rules: {
            "ParentId": {
                required: true
            }
        },
        messages: {
            "ParentId": {
                required: "لطفا یک دسته را انتخاب نمایید"
            }
        }
    }

    $($elem).appValidate($validateOptions);
}

var $validatePlan_OnLoad = function ($elem) {
    var $validateOptions = {
        onsubmit: true,
        rules: {
            "Title": {
                required: true,
                minlength: 2,
                maxlength: 30
            },
            "Code": {
                required: true,
                minlength: 2,
                maxlength: 30
            },
            "Price": {
                required: true,
                digits: true
            },
            "PreviousePrice": {
                required: true,
                digits: true
            },
            "PlanDuration": {
                required: true
            },
            "RoleId": {
                required: true
            },
            "Color": {
                required: true
            }
        },
        messages: {
            "Title": {
                required: "عنوان را وارد کنید",
                minlength: "کمتر از 2 کاراکتر است",
                maxlength: "بیشتر از 30 کاراکتر است"
            },
            "Code": {
                required: "کد پلن را وارد کنید",
                minlength: "کمتر از 2 کاراکتر است",
                maxlength: "بیشتر از 30 کاراکتر است"
            },
            "Price": {
                required: "مبلغ را وارد کنید",
                digits: "عدد وارد شود"
            },
            "PreviousePrice": {
                required: "مبلغ قبلی را وارد کنید",
                digits: "عدد وارد شود"
            },
            "PlanDuration": {
                required: "مدت زمان را وارد کنید"
            },
            "RoleId": {
                required: "نقش را وارد کنید"
            },
            "Color": {
                required: "رنگ را وارد کنید"
            }
        }
    }

    $($elem).appValidate($validateOptions);
}

var $validatePlanDiscount_OnLoad = function ($elem) {
    var $validateOptions = {
        onsubmit: true,
        rules: {
            "Percent": {
                required: true,
                digits: true
            },
            "Max": {
                required: true,
                digits: true
            },
            "Count": {
                required: true,
                digits: true
            },
            "Code": {
                required: true,
                minlength: 6,
                maxlength: 10
            }
        },
        messages: {
            "Percent": {
                required: "درصد تخفیف را وارد کنید",
                digits: "عدد وارد شود"
            },
            "Max": {
                required: "حداکثر مبلغ تخفیف را وارد کنید",
                digits: "عدد وارد شود"
            },
            "Count": {
                required: "تعداد تخفیف را وارد کنید",
                digits: "عدد وارد شود"
            },
            "Code": {
                required: "کد تخفیف را وارد کنید",
                minlength: "کمتر از 6 کاراکتر است",
                maxlength: "بیشتر از 10 کاراکتر است"
            }
        }
    }

    $($elem).appValidate($validateOptions);
}

var $validatePlanPayment_OnLoad = function ($elem) {
    var $validateOptions = {
        onsubmit: true,
        rules: {
            "Pay": {
                required: true
            },
            "Code": {
                required: true
            }
        },
        messages: {
            "Pay": {
                required: "لطفا یک درگاه پرداخت را انتخاب نمایید"
            },
            "Code": {
                required: "لطفا یک طرح را انتخاب نمایید"
            }
        }
    }

    $($elem).appValidate($validateOptions);
}

var $validateProduct_OnLoad = function ($elem) {
    var $validateOptions = {
        onsubmit: true,
        rules: {
            "title": {
                required: true,
                minlength: 2,
                maxlength: 50
            },
            "PreviousPrice": {
                digits: true
            },
            "Price": {
                required: true,
                digits: true
            },
            "CategoryId": {
                required: true
            },
            "sell": {
                required: true
            }
        },
        messages: {
            "title": {
                required: "عنوان را وارد کنید",
                minlength: "کمتر از 2 کاراکتر است",
                maxlength: "بیشتر از 50 کاراکتر است"
            },
            "PreviousPrice": {
                digits: "عدد وارد شود"
            },
            "Price": {
                digits: "عدد وارد شود",
                required: "قیمت وارد شود"
            },
            "CategoryId": {
                digits: "یک دسته را انتخاب کنید"
            },
            "sell": {
                digits: "لطفا وضعیت را انتخاب نمایید"
            }
        }
    }

    $($elem).appValidate($validateOptions);
}

var $validateProductReview_OnLoad = function ($elem) {
    var $validateOptions = {
        onsubmit: true,
        rules: {
            "ProductId": { required: true },
            "Body": { required: true }
        },
        messages: {
            "CompanyId": "لطفا محصول را انتخاب نمایید",
            "Body": "لطفا نقد و بررسی خود را بنویسید"
        }
    }
    $($elem).appValidate($validateOptions);
}

var $validateReceipt_OnLoad = function ($elem) {
    var $validateOptions = {
        onsubmit: true,
        rules: {
            "Address.City.ParentId": { required: true },
            "FirstName": { required: true },
            "LastName": { required: true },
            "NationalCode": {
                required: true,
                digits: true,
                minlength: 10,
                maxlength: 10
            },
            "HomeNumber": {
                required: true,
                digits: true,
                minlength: 11,
                maxlength: 11
            },
            "PhoneNumber": {
                required: true,
                digits: true,
                minlength: 11,
                maxlength: 11
            },
            "Address.PostalCode": {
                required: true,
                digits: true,
                minlength: 10,
                maxlength: 10
            },
            "Address.Extra": { required: true },
            "Payment": { required: true },
            "Address.City.Id": { required: true }
        },
        messages: {
            "Address.City.ParentId": "لطفا استان محل سکونت خود را تعیین نمایید",
            "FirstName": "نام خود را وارد کنید",
            "LastName": "نام خانوادگی خود را وارد کنید",
            "NationalCode": {
                required: "کد ملی را وارد کنید",
                digits: "عدد وارد شود",
                minlength: "کمتر از 10 رقم است",
                maxlength: "بیشتر از 10 رقم است"
            },
            "HomeNumber": {
                required: "شماره تلفن ثابت را وارد کنید",
                digits: "عدد وارد شود",
                minlength: "کمتر از 11 رقم است",
                maxlength: "بیشتر از 11 رقم است"
            },
            "PhoneNumber": {
                required: "شماره همراه را وارد کنید",
                digits: "عدد وارد شود",
                minlength: "کمتر از 11 رقم است",
                maxlength: "بیشتر از 11 رقم است"
            },
            "Address.PostalCode": {
                required: "لطفا کد پستی خود را وارد نمایید",
                digits: "عدد وارد شود",
                minlength: "کمتر از 10 رقم است",
                maxlength: "بیشتر از 10 رقم است"
            },
            "Address.City.Id": "لطفا استان محل سکونت خود را تعیین نمایید",
            "Address.Extra": "لطفا نشانی خود را وارد نمایید",
            "Payment": "نوع پرداخت را انتخاب نمائید"
        }
    }
    $($elem).appValidate($validateOptions);
}

var $validateRole_OnLoad = function ($elem) {
    var $validateOptions = {
        onsubmit: true,
        rules: {
            "Name": {
                required: true,
                minlength: 6,
                maxlength: 30
            }
        },
        messages: {
            "Name":
                {
                    required: "نام را انتخاب نمایید",
                    minlength: "کمتر از 6 کاراکتر است",
                    maxlength: "بیشتر از 30 کاراکتر است"
                }
        }
    }
    $($elem).appValidate($validateOptions);
}

var $validateSeoSetting_OnLoad = function ($elem) {
    var $validateOptions = {
        onsubmit: true,
        rules: {
            "WwwRequirement": {
                required: true
            }
        },
        messages: {
            "WwwRequirement":
            {
                required: "وضعیت را وارد کنید www"
            }
        }
    }
    $($elem).appValidate($validateOptions);
}

var $validateSeoUrl_OnLoad = function ($elem) {
    var $validateOptions = {
        onsubmit: true,
        rules: {
            "AbsoulateUrl": {
                required: true
            },

            "CurrentUrl": {
                required: true
            },
            "Redirection": {
                required: true
            }
        },
        messages: {
            "AbsoulateUrl":
            {
                required: "آدرس قبلی را وارد کنید"
            },
            "CurrentUrl":
            {
                required: "آدرس جدید را وارد کنید"
            }, "Redirection":
            {
                required: "نوع انتقال را وارد کنید"
            }
        }
    }
    $($elem).appValidate($validateOptions);
}

var $validateSpecification_OnLoad = function ($elem) {
    var $validateOptions = {
        onsubmit: true,
        rules: {
            "CategoryId": {
                required: true
            },
            "Title": {
                required: true,
                minlength: 2,
                maxlength: 70
            },
            "Description": {
                required: true,
                minlength: 2,
                maxlength: 250
            },
            "Order": {
                required: true,
                digits: true
            },
            "Type": {
                required: true
            }
        },
        messages: {
            "CategoryId":
            {
                required: "لطفا یک دسته را انتخاب نمایید"
            },
            "Title":
            {
                required: "نام را انتخاب نمایید",
                minlength: "کمتر از 2 کاراکتر است",
                maxlength: "بیشتر از 70 کاراکتر است"
            }
            ,
            "Description":
            {
                required: "توضیحات را انتخاب نمایید",
                minlength: "کمتر از 2 کاراکتر است",
                maxlength: "بیشتر از 250 کاراکتر است"
            }
            ,
            "Order":
            {
                required: "عدد را وارد نمایید",
                digits: "عدد وارد شود"
            },
            "Type":
            {
                required: "لطفا یک نوع را انتخاب نمایید"
            }
        }
    }
    $($elem).appValidate($validateOptions);
}

var $validateTag_OnLoad = function ($elem) {
    var $validateOptions = {
        onsubmit: true,
        rules: {
            "Title": {
                required: true
            },
            "CostValue": {
                digits: true
            }
           
        },
        messages: {
            "Title":
            {
                required: " عنوان را وارد کنید"
            },
            "CostValue":
            {
                digits: "عدد وارد شود"
            }
           
        }
    }
    $($elem).appValidate($validateOptions);
}

var $validateUserOperator_OnLoad = function ($elem) {
    var $validateOptions = {
        onsubmit: true,
        rules: {
            "Email": {
                required: true,
                email: true
            },
            //"UserName": {
            //    required: true,
            //   // regex: "^([A-Za-z]{1}[A-Za-z0-9\-]{1,}[A-Za-z0-9]{1,})$",
            //    minlength: 6,
            //    maxlength: 50
            //},
            "Alias": {
                required: true,
                regex: "^([A-Za-z]{1}[A-Za-z0-9\-]{1,}[A-Za-z0-9]{1,})$",
                minlength: 6,
                maxlength: 50
            },
            "specificationContainer": {
                required: true
            },
            "MobileNumber": {
                required: true,
                digits: true,
                minlength: 11,
                maxlength: 11
            },
            "Password": {
                required: true,
                minlength: 6,
                maxlength: 100
            },
            "Amount": {
                digits: true
            },
            "RoleId": {
                required: true
            },
            "CategoryId": {
                required: true
            },
            "CompanyTitle": {
                required: true
            },
            "PaymentType": {
                required: true
            }
        },
        messages: {
            "Email":
            {
                required: "ایمیل را وارد کنید",
                email: "ایمیل نادرست است"
            },
            //"UserName":
            //{
            //    required: "نام کاربری را وارد کنید",
            //    //regex: "شما می‌بایست تنها از حروف الفبای انگلیسی، خط‌فاصله و اعداد در نام دامنه استفاده نمایید که این نام الزاما با حروف الفبای انگلیسی آغاز می‌شود و حرف آخر نمی‌تواند خط‌فاصله باشد",
            //    minlength: "کمتر از 6 کاراکتر است",
            //    maxlength: "بیشتر از 50 کاراکتر است"
            //},
            "Alias":
            {
                required: "نام دامین را وارد کنید",
                regex: "شما می‌بایست تنها از حروف الفبای انگلیسی، خط‌فاصله و اعداد در نام دامنه استفاده نمایید که این نام الزاما با حروف الفبای انگلیسی آغاز می‌شود و حرف آخر نمی‌تواند خط‌فاصله باشد",
                minlength: "کمتر از 6 کاراکتر است",
                maxlength: "بیشتر از 50 کاراکتر است"
            },
            "MobileNumber": {
                required: "موبایل وارد شود",
                digits: "عدد وارد شود",
                minlength: "کمتر از 11 رقم است",
                maxlength: "بیشتر از 11 رقم است"
            },
            "Password": {
                required: "پسورد وارد شود",
                minlength: "کمتر از 6 رقم است",
                maxlength: "بیشتر از 100 رقم است"
            },
            "Amount": {
                digits: "عدد وارد شود"
            },
            "RoleId": {
                required: "یک نقش را انتخاب کنید"
            },
            "CategoryId": {
                required: "یک دسته را انتخاب کنید"
            },
            "CompanyTitle": {
                required: "نام شرکت را وارد کنید"
            },
            "PaymentType": {
                required: "نوع پرداخت را انتخاب کنید"
            }
        }
    }
    $($elem).appValidate($validateOptions);
}

var $validateEmailRegister_OnLoad = function ($elem) {
    var $validateOptions = {
        onsubmit: true,
        rules: {
            "Email": {
                required: true,
                email: true
            },
            "Password": {
                required: true,
                minlength: 6,
                maxlength: 100
            },
            "TermOfService": {
                required: true
            }
        },
        messages: {
            "Email":
            {
                required: "ایمیل را وارد کنید",
                email: "ایمیل نادرست است"
            },
            "Password": {
                required: "پسورد وارد شود",
                minlength: "کمتر از 6 رقم است",
                maxlength: "بیشتر از 100 رقم است"
            },
            "TermOfService": {
                required: "قوانین را قبول ندارید؟"
            }
        }
    }
    $($elem).appValidate($validateOptions);
}

var $validateForgotPassword_OnLoad = function ($elem) {
    var $validateOptions = {
        onsubmit: true,
        rules: {
            "Email": {
                required: true,
                email: true
            }
        },
        messages: {
            "Email":
            {
                required: "ایمیل را وارد کنید",
                email: "ایمیل نادرست است"
            }
        }
    }
    $($elem).appValidate($validateOptions);
}

var $validateLogin_OnLoad = function ($elem) {
    var $validateOptions = {
        onsubmit: true,
        rules: {
            "UserName": {
                required: true,
                minlength: 6,
                maxlength: 50
            },
            "Password": {
                required: true,
                minlength: 6,
                maxlength: 100
            }
        },
        messages: {
            "UserName":
            {
                required: "نام کاربری را وارد کنید",
                minlength: "کمتر از 6 کاراکتر است",
                maxlength: "بیشتر از 50 کاراکتر است"
            },
            "Password": {
                required: "پسورد وارد شود",
                minlength: "کمتر از 6 رقم است",
                maxlength: "بیشتر از 100 رقم است"
            }
        }
    }
    $($elem).appValidate($validateOptions);
}
var $validateConfirmationPhoneNumber_OnLoad = function ($elem) {
    var $validateOptions = {
        onsubmit: true,
        rules: {
            "MobileNumber": {
                required: true,
                minlength: 11,
                maxlength: 11,
                digits: true
            }
        },
        messages: {
            "MobileNumber":
            {
                required: "موبایل را وارد کنید",
                minlength: "کمتر از 11 کاراکتر است",
                maxlength: "بیشتر از 11 کاراکتر است",
                digits: "عدد وارد شود"
            }
        }
    }
    $($elem).appValidate($validateOptions);
}

var $validateConfirmationResetPassword_OnLoad = function ($elem) {
    var $validateOptions = {
        onsubmit: true,
        rules: {
            "Email": {
                required: true,
                email: true
            },
            "Password": {
                required: true,
                minlength: 6,
                maxlength: 100
            },
            "ConfirmPassword": { equalTo: "#Password" }
        },
        messages: {
            "Email":
            {
                required: "ایمیل را وارد کنید",
                email: "ایمیل نادرست است"
            },
            "Password": {
                required: "پسورد وارد شود",
                minlength: "کمتر از 6 رقم است",
                maxlength: "بیشتر از 100 رقم است"
            },
            "ConfirmPassword": "تکرار گذرواژه با گذرواژه مطابقت ندارد"
        }
    }
    $($elem).appValidate($validateOptions);
}

var $validateChangePassWord_OnLoad = function ($elem) {
    var $validateOptions = {
        onsubmit: true,
        rules: {
            "OldPassword": {
                required: true,
                minlength: 6,
                maxlength: 100
            },
            "NewPassword": {
                required: true,
                minlength: 6,
                maxlength: 100
            },
            "ConfirmPassword": { equalTo: "#NewPassword" }
        },
        messages: {
            "OldPassword": {
                required: "پسورد  قدیم وارد شود",
                minlength: "کمتر از 6 رقم است",
                maxlength: "بیشتر از 100 رقم است"
            },
            "NewPassword": {
                required: "پسورد جدید وارد شود",
                minlength: "کمتر از 6 رقم است",
                maxlength: "بیشتر از 100 رقم است"
            },
            "ConfirmPassword": "تکرار گذرواژه با گذرواژه مطابقت ندارد"
        }
    }
    $($elem).appValidate($validateOptions);
}

var $validateUserSetting_OnLoad = function ($elem) {
    var $validateOptions = {
        onsubmit: true,
        rules: {
            "Language": {required: true},
            "Theme": {required: true}
        },
        messages: {
            "Language": "زبان وارد شود",
            "Theme": "تم وارد شود"
        }
    }
    $($elem).appValidate($validateOptions);
}


var $validateProductComment_OnLoad = function ($elem) {
    var $validateOptions = {
        onsubmit: true,
        rules: {
            "Body": {
                required: true,
                minlength: 3,
                maxlength: 200
            }
        },
        messages: {
            "Body": "لطفا توضیحات خود را بنویسید",
            minlength: "کمتر از 3 کاراکتر است",
            maxlength: "بیشتر از 200 کاراکتر است"
        }
    }
    $($elem).appValidate($validateOptions);
}

var $validateProductBulk_OnLoad = function($elem) {

    var $index = $($elem).find(".catalogContainer .catalogItem").last().data("index");
    var $validateOptions = {
        onsubmit: true,
        rules: {},
        messages: {}
    }

    for (var i = 0; i <= $index; i++) {
        $validateOptions.rules["ProductBulks[" + i + "].AvailableCount"] = { digit: true };
        $validateOptions.rules["ProductBulks[" + i + "].Price"] = { required: true, digit: true };
        $validateOptions.messages["ProductBulks[" + i + "].AvailableCount"] = { digit: "عدد وارد شود" };
        $validateOptions.messages["ProductBulks[" + i + "].Price"] = { required: "وارد کنید", digit: "عدد وارد شود" };

    }


    $($elem).appValidate($validateOptions);
}

   
   




var $validateCompanyQuestion_OnLoad = function ($elem) {
    var $validateOptions = {
        onsubmit: true,
        rules: {
            "Body": {
                required: true ,
                minlength: 3,
                maxlength: 200
            }
        },
        messages: {
            "Body": "لطفا سوال خود را بنویسید",
            minlength: "کمتر از 3 کاراکتر است",
            maxlength: "بیشتر از 200 کاراکتر است"
        }
    }
    $($elem).appValidate($validateOptions);
}


var $validateManufacturer_OnLoad = function ($elem) {
    var $validateOptions = {
        onsubmit: true,
        rules: {
            "Country": {
                required: true
            },"Name": {
                required: true
            }

        },
        messages: {
            "Country": "لطفاکشور را انتخاب کنید",
            "Name": "لطفا نام برند را وارد کنید"
        }
    }
    $($elem).appValidate($validateOptions);
}

var $validateGuarantee_OnLoad = function ($elem) {
    var $validateOptions = {
        onsubmit: true,
        rules: {
            "Email": {
                email: true
            },
            "MobileNumber": {
                digits: true,
                minlength: 11,
                maxlength: 11
            },
            "PhoneNumber": {
                digits: true,
                minlength: 11,
                maxlength: 11
            },
            "Title": {
                required: true
            }

        },
        messages: {
            "Title": "لطفا نام گارانتی را وارد کنید",
            "Email": "ایمیل نادرست است",
            "PhoneNumber": {
                digits: "عدد وارد شود",
                minlength: "کمتر از 11 کاراکتر است",
                maxlength: "بیشتر از 11 کاراکتر است"
            },
            "MobileNumber": {
                digits: "عدد وارد شود",
                minlength: "کمتر از 11 کاراکتر است",
                maxlength: "بیشتر از 11 کاراکتر است"
            }
        }
    }
    $($elem).appValidate($validateOptions);
}
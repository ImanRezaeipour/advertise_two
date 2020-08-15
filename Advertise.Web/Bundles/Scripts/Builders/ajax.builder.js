/**
 *
 * @param {} elem
 * @returns {}
 */
var $ajaxRemoveItem_OnClick = function (elem, e) {
    var ajaxOptions = {
        url: $(elem).data("param"),
        type: "POST",
        culture: false,
        complete: function (xhr, status) {
            if (xhr.status === 403) {
                messageError("عدم دسترسی");
            }
            if (xhr.status === 200) {
                messageSuccess("حذف با موفقیت انجام شد");
                window.location.reload();
            } else {
                messageError("خطایی رخ داده است");
            }
            return false;
        }
    }

    $.appAjax(ajaxOptions);
}

/**
 *
 * @param {} elem
 * @returns {}
 */
var $ajaxSelectDurationType_OnChange = function (elem) {
    var ajaxOptions = {
        url: "/AdsOption/GetPriceAjax",
        data: {
            optionId: $("#AdsOptionId").val(),
            durationType: $("#DurationType").val()
        },
        complete: function (xhr, status) {
            if (statuse === "success") {
                if (xhr.responseJSON.Success === true) {
                    $("#AdPrice").html(xhr.responseJSON.Data);
                }
            }
        }
    }

    $.appAjax(ajaxOptions);
}


var $ajaxDateofRelease_OnChange = function(elem) {
    var ajaxOptions = {
        url: "/AdsReserve/DateofReleaseAjax",
        data: {
            optionId: $('#AdsOptionId').val()
        },
        complete: function(xhr, status) {
            if (statuse === "success") {
                if (xhr.responseJSON.Success === true) {
                    console.log(xhr.responseJSON.Data);
                    $("#AdDateRelease").html(xhr.responseJSON.Data);
                    $ajaxSelectDurationType_OnChange();
                }
            }
        }
    }

    $.appAjax(ajaxOptions);
    
}

/**
 *
 * @param {} elem
 * @returns {}
 */
var $ajaxCheckAlias_OnClick = function (elem) {
    var ajaxOptions = {
        url: "/fa/Company/IsExistAliasAjax",
        data: {
            companyAlias: $("#Alias").val()
        },
        complete: function (xhr, status) {
            if (statuse === "success") {
                if (xhr.responseJSON.Success === true) {
                    if (xhr.responseJSON.Data === true) {
                        $("#checkAliasButton").html('<span style="background-color: red">نام مستعار وجود دارد</span>');
                    } else {
                        $("#checkAliasButton").html('<span style="background-color: green">نام مستعار مجاز است</span>');
                    }
                } else {
                    messageError("خطایی سمت سرور رخ داده است");
                }
            } else {
                messageError("خطایی سمت کلاینت رخ داده است");
            }
        }
    }

    $.ajax(ajaxOptions);
};

/**
 *
 * @param {} elem
 * @returns {}
 */
var $ajaxCheckPlanDiscount_OnClick = function (elem) {
    var ajaxOptions = {
        url: "/PlanDiscount/GetPercentAjax",
        data: {
            code: $("#DiscountCode").val()
        },
        type: "POST",
        beforeSend: function (xhr, configs) {
            var price = $("#PlanFinalPrice").html();
            if (price === "-----")
                return;
        },
        complete: function (xhr, status) {
            if (xhr.responseJSON.Success === true) {
                var price = $("#PlanFinalPrice").html();
                price.replace(",", "").replace("تومان", "").replace(" ", "");
                alert(" کد تخفیف شما شامل" + xhr.responseJSON.Data + " درصد تخفیف میباشد");
                var percent = (parseFloat(price) * parseFloat(xhr.responseJSON.Data)) / 100;
                var finalPrice = (parseFloat(price) - percent) * 1000;
                $("#PlanFinalPrice").html(finalPrice);
                $("#DiscountCodeApply").removeClass("discount-code-apply").addClass("discount-code-apply-ok");
            }
        }
    }

    $.appAjax(ajaxOptions);
}

/**
 *
 * @returns {}
 */
var ajaxLoadProductSpecification = function () {
    var ajaxOptions = {
        url: "/ProductSpecification/CreateAjax",
        data: {
            categoryId: $("#CategoryId").val()
        },
        complete: function (xhr, status) {
            if (xhr.responseJSON.Success === true) {
                $("#specificationContainer").empty().append(xhr.responseText);
            }
            else {
                $("#specificationContainer").empty().append(xhr.responseJSON.Data);
            }
        }
    }

    $.appAjax(ajaxOptions);
}

/**
 *
 * @param {} elem
 * @returns {}
 */
var $ajaxLoadEditProductSpecification_OnLoad = function (elem) {
    var ajaxOptions = {
        url: "/ProductSpecification/EditAjax",
        data: {
            productId: $("#Id").val()
        },
        complete: function (xhr, status) {
            if (xhr.responseJSON.Success === true) {
                $(elem).empty().append(xhr.responseJSON.Data);
            }
            else {
                $(elem).empty().append(xhr.responseJSON.Data);
            }
        }
    }

    $.appAjax(ajaxOptions);
}

/**
 *
 * @param {} elem
 * @returns {}
 */
var $ajaxBagDelete_OnClick = function (elem) {
    var ajaxOptions = {
        url: "/Bag/DeleteAjax",
        data: {
            productId: $(elem).data("param")
        },
        type: "POST",
        beforeSend: function (xhr, configs) {
            $(elem).prop("disabled", true);
        },
        complete: function (xhr, status) {
            if (xhr.responseJSON.Success === true) {
                $("[data-param=" + $(elem).data("param") + "][data-state='buy']").parent().css("margin-top", "0");
            }
            $(elem).prop("disabled", false);
        }
    }

    $.appAjax(ajaxOptions);
}

/**
 *
 * @param {} elem
 * @returns {}
 */
var $ajaxBagCreate_OnClick = function (elem) {
    var ajaxOptions = {
        url: "/Bag/CreateAjax",
        data: {
            productId: $(elem).data("param")
        },
        type: "POST",
        beforeSend: function (xhr, configs) {
            $(elem).prop("disabled", true);
        },
        complete: function (xhr, status) {
            console.log(xhr);
            if (xhr.responseJSON.Success === true) {
                $("[data-param=" + $(elem).data("param") + "][data-state='unbuy']").parent().css("margin-top", "-42px");
            }
            $(elem).prop("disabled", false);
        }
    }

    $.appAjax(ajaxOptions);
}

/**
 *
 * @param {} elem
 * @returns {}
 */
var $ajaxToggleLikeProduct_OnClick = function (elem) {
    debugger;
    var ajaxOptions = {
        url: "/ProductLike/MyToggleAjax",
        data: {
            productId: $("#productId").val()
        },
        type: "POST",
        complete: function (xhr, status) {
            if (status === "success") {
                var count = parseInt($(elem).children("span").text());
                var isLiked = $(elem).children("i").hasClass("fa-heart");
                $(elem).children("i").toggleClass("fa-heart fa-heart-o");
                if (isLiked === true) {
                    var minusCount = String(count - 1);
                    $(elem).children("span").text(minusCount);
                } else {
                    var plusCount = String(count + 1);
                    $(elem).children("span").text(plusCount);
                }
            }
        }
    }

    $.appAjax(ajaxOptions);
}

/**
 *
 * @param {} elem
 * @returns {}
 */
var $ajaxToggleNotifyProduct_OnClick = function (elem) {
    var ajaxOptions = {
        url: "/ProductNotify/MyToggleAjax",
        data: {
            productId: $("#productId").val()
        },
        type: "POST",
        complete: function (xhr, status) {
            if (status === "success") {
                $(elem).children("i").toggleClass("fa-bell fa-bell-slash-o");
            }
        }
    }

    $.appAjax(ajaxOptions);
}

/**
 *
 * @param {} elem
 * @returns {}
 */
var $ajaxToggleFollowCompany_OnClick = function (elem) {
    var ajaxOptions = {
        url: "/CompanyFollow/MyToggleAjax",
        data: {
            companyId: $(elem).parent(".follow-button-wrapper").children("#Id").val()
        },
        type: "POST",
        complete: function (xhr, status) {
            if (status === "success") {
                var countDetail = parseInt($(elem).parents(".side-statistics").find("#FollowerCount").text());
                var countItem = parseInt($(elem).parents(".product-item").find("#FollowerCount").text());
                var isFollowed = $(elem).hasClass("followed-btn");
                var follow = $(elem).attr("data-follow");
                var unfollow = $(elem).attr("data-unfollow");
                $(elem).removeClass("followed-btn").removeClass("unfollowed-btn");
                if (isFollowed === true) {
                    $(elem).addClass("unfollowed-btn").text("").text(follow);
                    var minusCountDetail = String(countDetail - 1);
                    var minusCountItem = String(countItem - 1);
                    $(elem).parents(".side-statistics").find("#FollowerCount").text("").text(minusCountDetail + " ");
                    $(elem).parents(".product-item").find("#FollowerCount").text("").text(minusCountItem + " ");
                } else {
                    $(elem).addClass("followed-btn").text("").text(unfollow);
                    var plusCountDetail = String(countDetail + 1);
                    var plusCountItem = String(countItem + 1);
                    $(elem).parents(".side-statistics").find("#FollowerCount").text("").text(plusCountDetail + " ");
                    $(elem).parents(".product-item").find("#FollowerCount").text("").text(plusCountItem + " ");
                }
            }
        }
    }
    $.appAjax(ajaxOptions);
}

/**
 *
 * @param {} elem
 * @returns {}
 */
var $ajaxLoadCategories_OnLoad = function (elem) {
    var ajaxOptions = {
        url: "/Category/GetCategoriesAjax",
        complete: function (xhr, status) {
            $.each(xhr.responseJSON.Data, function (key, value) {
                $(elem).append('<option value="' + value.Id + '">' + value.Title + "</option>");
            });
        }
    }

    $.appAjax(ajaxOptions);
}

/**
 *
 * @param {} elem
 * @returns {}
 */
var $ajaxSelectCity_OnLoad = function (elem) {
    debugger;
    var ajaxOptions = {
        url: "/City/GetCityAjax",
        data: {
            id: $("#ProvinceId").val()
        },
        complete: function (xhr, status) {
            $("#Address_City_Id").empty();
            $.each(xhr.responseJSON.Data, function (key, value) {
                $("#Address_City_Id").append('<option value="' + value.Value + '">' + value.Text + "</option>");
            });
            var cityId = $("#CityId").val();
            $("#Address_City_Id").val(cityId);
        }
    }

    $.appAjax(ajaxOptions);
}

/**
 *
 * @param {} elem
 * @returns {}
 */
var $ajaxSelectProvince_OnChange = function (elem) {
    debugger;
    var ajaxOptions = {
        url: "/City/GetCityAjax",
        data: {
            id: $(elem).find(":selected").val()
        },
        complete: function (xhr, status) {
            $("#Address_City_Id").empty().append('<option value="" selected disabled>-- انتخاب کنید --</option>');
            $.each(xhr.responseJSON.Data, function (index, item) {
                $("#Address_City_Id").append('<option value="' + item.Value + '">' + item.Text + "</option>");
               
            });
            $ajaxChangeLocation_OnChange(elem);
        }
    }

    $.appAjax(ajaxOptions);
}

/**
 *
 * @param {} elem
 * @returns {}
 */
var $ajaxSendProductComment_OnClick = function (elem) {
    var ajaxOptions = {
        url: "/ProductComment/CreateAjax",
        data: {
            productId: $("#Id").val(),
            body: $("#commentBody").val()
        },
        beforeSend: function (xhr, configs) {
            $("#btnSendComment").prop("disabled", true);
        },
        complete: function (xhr, status) {
            if (xhr.responseJSON.Success === false) {
                messageError("متاسفانه خطایی رخ داده است مجدد تلاش کنید");
                $("#btnSendComment").prop("disabled", false);
            } else if (xhr.responseJSON.Success === true) {
                messageSuccess("دیدگاه شما با موفقیت ثبت گردید");
                $("#commentBody").val("");
                $("#btnSendComment").prop("disabled", false);
            } else {
                messageError("متاسفانه خطایی رخ داده است مجدد تلاش کنید");
                $("#btnSendComment").prop("disabled", false);
            }
        }
    }

    $.appAjax(ajaxOptions);
}

/**
 *
 * @param {} elem
 * @returns {}
 */
var $ajaxSendCompanyConversation_OnClick = function (elem) {
    var ajaxOptions = {
        url: "/CompanyConversation/CreateAjax",
        data: {
            receivedById: $("#CreatedById").val(),
            body: $("#commentBody").val()
        },
        complete: function (xhr, status) {
            if (xhr.responseJSON.Success === false) {
                messageError("متاسفانه خطایی رخ داده است مجدد تلاش کنید");
            } else if (xhr.responseJSON.Success === true) {
                messageSuccess(" با موفقیت ثبت گردید");
                $("#commentBody").val("");
            } else {
                messageError("متاسفانه خطایی رخ داده است مجدد تلاش کنید");
            }
        }
    }

    $.appAjax(ajaxOptions);
}

/**
 *
 * @param {} elem
 * @returns {}
 */
var $ajaxSelectListConversation_OnChange = function (elem) {
    debugger;
    var ajaxOptions = {
        url: "/CompanyConversation/DetailAjax",
        data: {
            id: $("#CreatedById").val()
        },
        complete: function (xhr, status) {
            $("#container").removeData();
            $("#container").html(xhr.responseJSON.Data);
            $("#btnSendConversation").unbind("click").click(function () {
                $ajaxSendCompanyConversation_OnClick(this);
            });
        }
    }

    $.appAjax(ajaxOptions);
}

/**
 *
 * @param {} elem
 * @returns {}
 */
var $ajaxSubscribe_OnClick = function (elem) {
    var ajaxOptions = {
        url: "/Newsletter/SubscribeAjax",
        data: {
            email: $("#Email").val()
        },
        type: "POST",
        complete: function (xhr, status) {
            messageSuccess("با موفقیت ثبت گردید");


        }
    }

    $.appAjax(ajaxOptions);
}

/**
 *
 * @param {} elem
 * @returns {}
 */
var $ajaxToggleFollowCategory_OnClick = function (elem) {
    debugger;
    var ajaxOptions = {
        url: "/CategoryFollow/MyToggleAjax",
        data: {
            categoryId: $(elem).parent(".follow-button-wrapper").children("#categoryId").val()
        },
        type: "POST",
        complete: function (xhr, status) {
            if (status === "success") {
                var count = parseInt($("#FollowerCount").text());
                var isFollowed = $(elem).hasClass("followed-btn");
                var follow = $(elem).attr("data-follow");
                var unfollow = $(elem).attr("data-unfollow");
                $(elem).removeClass("followed-btn").removeClass("unfollowed-btn");
                if (isFollowed === true) {
                    $(elem).addClass("unfollowed-btn").text("").text(follow);
                    var minusCount = String(count - 1);
                    $("#FollowerCount").text("").text(minusCount);
                } else {
                    $(elem).addClass("followed-btn").text("").text(unfollow);
                    var plusCount = String(count + 1);
                    $("#FollowerCount").text("").text(plusCount);
                }
            }
        }
    }

    $.appAjax(ajaxOptions);
}

/**
 *
 * @param {} elem
 * @returns {}
 */
var $ajaxBagChangeProductCount_OnChange = function (elem) {
    var ajaxOptions = {
        url: "/Bag/ChangeProductCountAjax",
        data: {
            productId: $(elem).data("param"),
            productCount: $(elem).val()
        },
        type: "POST",
        beforeSend: function (xhr, configs) {
            $(elem).prop("disabled", true);
        },
        complete: function (xhr, status) {
            if (xhr.responseJSON.Success === true) {
                var price = $(elem).data("param-2");
                var count = $(elem).val();
                var productTotal = price * count;
                $(elem).closest(".removable-bag-item").children(".purchase-item-recommend").children(".price")
                    .text("").append(productTotal).attr("data-val", productTotal);
                var total = $findTotalBagPrice(".total-product-price");
                $(".total-bag-price").text("").append(total);
                $(elem).prop("disabled", false);
            }
        }
    }

    $.appAjax(ajaxOptions);
}

/**
 *
 * @param {} elem
 * @returns {}
 */
var $ajaxBagProfileDelete_OnClick = function (elem) {
    var ajaxOptions = {
        url: "/Bag/DeleteAjax",
        data: {
            productId: $(elem).data("param")
        },
        type: "POST",
        beforeSend: function (xhr, configs) {
            $(elem).prop("disabled", true);
        },
        complete: function (xhr, status) {
            if (xhr.responseJSON.Success === true) {
                $(elem).parent().remove();
                $("#PageLoader").append('<i class="fa fa-spinner fa-pulse fa-3x"></i>').show();
                $("#BagShadow").show();
                var total = $findTotalBagPrice(".total-product-price");
                $(".total-bag-price").text("").append(total);
                location.reload();
            }
            $(elem).prop("disabled", false);
        }
    }

    $.appAjax(ajaxOptions);
}

/**
 *
 * @param {} elem
 * @returns {}
 */
var $ajaxGetBusinessInformations_OnLoad = function (elem) {
    var ajaxOptions = {
        url: "/Company/DetailInfoAjax",
        data: {
            id: $(elem).data("param")
        },
        complete: function (xhr, status) {
            if (status === "success") {
                if (xhr.responseJSON.Success === true) {
                    $("#PhoneNumber").text("").removeClass("first-load-info").append(xhr.responseJSON.Data.PhoneNumber);
                    $("#MobileNumber").text("").removeClass("first-load-info").append(xhr.responseJSON.Data.MobileNumber);
                    $("#EmailAddress").text("").removeClass("first-load-info").append(xhr.responseJSON.Data.Email);
                    $("#AddressPlace").text("").removeClass("first-load-info").append(xhr.responseJSON.Data.Address);
                    $("#WebsiteAddress").text("").removeClass("first-load-info").append(xhr.responseJSON.Data.WebSite);
                }
            }
        }
    }

    $.appAjax(ajaxOptions);
}

/**
 *
 * @param {} elem
 * @returns {}
 */
var $ajaxGetUserInformations_OnLoad = function (elem) {
    var ajaxOptions = {
        url: "/User/DetailAjax",
        data: {
            id: $(elem).data("param")
        },
        complete: function (xhr, status) {
            $("#HomeNumber").text("").removeClass("first-load-info").append(xhr.responseJSON.Data.HomeNumber);
            $("#PhoneNumber").text("").removeClass("first-load-info").append(xhr.responseJSON.Data.PhoneNumber);
            $("#EmailAddress").text("").removeClass("first-load-info").append(xhr.responseJSON.Data.Email);
            $("#AddressPlace").text("").removeClass("first-load-info").append(xhr.responseJSON.Data.Address.Extra);
            $("#WebsiteAddress").text("").removeClass("first-load-info").append(xhr.responseJSON.Data.Website);
        }
    }

    $.appAjax(ajaxOptions);
}

//    $.appAjax(ajaxOptions);
//}

var $ajaxRateProduct_OnClick = function (elem) {
    var ajaxOptions = {
        url: '/ProductRate/CreateAjax',
        data: {
            productId: $("#Id").val(),
            rate: parseInt($(elem).data("rate"))
        },
        type: 'POST',
        complete: function (xhr, status) {
            if (status === "success") {
                if (xhr.responseJSON.Success === true) {
                    var rate = parseInt($(elem).data("rate"));
                    var myPreviousRate = parseInt($("#MyRate").val());
                    var averageRate = parseFloat($("#AverageRate").val().replace("/", "."));
                    var userCount = parseInt($("#UserCount").text());
                    var totalPoint = averageRate * userCount;
                    var newUserCount;
                    var newAverage;
                    if (myPreviousRate === 0) {
                        newUserCount = userCount + 1;
                        newAverage = (totalPoint + rate) / newUserCount;
                    } else {
                        newUserCount = userCount;
                        newAverage = (totalPoint - myPreviousRate + rate) / userCount;
                    }
                    $("#UserCount").text(newUserCount);
                    $("#AverageRateText").text(Math.round(newAverage * 10) / 10);
                    newStarsArrange(newAverage);
                    messageSuccess("رای شما ثبت شد");
                } else {
                    messageInfo(xhr.responseJSON.ErrorMessage);
                }
            } else {
                messageError(xhr.responseJSON.ErrorMessage);
            }
        }
    }
    $.appAjax(ajaxOptions);
}

/**
 *
 * @param {} elem
 * @returns {}
 */
var $ajaxSendQuestion_OnClick = function (elem) {
    debugger;
    var index = 0;
    var ajaxOptions = {
        url: "/CompanyQuestion/CreateAjax",
        data: {
            Body: $("#Question").val(),
            CompanyId: $("#Id").val()
        },
        type: "POST",
        complete: function (xhr, status) {
            if (status === "success") {
                if (xhr.responseJSON.Success === true) {
                    $("#Question").val("");
                    messageSuccess("ثبت شد");
                } else {
                    messageError("خطا،");
                }
            } else {
                messageError(status);
            }
        }
    }

    $.appAjax(ajaxOptions);
}


var $ajaxReplyToQuestion_OnClick = function (elem) {
    debugger;
    var index = $(elem).closest(".comment-wrap-each").data('index');
    var ajaxOptions = {
        url: "/CompanyQuestion/CreateAjax",
        data: {
            Body: $("#Question_" + index).val(),
            CompanyId: $("#Id").val(),
            ReplyId: $('#ReplyId_' + index).val()
        },
        type: "POST",
        complete: function (xhr, status) {
            if (status === "success") {
                if (xhr.responseJSON.Success === true) {
                    $("#Question").val("");
                    messageSuccess("ثبت شد");
                } else {
                    messageError("خطا،");
                }
            } else {
                messageError(status);
            }
        }
    }

    $.appAjax(ajaxOptions);
}

var $ajaxChangeAdsOptionPosition_OnChange = function (elem) {
    var type = $('#AdsOptionType').val();
    var position = $('#AdsOptionPositionType').val();
    var ajaxOptions = {
        url: '/adsoption/getoptionajax',
        data: { type: type, position: position },
        complete: function(xhr, status) {
            if (status === 'success') {
                if (xhr.responseJSON.Success === true) {
                    if (type !== null && position !== null) {
                        $('#adsOptionContainer').removeClass('hide-none');
                        $('#adsOptionContainer').prev('.msg-container').removeClass('hide-none');
                        $('#AdsOptionId').empty();
                        $('#AdsOptionId').append("<option  selected disabled>-- انتخاب کنید --</option>");
                        $.each(xhr.responseJSON.Data,
                            function(index, item) {
                                $('#AdsOptionId')
                                    .append("<option value='" + item.Value + "'>" + item.Text + "</option>");
                            });
                        $('#AdDateRelease').empty();
                        $('#Title1').removeClass('hide-none');
                        $('#Title1').prev('.msg-container').removeClass('hide-none');
                        $('#EntityName1').removeClass('hide-none');
                        $('#EntityName1').prev('.msg-container').removeClass('hide-none');
                        $('#DurationType1').removeClass('hide-none');
                        $('#DurationType1').prev('.msg-container').removeClass('hide-none');
                        $('#AdPrice').empty().html("0");
                        $('#Image1').removeClass('hide-none');
                        $('#Image1').prev('.msg-container').removeClass('hide-none');
                        if (position === "2") {
                            $('#CategoryTree1').removeClass('hide-none');
                            $('#CategoryTree1').prev('.msg-container').removeClass('hide-none');
                        } else {
                            $('#CategoryTree1').addClass('hide-none');
                            $('#CategoryTree1').prev('.msg-container').addClass('hide-none');
                        }
                    }
                } else {
                    messageError('');
                }
            } else {
                messageError('');
            }
        }
    }
    $.appAjax(ajaxOptions);

}

var $ajaxChangeLocation_OnChange = function(elem) {
    debugger;
    var id = $('#Address_City_Id').val();
    if (id === null) {
        id = $('#Address_City_ParentId').val();
    }
    var jqueryOtion = {
        url: "/city/GetLocationAjax",
        data: {
            id: id
        },
        complete: function(xhr, status) {
            if (status === "success") {
                if (xhr.responseJSON.Success === true) {
                    var lat = xhr.responseJSON.Data.Latitude;
                    var long = xhr.responseJSON.Data.Longitude;
                    $('#setMap').trigger("setLocation", [lat, long]);
                }
            }
        }
    }
    $.appAjax(jqueryOtion);
}

var $ajaxSimple_OnClick = function(elem) {
    var $ajaxOptions = {
        url: $(elem).data("param"),
        type: "POST",
        culture: false,
        complete: function(xhr, status) {
            messageSuccess("با موفقیت انجام شد");
        }
    }
    $.appAjax($ajaxOptions);
}
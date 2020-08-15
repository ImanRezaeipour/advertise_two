$(document).ready(function () {
    setCurrentDomainUrl();
    enableSubmitButton();
    startUp();
    productDetailRank();
    $(window).scroll(productDetailRank);
    $("body").appNavigate();
    function onLoadSetMobileCategorySpecification() {
        var categoryId = "b55ee720-f0bc-7dc0-e160-39e0903ebbce";
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
    onLoadSetMobileCategorySpecification();
    $('.post-tab').xmtab({startOn: 1});
    dashboardHeader();
});
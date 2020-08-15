var $productZoom_OnLoad = function ($elem, $originalLink) {
    if (($(window).width() + 17) > 1260) {
        var $originalImageContainer = $($elem).children("a");
        var $originalImageLink = $originalLink;
        if (!$originalImageLink)
            $originalImageLink = $($elem).children("a").children("img").attr("src");
        $originalImageContainer.attr("href", $originalImageLink);
        var $zoomOptions = {}
        var $resultOperation = $($elem).appZoom($zoomOptions);
        var $resultApi = $resultOperation.filter(".easyzoom--with-thumbnails").data("easyZoom");
        $resultApi.swap($originalImageLink, $originalImageLink);
    }
}
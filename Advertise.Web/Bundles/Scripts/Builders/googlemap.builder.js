/**
 * 
 * @returns {} 
 */
var mapSet = function () {
    var mapOptions = {
        elementId: "setMap"
    }
    $("#" + mapOptions.elementId).appMap(mapOptions);
}

/**
 * 
 * @returns {} 
 */
var mapGet = function () {
    var mapOptions = {
        elementId: "getMap",
        showMarker: true
    }

    $("#" + mapOptions.elementId).appMap(mapOptions);
}


/**
 * 
 * @returns {} 
 */
var mapGetCluster = function() {
    var mapClusterOptions = {
        elementId: "getClusterMap"
    }

    $("#" + mapClusterOptions.elementId).appMapCluster(mapClusterOptions);
}
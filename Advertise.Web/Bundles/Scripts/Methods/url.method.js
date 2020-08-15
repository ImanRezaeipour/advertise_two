/**
 * 
 * @param {} key 
 * @param {} value 
 * @returns {} 
 */
var setQuryStringParameter = function (key, value) {
    window.history.pushState(null, null, setUrlEncodedKey(key, value));
    window.location.reload();
}

var addQueryStringParameter = function (key, value) {
    debugger;
    var href = window.location.href.split("?")[0];
    var queryString = (window.location.href.indexOf("?") !== -1) ? window.location.href.split("?")[1] : "";
    var paramsArr = [];
    paramsArr.push(key + "=" + value);
    for (var i = 0; i < queryString.split("&").length; i++) {
        var paramKey = queryString.split("&")[i].split("=")[0];
        var paramValue = queryString.split("&")[i].split("=")[1];

        if (paramKey === encodeURIComponent("pageindex"))
            continue;
        else if (paramKey === encodeURIComponent("price") && key === encodeURIComponent("price"))
            continue;
        else if (paramKey === encodeURIComponent("term") && key === encodeURIComponent("term"))
            continue;
       else
            paramsArr.push(paramKey + "=" + paramValue);
    }
           
        href = href + "?" + paramsArr.join("&");
    window.location.href = href;
    return;
}

var addOrUpdateQueryStringParameter = function(key, value) {
    window.history.pushState(null, null, setUrlEncodedKey(key, value));
    var rtn = window.location.href.split("?")[0];
    var queryString = (window.location.href.indexOf("?") !== -1) ? window.location.href.split("?")[1] : "";

    if (queryString !== "") {

        var paramsArr = queryString.split("&");
        for (var i = 0; i < paramsArr.length; i += 1) {
            var paramKey = paramsArr[i].split("=")[0];
            var paramValue = paramsArr[i].split("=")[1];
            if (paramKey === encodeURIComponent(key) && paramValue === encodeURIComponent(value) || paramKey === "pageindex") {
                paramsArr.splice(i, 1);
            }
        }

        rtn = rtn + "?" + paramsArr.join("&");
    }
    window.location.href = rtn;
    return;
}


/**
 * 
 * @param {} key 
 * @returns {} 
 */
var removeQuryStringParameter  = function (key) {
    var rtn = window.location.href.split("?")[0];
    var queryString = (window.location.href.indexOf("?") !== -1) ? window.location.href.split("?")[1] : "";

    if (queryString !== "") {
        var paramsArr = queryString.split("&");
        for (var i = paramsArr.length - 1; i >= 0; i -= 1) {
            var param = paramsArr[i].split("=")[0];
            if (param === key) {
                paramsArr.splice(i, 1);
            }
        }
        rtn = rtn + "?" + paramsArr.join("&");
    }
    window.location.href = rtn;
}

  
var removeQuryStringParameters = function (key, value) {
    debugger;
    var href = window.location.href.split("?")[0];
    var queryString = (window.location.href.indexOf("?") !== -1) ? window.location.href.split("?")[1] : "";

    if (queryString !== "") {
        var  paramsArr = [] ;
        for (var i = 0; i < queryString.split("&").length; i++) {
            var paramKey = queryString.split("&")[i].split("=")[0];
            var paramValue = queryString.split("&")[i].split("=")[1];

            if (paramKey === encodeURIComponent("pageindex"))
                continue;
            else if (paramKey === encodeURIComponent(key) && paramValue === encodeURIComponent(value))
                continue;
            else if (paramKey === key && paramValue === value)
                continue;
            else
            paramsArr.push(paramKey + "=" + paramValue);
        }
        href = href + "?" + paramsArr.join("&");
    }
    window.location.href = href;
    return;
}

var UpdateQueryString = function(key,value) {
    var rtn = window.location.href.split("?")[0];
    var paramKey;
    var paramValue;
    var params_arr = [];
    debugger;
    var queryString = (window.location.href.indexOf("?") !== -1) ? window.location.href.split("?")[1] : "";

    if (queryString !== "") {
        params_arr = queryString.split("&");
            var keyCheck = params_arr[params_arr.length-1].split("=")[0];
            var valueCheck = params_arr[params_arr.length-1].split("=")[1];
            for (var i = params_arr.length - 2; i >= 0; i -= 1) {
                paramKey = params_arr[i].split("=")[0];
                paramValue = params_arr[i].split("=")[1];
                if (paramKey === keyCheck && paramValue === valueCheck) {
                  params_arr.splice(i, 1);
                }
            }
        
        rtn = rtn + "?" + params_arr.join("&");
    }
    window.location.href = rtn;

}

/**
 * 
 * @param {} name 
 * @param {} url 
 * @returns {} 
 */
var getUrlParameterByName = function(name, url) {
    if (!url) url = window.location.href;
    name = name.replace(/[\[\]]/g, "\\$&");
    var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
        results = regex.exec(url);
    if (!results) return null;
    if (!results[2]) return '';
    return decodeURIComponent(results[2].replace(/\+/g, " "));
}

/**
 * 
 * @param {} uri 
 * @param {} key 
 * @param {} value 
 * @returns {} 
 */
var updateQueryStringParameter = function (uri, key, value) {
    var re = new RegExp("([?&])" + key + "=.*?(&|$)", "i");
    var separator = uri.indexOf('?') !== -1 ? "&" : "?";

    if (uri.match(re)) {
        return uri.replace(re, '$1' + key + "=" + value + '$2');
    }
    else {
        return uri + separator + key + "=" + value;
    }
}

/**
 * 
 * @param {} key 
 * @param {} query 
 * @returns {} 
 */
var getUrlEncodedKey = function (key, query) {
    if (!query)
        query = window.location.search;
    var re = new RegExp("[?|&]" + key + "=(.*?)&");
    var matches = re.exec(query + "&");
    if (!matches || matches.length < 2)
        return "";
    return decodeURIComponent(matches[1].replace("+", " "));
}

/**
 * 
 * @param {} key 
 * @param {} value 
 * @param {} query 
 * @returns {} 
 */
var setUrlEncodedKey = function (key, value, query) {

    query = query || window.location.search;
    var q = query + "&";
    var re = new RegExp("[?|&]" + key + "=.*?&");
    if (!re.test(q))
        q += key + "=" + encodeURI(value);
    else
        q = q.replace(re, "&" + key + "=" + encodeURIComponent(value) + "&");
    q = q.trimStart("&").trimEnd("&");
    return q[0] == "?" ? q : q = "?" + q;
}

/**
 * 
 * @param {} c 
 * @returns {} 
 */
String.prototype.trimEnd = function (c) {
    if (c)
        return this.replace(new RegExp(c.escapeRegExp() + "*$"), '');
    return this.replace(/\s+$/, '');
}

/**
 * 
 * @param {} c 
 * @returns {} 
 */
String.prototype.trimStart = function (c) {
    if (c)
        return this.replace(new RegExp("^" + c.escapeRegExp() + "*"), '');
    return this.replace(/^\s+/, '');
}

/**
 * 
 * @returns {} 
 */
String.prototype.escapeRegExp = function () {
    return this.replace(/[.*+?^${}()|[\]\/\\]/g, "\\$0");
}

var setCurrentDomainUrl = function() {
    window.appCultureRoute = "/fa";
    window.appDomain = document.domain;
    window.appPort = location.port;
    window.appProtocol = location.protocol;
    window.appHost = location.hostname;

    var parts = location.hostname.split('.');
    var subdomain = parts.shift();
    var upperleveldomain = parts.join('.');

    if (window.appPort === null)
        window.appCurrentDomainUrl = window.appProtocol + "//" + upperleveldomain;
    else
        window.appCurrentDomainUrl = window.appProtocol + "//" + upperleveldomain + ":" + window.appPort;
}
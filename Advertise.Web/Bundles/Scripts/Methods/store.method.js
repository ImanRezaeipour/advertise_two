// Check the emptiness of localStorage.myViewTypes
if (localStorage.myViewTypes == null)
{
    localStorage.myViewTypes = '[{}]';
}

/**
 * A method building new virtual variables for local storage
 * @param {} pageNameParam 
 * @returns {} 
 */
var buildVirtualLS = function (pageNameParam) {

    // Change myViewTypes localStorage variable to JSON type
    var myJsonViewTypes = JSON.parse(localStorage.myViewTypes);

    // Set an initial view type while loading page at the first time
    var firstLoad;
    var firstLoadItem = $('.landing-items-wrapper');
    var firstLoadGrid = $('.landing-grids-wrapper');
    if ((firstLoadItem.length !== 0) && !(pageNameParam in myJsonViewTypes[0])) {
        firstLoad = "item";
    }
    else if (firstLoadGrid.length !== 0 && !(pageNameParam in myJsonViewTypes[0])) {
        firstLoad = "grid";
    } else if (pageNameParam in myJsonViewTypes[0]) {
        firstLoad = myJsonViewTypes[0][pageNameParam];
    }

    // Build a JSON variable we need and set existing values to them or making new ones
    var viewTypes = myJsonViewTypes[0];
    viewTypes[pageNameParam] = firstLoad;
    myJsonViewTypes[0] = viewTypes;
    return (myJsonViewTypes);
}

/**
 * making a string of myViewTypes to store in localStorage
 * @param {} jsonObjectParameter 
 * @returns {} 
 */
var createLocalStorage = function (jsonObjectParameter) {
    localStorage.myViewTypes = JSON.stringify(jsonObjectParameter);
}

/**
 * Method changing variable values of myViewTypes localStorage
 * @param {} currentViewTypeParameter 
 * @returns {} 
 */
var buildPageLS = function (currentViewTypeParameter) {
    var currentPageName = $('#PageName').data('page-name');
    var newViewTypes = buildVirtualLS(currentPageName);
    var viewType = newViewTypes[0][currentPageName];
    newViewTypes[0][currentPageName] = currentViewTypeParameter;
    createLocalStorage(newViewTypes);
}

/**
 * Methods choosing the view type of page while start loading from localStorage values
 * @param {} elem 
 * @returns {} 
 */
var $loadViewType_OnLoad = function (elem) {
    var currentPageName = $(elem).data('page-name');
    var newViewTypes = buildVirtualLS(currentPageName);
    var viewType = newViewTypes[0][currentPageName];
    $switchViewType(viewType);
    $showList();
    createLocalStorage(newViewTypes);
}
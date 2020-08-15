/**
 * 
 * @param {} message 
 * @param {} isModal 
 * @returns {} 
 */
var messageSuccess = function (message, isModal) {
    var messageOptions = {
        message: message,
        type: "success",
        isModal: isModal
    }

    $.appMessage(messageOptions);
}

/**
 * 
 * @param {} message 
 * @param {} isModal 
 * @returns {} 
 */
var messageInfo = function (message, isModal) {
    var messageOptions = {
        message: message,
        type: "information",
        isModal: isModal
    }

    $.appMessage(messageOptions);
}

/**
 * 
 * @param {} message 
 * @param {} isModal 
 * @returns {} 
 */
var messageError = function (message, isModal) {
    var messageOptions = {
        message: message,
        type: "error",
        isModal: isModal
    }

    $.appMessage(messageOptions);
}

/**
 * 
 * @param {} message 
 * @param {} isModal 
 * @returns {} 
 */
var messageWarning = function (message, isModal) {
    var messageOptions = {
        message: message,
        type: "warning",
        isModal: isModal
    }

    $.appMessage(messageOptions);
}

/**
 * 
 * @param {} message 
 * @param {} isModal 
 * @param {} yesButtonClicked 
 * @param {} noButtonClicked 
 * @returns {} 
 */
var messageConfirmDialog = function(message, isModal, yesButtonClicked, noButtonClicked) {
    var messageOptions = {
        message: message,
        type: "warning",
        isModal: isModal,
        isShowButtons: true,
        yesButtonClicked: yesButtonClicked,
        noButtonClicked: noButtonClicked
    }

    $.appMessage(messageOptions);
}

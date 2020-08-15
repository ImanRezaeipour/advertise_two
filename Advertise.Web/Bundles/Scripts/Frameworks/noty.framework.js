(function($) {
    $.appMessage = function(options) {

        // default options
        var defaults = {
            message: "",
            type: "success",
            isModal: false,
            isShowButtons: false,
            yesButtonClicked: function(){},
            noButtonClicked: function(){}
        }

        var settings = $.extend({}, defaults, options);

        // work on element
        var notyOptions = {
            layout: 'center',
            theme: 'mint',
            type: settings.type,
            text: settings.message,
            timeout: 3000,
            modal: settings.isModal,
            progressBar: true,
            animation: {
                open: 'noty_effects_open',
                close: 'noty_effects_close'
            }
        }

        var buttonOptions = [
            Noty.button('بله', 'button primary', function() {
                    notyResult.close();
                    settings.yesButtonClicked();
            }, { id: 'button1', 'data-status': 'ok' }),

            Noty.button('خیر', 'button secondary', function() {
                    notyResult.close();
                    settings.noButtonClicked();
            })];
        
        if (settings.isShowButtons === true)
            notyOptions.buttons = buttonOptions;

        var notyResult = new Noty(notyOptions).show();
    };
}(jQuery))
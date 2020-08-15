; (function ($) {
    $.fn.appCheckbox = function ($options) {

        var $self = this;
        var $elem = $(this);

        var $defaults = {

        }

        var $settings = $.extend({}, $defaults, $options);

        var $icheckOptions = {
            handle: '',
            checkboxClass: 'icheckbox icheckbox_flat-red',
            radioClass: 'iradio iradio_flat-red',
            checkedClass: 'checked',
            checkedCheckboxClass: '',
            checkedRadioClass: '',
            uncheckedClass: '',
            uncheckedCheckboxClass: '',
            uncheckedRadioClass: '',
            disabledClass: 'disabled',
            disabledCheckboxClass: '',
            disabledRadioClass: '',
            enabledClass: '',
            enabledCheckboxClass: '',
            enabledRadioClass: '',
            indeterminateClass: 'indeterminate',
            indeterminateCheckboxClass: '',
            indeterminateRadioClass: '',
            determinateClass: '',
            determinateCheckboxClass: '',
            determinateRadioClass: '',
            hoverClass: 'hover',
            focusClass: 'focus',
            activeClass: 'active',
            labelHover: true,
            labelHoverClass: 'hover',
            increaseArea: '',
            cursor: false,
            inheritClass: false,
            inheritID: false,
            aria: false,
            insert: ''
        };

        $($self).iCheck($icheckOptions);

        $($self).on('ifChanged', function(event) {
             $(event.target).trigger('change');
        });

        return $elem;
    }
}(jQuery))
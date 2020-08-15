; (function ($) {
    $.fn.appDropdown = function ($options) {
        var $self = this;
        var $elem = $(this);

        var $defaults = {
            data: [],
            value: "",
            multiple: false,
            tags: false,
            placeholder: "",
            hasRoot: false,
            relatedId: "",
            max: 100,
            onChanged: function(e) {}
        }

        var $settings = $.extend({}, $defaults, $options);

        function markMatch(text, term) {
            var match = text.toUpperCase().indexOf(term.toUpperCase());
            var $result = $('<span></span>');
            if (match < 0) {
                return $result.text(text);
            }
            $result.text(text.substring(0, match));
            var $match = $('<span class="select2-rendered__match"></span>');
            $match.text(text.substring(match, match + term.length));
            $result.append($match);
            $result.append(text.substring(match + term.length));
            return $result;
        }

        function matchCustom(params, data) {
            if ($.trim(params.term) === '') {
                return data;
            }
            if (typeof data.text === 'undefined') {
                return null;
            }
            if (data.text === null) {
                return null;
            }
            if (data.text.toUpperCase().indexOf(params.term.toUpperCase()) > -1) {
                var modifiedData = $.extend({}, data, true);
                modifiedData.text = markMatch(modifiedData.text, params.term)[0].innerHTML;
                return modifiedData;
            }
            return null;
        }

        function formatResult(node) {
            var $deep = node.level;
            if ($settings.hasRoot === false)
                $deep--;
            var $result = $('<span style="padding-right:' + (20 * $deep) + 'px;">' + node.text + '</span>');
            return $result;
        };

        var $select2Options = {
            placeholder: $settings.placeholder,
            dir: "rtl",
            language: "fa",
            allowClear: true,
            theme: "default",
            width: "resolve",
            multiple: $settings.multiple,
            tags: $settings.tags,
            data: $settings.data,
            maximumSelectionLength: $settings.max,
            formatSelection: function (item) {
                return item.text;
            },
            formatResult: function (item) {
                return item.text;
            },
            templateResult: formatResult,
            matcher: matchCustom
        };

        if ($settings.relatedId !== "") {
            var $filteredData = $.grep($settings.data, function (n, i) {
                    return n.related_id === $settings.relatedId;
            });
            $($self).empty();
            $select2Options.data = $filteredData;
        }

       $($self).select2($select2Options);

        if ($settings.value !== "") {
            $($self).val($settings.value).trigger("change");
        }

        $($self).on('select2:select select2:unselecting', function (e) {
            $settings.onChanged(e);
        });

        return $elem;
    }
}(jQuery))
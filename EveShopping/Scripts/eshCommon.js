ajaxLoader = {
    timer: 0,

    initTimer: function () {
        ajaxLoader.timer = setTimeout("$.blockUI({message: '<img src=\"../../content/images/ajax-loader4.gif\"/>', css: {backgroundColor: '#3A3A3A', border: '2px solid #1F4E66', padding: '10px 2em', width: '14%', left: '43%'}, overlayCSS: {opacity: '0.3'}})", 300);
    },

    endTimer: function () {
        clearTimeout(ajaxLoader.timer);
        $.unblockUI();
    },
}


accordionState = {

    initAccordion: function (acc, index) {
        $(function () { $(acc).accordion("destroy").accordion({ collapsible: true, active: false, heighStyle: "content", autoHeight: false, clearStyle: true }) });
        if (index != null) {
            $(acc).accordion({ active: index });
        }
    },

    disableAccordion: function (acc) {
        $(function () { $(acc).accordion("disable") });
    },

    enableAccordion: function (acc) {
        $(function () { $(acc).accordion("enable") });
    },

    openPanel: function (acc, idItem) {
        var index = accordionState.getIndex(acc, idItem);
        var currentActive = $(acc).accordion("option", "active");
        if (index !== currentActive) {
            $(acc).accordion({ active: index });
        }
    },

    getIndex: function (acc, idItem) {
        var items = $(acc).find('h3');
        var max = items.length;

        for (var i = 0; i < max; i++) {
            var item = items[i];
            if ($(item).data('esh-id') == idItem) {
                return i;
            }
        }
        return -1;
    }
}


$(document).ready(function () {
    $(function () { $('#help-container').accordion(); });
});

$(function () { $('#help-container').accordion(); });

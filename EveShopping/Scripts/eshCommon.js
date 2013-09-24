ajaxLoader = {
    timer: 0,

    initTimer: function () {
        ajaxLoader.timer = setTimeout("$('body').blockUI({message: '<img src=\"../../content/images/ajax-loader4.gif\"/>', css: {backgroundColor: '#3A3A3A', border: '2px solid #1F4E66', padding: '10px 2em', width: '14%', left: '43%'}, overlayCSS: {opacity: '0.3'}})", 300);
    },

    endTimer: function () {
        clearTimeout(ajaxLoader.timer);
        $('body').unblockUI();
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

infoDialog = {
    show: function (head, mainMessage, secondMessage) {
        $("#info-dialog-message").first().attr["title"] = head;
        $("#info-dialog-main-msg").text(mainMessage);
        $("#info-dialog-second-msg").text(secondMessage);
        $("#info-dialog-message").dialog({
            modal: true,
            buttons: {
                Ok: function () {
                    $(this).dialog("close");
                }
            }
        });
        $("#info-dialog-message").dialog("option", "position", "center");
        var width = $("#info-dialog-message").width();
        var height = $("#info-dialog-message").height();
        var wwidth = $(window).width();
        var wheight = $(window).height();

        //alert(width + '-' + height);
        //alert(wwidth + '-' + wheight);
        


    }
}


$(document).ready(function () {
    $(function () { $('#help-container').accordion(); });
});

$(function () { $('#help-container').accordion(); });

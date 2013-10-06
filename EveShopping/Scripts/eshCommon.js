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

eshFormats = {
    formatPrice: function (price) {
        if (price > 1000000) {
            return (price / 1000000).toFixed(2) + ' M';
        }
        if (price > 1000) {
            return (price / 1000).toFixed(2) + ' K';
        }
        return price.toFixed(2);
    },
    formatVolume: function (vol) {
        var ivol = Math.round(vol)
        if (ivol == vol) {
            return ivol + ' m3';
        }
        return vol.toFixed(2) + ' m3';
    },
    formatDelta: function (delta) {
        if (delta > 0) {
            return '+' + delta;
        }
        return delta;
    }
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

    openPanelByIndex: function (acc, index) {
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

function openEoghanInfo() {
    try {
        CCPEVE.showInfo(1377, 310338229);
    } catch (e) {
        window.open( "https://gate.eveonline.com/Profile/Eoghan%20Gorthaur");
    }
}


infoDialog = {
    warning: "warning",
    info: "info",
    error: "error",

    show: function (head, mainMessage, secondMessage, dialogType) {
        dialogType = typeof dialogType != 'undefined' ? dialogType : 'info';

        var dlgClass;

        switch (dialogType) {
            case 'info':
                dlgClass = 'simplemodal-container';
                break;
            case 'warning':
                dlgClass = 'simplemodal-container-warning';
                break;
            case 'error':
            default:
                dlgClass = 'simplemodal-container-error';
        }

        $("#info-dialog-header").text(head);
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
        //$('#basic-modal-content').addClass(dlgClass);
        $('#basic-modal-content').modal({ containerId: dlgClass });
    }
}

function setTotalPriceAndUnits() {
    var vol = 0;
    $('[data-esh-vol]').each(function () { vol += Number($(this).attr('data-esh-vol')); })

    var price = 0;
    $('[data-esh-price]').each(function () { price += Number($(this).attr('data-esh-price')); })
    var formated = null;
    if (price > 1000000) {
        price = price / 1000000;
        formated = ' M';
    }
    if (!formated && (price > 1000)) {
        price = price / 1000;
        formated = ' K';
    }
    price = price.toFixed(2);
    if (price > 0) {
        $('#total-price-vol').text(price + formated + ' - ' + vol + ' m3');
    }
    else {
        $('#total-price-vol').text('');
    }
}


$(document).ready(function () {
    $(function () { $('#help-container').accordion(); });
});

//<!-- UserVoice JavaScript SDK (only needed once on a page) -->
(function () { var uv = document.createElement('script'); uv.type = 'text/javascript'; uv.async = true; uv.src = '//widget.uservoice.com/VYaVaE1xxoHzV5L41ThF9A.js'; var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(uv, s) })();

//<!-- A tab to launch the Classic Widget -->
UserVoice = window.UserVoice || [];
UserVoice.push(['showTab', 'classic_widget', {
    mode: 'feedback',
    primary_color: '#cc6d00',
    link_color: '#007dbf',
    forum_id: 224281,
    tab_label: 'Feedback',
    tab_color: '#cc6d00',
    tab_position: 'middle-right',
    tab_inverted: false
}]);



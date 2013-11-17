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




$(document).ready(function () {
    $(document).ajaxStart(function () { ajaxLoader.initTimer(); });
    $(document).ajaxStop(function () { ajaxLoader.endTimer() });
    $(document).ajaxSuccess(function () { ajaxLoader.endTimer() });
    $(document).ajaxComplete(function () { ajaxLoader.endTimer(); try { accordionState.removeHeight(); } catch (ex) { } });
    $(document).ajaxError(function () { ajaxLoader.endTimer(); });
});

eshFormats = {
    formatNumber : function (number){
        var ivol = Math.round(number)
        if (ivol == number) {
            return eshFormats.addCommas(ivol);
        }
        return eshFormats.addCommas( vol.toFixed(2));
    },
    formatPrice: function (price) {
        if (price > 1000000) {
            return eshFormats.addCommas((price / 1000000).toFixed(2)) + ' M';
        }
        if (price > 1000) {
            return eshFormats.addCommas((price / 1000).toFixed(2)) + ' K';
        }
        return eshFormats.addCommas( price.toFixed(2));
    },
    formatVolume: function (vol) {
        var ivol = Math.round(vol)
        if (ivol == vol) {
            return ivol + ' m3';
        }
        return eshFormats.addCommas( vol.toFixed(2)) + ' m3';
    },
    formatDelta: function (delta) {
        if (delta > 0) {
            return '+' + eshFormats.addCommas(delta);
        }
        return eshFormats.addCommas( delta);
    },

    addCommas : function (nStr)
    {
        nStr += '';
        x = nStr.split('.');
        x1 = x[0];
        x2 = x.length > 1 ? '.' + x[1] : '';
        var rgx = /(\d+)(\d{3})/;
        while (rgx.test(x1)) {
            x1 = x1.replace(rgx, '$1' + ',' + '$2');
        }
        return x1 + x2;
    }
}

eveapi = {
    openMarketDatailsWindow: function (id) {
        try {
            CCPEVE.showMarketDetails(id);
        } catch (e) {
            $(function () {
                infoDialog.show(
                    "Market not available in this browser"
                    , "You can access market details for the items only from EVE Online browser."
                    , "Clicking in this link from in game browser will open market details window.");
            });
        }
    },

    openFitWindow: function(dna){
        try {
            CCPEVE.showFitting(dna);
        } catch (e) {
            $(function () {
                infoDialog.show(
                    "Not using EVE Online's ingame browser.", null
                    , "To export your fitting to the EVE client you need to be using the ingame browser.");
            });
        }
    }
}

general = {
    authenticated: false,

    setEnter: function (idSender, idDest) {
        $(idSender).keyup(function (event) {
            if (event.keyCode == 13) {
                $(idDest).click();
            }
        });

    }
}
    


accordionState = {

    initAccordion: function (acc, index) {
        $(function () {
            try {
                $(acc).accordion("destroy");
                accordionState.removeHeight();
            }
            catch (ex){
            }
            $(acc).accordion({ collapsible: true, active: false, autoHeight: false, clearStyle: true })
        });
        if (index != null) {
            $(acc).accordion({ collapsible: true, active: false, autoHeight: false, clearStyle: true, active: index });
        }

    },

    removeHeight: function(){
        var style = $(".ui-accordion-content").css("height", "100%");

    },

    disableAccordion: function (acc) {
        $(function () { $(acc).accordion("disable") });
    },

    enableAccordion: function (acc) {
        $(function () { $(acc).accordion("enable"); accordionState.removeHeight(); });
        
    },

    openPanel: function (acc, idItem) {
        accordionState.removeHeight();
        var index = accordionState.getIndex(acc, idItem);
        var currentActive = $(acc).accordion("option", "active");
        if (index !== currentActive) {
            $(acc).accordion({ active: index });
        }
    },

    openPanelByIndex: function (acc, index) {
        accordionState.removeHeight();
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

function joinEveShoppingChannel() {
    try {
        CCPEVE.joinChannel("eve-shopping");
    } catch (e) {
        $(function () {
            infoDialog.show(
                "Can't join an EVE channel in this browser"
                , "You can join an in-game EVE channel only from EVE Online browser."
                , "Clicking in this link from in game browser will join you to eve-shopping channel.");
        });
    }
}

function openEoghanInfo() {
    try {
        CCPEVE.showInfo(1377, 310338229);
    } catch (e) {
        window.open( "https://gate.eveonline.com/Profile/Eoghan%20Gorthaur");
    }
}

menuCounters = {
    incFittings: function (units) {
        if (typeof units === "undefined") {
            units = 1;
        }
        actual = parseInt($("#fittingCount").text());
        actual += units;
        $("#fittingCount").text(actual)
    },
    decFittings: function (units) {
        if (typeof units === "undefined") {
            units = 1;
        }
        actual = parseInt($("#fittingCount").text());
        actual -= units;
        $("#fittingCount").text(actual)
    },
    incLists: function (units) {
        if (typeof units === "undefined") {
            units = 1;
        }
        actual = parseInt($("#listCount").text());
        actual += units;
        $("#listCount").text(actual)

    },
    decLists: function (units) {
        if (typeof units === "undefined") {
            units = 1;
        }
        actual = parseInt($("#listCount").text());
        actual -= units;
        $("#listCount").text(actual)
    }
}

function confirm(message, callback) {
    $('#confirm').modal({
        closeHTML: "<a href='#' title='Close' class='modal-close'>x</a>",
        position: ["20%", ],
        overlayId: 'confirm-overlay',
        containerId: 'confirm-container',
        onShow: function (dialog) {
            var modal = this;

            $('.message', dialog.data[0]).append(message);

            // if the user clicks "yes"
            $('.yes', dialog.data[0]).click(function () {
                // call the callback
                if ($.isFunction(callback)) {
                    callback.apply();
                }
                // close the dialog
                modal.close(); // or $.modal.close();
            });
        }
    });
}

confirmDialog = {
    show: function (message, callback) {
        $('#confirm').modal({
            closeHTML: "<a href='#' title='Close' class='modal-close'>x</a>",
            position: ["20%", ],
            overlayId: 'confirm-overlay',
            containerId: 'confirm-container',
            onShow: function (dialog) {
                var modal = this;

                $('.message', dialog.data[0]).append(message);

                // if the user clicks "yes"
                $('.yes', dialog.data[0]).click(function () {
                    // call the callback
                    if ($.isFunction(callback)) {
                        callback.apply();
                    }
                    // close the dialog
                    modal.close(); // or $.modal.close();
                });
            }
        });

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
        var msg = ""
        if (mainMessage != null) {
            msg += '<p>' + mainMessage + "</p><p>";
        }
        msg += secondMessage;
        if (mainMessage != null) {
            msg += "</p>";
        }
        //$("#info-dialog-main-msg").html(mainMessage);
        $("#info-dialog-second-msg").html(msg);
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
    
    if (price > 0) {
        $('#total-price-vol').text( eshFormats.formatPrice(price) + ' - ' + eshFormats.formatVolume(vol));
    }
    else {
        $('#total-price-vol').text('');
    }
}


$(document).ready(function () {
    if ($('#help-container').length > 0) {
        $(function () { $('#help-container').accordion(); });
    }
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



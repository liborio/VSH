/// <reference path="eshCommon.js" />

$(function () {
    $('#summary-table').footable();
    $('.footable').data('page-size', 20);
});

$(function () {
    $('#help-container').show();
    $('#help-container').show().accordion({ collapsible: true, active: false, heighStyle: "content", autoHeight: false, clearStyle: true });
});

function onSuccessSaveShoppingListHeader(data) {
    var name = $('#slName').val();
    $('#hListName').text(name);
}

function openMarketDatailsWindow(id) {
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
}

function cleanEdits() {
    $('[data-esh-row-edit]').remove();
    $('.row-edit').removeClass('row-edit');
    $('[data-esh-id]').find('a').show();
}


function editItemInSummary(id) {
    cleanEdits();
    var row = $('[data-esh-id="' + id + '"]');

    $(row).addClass('row-edit')
    $(row).find('a').hide()
    var units = $(row).find('[data-esh-cdelta]').data('esh-cdelta');

    var filaControlesEdicion = "<tr class='fila-impar' data-esh-row-edit><td colspan='5' class='col-edit'><span><a onclick=\"setDeltaInSummary('" + id + "')\">Set</a><input data-esh-units type='number' value='" + units + "'>units to add (negative number will remove units from totals)</span><span><a onclick=\"cancelEditSummary('" + id + "')\">Close edit</a></span>"
    $(filaControlesEdicion).insertAfter(row)

    var inputRows = $(filaControlesEdicion).find('input:text');
    $(inputRows).focus(function () { $(this).select(); });
    $(inputRows).focus();
}

function cancelEditSummary(id) {
    cleanEdits();
}

function setDeltaInSummary(id) {
    var units = $('[data-esh-row-edit]').find('[data-esh-units]').val();
    updateDeltaInSummary(id, onSuccessUpdateDeltaInSummary, units)
}

function onSuccessUpdateDeltaInSummary(data) {
    var newdelta = parseInt( $('[data-esh-row-edit]').find('[data-esh-units]').val());
    var row = $('.row-edit').first();
    var units = parseInt( $(row).find('[data-esh-cunits]').data('esh-cunits') );
    var volume = parseFloat($(row).find('[data-esh-cvolume]').data('esh-cvolume'));
    var price = parseFloat( $(row).find('[data-esh-cprice]').data('esh-cprice') );

    if ((newdelta < 0) && (newdelta * -1 > units)) {
        newdelta = units * -1;
    }    
    var newunits = units + newdelta;
    //update info in screen
    $(row).find('[data-esh-cunits]').text("x " + newunits);
    $(row).find('[data-esh-cprice]').text(eshFormats.formatPrice(price * newunits));
    $(row).find('[data-esh-cvolume]').text(eshFormats.formatVolume(volume * newunits));
    $(row).find('[data-esh-cdelta]').text(eshFormats.formatDelta(newdelta));
    //update data info
    $(row).find('[data-esh-cdelta]').data('esh-cdelta', newdelta);
    $(row).find('[data-esh-cdelta]').data('value', newdelta);
    $(row).find('[data-esh-cunits]').data('value', newunits);
    $(row).find('[data-esh-cvolume]').data('value', volume * newunits);
    $(row).find('[data-esh-cprice]').data('value', price * newunits);
    //update header
    var totalPrice = 0;
    $('[data-esh-cprice]').each(
        function () {
            totalPrice += parseFloat($(this).data('value'));
        });
    var totalVolume = 0;
    $('[data-esh-cvolume]').each(
        function () {
            totalVolume += parseFloat($(this).data('value'));
        });
    $('#total-price-vol').text(eshFormats.formatPrice(totalPrice) + ' - ' + eshFormats.formatVolume(totalVolume));

    cleanEdits();
}

function updateDeltaInSummary(id, funcSuccess, units) {
    $.ajax({
        type: 'POST',
        url: '/Lists/UpdateDeltaInSummary',
        context: id,
        success: funcSuccess,
        data: { id: id, units: units },
        dataType: 'html'
    });
}

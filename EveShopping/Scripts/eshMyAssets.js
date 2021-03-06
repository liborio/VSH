﻿/// <reference path="eshCommon.js" />

$(function () {
    $('#summary-table').footable();
    $('.footable').data('page-size', 20);
});

$(document).ready(function () {
    $("#idAnalyseBtn").click(function () {
        analyseAssets($("#rawAssets").val())
    });
    $('#help-container div').show();
    $('#help-container').show().accordion({ collapsible: true, active: false, heighStyle: "content", autoHeight: false, clearStyle: true });

});

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
    var units = $(row).find('[data-esh-cdelta]').attr('data-esh-cdelta');

    var filaControlesEdicion = "<tr class='fila-impar' data-esh-row-edit><td colspan='7' class='col-edit'><span><a onclick=\"setDeltaInSummary('" + id + "')\">Set</a><input data-esh-units type='number' value='" + units + "'>units to add (negative number will remove units from totals)</span>"
        + "<span><a onclick=\"adjustDelta('" + id + "')\" >Adjust to x0 units</a></span>"
        + "<span><a onclick=\"clearDelta('" + id + "')\" >Clear (+ / -)</a></span>"
        + "<span><a onclick=\"cancelEditSummary('" + id + "')\">Close edit</a></span>"
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
    updateDeltaInSummary(id, onSuccessUpdateDeltaInSummary, units);
}

function adjustDelta(id) {
    var units = $('[data-esh-row-edit]').prev().find("[data-esh-ounits]").attr("data-value");
    units = parseInt(units) * -1;
    $('[data-esh-row-edit]').find('[data-esh-units]').val(units);
    setDeltaInSummary(id);
}

function clearDelta(id) {
    $('[data-esh-row-edit]').find('[data-esh-units]').val(0);
    setDeltaInSummary(id);
}


function onSuccessUpdateDeltaInSummary(data) {
    var newdelta = parseInt($('[data-esh-row-edit]').find('[data-esh-units]').val());
    var row = $('.row-edit').first();
    var units = parseInt($(row).find('[data-esh-cunits]').data('esh-cunits'));

    if ((newdelta < 0) && (newdelta * -1 > units)) {
        newdelta = units * -1;
    }

    calculateCommonRowDelta(row, newdelta);
    recalculateTotalsInSummaryHeader();
    cleanEdits();
}

function calculateCommonRowDelta(row, newdelta) {
    newdelta = parseInt(newdelta);
    var units = parseInt($(row).find('[data-esh-cunits]').data('esh-cunits'));
    var newunits = units + newdelta;
    var volume = parseFloat($(row).find('[data-esh-cvolume]').data('esh-cvolume'));
    var price = parseFloat($(row).attr("data-esh-uprice")); //.find('[data-esh-cprice]').data('esh-cprice'));
    //update info in screen
    $(row).find('[data-esh-cunits]').text("x" + eshFormats.formatNumber(newunits));
    $(row).find('[data-esh-cprice]').text(eshFormats.formatPrice(price * newunits));
    $(row).find('[data-esh-cvolume]').text(eshFormats.formatVolume(volume * newunits));
    $(row).find('[data-esh-cdelta]').text(eshFormats.formatDelta(newdelta));
    //update data info
    $(row).attr('data-esh-delta', newdelta);
    $(row).find('[data-esh-cdelta]').attr('data-esh-cdelta', newdelta);
    $(row).find('[data-esh-cdelta]').attr('data-value', newdelta);
    $(row).find('[data-esh-cunits]').data('value', newunits);
    $(row).find('[data-esh-cvolume]').data('value', volume * newunits);
    $(row).find('[data-esh-cprice]').data('value', price * newunits);
}

function recalculateTotalsInSummaryHeader() {
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

function clearAllDelta(id) {
    confirmDialog.show("Are you sure to clear all (+ / -) defined in the summary?", function () { clearAllDeltaConfirmed(id); });
}

function clearAllDeltaConfirmed(id) {
    $.ajax({
        type: 'POST',
        url: '/Lists/clearAllDelta',
        context: id,
        success: onSuccessClearAllDelta,
        error: onErrorClearAllDelta,
        data: { id: id },
        dataType: 'html'
    });
}

function onSuccessClearAllDelta(data) {
    $('#summary-table').find("tr[data-esh-id]").each(
        function () {
            calculateCommonRowDelta(this, 0);
        }
    )
    recalculateTotalsInSummaryHeader();
}

function onErrorClearAllDelta(data) {
    infoDialog.show("Couldn't clear all the (+ / -)", "There was a problem clearing the (+ / -).", data.statusText, infoDialog.warning);
}

// Analyse assets ///////////////////////////////////

function onSuccessAnalyseAssets(data) {
    $('#analyseResult').replaceWith(data);
    $('#analyse-result-table').footable();
    $("#rawAssets").val("");
}
function analyseAssets(text) {
    $.ajax({
        type: 'POST',
        url: '/lists/AnalyseAssetsForDeltas',
        success: onSuccessAnalyseAssets,
        data: {rawAssets: text},
        dataType: 'html'
    });
}

function useAllAssets() {
    var salida = [];
    $("#analyse-result-table tbody tr").each(function () { salida.push({ id: $(this).attr("data-esh-id"), units: $(this).attr("data-esh-units") }); });
    useAssetsForDelta(salida);
}

function useAsset(_id, _units) {
    var salida = [];
    salida.push({ id: _id, units: _units });
    useAssetsForDelta(salida);
}

function useAssetsForDelta(deltas) {
    $.ajax({
        type: 'POST',
        url: '/lists/UseAssetsForDeltas',
        success: onSuccessUseAssetsForDelta,
        data: { deltas: deltas },
        dataType: 'html',
        context: deltas
    });
}

function onSuccessUseAssetsForDelta(data) {
    $(this).each(function () {
        $("#analyse-result-table").find('[data-esh-id="' + $(this).attr("id") + '"]').remove();
        updateDeltaInSummaryAfterUsingAnalysed($(this).attr("id"), $(this).attr("units"));
    });
    if ($("#analyse-result-table tr[data-esh-id]").length <= 0) {
        $("#analyse-result-table").remove();
    }

}

function updateDeltaInSummaryAfterUsingAnalysed(id, addedunits) {
    var row = $("#summary-table tr[data-esh-id='" + id + "'");
    var newdelta = parseInt($(row).attr("data-esh-delta")) + parseInt( addedunits);

    var units = parseInt($(row).find('[data-esh-cunits]').data('esh-cunits'));

    if ((newdelta < 0) && (newdelta * -1 > units)) {
        newdelta = units * -1;
    }

    calculateCommonRowDelta(row, newdelta);
    recalculateTotalsInSummaryHeader();
    cleanEdits();
}
/// <reference path="eshCommon.js" />

$(document).ready(function () {
    $('#help-container div').hide();
});

$("#rawFit").keyup(function (event) {
    if (event.keyCode == 13) {
        $("#idAnalyseBtn").click();
    }
});

$(function () {
    $('#help-container div').show();
    $('#help-container').show().accordion({ collapsible: true, active: false, heighStyle: "content", autoHeight: false, clearStyle: true });
});


//////////////////////////////  import fittings
function ReactivateImportedFitsAccordion() {
    accordionState.initAccordion($("#fitsAnalysed"))
    $("#rawFit").val('');
}
function onFailureAnalyzeRawFit(data) {
    infoDialog.show("Could'nt analyse fit", "There was a problem analysing your fit.", data.statusText, infoDialog.warning);
}
//////////////////////////////

/// personal fits navigation
function OnSuccessNavigateMarketGroup(data) {
    $('[data-esh-marketMenu]').replaceWith(data);
    accordionState.initAccordion($('#fitsInList'));
}

function navigateMarketGroup(id) {
    $.ajax({
        url: '/Fittings/NavigateMarketGroup/' + id,
        success: OnSuccessNavigateMarketGroup,
        dataType: 'html'
    });
}

/// Use analysed fit
function OnSuccessUseAnalysedFit(data) {
    $("#personal-fittings-menu").find(".menu-market").replaceWith(data);

    var name = $("[data-esh-context-selfitname]").data("esh-context-selfitname");
    $('[data-esh-analysed-fits]').children('[data-esh-name = "' + name + '"]').remove();

    var id = $("[data-esh-context-selfitname]").data("esh-context-selfitid");
    accordionState.initAccordion($('#fitsInList'));
    accordionState.openPanel($('#fitsInList'), id);

    menuCounters.incFittings();
}

function OnErrorUseAnalysedFit(data) {
}


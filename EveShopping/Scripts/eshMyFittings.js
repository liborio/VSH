/// <reference path="eshCommon.js" />

$(document).ready(function () {
    $('#help-container div').hide();
});


function regenerateModifyLinks() {
    $("[data-esh-del-fit-link]").click(function () {
        var id = $(this).parents("h3").attr("data-esh-id");
        deleteFitting(id);
    });
}

$("#rawFit").keyup(function (event) {
    if (event.keyCode == 13) {
        $("#idAnalyseBtn").click();
    }
});

$(function () {
    $('#help-container div').show();
    $('#help-container').show().accordion({ collapsible: true, active: false, heighStyle: "content", autoHeight: false, clearStyle: true });
});


//////////////////////////////

/// personal fits navigation
function OnSuccessNavigateMarketGroup(data) {
    $('[data-esh-marketMenu]').replaceWith(data);
    accordionState.initAccordion($('#fitsInList'));
    regenerateModifyLinks();
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
    infoDialog.show("Could'nt use fit", "There was a problem adding the fit to your shopping list.", data.statusText, infoDialog.warning);
}

/// CRUD
function delFitInShoppingList(id) {
    confirmDialog.show("Are you sure to delete the fit from your personal fittings?", function () { confirmedDeleteFitting(id); });
}

function confirmedDeleteFitting(id) {
    $.ajax({
        type: 'POST',
        url: '/Fittings/DeleteFitting',
        context: id,
        success: onSuccessDeleteFitting,
        error: onErrorDeleteFitting,
        data: { id: id },
        dataType: 'html'
    });
}

function onErrorDeleteFitting(data) {
    infoDialog.show("Couldn't delete the fitting", "There was a problem deleting your fitting.", data.statusText, infoDialog.warning);
}

function onSuccessDeleteFitting(data) {
    var id = this;
    $("#personal-fittings-menu").find("[data-esh-id='" + id + "']").remove();
    menuCounters.decFittings();
}



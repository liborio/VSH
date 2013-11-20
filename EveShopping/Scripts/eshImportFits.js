/// <reference path="jquery-1.8.2.js" />
/// <reference path="jquery-ui-1.8.24.js" />
/// <reference path="eshCommon.js" />




$(document).ready(function () {
    $('#help-container div').hide();
});

$("#rawFit").keyup(function (event) {
    if (event.keyCode == 13) {
        $("#idAnalyseBtn").click();
    }
});

//$(function () {
//    $('#help-container div').show();
//    $('#help-container').show().accordion({ collapsible: true, active: false, heighStyle: "content", autoHeight: false, clearStyle: true });
//});


//if (general.authenticated) {
//    accordionState.initAccordion($('#import-fits-accordion'), 1);
//    accordionState.openPanelByIndex($('#import-fits-accordion'), 1);
//}


$(document).ready(function () {
    $('.header-container').find('a').removeClass('selected');
    $('.header-container').find('#navlink_newList').addClass('selected');
    accordionState.initAccordion($('#fitsInList'));
    accordionState.initAccordion($('#myFitList'));

    if (general.authenticated) {
        accordionState.initAccordion($('#import-fits-accordion'), 1);
        accordionState.openPanelByIndex($('#import-fits-accordion'), 1);
    }

    $('#help-container div').show();
    $('#help-container').show().accordion({ collapsible: true, active: false, heighStyle: "content", autoHeight: false, clearStyle: true });

    if (general.authenticated) {
        accordionState.initAccordion($('#import-fits-accordion'), 1);
        accordionState.openPanelByIndex($('#import-fits-accordion'), 1);
    }

});




function OnSuccessUseAnalysedFit(data) {
    $("#fitsInList").prepend(data);
    //$(data).prependTo($("#fitsInList").first());
    //var name = $(data).first().attr('data-esh-name');
    var name = $("#fitsInList").find("[data-esh-id]").first().attr("data-esh-name");
    $('[data-esh-analysed-fits]').children('[data-esh-name = "' + name + '"]').remove();
    accordionState.initAccordion($('#fitsInList'), 0);
    menuCounters.incFittings();
    setTotalPriceAndUnits();
}


function OnSuccessDeleteFitFromList() {
    $('#fitsInList').children('[data-esh-id = "' + this + '"]').remove();
    accordionState.initAccordion($('#fitsInList'));
    cleanEdits();
    setTotalPriceAndUnits();
}

function onSetUnitsInShoppingListSuccess(data) {
    var id = this;
    var fitsContainer = $('#fitsInList');
    $(fitsContainer).find('[data-esh-id = ' + id + '] + div').remove();
    //$(data).replaceAll($('#fitsInList').find('[data-esh-id = ' + id + ']'));
    $('#fitsInList').find('[data-esh-id = ' + id + ']').replaceWith(data);
    accordionState.initAccordion($('#fitsInList'));
    accordionState.openPanel($('#fitsInList'), id);
    cleanEdits();
    setTotalPriceAndUnits();
}


    function editFitInShoppingList(id) {
        cleanEdits();
        var row = $('#fitsInList').find('[data-esh-id="' + id + '"]').find('tr').first();
        var units = $('#fitsInList').find('h3[data-esh-id="' + id + '"]').data('esh-units')
        $(row).addClass('row-edit');

        $('#fitsInList').find('[data-esh-edit-link]').hide();
        $('#fitsInList').find('[data-esh-del-fit-link]').hide();
        var filaControlesEdicion = "<tr class='fila-impar' data-esh-row-edit><td colspan='4' class='col-edit'><span><input  data-esh-units type='number' min='1' value='" + units + "'>units</span><span><a onclick=\"setUnitsItemInShoppingList('" + id + "')\">Save</a></span><span><a onclick=\"cancelEditItemInShoppingList('" + id + "')\">Cancel edit</a></span>";
        var filaControlesAdd = "<tr class='fila-impar' data-esh-row-edit><td colspan='5' class='col-edit'><div style='float: left;'><div><span><a onclick=\"addUnitsItemInShoppingList(1)\">+1</a></span></div><div><span><a onclick=\"addUnitsItemInShoppingList(-1)\">-1</a></span></div></div><div style='float: left;'><div><span><a onclick=\"addUnitsItemInShoppingList(10)\">+10</a></span></div><div><span><a onclick=\"addUnitsItemInShoppingList(-10)\">-10</a></span></div></div><div style='float: left;'><div><span><a onclick=\"addUnitsItemInShoppingList(100)\">+100</a></span></div><div><span><a onclick=\"addUnitsItemInShoppingList(-100)\">-100</a></span></div></div>"

        $(filaControlesEdicion).insertBefore(row);
        $(filaControlesAdd).insertBefore(row);

        var acc = $('#fitsInList');

        accordionState.openPanel(acc, id);

        accordionState.disableAccordion(acc);
        //$(function () { $('#fitsInList').accordion("disable")});

        var inputRows = $(filaControlesEdicion).find('input:text');
        $(inputRows).focus(function () { $(this).select(); });
        $(inputRows).focus();
        $(inputRows).spinner();

        //$('[data-esch-marketitemsinshoppinglist]').find('[data-esh-row-edit]').find('input:text').focus();
    }

    function addUnitsItemInShoppingList(units) {
        var unidades = parseInt($("input[data-esh-units]").val());
        unidades += units;
        if (unidades < 0) {
            unidades = 0;
        }
        $("input[data-esh-units]").val(unidades);
    }

    function delFitInShoppingList(id) {
        confirmDialog.show("Are you sure to delete the fit from your shopping list?", function () { deleteItemInShoppingList(id); });
    }


    function disableFitInShoppingListPanels() {
        accordionState.disableAccordion($("#fitsAnalysed"));
    }

    function setUnitsItemInShoppingList(id) {

        var units = $('#fitsInList').find('[data-esh-id=' + id + '] + div').find('[data-esh-units]').val();
        $.ajax({
            type: 'POST',
            url: '/Lists/SetUnitsToFitInShoppingList',
            context: id,
            success: onSetUnitsInShoppingListSuccess,
            data: { id: id, units: units },
            dataType: 'html'
        });
    }

    function deleteItemInShoppingList(id) {
        $.ajax({
            url: '/Lists/DeleteFittingFromShoppingList/' + id,
            context: id,    
            success: OnSuccessDeleteFitFromList,
            dataType: 'html'
        });
    }




/// personal fits navigation
    function OnSuccessNavigateMarketGroup(data) {
        $('[data-esh-marketMenu]').replaceWith(data);
        accordionState.initAccordion($('#myFitList'));
    }

    function navigateMarketGroup(id) {
        $.ajax({
            url: '/Lists/NavigateMyFittingsMenu/' + id,
            success: OnSuccessNavigateMarketGroup,
            dataType: 'html'
        });
    }

    function onSuccessUseFitInMyList(data) {
        $("#fitsInList").prepend(data);
        //$(data).prependTo( $("#fitsInList"));
        accordionState.initAccordion($("#fitsInList"), 0);
        setTotalPriceAndUnits();
    }



    function useFitInMyList(id) {
        $.ajax({
            url: '/Lists/UseFitInMyList/' + id,
            success: onSuccessUseFitInMyList,
            error: OnErrorUseAnalysedFit,
            dataType: 'html'
        });
    }

    function OnErrorUseAnalysedFit(data) {
        infoDialog.show("Could'nt use fit", "There was a problem adding the fit to your shopping list.", data.statusText, infoDialog.warning);
    }

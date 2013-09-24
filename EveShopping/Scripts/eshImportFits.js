/// <reference path="jquery-1.8.2.js" />
/// <reference path="jquery-ui-1.8.24.js" />
/// <reference path="eshCommon.js" />





$(document).ready(function () {
    $('#help-container div').hide();

});

$(document).ajaxStart(ajaxLoader.initTimer)
   .ajaxStop(ajaxLoader.endTimer);

$(function () {
    $('#help-container div').show();
    $('#help-container').show().accordion({ collapsible: true, active: false, heighStyle: "content", autoHeight: false, clearStyle: true });
});


$(document).ready(function () {
    $('.header-container').find('a').removeClass('selected');
    $('.header-container').find('#navlink_newList').addClass('selected');
    accordionState.initAccordion($('#fitsInList'));
});


function ReactivateImportedFitsAccordion() {
    accordionState.initAccordion($("#fitsAnalysed"))
    //$(function () { $("#fitsAnalysed").accordion({ collapsible: true, active: false, heighStyle: "content", autoHeight: false, clearStyle: true }) });
}

function OnSuccessUseAnalysedFit(data) {
    $(data).prependTo($("[data-esh-fits-in-list]").first());
    var name = $(data).first().attr('data-esh-name');
    $('[data-esh-analysed-fits]').children('[data-esh-name = "' + name + '"]').remove();
    accordionState.initAccordion($('#fitsInList'), 0);
    setTotalPriceAndUnits();
}

function OnSuccessDeleteFitFromList() {
    $('[data-esh-fits-in-list]').children('[data-esh-id = "' + this + '"]').remove();
    accordionState.initAccordion($('#fitsInList'));
    cleanEdits();
    setTotalPriceAndUnits();
}

function onSetUnitsInShoppingListSuccess(data) {
    var id = this;
    var fitsContainer = $('[data-esh-fits-in-list]');
    $(fitsContainer).find('[data-esh-id = ' + id + '] + div').remove();
    $(data).replaceAll('[data-esh-id = ' + id + ']');
    
    accordionState.initAccordion($('#fitsInList'));
    accordionState.openPanel($('#fitsInList'), id);
    cleanEdits();
    setTotalPriceAndUnits();
}



function cleanEdits() {
    $('[data-esh-fits-in-list]').find('[data-esh-row-edit]').remove();
    $('[data-esh-fits-in-list]').find('[data-esh-edit-link]').show();
}

    function editFitInShoppingList(id) {
        cleanEdits();
        var row = $('[data-esh-fits-in-list]').find('[data-esh-id="' + id + '"]').find('tr').first();
        var units = $('[data-esh-fits-in-list]').find('h3[data-esh-id="' + id + '"]').data('esh-units')
        $(row).addClass('row-edit');

        $('[data-esh-fits-in-list]').find('[data-esh-edit-link]').hide();
        var filaControlesEdicion = "<tr class='fila-impar' data-esh-row-edit><td colspan='4' class='col-edit'><span><a onclick=\"setUnitsItemInShoppingList('" + id + "')\">Set</a> <input data-esh-units type='text' value='" + units + "'>units</span><span><a onclick=\"deleteItemInShoppingList('" + id + "')\">Delete</a></span><span><a onclick=\"cancelEditItemInShoppingList('" + id + "')\">Close edit</a></span>";
        $(filaControlesEdicion).insertBefore(row);

        var acc = $('#fitsInList');

        accordionState.openPanel(acc, id);

        accordionState.disableAccordion(acc);
        //$(function () { $('#fitsInList').accordion("disable")});

        $(filaControlesEdicion).find('input:text').focus(function () { $(this).select(); });
        $('[data-esh-fits-in-list]').find('[data-esh-row-edit]').find('input:text').focus();
        //$('[data-esch-marketitemsinshoppinglist]').find('[data-esh-row-edit]').find('input:text').focus();
    }

    function disableFitInShoppingListPanels() {
        accordionState.disableAccordion($("#fitsAnalysed"));
    }

    function cancelEditItemInShoppingList(id) {
        cleanEdits();
        accordionState.enableAccordion($('#fitsInList'));
    }

    function setUnitsItemInShoppingList(id) {

        var units = $('[data-esh-fits-in-list]').find('[data-esh-id=' + id + '] + div').find('[data-esh-units]').val();
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



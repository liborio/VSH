/// <reference path="jquery-1.8.2.js" />
/// <reference path="jquery-ui-1.8.24.js" />



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

$(document).ajaxStart(ajaxLoader.initTimer)
   .ajaxStop(ajaxLoader.endTimer);



function initAccordion(acc) {
    $(function () { $(acc).accordion({ collapsible: true, active: false, heighStyle: "content", autoHeight: false, clearStyle: true }) });
}

function disableAccordion(acc) {
    $(function () { $(acc).accordion("disable") });
}

function enableAccordion(acc) {
    $(function () { $(acc).accordion("enable") });
}


$(document).ready(function () {
    $('.header-container').find('a').removeClass('selected');
    $('.header-container').find('#navlink_newList').addClass('selected');
    //$(function () { $('#fitsInList').accordion({ collapsible: true , active: false, heighStyle:"content", autoHeight: false, clearStyle: true}) });
    initAccordion($('#fitsInList'));
});


//function eshImportFits() {
//    $(function () {
//        $("#fitsAnalysed").accordion({ collapsible: true , active: false})});
//    };
//}

function ReactivateImportedFitsAccordion() {
    initAccordion($("#fitsAnalysed"))
    //$(function () { $("#fitsAnalysed").accordion({ collapsible: true, active: false, heighStyle: "content", autoHeight: false, clearStyle: true }) });
}

function OnSuccessUseAnalysedFit(data){
    $(data).prependTo($("[data-esh-fits-in-list]").first());
    var name = $(data).first().attr('data-esh-name');
    $('[data-esh-analysed-fits').children('[data-esh-name = "' + name + '"]').remove();
    initAccordion($('#fitsInList'));
    //$(function () { $('#fitsInList').accordion({ collapsible: true, active: false, heighStyle: "content", autoHeight: false, clearStyle: true }) });
}

function OnSuccessDeleteFitFromList() {    
    $('[data-esh-fits-in-list').children('[data-esh-id = "' + this + '"]').remove();
}

function onSetUnitsInShoppingListSuccess(data) {
    var id = this;
    var fitsContainer = $('[data-esh-fits-in-list');
    $(fitsContainer).find('[data-esh-id = ' + id + '] + div').remove();
    $(data).replaceAll('[data-esh-id = '+ id + ']');
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
    
    disableAccordion($('#fitsInList'));
    //$(function () { $('#fitsInList').accordion("disable")});

    $(filaControlesEdicion).find('input:text').focus(function () { $(this).select(); });
    $('[data-esh-fits-in-list]').find('[data-esh-row-edit]').find('input:text').focus();
    //$('[data-esch-marketitemsinshoppinglist]').find('[data-esh-row-edit]').find('input:text').focus();
}

function disableFitInShoppingListPanels() {
    disableAccordion($("#fitsAnalysed"));
}

function cancelEditItemInShoppingList(id) {
    cleanEdits();
    enableAccordion($('#fitsInList'));
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



/// <reference path="jquery.blockUI.js" />


var thread = null;

function findMember(t) {
    alert(t);
}

$(document).ready(function () {
    $('.header-container').find('a').removeClass('selected');
    $('.header-container').find('#navlink_newList').addClass('selected');
    accordionState.initAccordion($('#market-items-accordion'));


    $('#searchText').keyup(function () {
        if ($(this).val().length >= 5) {
            clearTimeout(thread);
            var $this = $(this); thread = setTimeout(function () { searchMarketItem($this.val()) }, 500);
        }
    });
});

 ajaxLoader = {
    timer : 0,

    initTimer : function(){
        ajaxLoader.timer = setTimeout("$.blockUI({message: '<img src=\"../../content/images/ajax-loader4.gif\"/>', css: {backgroundColor: '#3A3A3A', border: '2px solid #1F4E66', padding: '10px 2em', width: '14%', left: '43%'}, overlayCSS: {opacity: '0.3'}})", 300);
    },

    endTimer : function ()  {
        clearTimeout(ajaxLoader.timer);
        $.unblockUI();
    },
}

$(document).ajaxStart(ajaxLoader.initTimer)
   .ajaxStop(ajaxLoader.endTimer);


function OnSuccessNavigateMarketGroup(data) {
    $('[data-esh-marketMenu]').replaceWith(data);
}


function AddOrReplaceItemInShoppingList(data, id, inEdit) {
    var itemTable = $('[data-esch-marketItemsInShoppingList]');
    var existeItem = $(itemTable).find('[data-esh-id="' + id + '"]').length > 0;
    if ($(itemTable).find("[data-esh-id]").length == 0) {
        $(itemTable).append(data);
    }
    else {
        if (!existeItem) {
            $(data).insertBefore(itemTable.find('tr').first());
        }
        else {
            $(data).replaceAll(itemTable.find('[data-esh-id="' + id + '"]'));
        }
        if (inEdit) {
            itemTable.find('[data-esh-id="' + id + '"]').addClass('row-edit');
        }
    }
}

function OnSuccessAddItemToShoppingList(data) {
    AddOrReplaceItemInShoppingList(data, this, false);
}

function onSuccessUpdateItemToShoppingList(data) {
    AddOrReplaceItemInShoppingList(data, this, true);
    cancelEditItemInShoppingList(this);
}

function onSuccessSearchItem(data) {
    $('#searchResult').replaceWith(data);
}


function searchMarketItem(text) {
    $.ajax({
        url: '/lists/searchMarketItem/' + text,
        success: onSuccessSearchItem,
        dataType: 'html'
    });
}


function navigateMarketGroup(id) {
    $.ajax({
        url: '/Lists/NavigateMarketGroup/' + id,
        success: OnSuccessNavigateMarketGroup,
        dataType: 'html'  
    });
}


function addItemToShoppingList(id) {
    addupdatItemToShoppingList(id, OnSuccessAddItemToShoppingList, 1);
}

function updateItemToShoppingList(id, units) {
    addupdatItemToShoppingList(id, onSuccessUpdateItemToShoppingList, units);
}

function addupdatItemToShoppingList(id, funcSuccess, units) {
    $.ajax({
        type: 'POST',
        url: '/Lists/UpdateMarketItemToShoppingList',
        context: id,
        success: funcSuccess,
        data: {id: id, units: units},
        dataType: 'html'        
    });
}

function editItemInShoppingList(id) {
    cleanEdits();
    var row = $('[data-esch-marketitemsinshoppinglist]').find('[data-esh-id="' + id + '"]');

    $(row).addClass('row-edit')
    $(row).find('a').hide()
    var units = $(row).data('esh-units');

    var filaControlesEdicion = "<tr class='fila-impar' data-esh-row-edit><td colspan='5' class='col-edit'><span><a onclick=\"setUnitsItemInShoppingList('" + id + "')\">Set</a><input data-esh-units type='text' value='" + units + "'>units</span><span><a onclick=\"deleteItemInShoppingList('" + id + "')\">Delete</a></span><span><a onclick=\"cancelEditItemInShoppingList('" + id + "')\">Close edit</a></span>"
    $(filaControlesEdicion).insertAfter(row)

    $(filaControlesEdicion).find('input:text').focus(function () { $(this).select(); });
    $('[data-esch-marketitemsinshoppinglist]').find('[data-esh-row-edit]').find('input:text').focus();



}


function cleanEdits() {
    $('[data-esch-marketitemsinshoppinglist]').find('[data-esh-row-edit]').remove();
    $('[data-esch-marketitemsinshoppinglist]').find('.row-edit').removeClass('row-edit');
    $('[data-esch-marketitemsinshoppinglist]').find('a').show();
}

function cancelEditItemInShoppingList(id) {
    $('[data-esh-id="' + id + '"]').removeClass('row-edit')
    $('[data-esh-id="' + id + '"]').find('a').show();
    $('[data-esch-marketitemsinshoppinglist]').find('[data-esh-row-edit]').remove();
}

function setUnitsItemInShoppingList(id) {
    var units = $('[data-esch-marketitemsinshoppinglist]').find('[data-esh-row-edit]').find('[data-esh-units]').val();
    updateItemToShoppingList(id, units)

}

function deleteItemInShoppingList(id) {
    $.ajax({
        url: '/Lists/DeleteMarketItemToShoppingList/' + id,
        context: id,
        success: onSuccessDeleteItemToShoppingList,
        dataType: 'html'
    });
}

function onSuccessDeleteItemToShoppingList() {
    cleanEdits();
    $('[data-esch-marketitemsinshoppinglist]').find('[data-esh-id="' + this + '"]').remove();

}


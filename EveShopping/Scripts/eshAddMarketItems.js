/// <reference path="jquery.blockUI.js" />


var thread = null;

function findMember(t) {
    alert(t);
}

$(function () {
    accordionState.initAccordion($('#market-items-accordion'));
    accordionState.openPanelByIndex($('#market-items-accordion'), 1);
});

$(document).ready(function () {
    $('.header-container').find('a').removeClass('selected');
    $('.header-container').find('#navlink_newList').addClass('selected');

    $("#searchButton").click(function () {
        searchMarketItem($("#searchText").val())
    });


    $("#searchText").keyup(function (event) {
        if (event.keyCode == 13) {
            $("#searchButton").click();
        }
    });

    accordionState.openPanelByIndex($('#market-items-accordion'), 1);

});




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
    setTotalPriceAndUnits();
}

function onSuccessUpdateItemToShoppingList(data) {
    AddOrReplaceItemInShoppingList(data, this, true);
    cancelEditItemInShoppingList(this);
    setTotalPriceAndUnits();
}

function onSuccessSearchItem(data) {
    $('#searchResult').replaceWith(data);
    $('#search-result-table').footable();

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

    var filaControlesEdicion = "<tr class='fila-impar' data-esh-row-edit><td colspan='5' class='col-edit'><span><a onclick=\"setUnitsItemInShoppingList('" + id + "')\">Set</a><input data-esh-units type='number' min='1' value='" + units + "'>units</span><span><a onclick=\"deleteItemInShoppingList('" + id + "')\">Delete</a></span><span><a onclick=\"cancelEditItemInShoppingList('" + id + "')\">Close edit</a></span>"
    $(filaControlesEdicion).insertAfter(row)

    var inputRows = $(filaControlesEdicion).find('input:text');
    $(inputRows).focus(function () { $(this).select(); });
    $(inputRows).focus();
    $(inputRows).spinner();


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
    setTotalPriceAndUnits();
}


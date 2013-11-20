/// <reference path="jquery.blockUI.js" />


var thread = null;

function findMember(t) {
    alert(t);
}

$(function () {
    //accordionState.initAccordion($('#market-items-accordion'));
    //accordionState.openPanelByIndex($('#market-items-accordion'), 1);
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

    accordionState.initAccordion($('#market-items-accordion'), 1);
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
            $("[data-esch-marketitemsinshoppinglist]").prepend(data);
            //$(data).insertBefore(itemTable.find('tr').first());
        }
        else {
            itemTable.find('[data-esh-id="' + id + '"]').replaceWith(data);
            //$(data).replaceAll(itemTable.find('[data-esh-id="' + id + '"]'));
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

    var filaControlesEdicion = "<tr class='fila-impar' data-esh-row-edit><td colspan='5' class='col-edit'><span><input style='width:5.5em;' data-esh-units type='number' min='1' value='" + units + "'>units</span><span><a onclick=\"setUnitsItemInShoppingList('" + id + "')\">Save</a></span><span><a onclick=\"cancelEditItemInShoppingList('" + id + "')\">Cancel edit</a></span>"
    var filaControlesAdd = "<tr class='fila-impar' data-esh-row-edit><td colspan='5' class='col-edit'><div style='float: left;'><div><span><a onclick=\"addUnitsItemInShoppingList(1)\">+1</a></span></div><div><span><a onclick=\"addUnitsItemInShoppingList(-1)\">-1</a></span></div></div><div style='float: left;'><div><span><a onclick=\"addUnitsItemInShoppingList(10)\">+10</a></span></div><div><span><a onclick=\"addUnitsItemInShoppingList(-10)\">-10</a></span></div></div><div style='float: left;'><div><span><a onclick=\"addUnitsItemInShoppingList(100)\">+100</a></span></div><div><span><a onclick=\"addUnitsItemInShoppingList(-100)\">-100</a></span></div></div><div style='float: left;'><div><span><a onclick=\"addUnitsItemInShoppingList(1000)\">+1,000</a></span></div><div><span><a onclick=\"addUnitsItemInShoppingList(-1000)\">-1,000</a></span></div></div><div style='float: left;'><div><span><a onclick=\"addUnitsItemInShoppingList(10000)\">+10,000</a></span></div><div><span><a onclick=\"addUnitsItemInShoppingList(-10000)\">-10,000</a></span></div></div><div style='float: left;'><div><span><a onclick=\"addUnitsItemInShoppingList(100000)\">+100,000</a></span></div><div><span><a onclick=\"addUnitsItemInShoppingList(-100000)\">-100,000</a></span></div></div>"
    $(filaControlesAdd).insertAfter(row)
    $(filaControlesEdicion).insertAfter(row)

    var inputRows = $(filaControlesEdicion).find('input:text');
    $(inputRows).focus(function () { $(this).select(); });
    $(inputRows).focus();
    $(inputRows).spinner();
}

function addUnitsItemInShoppingList(units) {
    var unidades = parseInt($("input[data-esh-units]").val());
    unidades += units;
    if (unidades < 0) {
        unidades = 0;
    }
    $("input[data-esh-units]").val(unidades);
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
    confirmDialog.show("Are you sure to delete the item from your shopping list?", function () { confirmedDeleteItemInShoppingList(id); });

}

function confirmedDeleteItemInShoppingList(id) {
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



function OnSuccessNavigateMarketGroup(data) {
    $('[data-esh-marketMenu]').replaceWith(data);
}

function OnSuccessAddItemToShoppingList(data) {
    var itemTable = $('[data-esch-marketItemsInShoppingList]');
    var existeItem = $(itemTable).find('[data-esh-id="' + this + '"]').length > 0;

    

    if (!existeItem) {
        $(data).insertBefore(itemTable.find('tr').first());
    }

    

    

}

function navigateMarketGroup(id) {
    $.ajax({
        url: '/Lists/NavigateMarketGroup/' + id,
        success: OnSuccessNavigateMarketGroup,
        dataType: 'html'  
    });
}

function addItemToShoppingList(id) {
    $.ajax({
        url: '/Lists/UpdateMarketItemToShoppingList/' + id,
        context: id,
        success: OnSuccessAddItemToShoppingList,
        dataType: 'html'
    });
}
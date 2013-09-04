
function OnSuccessNavigateMarketGroup(data) {
    $('[data-esh-marketMenu]').replaceWith(data);
}

function OnSuccessAddItemToShoppingList(data) {
    var i = 1;
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
        success: OnSuccessAddItemToShoppingList,
        dataType: 'html'
    });
}
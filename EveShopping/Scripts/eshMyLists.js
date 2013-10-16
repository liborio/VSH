$(document).load(function () {
});

$("[data-esh-delete-list]").click(function () {
    var id = $(this).parents("tr").attr("data-esh-list-publicid");
    deleteList(id);
});

$("[data-esh-list-publicid]").click(function () {
    var id = $(this).parents("tr").attr("data-esh-list-publicid");
    clearAllInner();
    getStaticLists(id, $(this).parents("tr").first());
});

function clearAllInner() {
   
    $("[data-esh-table-internal]").remove();
}

function getStaticLists(id, ctx) {
    var name = $("#hListName").text();
    $.ajax({
        url: '/Lists/GetShoppingListsByListPublicIDMyLists/' + id,
        success: onGetStaticListsSuccess,
        dataType: 'html',
        context: ctx
    });
}

function onGetStaticListsSuccess(data) {
    var rowClicked = $(this);
    $(rowClicked).after($("<tr data-esh-table-internal class='inner-table'><td colspan='5'>" + data + "</td></tr>"));
    $(data).footable();
}

function deleteList(id) {
    //confirmDialog.show("Are you sure to delete the static shopping list?", function () { confirmedDeleteStaticList(id); });
    confirmDialog.show("Are you sure to delete the shopping list?", function () { confirmedDeleteList(id); });
}

function confirmedDeleteList(id) {
    $.ajax({
        type: 'POST',
        url: '/Lists/DeleteShoppingList',
        context: id,
        success: onSuccessDeleteList,
        error: onErrorDeleteList,
        data: { id: id },
        dataType: 'html'
    });
}

function onErrorDeleteList(data) {
    infoDialog.show("Couldn't delete the list", "There was a problem deleting your shopping list.", data.statusText, infoDialog.warning);
}

function onSuccessDeleteList(data) {
    var id = this;
    $("[data-esh-list-publicid='" + id + "']").remove();
}


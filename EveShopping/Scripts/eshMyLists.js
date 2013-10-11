$(document).load(function () {
});

$("[data-esh-list-publicid]").click(function () {
    var id = $(this).data("esh-list-publicid");
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
    refreshDeleteEvents();


}

/////////// Static lists

function refreshDeleteEvents() {
    $("[data-esh-delete-static]").click(function () {
        var id = $(this).parents("tr").attr("data-esh-static-publicid");
        deleteStaticList(id);
    })

}

function createStaticList() {
    var name = $("#hListName").text();
    $.ajax({
        url: '/Lists/NewStaticShoppingList',
        success: onCreateStaticListSuccess,
        dataType: 'html',
        data: { name: name }
    });
}

function onCreateStaticListSuccess(data) {
    $("#tableStaticLists").replaceWith(data);
    refreshDeleteEvents();

}

function deleteStaticList(id) {
    //confirmDialog.show("Are you sure to delete the static shopping list?", function () { confirmedDeleteStaticList(id); });
    confirm("Are you sure to delete the static shopping list?", function () { confirmedDeleteStaticList(id); });
}

function confirmedDeleteStaticList(id) {
    $.ajax({
        type: 'POST',
        url: '/Lists/DeleteStaticShoppingList',
        context: id,
        success: onCreateStaticListSuccess,
        error: onErrorDeleteStaticList,
        data: { id: id },
        dataType: 'html'
    });
}

function onErrorDeleteStaticList(data) {
    infoDialog.show("Couldn't delete the list", "There was a problem deleting your static list.", data.statusText, infoDialog.warning);
}


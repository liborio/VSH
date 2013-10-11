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
        url: '/Lists/GetShoppingListsByListPublicID/' + id,
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

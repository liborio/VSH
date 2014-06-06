/// <reference path="eshCommon.js" />

$(function () {
    $('#summary-table').footable();
    $('.footable').data('page-size', 20);
});

$(document).ready(function () {
    $("#lnkCreateStaticList").click(function () { createStaticList(); });

    $('#help-container div').show();
    $('#help-container').show().accordion({ collapsible: true, active: false, heighStyle: "content", autoHeight: false, clearStyle: true });

    $('[data-esh-boughtchk]').change(function () { onBoughtLnkChange(this); });

    refreshDeleteEvents();    
});

function exportList() {
    var row = $("tr[esh-data-pager]");
    var filaControlesEdicion = "<tr class='fila-impar' data-esh-row-export><td colspan='4' class='col-edit'><span><a onclick=\"exportSummaryAsLinks()\">To EVE Mail friendly list</a></span><span><a onclick=\"exportSummaryAsList()\">To a simple list</a></span><span><a  onclick=\"closeExport()\">Close export</a></span>";
    $("[data-esh-row-export]").remove();
    $(filaControlesEdicion).insertAfter(row);
}

function closeExport() {
    $("[data-esh-row-export]").remove();
}

function exportSummaryAsList() {
    var salida = "";
    $('tr[data-esh-id]').each(function () {
        var name = $($(this).children()[1]).html();
        var units = $($(this).children().filter("[data-esh-cunits]")).html();
        salida += name + " " + units + "\n";
    });
    salida += "\nExported by http://eve-shopping.com\n";

    var text = "<textarea style='width: 98%; height: 290px;'>" + salida + "</textarea>";
    infoDialog.show("Items list", null, text, infoDialog.info);
}


function exportSummaryAsLinks() {
    var salida = "";
    $('tr[data-esh-id]').each( function() {
        var id = $(this).attr("data-esh-id");
        var name = $($(this).children()[1]).html();
        var units = $($(this).children().filter("[data-esh-cunits]")).html();
        salida += "<url=showinfo:" + id + ">" + name + "</url> " + units + "\n";
    });
    salida += "\nExported by http://eve-shopping.com\n";

    var text = "<textarea style='width: 98%; height: 290px;'>" + salida + "</textarea>";
    infoDialog.show("EVE Mail friendly list", null, text, infoDialog.info);
}

function onBoughtLnkChange(lnk) {
    
    if (lnk.checked) {
        $(lnk).parents("tr").first().addClass("fila-par");
    }
    else {
        $(lnk).parents("tr").first().removeClass("fila-par");
    }
}


function onSuccessSaveShoppingListHeader(data) {
    var name = $('#slName').val();
    $('#hListName').text(name);
}

function openMarketDatailsWindow(id) {
    $("[data-esh-id = " +  id + "]").find("[data-esh-boughtchk]").prop("checked", true).trigger("change")
    eveapi.openMarketDatailsWindow(id);
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
    confirmDialog.show("Are you sure to delete the static shopping list?", function () { confirmedDeleteStaticList(id); });
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

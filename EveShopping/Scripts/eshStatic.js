$(function () {
    $('#summary-table').footable();
    $('.footable').data('page-size', 20);
});

$(function () {
});

$(document).ready(function () {
    $("#lnkCreateStaticList").click(function () { createStaticList(); });

    $('#help-container div').show();
    $('#help-container').show().accordion({ collapsible: true, active: false, heighStyle: "content", autoHeight: false, clearStyle: true });

    $('[data-esh-boughtchk]').change(function () { onBoughtLnkChange(this); });
});

function onBoughtLnkChange(lnk) {

    if (lnk.checked) {
        $(lnk).parents("tr").first().addClass("fila-par");
    }
    else {
        $(lnk).parents("tr").first().removeClass("fila-par");
    }
}

function openMarketDatailsWindow(id) {
    $("[data-esh-id = " + id + "]").find("[data-esh-boughtchk]").prop("checked", true).trigger("change")
    eveapi.openMarketDatailsWindow(id);
}
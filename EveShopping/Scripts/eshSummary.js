/// <reference path="eshCommon.js" />

$(function () {
    $('#summary-table').footable();
    $('.footable').data('page-size', 20);
});

function openMarketDatailsWindow(id) {
    try {
        CCPEVE.showMarketDetails(id);
    } catch (e) {
        $(function () {
            infoDialog.show(
                "Market not available in this browser"
                , "You can access market details for the items only from EVE Online browser."
                , "Clicking in this link from in game browser will open market details window.");
        });
    }
}

function formatPrice(price) {
    if (price > 1000000) {
        return (price / 1000000).toFixed(2) + ' M';
    }
    if (price > 1000) {
        return (price / 1000).toFixed(2) + ' K';
    }
    return price.toFixed(2);
}



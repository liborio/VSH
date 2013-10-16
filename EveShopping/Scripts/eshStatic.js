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
});

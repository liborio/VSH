$(function () {
    $('#summary-table').footable();
    $('.footable').data('page-size', 20);
});

$(function () {
    $('#help-container').show();
    $('#help-container').show().accordion({ collapsible: true, active: false, heighStyle: "content", autoHeight: false, clearStyle: true });
});

$(document).ready(function () {
    $("#lnkCreateStaticList").click(function () { createStaticList(); });
});

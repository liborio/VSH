/// <reference path="eshCommon.js" />

$(document).ready(function () {
    general.setEnter("#idStaticUrl", "#idIncludeBtn");
    $("#idIncludeBtn").click(function () {
        includeStaticListInGroup($("#idStaticUrl").val(), $("#idNick").val());
    });
    SetRemoveListFromGroupEvent();

});

function SetRemoveListFromGroupEvent() {
    $("#idStaticLists").find("[data-esh-delete-static]").click(function () {
        var id = $(this).parents("tr").attr("data-esh-static-publicid");
        deleteList(id);
    });
}

function includeStaticListInGroup(id, nick) {

    $.ajax({
        type: 'POST',
        url: '/Group/IncludeStaticListInGroup',
        context: id,
        success: onSuccessIncludeStaticListInGroup,
        error: onErrorIncludeStaticListInGroup,
        data: { id: id, nick: nick},    
        dataType: 'html'
    });
}

function onSuccessIncludeStaticListInGroup(data) {
    $("#tableStaticLists tbody").append($(data));
    SetRemoveListFromGroupEvent();
}

function onErrorIncludeStaticListInGroup(data) {
    infoDialog.show("Couldn't include the list", "There was a problem adding your list to the group.", data.statusText, infoDialog.warning);
}



//delete static list
function deleteList(id) {
    confirmDialog.show("Are you sure to remove the static list from the group?", function () { confirmedDeleteList(id, "/Group/RemoveListFromGroup"); });
};

function confirmedDeleteList(id, url) {
    $.ajax({
        type: 'POST',
        url: url,
        context: id,
        success: onSuccessDeleteList,
        error: onErrorDeleteList,
        data: { id: id },
        dataType: 'html'
    });
}

function onErrorDeleteList(data) {
    infoDialog.show("Couldn't remove the list", "There was a problem removing your static list from the group.", data.statusText, infoDialog.warning);
}

function onSuccessDeleteList(data) {
    var id = this;
    $("[data-esh-static-publicid='" + id + "']").remove();
}
function checkAPI() {
    ajaxCheckAPI
}

function onSucessCheckAPI(data) {
    $("#lnkSaveAccount").show();
    $("[data-esh-chkAccount]").change(function () { chkAccountChanged(this); });
}

function onFailureCheckAPI(data) {
    infoDialog.show("Couldn't recover the characters", "There was a problem accessing your API account.", data.statusText, infoDialog.warning);
}

function ajaxCheckAPI(id, funcSuccess, units) {
    $.ajax({
        type: 'POST',
        url: '/Account/',
        context: id,
        success: funcSuccess,
        data: { id: id, units: units },
        dataType: 'html'
    });
}

//General para el control.

$(document).ready(function () {
    $("#lnkCheckAccount").click(function () {
        checkAPI();
    });
});

function chkAccountChanged(chk) {
    var checked = $(chk).is(":checked");
    var divImage = $(chk).parents(".divChar").find(".divCharImage");
    if (checked) {
        $(divImage).removeClass("shadowedImage");
    }
    else {
        $(divImage).addClass("shadowedImage");
    }
}
$(function () {
    'use strict';
    // Change this to the location of your server-side upload handler:
    $('#fu-my-auto-upload').fileupload({
        autoUpload: true,
        url: '/Lists/FileUpload',
        dataType: 'json',
        add: function (e, data) {
            var jqXHR = data.submit()
                .success(function (data, textStatus, jqXHR) {
                    if (data.isUploaded) {

                    }
                    else {

                    }
                    $("#rawFit").val(data.message);
                })
                .error(function (data, textStatus, errorThrown) {
                    if (typeof (data) != 'undefined' || typeof (textStatus) != 'undefined' || typeof (errorThrown) != 'undefined') {
                        alert(textStatus + errorThrown + data);
                    }
                });
        },
        fail: function (event, data) {
            if (data.files[0].error) {
                alert(data.files[0].error);
            }
        }
    });
});

$(document).ready(function () {
    $("#idAnalyseBtn").click(function () { analyseFit(); });
});


function analyseFit() {
    var fit = $("#rawFit").val();
    $.ajax({
        type: 'POST',
        url: '/Lists/AnalyzeRawFit',
        success: onSuccessAnalyzeRawFit,
        error: onFailureAnalyzeRawFit,
        data: { rawFit: fit },
        dataType: 'html'
    });
}


function onSuccessAnalyzeRawFit(data) {
    $("#fitsAnalysed").html(data);
    ReactivateImportedFitsAccordion();
    $(".accordion").accordion("resize");
}

function onFailureAnalyzeRawFit(data) {
    infoDialog.show("Could'nt analyse fit", "There was a problem analysing your fit.", data.statusText, infoDialog.warning);
}

function ReactivateImportedFitsAccordion() {
    accordionState.initAccordion($("#fitsAnalysed"))
    $("#rawFit").val('');
}

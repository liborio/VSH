/// <reference path="jquery-1.8.2.js" />
/// <reference path="jquery-ui-1.8.24.js" />


function eshImportFits() {
    this.ReactivateImportedFitsAccordion = function () {
        $("#fitsAnalysed").accordion();
    };
}

function ReactivateImportedFitsAccordion() {
    $("#fitsAnalysed").accordion({ collapsible: true });
}

function OnSuccessUseAnalysedFit(data){
    $(data).prependTo($("[data-esh-fits-in-list]").first());
    var name = $(data).first().attr('data-esh-name');
    $('[data-esh-analysed-fits').children('[data-esh-name = "' + name + '"]').remove();
}

function OnSuccessDeleteFitFromList(id) {
    $('[data-esh-fits-in-list').children('[data-esh-id = "' + id + '"]').remove();
}
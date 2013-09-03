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
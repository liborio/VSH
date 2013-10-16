/// <reference path="eshCommon.js" />

fitsConvert = {
    toDNA: function (fit) {
        var first = true;
        var dna = "";
        $(fit).find("[data-esh-itemid]").each(function () {
            row = this;
            var id = $(row).data("esh-itemid");
            if (!first) {
                var szunits = $($(row).find("td")[2]).html();
                szunits = szunits.substring(2, szunits.length);
                dna += ":" + id + ";" + szunits;
            }
            else {
                dna += id;
                first = false;
            }
        });
        dna += "::";
        return dna;
    },

    toEFT: function (fit) {
        var eft = "";
        var name = $(fit).data("esh-name");
        eft += '[' + name + ']';
        var slot;
        eft += "\r\n";
        $(fit).find("[data-esh-inslot='3']").each(function () {
            eft += fitsConvert.partialItemEFT(this);
        });
        eft += "\r\n";
        $(fit).find("[data-esh-inslot='2']").each(function () {
            eft += fitsConvert.partialItemEFT(this);
        });
        eft += "\r\n";
        $(fit).find("[data-esh-inslot='1']").each(function () {
            eft += fitsConvert.partialItemEFT(this);
        });
        eft += "\r\n";
        $(fit).find("[data-esh-inslot='4']").each(function () {
            eft += fitsConvert.partialItemEFT(this);
        });
        eft += "\r\n";
        $(fit).find("[data-esh-inslot='5']").each(function () {
            eft += fitsConvert.partialItemEFTxN(this);
        });
        $(fit).find("[data-esh-inslot='6']").each(function () {
            eft += fitsConvert.partialItemEFTxN(this);
        });
        return eft;
    },

    partialItemEFT: function (item) {
        var eft = "";
        var szunits;
        var name = $($(item).find("td")[1]).html();
        szunits = $($(item).find("td")[2]).html();
        szunits = szunits.substring(2, szunits.length);
        for (var i = 0; i < parseInt(szunits) ; i++) {
            eft += "\r\n" + name;
        }
        return eft;
    },
    partialItemEFTxN: function (item) {
        var eft = "";
        var szunits;
        var name = $($(item).find("td")[1]).html();
        szunits = $($(item).find("td")[2]).html();
        szunits = szunits.substring(2, szunits.length);
        eft += "\r\n" + name + ' x' + szunits;
        return eft;
    }


}

function cleanEdits() {
    $('#fitsInList').find('[data-esh-row-edit]').remove();
    $('#fitsInList').find('[data-esh-row-export]').remove();
    $('#fitsInList').find('[data-esh-edit-link]').show();
    $('#fitsInList').find('[data-esh-del-fit-link]').show();
}

function cancelEditItemInShoppingList(id) {
    cleanEdits();
    accordionState.enableAccordion($('#fitsInList'));
}


function exportFit(id) {
    cleanEdits();
    var row = $('#fitsInList').find('[data-esh-id="' + id + '"]').find('tr').first();
    var units = $('#fitsInList').find('h3[data-esh-id="' + id + '"]').data('esh-units')
    $(row).addClass('row-edit');

    $('#fitsInList').find('[data-esh-edit-link]').hide();
    $('#fitsInList').find('[data-esh-del-fit-link]').hide();
    var filaControlesEdicion = "<tr class='fila-impar' data-esh-row-export><td colspan='4' class='col-edit'><span><a onclick=\"exportToEVEClient(this)\">To EVE client</a></span><span><a onclick=\"exportToEFT(this)\">To EFT format</a></span><span><a  onclick=\"cancelEditItemInShoppingList('" + id + "')\">Close export</a></span>";
    $(filaControlesEdicion).insertBefore(row);

    var acc = $('#fitsInList');

    accordionState.openPanel(acc, id);
    accordionState.disableAccordion(acc);
}

function exportToEVEClient(exportRow) {
    var divFit = $(exportRow).parents("[data-esh-id]").first();
    var dna = fitsConvert.toDNA(divFit);
    eveapi.openFitWindow(dna);
}

function exportToEFT(exportRow) {
    var divFit = $(exportRow).parents("[data-esh-id]").first();
    var eft = fitsConvert.toEFT(divFit);
    var text = "<textarea style='width: 98%; height: 290px;'>" + eft + "</textarea>";
    infoDialog.show("EFT format", null, text, infoDialog.info);
}

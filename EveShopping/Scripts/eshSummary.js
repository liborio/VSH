﻿/// <reference path="eshCommon.js" />


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


$(function () {
    var wd = $("#full-main").innerWidth();
    var obj = {
        title: "Grid From Array",
        editable: false,
        roundCorners: false,
        width: wd,
        flexHeight: true,
        numberCell: false,
        columnBorders: false,
        topVisible: false,
        scrollModel: { horizontal: false, autoFit: true }

    };
    //var data = $.parseJSON($('#gridData').val());
    var data = $.parseJSON(summary_data);

    obj.colModel = [
        {
            title: "",
            width: 70, dataType: "string",
            render: function (ui) {
                return "<img src='" + ui.rowData[0] + "'/>";
            },
        },
        { title: "Name", width: 350, dataType: "string" },
        {
            title: "Volume", width: 56, dataType: "float", align: "right",
            render: function (ui) {
                return ui.rowData[2] + ' m3';
            }
        },
        {
            title: "Units", width: 100, dataType: "int", align: "right",
            render: function (ui) {
                return "x " + ui.rowData[3];
            }
        },
        {
            title: "",
            width: 70,
            dataType: "string",
            align: "right",
            render: function (ui) {
                return "<a onClick=\"openMarketDatailsWindow(" + ui.rowData[4] + ")\">Market</a>"
            }
        }

    ];
    obj.dataModel = { data: data };

    obj.rowSelect = function (rowid, e) {
        $("#grid_parts").pqGrid("setSelection", null)
    }

    var $grid = $("#grid_parts").pqGrid(obj);

    $grid.find(".pq-scrollbar-vert").pqScrollBar("disable");

    //});
});

    $(window).resize(function () {
        var wd = $("#full-main").innerWidth();
        $("#grid_parts").pqGrid("option", { width: wd });
    });

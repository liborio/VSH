$('#loading-image').bind('ajaxStart', function(){
    $(this).show();
}).bind('ajaxStop', function(){
    $(this).hide();
});



//$('#loadingDiv').hide().ajaxStart(function () {
//    $(this).show();  // show Loading Div
//}).ajaxStop(function () {
//    $(this).hide(); // hide loading div
//});
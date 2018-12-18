function PrintCanvasDiv(hiddelElements, divCanvas) {
    
    var divPrinting = $("#" + divCanvas).clone().attr('id', "divClonedCanvas");
    divPrinting = divPrinting.length > 0 ? divPrinting[0] : divPrinting;
    var elements = $("#divClonedCanvas").find('.btn');
    $(divPrinting).find('.btn').remove();
    if ($(divPrinting).find('#prntTableDiv').length > 0) {
        $(divPrinting).find('#prntTableDiv').css('margin-left', '0%');
    }
    if ($(divPrinting).find('#hspHeader').length > 0) {
        $(divPrinting).find('#hspHeader').css('margin-left', '8%');
        $(divPrinting).find('.text-info').css('padding-left', '8%');
        $(divPrinting).find('#hspHeader').addClass('divPrintElementhspHeader');
    }
    
    var headerPrintText = ($('#canvasElement').find('.text-info')[0]).innerHTML;
    //Ultra Sonography
    if (headerPrintText.indexOf('Lab Bill') > -1 || headerPrintText.indexOf('Ultra Sonography') > -1
        || headerPrintText.indexOf('Medical Bill') > -1) {
        $(divPrinting).find('table').closest('div').css('margin-left', '5%');
        $(divPrinting).find('table').css('width', '90%');
    }
    else if ($(divPrinting).find('table').closest('div').length > 0) {

        $(divPrinting).find('table').closest('div').css('margin-right', '16%');
        $(divPrinting).find('table').css('width', '90%');
    }

    //$(divPrinting).css('padding-left', '70%');
    $("#dvPrintElemet").append(divPrinting.innerHTML);
    $("#dvPrintElemet").toggleClass('hidden');
    $("#dvPrintElemet").addClass('divPrintElement');
    var changeFontonPrint = $('.divPrintElement .row');
    $.each(changeFontonPrint, function (elemIndex, elem) {

        $(elem).addClass('printing-margin');
    });
    html2canvas($("#dvPrintElemet"), {
        onrendered: function (canvas) {
            theCanvas = canvas;
            document.body.appendChild(canvas);
            var myImage = convertCanvasToImage(canvas);
            PrintImage(myImage.src);
            $('#dvPrintElemet').html('');
            $("#dvPrintElemet").toggleClass('hidden');
            // Clean up 
            document.body.removeChild(canvas);
        }
    });
}
function ImagetoPrint(source) {
    return "<html><head><script>function step1(){\n" +
        "setTimeout('step2()', 10);}\n" +
        "function step2(){window.print();window.close()}\n" +
        "</scri" + "pt></head><body onload='step1()'>\n" +
        "<img src='" + source + "' /></body></html>";
}
function PrintImage(source) {
    var Pagelink = document.title;
    var pwa = window.open(Pagelink, "_new");
    pwa.document.open();
    pwa.document.write(ImagetoPrint(source));
    pwa.document.close();
}
// Converts canvas to an image
function convertCanvasToImage(canvas) {
    var image = new Image();
    image.src = canvas.toDataURL("image/png");
    return image;
}
function generatePDF(headerSection,patientBillDetails,columns,data,fileNameWithoutExtension) {
    //const columns = [
    //    { title: "Particulars", dataKey: "discription" },
    //    { title: "Quantity", dataKey: "quantity" },
    //    { title: "UnitPrice", dataKey: "unitprice" }
    //];
    //data =  [
    //    { description: "Item Description", quantity: "1", unitprice: "450.00" },
    //    { description: "Item 2", quantity: "10", unitprice: "4500.00" },

    //]
    const doc = new jsPDF("p", "pt");

    // text is placed using x, y coordinates

    doc
        .setFont("times")
        .setFontSize(10)
        .text(370, 40, "Name:");
    doc
        .setFont("times")
        .setFontSize(10)
        .text(430, 40, patientBillDetails.name);
    doc
        .setFont("times")
        .setFontSize(10)
        .text(370, 55, "Bill #:");
    doc
        .setFont("times")
        .setFontSize(10)
        .text(430, 55, patientBillDetails.billNo);
    doc
        .setFont("times")
        .setFontSize(10)
        .text(370, 70, "Contact:");
    doc
        .setFont("times")
        .setFontSize(10)
        .text(430, 70, patientBillDetails.contact);

    doc
        .setFont("times")
        .setFontSize(10)
        .text(370, 85, "Date:");
    doc
        .setFont("times")
        .setFontSize(10)
        .text(430, 85, patientBillDetails.billDate);

    doc
        .setFont("times")
        .setFontSize(10)
        .text(370, 100, "Bill Amount :");
    doc
        .setFont("times")
        .setFontSize(10)
        .text(430, 100, patientBillDetails.billTotal);


    doc
        .setFont("times")
        .setFontSize(18)
        .text(50, 40, headerSection.name);

    doc
        .setFont("times")
        .setFontSize(9)
        .text(50, 55, headerSection.address);

    doc
        .setFont("times")
        .setFontSize(9)
        .text(50, 70, headerSection.contact);

    doc
        .setFont("times")
        .setFontSize(9)
        .text(50, 85, headerSection.email);

    doc.autoTable(columns, data, { margin: { top: 110 } });

    doc.setLineWidth(1);
    doc.line(560, 725, 40, 725);

    doc.save(fileNameWithoutExtension +'.pdf');


}
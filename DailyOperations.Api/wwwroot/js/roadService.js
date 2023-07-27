function printDivContent() {
    var printContent = document.getElementById("printContent");
    var printWindow = window.open("", "_blank");
    printWindow.document.write("<html><head><title>Print</title>");
    printWindow.document.write('<style>');
    printWindow.document.write(`
        :root {
            --color-white: #ffffff;
            --color-primary: blue;
            --color-gray: #ccc;
            --color-disabled: #e5e1e138;
            --card-padding: 1.6rem;
            --padding-1: 1rem;
            --padding-2: 8px;
            --card-border-radius: 1.6rem;
            --border-radius-1: 1rem;
            --border-radius-2: 6px;
            --transtion-300: all 300ms linear;
        }


        * {
            margin: 0;
            padding: 0;
            outline: 0;
            border: 0;
            appearance: none;
            text-decoration: none;
            list-style: none;
            box-sizing: border-box;
            font-family: "Tajawal", sans-serif;
        }


        html {
            font-size: 12px;
        }


        body {
            min-height: 100vh;
            color: black;
        }

        header {
            font-weight: 700;
            font-size: 2rem;
            color: var(--color-primary);
        }

        main {
            gap: 2rem;
            width: 96%;
            direction: rtl;
            background-image: url("/background-logo.png");
            background-size: contain;
            background-repeat: repeat-y;
            background-position: center center;
        }

       .flex-column {
            display: flex;
            flex-direction: column;
        }

        .flex-row {
            display: flex;
            flex-direction: row;
        }

        .center {
            display: flex;
            justify-content: center;
            align-items: center;
        }

        .justify-content-between {
            justify-content:space-between;
        }

        .gap2 {
            gap: 2rem;
        }

        .gap0 {
            gap: 0rem;
        }

        .gap1 {
            gap: 1rem;
        }

        .align-end {
            align-items: flex-end;
        }


        .align-start {
            align-items: flex-start;
        }

        .align-center {
            align-items: center;
        }

        .justify-around {
            justify-content: space-around;
        }

        .justify-content-end {
            justify-content: end;
        }

        .justify-content-start {
            justify-content: start;
        }

        .align-content-end {
            align-content: flex-end;
        }

        .align-content-start {
            align-content: flex-start;
        }

        table {
          border-spacing: 0;
          width: 100%;
          background-color: transparent;    
        }


        th, td {
            text-align: center;
            border: var(--color-gray) solid 1px;
            padding: 1px 1px;
        }

        thead {
            font-size: 1.2rem;
            color: blue;
            font-weight: 700;
            height: 50px;
        }

        td {
            font-size: 14px;
            font-weight: 500;
        }
        
        tr {
            page-break-inside: avoid;
        }

       
        .width100 {
            width: 100%;
        }

        .width90 {
            width: 90%;
        }

        .width80 {
            width: 80%;
        }

        .width75 {
            width: 75%;
        }


        .width50 {
            width: 50%;
        }

        .width40 {
            width: 40%;
        }

        .width30 {
            width: 30%;
        }

        .width20 {
            width: 20%;
        }

        .width25 {
            width: 25%;
        }

        .width10 {
            width: 10%;
        }

        .height-fit{
            height:fit-content;
        }

        .height100 {
            height: 100%;
        }

        .height150px {
            height: 150px;
        }

        .height170px {
            height: 170px;
        }

        .height75 {
            height: 75%;
        }


        .height50 {
            height: 50%;
        }

        .height50px {
            height: 50px;
        }

        .height40 {
            height: 40%;
        }

        .height30 {
            height: 30%;
        }

        .height20 {
            height: 20%;
        }

        .height25 {
            height: 25%;
        }

        .height10 {
            height: 10%;
        }

        .width100px {
            width: 100px;
        }

        .width200px {
            width: 200px;
        }

        .width300px {
            width: 300px;
        }

        .width400px {
            width: 400px;
        }

        .width500px {
            width: 500px;
        }

        .height100px {
            height: 100px;
        }

        .height200px {
            height: 200px;
        }

        .height300px {
            height: 300px;
        }

        .height400px {
            height: 400px;
        }

        .height50px {
            height: 50px;
        }

        .height60px {
            height: 60px;
        }

        .height75px {
            height: 75px;
        }

        .height500px {
            height: 500px;
        }

        .height120px {
            height: 120px;
        }

        .font20px {
            font-size: 20px;
        }

        .font50px {
            font-size: 50px;
        }

        .font40px {
            font-size: 40px;
        }

        .font30px {
            font-size: 30px !important;
        }

        .font2rem {
            font-size: 2rem;
        }

        .font60px {
            font-size: 60px;
        }

        .font70px {
            font-size: 70px;
        }

        .font80px {
            font-size: 80px;
        }

        .font100px {
            font-size: 100px;
            font-weight: bolder;
        }

        .bold {
            font-weight: 900 !important;
        }

        .background-graylight {
            background: var(--color-gray-light);
        }

        .mg-top50 {
            margin-top: 50px;
        }

        .mg-top20 {
            margin-top: 20px;
        }

        .mg-top10 {
            margin-top: 10px;
        }

        .mg-top5 {
            margin-top: 5px;
        }

        .mg-bottom50 {
            margin-bottom: 50px;
        }

        .mg-bottom20 {
            margin-bottom: 20px;
        }

        .radius50 {
            border-radius: 50%;
        }

        .z-index100 {
            z-index: 100;
        }

        .pos-abs {
            position: absolute;
        }


        .padding1 {
            padding: var(--padding-1);
        }

        .padding2 {
            padding: var(--padding-2);
        }

        .padding20-50 {
            padding: 20px 50px;
        }

        .padding10-50 {
            padding: 10px 50px;
        }

        .card-padding {
            padding: var(--card-padding);
        }

        .card-radius {
            border-radius: var(--card-border-radius);
        }

        
        .mg-right30px {
            margin-right: 30px;
        }

        .mg-right100px {
            margin-right: 100px;
        }

        .mg-right200px {
            margin-right: 200px;
        }

        .mg-right300px {
            margin-right: 300px;
        }

        .padding5 {
            padding: 5px;
        }

        .delete {
          display: none;
        }


`);
    printWindow.document.write("</style>");
    printWindow.document.write("</head><body><main class=\"watermark\">");
    printWindow.document.write(printContent.innerHTML);
    printWindow.document.write("</main></body></html>");
    printWindow.document.close();
    printWindow.print();
}








var addBtn = document.getElementById('add-btn');
var jobInput = document.getElementById('job');
var degreeInput = document.getElementById('degree');
var nameInput = document.getElementById('name');
var signaturesDiv = document.getElementById('signatures');
var numSignatures = 0;
var currentRowDiv;

addBtn.addEventListener('click', function () {
    // create a new row div if necessary
    if (numSignatures % 2 === 0) {
        currentRowDiv = document.createElement('div');
        currentRowDiv.classList.add('flex-row', 'justify-content-between', 'mg-bottom50');
        signaturesDiv.appendChild(currentRowDiv);
    }

    // create the signature div with class "flex-column" and "center" if there's only one signature per row
    var signatureDiv = document.createElement('div');
    signatureDiv.classList.add('flex-column');
    signatureDiv.classList.add('center');

    var jobPlace = document.createElement('div');
    jobPlace.textContent = jobInput.value;
    jobPlace.classList.add('job-title'); // add job-title class to center job title
    signatureDiv.appendChild(jobPlace);

    var degreeNameDiv = document.createElement('div');
    degreeNameDiv.classList.add('word-and-slash');
    var degreeNameText = document.createElement('span');
    degreeNameText.textContent = degreeInput.value + ' / ' + nameInput.value;
    degreeNameDiv.appendChild(degreeNameText);
    signatureDiv.appendChild(degreeNameDiv);

    // append the signature div to the current row div
    currentRowDiv.appendChild(signatureDiv);

    // increment the number of signatures
    numSignatures++;

    // clear the input values
    jobInput.value = '';
    degreeInput.value = '';
    nameInput.value = '';
});



function GetDriverData() {
    var selectedValue = document.getElementById('DriverSelect').value;
    console.log('Selected value:', selectedValue);

    var selectedValues = selectedValue.split('|');
    var driverId = selectedValues[0];
    var driverTypeId = selectedValues[1];
    console.log('Driver ID:', driverId);
    console.log('Driver type ID:', driverTypeId);

    document.getElementById('Driver').value = driverId;
    document.getElementById('DriverType').value = driverTypeId;

    console.log('Driver ID field value:', document.getElementById('Driver').value);
    console.log('Driver type ID field value:', document.getElementById('DriverType').value);
}
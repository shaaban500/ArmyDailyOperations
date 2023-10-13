function printDivContent() {
    var printContent = document.getElementById("printContent");
    var printWindow = window.open("", "_blank");
    printWindow.document.write("<html><head><title>Print</title>");
    printWindow.document.write('<style>');
    printWindow.document.write(`

        html{
            direction: rtl;
        }

        body {
            page-break-after: always; 
        }
         table {
            border-collapse: collapse; 
            overflow: hidden; 
            border-spacing: 0;
            width: 100%;
        }
        
        th, td {
            text-align: center;
            padding: 10px 10px;
            min-height: 30px;
            border: 1px solid gray;
        }
        
        thead, th {
            font-size: 22px;
            font-weight: normal;
            background-color: #D3D3D3;
        }
        
        
        td{
            font-size: 18px;
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

        .align-center {
            align-items: center;
        }

        
        .justify-content-between {
            justify-content: space-between;
        }

        .gap2 {
            gap: 2rem;
        }

        .gap3 {
            gap: 3rem;
        }

        .gap0 {
            gap: 0rem;
        }

        .gap1 {
            gap: 1rem;
        }

        .width100 {
            width: 100%;
        }
 
        .width50 {
            width: 50%;
        }

        .mg-top50 {
            margin-top: 20px;
        }

        .mg-top40 {
            margin-top: 20px;
        }

        .mg-top20 {
            margin-top: 20px;
        }

        .mg-top25 {
            margin-top: 20px;
        }

        .mg-top10 {
            margin-top: 10px;
        }

        .mg-top5 {
            margin-top: 5px;
        }

        .mg-bottom50 {
            margin-bottom: 20px;
        }

        .mg-bottom40 {
            margin-bottom: 20px;
        }


        .mg-bottom20 {
            margin-bottom: 20px;
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

        .width60 {
            width: 60%;
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

        .height-fit {
            height: fit-content;
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

        .font20px, header {
            font-size: 22px;
        }

        .page-break-inside{
            page-break-inside: avoid;
        }

        .no-print{
          display: none !important;
        }

        .border-black {
            border: 1px solid black;
        }

        
        .bold {
            font-weight: 900 !important;
        }

    `);
    printWindow.document.write("</style>");
    printWindow.document.write("</head><body><main class=\"watermark\">");
    printWindow.document.write(printContent.innerHTML);
    printWindow.document.write("</main></body></html>");
    printWindow.document.close();
    printWindow.print();
}





function addSignature() {
    var jobInput = document.getElementById('job');
    var degreeInput = document.getElementById('degree');
    var nameInput = document.getElementById('name');
    var signaturesDiv = document.getElementById('signatures');
    var numSignatures = 0;
    var currentRowDiv;

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
}


function updateTable() {
    var thInput = document.getElementById("thInput");
    var tdInput = document.getElementById("tdInput");
    var trth = document.getElementById("headerRow");
    var trtd = document.getElementById("dataRow");
    // Check if the input elements and the tr element are found and not null
    if (thInput && tdInput && trth && trtd) {
        var thValue = thInput.value;
        var tdValue = tdInput.value;
    console.log(1111111);

        // Check for empty values
        if (thValue !== "" && tdValue !== "") {
            // Create new th and td elements
            var newTh = document.createElement("th");
            newTh.textContent = thValue;

            var newTd = document.createElement("td");
            newTd.textContent = tdValue;

            // Append the new th and td to the existing tr
            trth.appendChild(newTh);
            trtd.appendChild(newTd);

        }
    }
}


function addLogo() {
    var fileInput = document.getElementById('photoInput');
    if (fileInput.files && fileInput.files[0]) {
        var reader = new FileReader();
        reader.onload = function (event) {
            document.getElementById('logo-photo').src = event.target.result;
        };
        reader.readAsDataURL(fileInput.files[0]);
    }
}




function disablePrint(elementId) {
    var element = document.getElementById(elementId);
    if (element) {
        element.classList.toggle("no-print");
        element.classList.toggle("hide");
    }
}
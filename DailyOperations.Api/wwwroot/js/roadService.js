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




$(document).ready(function () {
    $('#DepartmentId').on('change', function () {
        var DepartmentId = $(this).val();
        var Officers = $('#OfficerId');

        Officers.empty();
        Officers.append('<option></option>');

        if (DepartmentId !== '') {
            $.ajax({
                url: '/PoliceOfficers/GetAllByDepartment?id=' + DepartmentId,
                success: function (allOfficers) {
                    $.each(allOfficers, function (i, officer) {
                        Officers.append($('<option>').attr('value', officer.id).text(officer.name));
                    });
                },
                error: function () {
                    alert("An error occurred while retrieving officers.");
                }
            });
        }
    });
});



function GetOfficersCount(operationId)
{

    var dateFrom = document.getElementById('dateFrom').value;
    var dateTo = document.getElementById('dateTo').value;

    var Officers = $('#OfficerId');

    Officers.empty();
    Officers.append('<option></option>');

    $.ajax({
        url: '/PoliceOfficers/CountPoliceOfficers?operationId=' + operationId + '&dateFrom=' + dateFrom + '&dateTo=' + dateTo,
        success: function (allOfficers) {
            $.each(allOfficers, function (i, officer) {
                Officers.append($('<option>').attr('value', officer.id).text(officer.name + ' (' + officer.count + ')'));
            });
        },
        error: function () {
            alert("An error occurred while retrieving officers.");
        }
    });
}


function addAccusation() {
    var stringValue = $('#StringValue').val();
    var intValue = $('#IntValue').val();

    if (stringValue && intValue) {
        var newRow = '<tr><td>' + stringValue + '</td><td>' + intValue + '</td></tr>';
        $('#accusations tbody').append(newRow);
        $('#StringValue').val('');
        $('#IntValue').val('');
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



let editedText = '';

// Function to capture changes in the text editor
function handleTextChange() {
const textEditor = document.querySelector('.editor');
editedText = textEditor.textContent;
}

// Attach the event listener to the text editor
document.querySelector('.editor').addEventListener('input', handleTextChange);


    function preventSubmit(event) {
        event.preventDefault();

    // Update the hidden input field with the edited text
    document.querySelector('[name="OperationDescription.Description"]').value = editedText;

    // Manually trigger the form submission
    document.querySelector('form').submit();
  }

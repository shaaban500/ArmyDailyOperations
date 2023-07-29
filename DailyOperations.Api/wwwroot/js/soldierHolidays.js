var selectAllCheckbox = document.getElementById('check-all');
var checkboxes = document.getElementsByClassName('checkbox');

selectAllCheckbox.addEventListener('change', function () {
    for (var i = 0; i < checkboxes.length; i++) {
        checkboxes[i].checked = selectAllCheckbox.checked;
    }
});

for (var i = 0; i < checkboxes.length; i++) {
    checkboxes[i].addEventListener('change', function () {
        var allChecked = true;
        for (var j = 0; j < checkboxes.length; j++) {
            if (!checkboxes[j].checked) {
                allChecked = false;
                break;
            }
        }
        selectAllCheckbox.checked = allChecked;
    });
}
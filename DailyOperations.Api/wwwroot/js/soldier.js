const radioButtons = document.querySelectorAll('input[name="radio-group"]');
const inputField = document.querySelector('#CertificateName');

function isAnyButtonChecked() {
    for (let i = 0; i < radioButtons.length - 1; i++) {
        if (radioButtons[i].checked) {
            return true;
        }
    }
    return false;
}

radioButtons.forEach((button) => {
    button.addEventListener('change', () => {
        inputField.style.visibility = isAnyButtonChecked() ? 'visible' : 'hidden';
        inputField.style.display = isAnyButtonChecked() ? 'block' : 'none';
    });
});



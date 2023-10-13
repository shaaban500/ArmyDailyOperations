function openForm(formName, hiddenInputId = "", id = 0) {
    event.preventDefault();
    if (hiddenInputId) {
        document.getElementById(hiddenInputId).value = id;
    }
    document.getElementById(formName).style.display = 'flex';
    document.getElementById(formName).style.opacity = 1;
}

function closeForm(formName) {
    event.preventDefault();
    document.getElementById(formName).style.display = 'none';
    document.getElementById(formName).style.opacity = 0;
    document.body.style.opacity = 1;
}


function expand(id) {
    //const element = document.getElementById(id);
    //const isExpanded = element.style.display === 'block' || element.style.display === 'flex';
    //const spans = document.querySelectorAll(`#${id}spans > span`);

    //if (isExpanded) {
    //    element.style.display = 'none';
    //    spans[0].style.display = 'none';
    //    spans[1].style.display = 'block';
    //} else {
    //    element.style.display = 'block';
    //    spans[0].style.display = 'none';
    //    spans[1].style.display = 'none';
    //}
}
var commandButtons = document.querySelectorAll(".editor-commands a");
for (var i = 0; i < commandButtons.length; i++) {
    commandButtons[i].addEventListener("mousedown", function (e) {
        e.preventDefault();
        var commandName = e.target.getAttribute("data-command");
        if (commandName === "html") {
            var commandArgument = e.target.getAttribute("data-command-argument");
            document.execCommand('formatBlock', false, commandArgument);
        } else {
            document.execCommand(commandName, false);
        }
    });
}

var result = document.getElementById("Editor").innerHTML;
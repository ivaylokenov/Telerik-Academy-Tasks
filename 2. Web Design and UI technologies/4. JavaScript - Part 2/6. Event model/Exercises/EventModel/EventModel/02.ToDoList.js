var addElementFunction = function addElement() {
    var contentDiv = document.getElementById("content");
    var createdDiv = document.createElement("div");
    var childCheck = document.createElement("input");
    childCheck.type = "checkbox";
    createdDiv.appendChild(childCheck);
    if (document.getElementById("input-text").value === null || document.getElementById("input-text").value === "") {
        return;
    }

    createdDiv.innerHTML += document.getElementById("input-text").value;
    createdDiv.className = "visible";
    document.getElementById("input-text").value = "";
    contentDiv.appendChild(createdDiv);
};

var deleteElementFunction = function deleteElement() {
    var checkBoxes = document.querySelectorAll("#content input");

    for (var i = 0; i < checkBoxes.length; i++) {
        if (checkBoxes[i].checked === true) {
            document.getElementById("content").removeChild(checkBoxes[i].parentNode);
        }
    }
}

var hideCheckedElements = function hideCheckedElements() {
    var checkBoxes = document.querySelectorAll("#content input");

    for (var i = 0; i < checkBoxes.length; i++) {
        if (checkBoxes[i].checked === true && checkBoxes[i].parentNode.className === "visible") {
            checkBoxes[i].parentNode.className = "invisible";
        }
    }
}

var showHiddenElements = function showHiddenElements() {
    var checkBoxes = document.querySelectorAll("#content input");

    for (var i = 0; i < checkBoxes.length; i++) {
        if (checkBoxes[i].checked === true && checkBoxes[i].parentNode.className === "invisible") {
            checkBoxes[i].parentNode.className = "visible";
        }
    }
}

var addEvent = document.getElementById("add");
addEvent.addEventListener("click", addElementFunction, false);

var deleteEvent = document.getElementById("delete");
deleteEvent.addEventListener("click", deleteElementFunction, false);

var hideEvent = document.getElementById("hide");
hideEvent.addEventListener("click", hideCheckedElements, false);

var showEvent = document.getElementById("show");
showEvent.addEventListener("click", showHiddenElements, false);
function buttonClick(event, arguments) {
    var currentWindow = window;
    var currentBrowser = currentWindow.navigator.appCodeName;
    var isMozilla = (currentBrowser === "Mozilla");

    if (isMozilla) {
        alert("Yes");
    }
    else {
        alert("No");
    }
}

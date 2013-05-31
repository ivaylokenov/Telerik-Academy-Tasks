var currentVisibleImage = 1;

var previous = document.getElementById("previous");

previous.addEventListener("click", function () {
    var visibleImg = document.getElementById(currentVisibleImage);
    visibleImg.className = "invisible carousel";
    currentVisibleImage--;
    var imagesLength = document.querySelectorAll(".carousel").length;

    if (currentVisibleImage == 0) {
        currentVisibleImage = imagesLength;
    }

    visibleImg = document.getElementById(currentVisibleImage);
    visibleImg.className = "visible carousel";
}, false);

var next = document.getElementById("next");

next.addEventListener("click", function () {
    var visibleImg = document.getElementById(currentVisibleImage);
    visibleImg.className = "invisible carousel";
    currentVisibleImage++;
    var imagesLength = document.querySelectorAll(".carousel").length;

    if (currentVisibleImage == imagesLength + 1) {
        currentVisibleImage = 1;
    }

    visibleImg = document.getElementById(currentVisibleImage);
    visibleImg.className = "visible carousel";
}, false);
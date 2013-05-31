var canvas = document.getElementsByTagName("canvas")[0].getContext("2d");

var x = 40;
var y = 40;
var sideDirection = "left";
var vertDirection = "down";

setInterval(function () {

    if (sideDirection === "right" && vertDirection === "down") {
        x += 1;
        y += 1;
    }
    if (sideDirection === "right" && vertDirection === "up") {
        x += 1;
        y -= 1;
    }
    if (sideDirection === "left" && vertDirection === "up") {
        x -= 1;
        y -= 1;
    }
    if (sideDirection === "left" && vertDirection === "down") {
        x -= 1;
        y += 1;
    }

    if (x + 20 > 750 && sideDirection === "right") {
        sideDirection = "left";
    }
    if (x - 20 < 0 && sideDirection === "left") {
        sideDirection = "right";
    }
    if (y + 20 > 500 && vertDirection === "down") {
        vertDirection = "up";
    }
    if (y - 20 < 0 && vertDirection === "up") {
        vertDirection = "down";
    }

    canvas = document.getElementsByTagName("canvas")[0].getContext("2d");
    canvas.beginPath();
    canvas.arc(x, y, 20, 0, Math.PI * 2, false);
    canvas.stroke();
    canvas.clearRect(0, 0, 750, 500);
    canvas.stroke();

}, 5);
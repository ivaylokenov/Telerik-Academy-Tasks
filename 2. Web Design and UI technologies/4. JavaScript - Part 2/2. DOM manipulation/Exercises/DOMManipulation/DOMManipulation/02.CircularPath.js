function onButtonClick() {
    var contentDiv = document.getElementById("content");

    var center = document.createElement("div");
    center.innerHTML = "o";
    center.style.position = "absolute";
    center.style.top = "200px";
    center.style.left = "300px";

    contentDiv.appendChild(center);

    var x = 0;
    var y = 0;
    var angle = 0;

    for (var i = 0; i < 5; i++) {
        x = Math.round(Math.cos(angle) * 100);
        y = Math.round(Math.sin(angle) * 100);
        angle += 5;
        var currentDiv = document.createElement("div");
        currentDiv.id = i;
        currentDiv.innerHTML = "o";
        currentDiv.style.position = "absolute";
        currentDiv.style.top = (200 + y) + "px";
        currentDiv.style.left = (300 + x) + "px";
        contentDiv.appendChild(currentDiv);
    }

    angle = 0;
    setInterval(function () {

        for (var j = 0; j < 5; j++) {
            var div = document.getElementById(j.toString());
            x = parseInt(div.style.left);
            y = parseInt(div.style.top);

            div.style.left = (300 + 100 * Math.cos(angle)) + "px";
            div.style.top = (200 + 100 * Math.sin(angle)) + "px";

            angle += 5;
        }

        angle += 0.2;
    }, 100);
}
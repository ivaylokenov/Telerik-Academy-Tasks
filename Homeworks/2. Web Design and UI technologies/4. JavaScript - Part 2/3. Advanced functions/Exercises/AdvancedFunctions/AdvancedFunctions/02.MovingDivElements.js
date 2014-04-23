function movingShapes() {

    var width = "25px";
    var height = "25px";
    var counter = 0;

    function circularMovement() {
        counter++;
        var div = document.createElement("div");
        div.style.width = width;
        div.style.height = height;
        div.style.backgroundColor = randomColorGenerator();
        div.style.fontFamily = randomFont();
        div.style.border = "1px solid " + randomColorGenerator();
        div.style.position = "absolute";
        div.className = "circular";
        div.innerHTML = counter;
        div.style.textAlign = "center";

        var angle = 0;
        var centerX = Math.floor(Math.random() * 1200 + 1);
        var centerY = Math.floor(Math.random() * 1200 + 1);
        var radius = Math.floor(Math.random() * 200 + 1);

        document.body.appendChild(div);

        setInterval(function () {
            div.style.left = (centerX + radius * Math.cos(angle)) + "px";
            div.style.top = (centerY + radius * Math.sin(angle)) + "px";
            angle += 0.2;
        }, 100);
    }

    function rectangularMovement() {
        counter++;
        var div = document.createElement("div");
        div.style.width = width;
        div.style.height = height;
        div.style.backgroundColor = randomColorGenerator();
        div.style.fontFamily = randomFont();
        div.style.border = "1px solid " + randomColorGenerator();
        div.style.position = "absolute";
        div.className = "circular";
        div.innerHTML = counter;
        div.style.textAlign = "center";
        
        var startX = Math.floor(Math.random() * 800 + 1);
        var startY = Math.floor(Math.random() * 800 + 1);
        var widthMovement = Math.floor(Math.random() * 200 + 1);
        var heightMovement = Math.floor(Math.random() * 200 + 1);
        var direction = "left";

        div.style.left = startX + "px";
        div.style.top = startY + "px";

        document.body.appendChild(div);

        setInterval(function () {

            var currentLeft = parseInt(div.style.left);
            var currentTop = parseInt(div.style.top);

            if (startX + widthMovement < currentLeft && direction == "left") {
                direction = "bottom";
            }
            if (startX > currentLeft && direction == "right") {
                direction = "top";
            }
            if (startY + heightMovement < currentTop && direction == "bottom") {
                direction = "right";
            }
            if (startY > currentTop && direction == "top") {
                direction = "left";
            }

            if (direction == "left") {
                div.style.left = currentLeft + 10 + "px";
            }
            if (direction == "right") {
                div.style.left = currentLeft - 10 + "px";
            }
            if (direction == "top") {
                div.style.top = currentTop - 10 + "px";
            }
            if (direction == "bottom") {
                div.style.top = currentTop + 10 + "px";
            }

        }, 100);
    }

    function randomFont() {
        var fonts = ['Serif', 'Sans-serif', 'Monospace', 'Cursive', 'Fantasy'];
        var chooseFont = Math.floor(Math.random() * 5) + 1;
        return fonts[chooseFont];
    }

    function randomColorGenerator() {
        var red = (Math.random() * 256) | 0;
        var green = (Math.random() * 256) | 0;
        var blue = (Math.random() * 256) | 0;

        return "rgb(" + red + "," + green + "," + blue + ")";
    }

    return {
        add: function (movingOption) {
            if (movingOption === "circular") {
                circularMovement();
            }
            else if (movingOption === "rectangular") {
                rectangularMovement();
            }
            else {
                console.log("No such command in movingShapes module!");
            }
        }
    }
}

//test it
var shapesModule = new movingShapes();

function addCircularButtonClick() {
    shapesModule.add("circular");
}

function addRectangularButtonClick() {
    shapesModule.add("rectangular");
}
function generateDivs() {
    var counterOfNewDivs = document.getElementById("generate-divs").value;

    if (counterOfNewDivs <= 0) {
        counterOfNewDivs = 1;
    }

    var contentDiv = document.getElementById("content");

    var documentFragment = document.createDocumentFragment();

    for (var i = 0; i < counterOfNewDivs; i++) {
        var div = document.createElement("div");
        div.style.textAlign = "center";
        div.style.display = "inline-block";

        //add strong element
        var strong = document.createElement("strong");
        strong.innerHTML = "div";
        div.appendChild(strong);

        //width
        var randomNumber = Math.floor(Math.random() * 80) + 20;
        div.style.width = randomNumber + "px";

        //height
        randomNumber = Math.floor(Math.random() * 80) + 20;
        div.style.height = randomNumber + "px";

        //background color
        div.style.backgroundColor = generateColor();

        //font color
        div.style.color = generateColor();

        //border style - solid to display it properly
        div.style.borderStyle = "solid";

        //border radius
        randomNumber = Math.floor(Math.random() * 20) + 1;
        div.style.borderRadius = randomNumber + "px";

        //border color
        div.style.borderColor = generateColor();

        //border width
        randomNumber = Math.floor(Math.random() * 20) + 1;
        div.style.borderWidth = randomNumber + "px";

        //position randomizer
        randomNumber = parseInt(Math.floor(Math.random() * 5) + 1);

        switch (randomNumber) {
            case 1: div.style.position = "absolute"; break;
            case 2: div.style.position = "fixed"; break;
            case 3: div.style.position = "static"; break;
            case 4: div.style.position = "relative"; break;
            case 5: div.style.position = "inherit"; break;
        }

        documentFragment.appendChild(div);
    }

    contentDiv.appendChild(documentFragment);
}

function generateColor() {
    var red = (Math.random() * 256) | 0;
    var green = (Math.random() * 256) | 0;
    var blue = (Math.random() * 256) | 0;

    return "rgb(" + red + "," + green + "," + blue + ")";
}
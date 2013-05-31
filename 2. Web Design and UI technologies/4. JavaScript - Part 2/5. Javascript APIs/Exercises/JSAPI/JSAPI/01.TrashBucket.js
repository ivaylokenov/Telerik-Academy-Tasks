var bottlesCount = 10;
var currentNickname = null;
var time = 0;
var topScore = [];

function generateTrash() {
    var gameContainer = document.querySelectorAll(".trash");

    for (var i = 0; i < gameContainer.length; i++) {
        var trash = gameContainer[i];
        trash.style.position = "absolute";
        trash.style.left = (Math.random() * 500 + 400) + "px";
        trash.style.top = (Math.random() * 500) + "px";
        trash.id = i;
    }

    topScore = JSON.parse(localStorage["score"]);
    var resultScore = "Top scores: \n";
    for (var i = 1; i <= 5; i++) {
        resultScore += (i + ". " + topScore[i - 1] + "\n");
    }
    alert(resultScore);
}

function drag(ev) {
    ev.dataTransfer.setData("dragged-id", ev.target.id);
}

function allowDrop(ev) {
    ev.preventDefault();
}

function drop(ev) {
    ev.preventDefault();
    var data = ev.dataTransfer.getData("dragged-id");
    var container = document.getElementById("game");
    container.removeChild(document.getElementById(data));
    bottlesCount--;
    var trashCan = document.getElementById("bucket");
    trashCan.src = "images/bucketclosed.jpg";
}

function changeBucketStateToOpen() {
    var trashCan = document.getElementById("bucket");
    trashCan.src = "images/bucketopen.jpg";
}

function changeBucketStateToClosed() {
    var trashCan = document.getElementById("bucket");
    trashCan.src = "images/bucketclosed.jpg";
}

function saveUser(nick, score) {
    loadUser();
    var top = score.toPrecision(5) + " - " + nick;
    topScore.push(top);
    topScore.sort();
    if (topScore.length > 5) {
        topScore.pop();
    }
    localStorage["score"] = JSON.stringify(topScore);
}

function loadUser() {
    topScore = JSON.parse(localStorage["score"]);
}

setInterval(function () {
    time += 0.1;
    var score = document.getElementById("score");
    score.innerHTML = "Score: " + time.toPrecision(5);

    if (bottlesCount == 0) {
        var scoreDiv = document.getElementById("score");
        scoreDiv.id = "finished-score"; //I'm using this hack because clearInterval was not working for unknown reasons
        currentNickname = prompt("Enter your nickname:");
        saveUser(currentNickname, time);
    }
}, 100);

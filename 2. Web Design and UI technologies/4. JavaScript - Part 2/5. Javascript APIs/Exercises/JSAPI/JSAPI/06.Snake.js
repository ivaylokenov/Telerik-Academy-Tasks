var Snake = (function () {

    var Position = function (x, y) {
        this.X = x;
        this.Y = y;
    }

    var Direction = [new Position(0, 10), new Position(0, -10), new Position(10, 0), new Position(-10, 0)];

    var snakeQueue = [];
    var currentDirection = Direction[0];
    var directionHasChanged = null;
    var food;
    var score = 0;
    var topScore = [];

    function InitializeSnake() {
        snakeQueue = [];
        currentDirection = Direction[0];
        score = 0;
        var field = document.getElementsByTagName("canvas")[0].getContext("2d");
        field.clearRect(0, 0, 900, 600);
        field.stroke();
        for (var i = 10; i < 80; i += 10) {
            snakeQueue.push(new Position(10, i));
        }
    }

    function InitializeFood() {
        do {
            var x = (parseInt(Math.random() * 88) + 1) * 10;
            var y = (parseInt(Math.random() * 58) + 1) * 10;
            food = new Position(x, y);
        } while (snakeQueue.indexOf(food) > -1);
    }

    function ChangeDirection(key) {
        var keyCode = key.keyCode;
        if (keyCode === 37 && currentDirection !== Direction[2]) {
            directionHasChanged = Direction[3];
        }
        if (keyCode === 39 && currentDirection !== Direction[3]) {
            directionHasChanged = Direction[2];
        }
        if (keyCode === 38 && currentDirection !== Direction[0]) {
            directionHasChanged = Direction[1];
        }
        if (keyCode === 40 && currentDirection !== Direction[1]) {
            directionHasChanged = Direction[0];
        }
        if (keyCode === 27) {
            alert("PAUSE");
        }
        if (keyCode === 32) {
            MoveSnake();
            if (Snake.CheckDead()) {
                //var currentUser = prompt("Game over! Enter your username: ");
                //var scoreToGet = document.getElementById("score");
                //Snake.SaveScore(currentUser, scoreToGet.innerHTML);
                alert("Game over!");
                Snake.InitializeSnake();
                Snake.InitializeFood();
            }
            Snake.EatFood();
            Snake.UpdateScore();
            Snake.Render();
        }
    }

    function MoveSnake() {
        var snakeHead = snakeQueue[snakeQueue.length - 1];
        var nextDirection = currentDirection;

        snakeQueue.push(new Position(snakeHead.X + nextDirection.X, snakeHead.Y + nextDirection.Y));

        if (directionHasChanged) {
            currentDirection = directionHasChanged;
            directionHasChanged = null;
        }
    }

    function EatFood() {
        var snakeHead = snakeQueue[snakeQueue.length - 1];
        if (snakeHead.X === food.X && snakeHead.Y === food.Y) {
            InitializeFood();
            score += 10;
        }
        else {
            snakeQueue.shift();
        }
    }

    function CheckDead() {
        var snakeHead = snakeQueue[snakeQueue.length - 1];
        if (snakeHead.X >= 900 || snakeHead.X <= 0 || snakeHead.Y <= 0 || snakeHead.Y >= 600) {
            return true;
        }

        for (var i = 0; i < snakeQueue.length - 1; i++) {
            if (snakeHead.X === snakeQueue[i].X && snakeHead.Y === snakeQueue[i].Y) {
                return true;
            }
        }

        return false;
    }

    function RenderSnake() {
        var field = document.getElementsByTagName("canvas")[0].getContext("2d");
        field.clearRect(0, 0, 900, 600);
        field.stroke();

        for (var i = 0; i < snakeQueue.length; i++) {
            field.beginPath();
            field.arc(snakeQueue[i].X, snakeQueue[i].Y, 4, 0, 2 * Math.PI, false);
            field.stroke();
        }

        field.beginPath();
        field.arc(food.X, food.Y, 4, 0, 2 * Math.PI, false);
        field.stroke();
    }

    function UpdateScore() {
        var scoreSpan = document.getElementById("score");
        scoreSpan.innerHTML = score;
    }

    function SaveScore(nick, scoreToSave) {
        LoadScore();
        var top = scoreToSave + " - " + nick;
        topScore.push(top);
        topScore.sort();
        if (topScore.length > 5) {
            topScore.pop();
        }
        localStorage["snake-score"] = JSON.stringify(topScore);
    }

    function LoadScore() {
        topScore = JSON.parse(localStorage["snake-score"]);
    }

    function Speed() {
        return 1 + score / 10;
    }

    return {
        InitializeSnake: InitializeSnake,
        Render: RenderSnake,
        Move: MoveSnake,
        ChangeDirection: ChangeDirection,
        CheckDead: CheckDead,
        InitializeFood: InitializeFood,
        EatFood: EatFood,
        UpdateScore: UpdateScore,
        SaveScore: SaveScore,
        LoadScore: LoadScore,
        Speed: Speed
    }
}());

Snake.InitializeSnake();
Snake.InitializeFood();
Snake.EatFood();

setInterval(function () {
        Snake.Move();
        if (Snake.CheckDead()) {
            //var currentUser = prompt("Game over! Enter your username: ");
            //var scoreToGet = document.getElementById("score");
            //Snake.SaveScore(currentUser, scoreToGet.innerHTML);
            alert("Game over!");
            Snake.InitializeSnake();
            Snake.InitializeFood();
        }
        Snake.EatFood();
        Snake.UpdateScore();
        Snake.Render();
}, 100);

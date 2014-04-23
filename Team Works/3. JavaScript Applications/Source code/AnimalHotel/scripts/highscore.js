var HighScore = {
	initialize: function (hotel, mainMenu) {
        this.hotel = hotel;
        this.mainMenu = mainMenu;
		this.score = 0;
		var _self = this;
		
		var renderedScore = $('<h2>' + "Level: 1 Score: " + _self.score.toFixed(2) + '</h2>');
		$('#hotel-menu').append(renderedScore);
		
		var hasCat = [1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1];
		var names = ["Pesho", "Stamat", "Gosho", "Asparuh", "Limon", "Neofit", "Kolio", "Kyci", "Pryci", "Levski", "CSKA", "Zergling", "Zealot", "Sexy", "Slavkata", "Poli :D", "Ivo"];
		
		var soFarScore = 0;
		var addedCats = 1;
		
		this.level = addedCats;
		
		setInterval(function () {
			
		var moodSum = 0;
		var healthSum = 0;
		var hungerSum = 0;
		
		for(var i = 0; i < sanMarino.rooms.length; i++){
			if (_self.hotel.rooms[i].roomer) {
			
			if (_self.hotel.rooms[i].roomer.mood) {
				moodSum += _self.hotel.rooms[i].roomer.mood / 10;
			}
			
			if( _self.hotel.rooms[i].roomer.catid != "dragon"){
				hungerSum += _self.hotel.rooms[i].roomer._super.hunger / 100;
				healthSum += _self.hotel.rooms[i].roomer._super.health / 100;
				}
				
				// Points given for that that the Dragon is alive
				if(_self.hotel.rooms[i].roomer.catid == "dragon"){
				hungerSum += _self.hotel.rooms[i].roomer._super.hunger / 10000;
				healthSum += _self.hotel.rooms[i].roomer._super.health / 100;
				}
				// Two if statements give bonus points. 
				if(_self.hotel.rooms[i].roomer._super.health>9 &&_self.hotel.rooms[i].roomer.catid != "dragon"){
					_self.score+=3;
				}
				
				if(_self.hotel.rooms[i].roomer.mood>20 && _self.hotel.rooms[i].roomer.catid != "dragon"){
					_self.score+=3;
				}
				
				// Next if statement give bonus points for the Dragon
				if(_self.hotel.rooms[i].roomer._super.hunger>995){
					_self.score+=10;
				}
				
				_self.score += hungerSum + moodSum + healthSum;
			}
		}		
		
		$('#hotel-menu h2').text("Level: " + _self.hotel.numOccupiedRooms() + " Score: " + _self.score.toFixed(2));
		
		if (hasCat[addedCats - 1] == 1 && _self.score > addedCats * 100 + soFarScore){
			hasCat[addedCats - 1] = 0;
			addedCats++;
			soFarScore = addedCats * 100 + soFarScore;
			var cat = Object.create(Cat);
			cat.initialize(names[addedCats - 1], 10, 10, 10, 20);
			sanMarino.addCat(cat);
			sanMarino.render();
		}
		
		}, 1000);
	}
};

function getGameScore() {
    if (!localStorage.getObject("highScore")) {
        localStorage.setObject("highScore", 0);
    }

    var currentScore = localStorage.getObject("highScore");

    if (currentScore < highScoreFinal.score) {
        currentScore = highScoreFinal.score;
        localStorage.setObject("highScore", currentScore);
    }

    return currentScore;
}

function loadScoreGame() {
    if (localStorage.getObject("highScore")) {
        if (!document.getElementById("scoreBoard")) {
            var scoreDiv = $("<div></div>");
            scoreDiv.attr('id', 'scoreBoard');
        }

        var currentScore = localStorage.getObject("highScore");
        scoreDiv.append(currentScore.toFixed(2));

        $("#settings").append(scoreDiv);
    }
    else {
        var alertEmptyScorboard = $("<div class='alert'>0</div>");
        $("#settings").append(alertEmptyScorboard);
        setTimeout(function () {
            $("#settings .alert").remove();
        }, 3000);
    }

}
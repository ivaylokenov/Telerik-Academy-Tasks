var Animal = {
    initialize: function (name, age, health, hunger) {
        this.name = name;
        this.age = age;
        this.health = health;
        this.hunger = hunger;
    }
};

var generatedCats = [];

var Cat = Animal.extendmethod({
    initialize: function (name, age, health, hunger, mood) {
        this._super = Object.create(this._super);
        this._super.initialize(name, age, health, hunger);
        this.mood = mood;
        this.catid = null;

        var generateNumber = Math.floor((Math.random() * 14) + 1);

        while ($.inArray(generateNumber, generatedCats) > -1 && generatedCats.length <= 13) {
            generateNumber = Math.floor((Math.random() * 14) + 1);
        }

        generatedCats.push(generateNumber);

        this.image = "images/cat" + generateNumber + ".png";
        var _self = this;
        var passedTime = 0;
        var startHunger = this._super.hunger;

        var currentInterval = setInterval(function () {

            passedTime += 1000;

            if (_self._super.hunger == 0) {
                _self._super.hunger = startHunger;
                _self._super.health--;
            }

            if (passedTime % 1000 == 0) {
                passedTime = 0;
                _self._super.hunger--;
            }

            if (_self._super.health == 0) {
                _self._super.hunger = 0;
                _self.image = 'images/X.png';
                clearInterval(currentInterval);
            }

        }, 1000);

        var currentMoodInterval = setInterval(function () {

            passedTime += 1000;

            if (passedTime % 1000 == 0) {
                _self.mood--;
            }

            if (_self.mood == 0) {
                clearInterval(currentMoodInterval);
            }

        }, 1000);
    },

    introduce: function () {
        return this._super.name;
    },
    portrait: function () {
        var div = $('<div>');
        var img = $("<img>");
        img.attr('src', this.image);
        img.attr('alt', this._super.name);
        img.attr('class', 'draggable portrait');
        img.attr('draggable', true);
        img.attr('ondragstart', 'drag(event)');
        img.attr('ondrop', 'findCat(event)');
        img.attr('ondragover', 'allowDrop(event)');

        div.append(img);
        div.append("<p> <img src='images/healthIndicator.png'  />   " + this._super.health + "    " + " <img src='images/foodIndicator.png' />   "
        + this._super.hunger + "   " + " <img src='images/layout/smile.png' style='height: 18px; width: 18px '/>   " + this.mood + "</p>");
        return div;
    }
});

var Dragon = Animal.extendmethod({
    initialize: function () {
        this._super = Object.create(this._super);
        this._super.initialize("Dragon", 1, 1, 1000);
        this.catid = "dragon";

        this.image = "images/Dragon.png";
        var _self = this;
        var passedTime = 0;
        var startHunger = this._super.hunger;

        var currentInterval = setInterval(function () {

            passedTime += 1000;

            if (_self._super.hunger <= 0) {
                _self._super.hunger = startHunger;
                _self._super.health--;
            }

            if (passedTime % 1000 == 0) {
                passedTime = 0;
                _self._super.hunger--;
            }

            if (_self._super.health <= 0) {
                _self._super.hunger = 0;
                clearInterval(currentInterval);
            }

        }, 1000);
    },
    introduce: function () {
        return this._super.name;
    },
    portrait: function () {
        var div = $('<div>');
        var img = $("<img>");
        img.attr('src', this.image);
        img.attr('alt', this._super.name);
        img.attr('class', 'draggable portrait');
        img.attr('draggable', true);
        img.attr('ondragstart', 'drag(event)');
        img.attr('ondrop', 'dragonFeed(event)');
        img.attr('ondragover', 'allowDrop(event)');

        div.append(img);
        div.append("<p> <img src='images/healthIndicator.png'  />   " + this._super.health + "    " + " <img src='images/dragonHealth.png' />   "
		+ this._super.hunger + "</p>");
        return div;
    }
});
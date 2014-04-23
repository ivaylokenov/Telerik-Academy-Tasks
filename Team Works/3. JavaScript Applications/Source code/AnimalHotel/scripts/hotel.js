var Hotel = {
    initialize: function (name, capacity) {
        _self = this;
        this.hasDragon = false;
        this.name = name;
        this.rooms = [];
        this.capacity = capacity;
        this.occupied = 0;
        for (var j = 0; j < this.capacity; j++) {
            var room = Object.create(Room);
            room.initialize();
            this.rooms.push(room);
        }
    },
    addRoom: function (room) {
        this.rooms.push(room);
    },
    addCat: function (cat) {
        if (cat.catid == "dragon") {
            this.rooms[11].addRoomer(cat);
            this.occupied += 1;
        }
        else {
            for (var i = 0; i < this.rooms.length; i++) {
                if (this.rooms[i].isFree()) {
                    this.rooms[i].addRoomer(cat);
                    this.occupied += 1;
                    break;
                }
            }
        }
    },
    rename: function (name) {
        this.name = name;
    },
    removeRoom: function () {
        if (this.rooms.length > 0) {
            this.rooms.pop(rooms[rooms.length - 1]);
        } else {
            console.log("You can not remove room. There are no rooms!");
        }

    },
    numOccupiedRooms: function () {
        return this.occupied;
    },
    getName: function () {
        return this.name;
    },
    numFreeRooms: function () {
        var rooms = this.capacity - this.occupied;
        return rooms;
    },
    gameOver: function () {
        if (this.rooms.length > 0) {
            var freeRoomsCount = this.rooms.length;
            for (var i = 0; i < this.rooms.length; i++) {
                if (this.rooms[i].roomer != null && this.rooms[i].roomer._super.health == 0) {
                    freeRoomsCount--;
                }
            }

            if (freeRoomsCount == 0) {
                var alertGameOver = $("<div id='gameOver'> Game over! <h3 style='font-size: 16px'>Highscore: " + getGameScore().toFixed(2) + "</h3></div>");
                
                $("#hotel").append(alertGameOver);
                
                var isGameOver = true;
                return isGameOver;
            }
        }
    },
    render: function () {
        $("#hotel").html('');
        if (this.rooms.length > 0) {
            for (var i = 0; i < this.rooms.length; i++) {
                var room = this.rooms[i].render();
                this.rooms[i].id = i;
                room.attr('id', 'room' + i);
                $("#hotel").append(room);
                $('#room' + i + ' > div > img').attr('id', 'cat' + i);
            }
        }

        if (this.hasDragon) {
            $('#room11 > div > img').attr('id', 'dragon');
        }

        var _self = this;

        var timer = 0;
        var gameOverTotal = false;

        var interval = setInterval(function () {
            timer++;

            if (gameOverTotal) {
                clearInterval(interval);
                return;
            }

            if (_self.rooms.length > 0) {
                for (var i = 0; i < _self.rooms.length; i++) {
                    if (_self.rooms[i].roomer != null && _self.rooms[i].roomer._super.health > 0) {
                        var room = $('#room' + i + ' > div > p')[0];

                        if (_self.hasDragon && i == 11) {
                            room.innerHTML = "<img src='images/healthIndicator.png' /> "
                            + _self.rooms[i].roomer._super.health + " "
                            + "<img src='images/dragonHealth.png' />   "
                            + _self.rooms[i].roomer._super.hunger;
                        }
                        else {
                            room.innerHTML = "<img src='images/healthIndicator.png' /> "
                            + _self.rooms[i].roomer._super.health + " "
                            + "<img src='images/foodIndicator.png' />   "
                            + _self.rooms[i].roomer._super.hunger + " "
                            + "<img src='images/layout/smile.png' /> "
                            + _self.rooms[i].roomer.mood;
                        }

                        if (timer % 3 == 0) {
                            var image = $('#room' + i + ' > div > img');
                            var src = image.attr('src');

                            if (src.indexOf('b') != -1) {
                                src = src.substring(src.indexOf('/'), src.indexOf('b'));
                                image.attr('src', 'images' + src + '.png');
                            }
                            else {
                                src = src.substring(src.indexOf('/'), src.indexOf('.'));
                                image.attr('src', 'images' + src + 'b.png');
                            }
                        }
                    }
                    else if (_self.rooms[i].roomer != null && _self.rooms[i].roomer._super.health <= 0) {
                        room = $('#room' + i)[0];

                        room.innerHTML = "<h2>No vacancy</h2><img class='portrait' src='images/X.png' />";
                    }
                }
                if (_self.gameOver()) {
                    gameOverTotal = true
                }
            }
        }, 1000);
    }
};

var Room = {
    initialize: function () {
        this.occupied = false;
        this.roomer = null;
        this.id = null;
    },
    addRoomer: function (cat) {
        this.roomer = cat;
        this.occupied = true;
    },
    isFree: function () {
        if (this.occupied === false) {
            return true;
        }
        else return false;
    },
    removeRoomer: function () {
        if (this.roomer != null) {
            this.roomer = null;
            this.occupied = false;
            $('#room' + this.id + ' > h2').remove();
            $('#room' + this.id + ' > div').remove();
            $('#room' + this.id + ' > button').remove();
        }
    },
    render: function () {
        var _self = this;
        var room = $("<div></div>");
        room.attr('class', 'room');

        if (this.roomer != null && this.roomer._super.health > 0) {
            var name = $("<h2></h2>");
            name.text(this.roomer.introduce());

            var removeCat = $('<button/>');
            removeCat.attr('class', 'delete');
            removeCat.on('click', function () {
                _self.removeRoomer();
            });

            if (this.roomer.catid == "dragon") {
                room.append(name).append(this.roomer.portrait());
            }
            else {
                room.append(removeCat).append(name).append(this.roomer.portrait());
            }
        }
        else if (this.roomer != null && this.roomer._super.health > 0) {
            room.append("<h2>No vacancy</h2><img src='images/X.png' />");
        }

        return room;
    }
};
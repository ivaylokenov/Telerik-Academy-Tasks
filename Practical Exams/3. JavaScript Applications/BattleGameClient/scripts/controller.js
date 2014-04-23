/// <reference path="jquery-2.0.2.js" />
/// <reference path="class.js" />
/// <reference path="persister.js" />

var controllers = (function () {

    var rootUrl = "http://localhost:22954/api/";
    var updateTimer = null;

    var field = new Array(9);
    var selectedUnitId = null;
    var gameId;
    var currentUser;
    var me;

    var currentField = new Array(9);

    for (var i = 0; i < 9; i++) {
        currentField[i] = new Array(9);

        for (var j = 0; j < 9; j++) {
            currentField[i][j] = 0;
        }
    }

    for (var i = 0; i < 9; i++) {
        field[i] = new Array(9);
    }

    var Controller = Class.create({

        init: function () {
            this.persister = persisters.get(rootUrl);
        },
        loadUI: function (selector) {
            if (this.persister.isUserLoggedIn()) {
                this.loadGameUI(selector);
            }
            else {
                this.loadLoginUI(selector);
            }
            this.attachHandlers(selector);
        },
        loadLoginUI: function (selector) {
            var loginHtml = ui.loginForm();
            $(selector).html(loginHtml);
        },
        loadGameUI: function (selector) {
            var gameUI = ui.gameUI();
            $(selector).html(gameUI);
            $(selector + ' #nickname').text(this.persister.getNickname());

            this.reloadUI(selector);
            var self = this;

            updateTimer = setInterval(function () {
                self.reloadUI(selector);
            }, 10000);
        },
        reloadUI: function(selector){
            //add errors here
            this.persister.game.open(function (games) {
                var list = ui.openGamesList(games);
                $(selector + " #open-games")
					.html(list);
            });

            this.persister.game.myActive(function (games) {
                var list = ui.activeGamesList(games);
                $(selector + " #active-games")
					.html(list);
            });

            this.persister.message.all(function (msg) {
                var msgList = ui.messagesList(msg);
                $(selector + " #messages").html(msgList);
            });

            this.persister.user.scores(function (score) {
                var list = ui.scoreBoard(score);
                $(selector + " #scores").html(list);
            });

            if (gameId) {
                this.loadCurrentGame(gameId);
            }
        },
        loadCurrentGame: function (gameId) {
            this.persister.game.field(gameId, function (data) {

                currentUser = data.inTurn;
                var field = data;

                for (var i = 0; i < 9; i++) {
                    currentField[i] = new Array(9);

                    for (var j = 0; j < 9; j++) {
                        currentField[i][j] = 0;
                    }
                }

                if (data.turn % 2 == 1) {
                    me = "red";
                }
                else {
                    me = "blue";
                }

                for (var i = 0; i < field.red.units.length; i++) {
                    currentField[field.red.units[i].position.x][field.red.units[i].position.y] = field.red.units[i];
                }

                for (var i = 0; i < field.blue.units.length; i++) {
                    currentField[field.blue.units[i].position.x][field.blue.units[i].position.y] = field.blue.units[i];
                }

                var gameField = ui.currentGameState(data, currentField);
                $("#data-visualise").html(gameField);
            }, function (err) {
                wrapper.find('#game-data').append('<span id="error">' + err.responseJSON.Message + '</span>');
                setInterval(function () {
                    wrapper.find('#game-data').text("");
                }, 3000);
            });
        },
        attachHandlers: function (selector) {
            var wrapper = $(selector);
            var self = this;

            wrapper.on('click', '#register-span', function () {
                wrapper.find('#register.selected').removeClass('selected');
                wrapper.find('#login').addClass('selected');
                wrapper.find('#login-span').show();
                wrapper.find('#register-span').hide();
            });

            wrapper.on('click', '#login-span', function () {
                wrapper.find('#login.selected').removeClass('selected');
                wrapper.find('#register').addClass('selected');
                wrapper.find('#login-span').hide();
                wrapper.find('#register-span').show();
            });

            wrapper.on('click', '#register-btn', function () {
                var userData = {
                    username: $('<div />').html($(selector).find('#reg-username').val()).text(),
                    nickname: $('<div />').html($(selector).find('#reg-nickname').val()).text(),
                    password: $('<div />').html($(selector).find('#reg-password').val()).text(),
                }

                self.persister.user.register(userData, function () {
                    self.loadGameUI(selector);
                }, function (err) {
                    wrapper.find('#start-form').append('<span id="error">' + err.responseJSON.Message + '</span>');
                    setInterval(function () {
                        wrapper.find('#start-form #error').text("");
                    }, 3000);
                });

                return false;
            });

            wrapper.on('click', '#login-btn', function () {
                var userData = {
                    username: $('<div />').html($(selector).find('#lgn-username').val()).text(),
                    password: $('<div />').html($(selector).find('#lgn-password').val()).text(),
                }

                self.persister.user.login(userData, function () {
                    self.loadGameUI(selector);
                }, function (err) {
                    wrapper.find('#start-form').append('<span id="error">' + err.responseJSON.Message + '</span>');
                    setInterval(function () {
                        wrapper.find('#start-form #error').text("");
                    }, 3000);
                });
            });

            wrapper.on('click', '#logout', function () {
                self.persister.user.logout(function () {
                    self.loadLoginUI(selector);
                    clearInterval(updateTimer);
                }, function () {
                    wrapper.find('#game-data').append('<span id="error">' + err.responseJSON.Message + '</span>');
                    setInterval(function () {
                        wrapper.find('#game-data').text("");
                    }, 3000);
                });
            });

            wrapper.on('click', '#create-game', function () {
                var gameData = {
                    title: $('<div />').html($(selector).find('#game-title').val()).text(),
                }

                var pass = $('<div />').html($(selector).find('#game-password').val()).text();

                if (pass) {
                    gameData.password = pass;
                }

                self.persister.game.create(gameData, function () {
                    console.log('Game created');
                    me = "red";
                }, function () {
                    //to be added
                });
            });

            wrapper.on('click', '#open-games-container a', function () {
                $("#game-join-inputs").remove();
                var html =
					'<div id="game-join-inputs">' +
						'Password: <input type="text" id="tb-game-pass"/><br/>' +
						'<button id="btn-join-game">Join</button>' +
					'</div>';
                $(this).next().after(html);
            });

            wrapper.on("click", "#btn-join-game", function () {
                var game = {
                    id: $(this).parents("li").first().data("game-id")
                };

                var password = $('<div />').html($("#tb-game-pass").val()).text();

                if (password) {
                    game.password = password;
                }

                self.persister.game.join(game, function () {
                    console.log("joined");
                    me = "blue";
                }, function () {
                    wrapper.find('#game-data').append('<span id="error">' + err.responseJSON.Message + '</span>');
                    setInterval(function () {
                        wrapper.find('#game-data').text("");
                    }, 3000);
                });
            });

            wrapper.on("click", "#active-games-container li.game-status-full a.btn-active-game", function () {
                var gameCreator = $(this).parent().data("creator");
                var myNickname = self.persister.getNickname();
                if (gameCreator == myNickname) {
                    $("#btn-game-start").remove();
                    var html =
						'<a href="#" id="btn-game-start">' +
							' Start' +
						'</a>';
                    $(this).parent().append(html);
                }
            });

            wrapper.on("click", "#btn-game-start", function () {
                var parent = $(this).parent();

                var gameId = parent.data("game-id");
                self.persister.game.start(gameId, function () {
                    console.log('started');
                    wrapper.find("#game-holder").html("started");
                },
				function (err) {
				    wrapper.find('#game-data').append('<span id="error">' + err.responseJSON.Message + '</span>');
				    setInterval(function () {
				        wrapper.find('#game-data').text("");
				    }, 3000);
				});

                return false;
            });

            wrapper.on('click', "#vis-btn", function () {
                var parent = $(this).parent().parent();

                gameId = parent.data("game-id");

                self.loadCurrentGame(gameId);
            });

            wrapper.on('click', "td", function () {
                
                var x = $(this).data("x");
                var y = $(this).data("y");

                if (currentField[x][y] != 0 && currentField[x][y].owner == "blue") {

                    var type;

                    if (currentField[x][y].type == 'ranger') {
                        type = "Titan (Range)";
                    }
                    else {
                        type = "Dragon (Warrior)";
                    }

                    $('#unit-details-blue').html('<span> <strong>Type:</strong> ' + type + ' <strong>Attack:</strong> ' + currentField[x][y].attack
                        + ' <strong>Armor:</strong> ' + currentField[x][y].armor + ' <strong>Hit points:</strong> ' + currentField[x][y].hitPoints + ' <strong>Mode:</strong> ' + currentField[x][y].mode + '</span>');
                }

                if (currentField[x][y] != 0 && currentField[x][y].owner == "red") {

                    var type;

                    if (currentField[x][y].type == 'ranger') {
                        type = "Titan (Range)";
                    }
                    else {
                        type = "Dragon (Warrior)";
                    }

                    $('#unit-details-red').html('<span> <strong>Type:</strong> ' + type + ' <strong>Attack:</strong> ' + currentField[x][y].attack
                        + ' <strong>Armor:</strong> ' + currentField[x][y].armor + ' <strong>Hit points:</strong> ' + currentField[x][y].hitPoints + ' <strong>Mode:</strong> ' + currentField[x][y].mode + '</span>');
                }

                if (currentUser != me) {
                    return;
                }
                else if (selectedUnitId != null && currentField[x][y] != 0 && currentField[x][y].id == selectedUnitId.id) {

                        selectedUnitId = null;
                }
                else if (currentField[x][y] != 0 && currentField[x][y].owner == currentUser) {
                    selectedUnitId = currentField[x][y];
                    $('#game-data').html('<a href="#" id="defend">Defend x: ' + x + ' y: ' + y + '</a>');
                }
                else if (selectedUnitId != null && currentField[x][y] == 0) {

                    var position = {
                        x: x,
                        y: y
                    }

                    var unitData = {
                        unitId: selectedUnitId.id,
                        position: position
                    };

                    self.persister.battle.move(gameId, unitData, function () {
                        self.loadCurrentGame(gameId);
                    }, function (err) {
                        wrapper.find('#game-data').append('<span id="error">' + err.responseJSON.Message + '</span>');
                        setInterval(function () {
                            wrapper.find('#game-data').text("");
                        }, 3000);
                    });
                }
                else if (selectedUnitId != null && currentField[x][y] != 0) {

                    var position = {
                        x: x,
                        y: y
                    }

                    var unitData = {
                        unitId: selectedUnitId.id,
                        position: position
                    };

                    self.persister.battle.attack(gameId, unitData, function () {
                        self.loadCurrentGame(gameId);
                    }, function (err) {
                        wrapper.find('#game-data').append('<span id="error">' + err.responseJSON.Message + '</span>');
                        setInterval(function () {
                            wrapper.find('#game-data').text("");
                        }, 3000);
                    });
                }
            });

            wrapper.on('click', '#defend', function () {

                var id = selectedUnitId.id;

                self.persister.battle.defend(gameId, id, function () {
                    console.log("def");
                }, function (err) {
                    wrapper.find('#game-data').append('<span id="error">' + err.responseJSON.Message + '</span>');
                    setInterval(function () {
                        wrapper.find('#game-data').text("");
                    }, 3000);
                });

            });
        }

    });

    return {
        get: function () {
            return new Controller();
        }
    }

}());

$(function () {
    var controller = controllers.get();
    controller.loadUI('#battle-game');
});
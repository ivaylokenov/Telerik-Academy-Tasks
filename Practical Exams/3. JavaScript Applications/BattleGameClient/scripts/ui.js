/// <reference path="class.js" />
/// <reference path="persister.js" />
/// <reference path="jquery-2.0.2.js" />
/// <reference path="ui.js" />

var ui = (function () {

    function LoginFormUI() {
        var html =
            '<div id="start-form">' +
                '<h1>Battle Game</h1>' +
                '<div id="login-form">' +
                    '<div id="login" class="selected">' +
                        '<label for="lgn-username">Username</label>' +
                        '<input type="text" id="lgn-username"/>' +
                        '<label for="lgn-password">Password</label>' +
                        '<input type="password" id="lgn-password"/>' +
                        '<button id="login-btn">Login</button>' +
                    '</div>' +
                    '<div id="register">' +
                        '<label for="reg-username">Username</label>' +
                        '<input type="text" id="reg-username"/>' +
                        '<label for="reg-nickname">Nickname</label>' +
                        '<input type="text" id="reg-nickname"/>' +
                        '<label for="reg-password">Password</label>' +
                        '<input type="password" id="reg-password"/>' +
                        '<button id="register-btn">Register</button>' +
                    '</div>' +
                    '<span id="register-span">Register </span>' +
                    '<span id="login-span">Login </span>' +
                '</div>' +
            '</div>';

        return html;
    }

    function GameUI() {
        var html =
            '<h1>Battle Game</h1>' +
            '<div id="madness">' +
            '<div id="game-control">' +
                '<span id="nickname"></span>' +
                '<button id="logout">Logout</button>' +
                '<br/>' +

                '<label for="game-title">Title</label>' +
                '<input type="text" id="game-title">' +
                '<label for="game-password">Password</label>' +
                '<input type="password" id="game-password">' +
                '<button id="create-game">Create Game</button>' +
                '<br />' +
            '</div>' +

            '<div id="active-games-container">' +
                '<p><strong>Active games</strong></p>' +
                '<div id="active-games"></div>' +
            '</div>' +

            '<div id="open-games-container">' +
                '<p><strong>Open games</strong></p>' +
                '<div id="open-games"></div>' +
            '</div>' +

            '</div>' +

            '<div id="second-madness">' +

            '<div id="another-madness">' +
                '<div id="game-data"></div>' +
                '<div id="data-visualise">' +
                '</div>' +
            '</div>' +

            '<div id="messages-container">' +
                '<p><strong>Messages</strong></p>' +
                '<div id="messages"></div>' +
            '</div>' +

            '<div id="scores-container">' +
                '<p><strong>Score</strong></p>' +
                '<div id="scores"></div>' +
            '</div>' +

            '</div>'
        ;

        return html;
    }

    function buildOpenGamesList(games) {
        var list = '<ul class="game-list open-games">';
        for (var i = 0; i < games.length; i++) {
            var game = games[i];
            list +=
				'<li data-game-id="' + game.id + '">' +
					'<a href="#" >' +
						$("<div />").html(game.title).text() +
					'</a>' +
					'<span> by ' +
						game.creator +
					'</span>' +
				'</li>';
        }
        list += "</ul>";
        return list;
    }

    function buildActiveGamesList(games) {
        var gamesList = Array.prototype.slice.call(games, 0);
        gamesList.sort(function (g1, g2) {
            if (g1.status == g2.status) {
                return g1.title > g2.title;
            }
            else {
                if (g1.status == "in-progress") {
                    return -1;
                }
            }
            return 1;
        });

        var list = '<ul class="game-list active-games">';
        for (var i = 0; i < gamesList.length; i++) {
            var game = gamesList[i];
            var btnVisualize = '';
            if (game.status == 'in-progress') {
                btnVisualize = ' <a href="#" id="vis-btn">View Game</a>'
            }

            list +=
				'<li class="game-status-' + game.status + '" data-game-id="' + game.id + '" data-creator="' + game.creator + '">' +
					'<a href="#" class="btn-active-game">' +
						$("<div />").html(game.title).text() +
					'</a>' +
					'<span> by ' +
						game.creator + ' (' + game.status + ')' + btnVisualize +
					'</span>' +
				'</li>';
        }
        list += "</ul>";
        return list;
    }

    function buildMessagesList(messages) {
        var list = '<ul class="messages-list">';
        var msg;
        for (var i = 0; i < messages.length; i += 1) {
            msg = messages[i];
            var item =
				'<li>' +
					'<span href="#" class="message-state-' + msg.state + '">' +
						msg.text +
					'</span>' +
				'</li>';
            list += item;
        }
        list += '</ul>';
        return list;
    }

    function createScoresBoard(data) {

        data.sort(function (g1, g2) {
            if (g1.score == g2.score) {
                return g1.nickname > g2.nickname;
            }
            else
                if (g1.score > g2.score) {
                    return -1;
                }

            return 1;
        });

        var scoresUl = '<ul id="scores-list">';
        for (var i = 0; i < data.length; i++) {
            if (data[i].nickname == nickname) {
                scoresUl += '<li class ="current-player">' + data[i].nickname + ' -> ' + data[i].score + ' points</li>';
            }
            else {
                scoresUl += '<li>' + data[i].nickname + ' -> ' + data[i].score + ' points </li>';
            }
        }
        scoresUl += '</ul>'
        return scoresUl;
    }

    function loadCurrentGameUI(field, arrayField) {

        var table = '<span id="game-nick-blue">' + field.blue.nickname + '</span><span id="unit-details-blue"></span><table>';

        for (var i = 0; i < 9; i++) {
            table += "<tr>";
            for (var j = 0; j < 9; j++) {
                if (arrayField[i][j] == 0) {
                    table += "<td data-x='" + i + "' data-y='"+ j + "'></td>";
                }
                else {
                    table += "<td data-x='" + i + "' data-y='" + j + "' data-owner='" + arrayField[i][j].owner + "' data-unitid='" + arrayField[i][j].id + "' style='background-color: " + arrayField[i][j].owner + "'></td>";
                }
            }
            table += "</tr>";
        }

        table += '</table><span id="game-nick-red">' + field.red.nickname + '</span><span id="unit-details-red"></span>';

        return table;
    }

    return {
        loginForm: LoginFormUI,
        gameUI: GameUI,
        openGamesList: buildOpenGamesList,
        activeGamesList: buildActiveGamesList,
        messagesList: buildMessagesList,
        scoreBoard: createScoresBoard,
        currentGameState: loadCurrentGameUI
    }
}());
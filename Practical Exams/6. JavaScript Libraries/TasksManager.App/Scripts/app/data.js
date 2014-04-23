/// <reference path="../libs/_references.js" />

window.persisters = (function () {
    var token = "";
    var username = "";
    function getJSON(requestUrl, headers) {
        var promise = new RSVP.Promise(function (resolve, reject) {
            $.ajax({
                url: requestUrl,
                type: "GET",
                dataType: "json",
                headers: headers,
                success: function (data) {
                    resolve(data);
                },
                error: function (err) {
                    reject(err);
                }
            });
        });
        return promise;
    }

    function postJSON(requestUrl, data, headers) {
        var promise = new RSVP.Promise(function (resolve, reject) {
            $.ajax({
                url: requestUrl,
                type: "POST",
                contentType: "application/json",
                data: JSON.stringify(data),
                dataType: "json",
                headers: headers,
                success: function (data) {
                    resolve(data);
                },
                error: function (err) {
                    reject(err);
                }
            });
        });
        return promise;
    }

    function deleteJSON(requestUrl, headers) {
        var promise = new RSVP.Promise(function (resolve, reject) {
            $.ajax({
                url: requestUrl,
                type: "DELETE",
                dataType: "json",
                headers: headers,
                success: function (data) {
                    resolve(data);
                },
                error: function (err) {
                    reject(err);
                }
            });
        });
        return promise;
    }

    function putJSON(requestUrl, data, headers) {
        var promise = new RSVP.Promise(function (resolve, reject) {
            $.ajax({
                url: requestUrl,
                type: "PUT",
                contentType: "application/json",
                data: JSON.stringify(data),
                dataType: "json",
                headers: headers,
                success: function (data) {
                    resolve(data);
                },
                error: function (err) {
                    resolve(err);
                }
            });
        });
        return promise;
    }

    function generateHeader() {
        return {
            "X-accessToken": localStorage.getItem("token")
        };
    }

    var UsersPersister = Class.create({
        init: function (apiUrl) {
            this.apiUrl = apiUrl;
        },
        login: function (username, password) {
            var user = {
                username: username,
                authCode: CryptoJS.SHA1(username + password).toString(),
            };
            return postJSON(this.apiUrl + "auth/token", user)
				.then(function (data) {
				    localStorage.setItem("token", data.accessToken);
				    localStorage.setItem("username", data.username);
				    token = data.accessToken;
				    username = data.username;
				});
        },
        register: function (username, password, email) {
            var user = {
                username: username,
                authCode: CryptoJS.SHA1(username + password).toString(),
                email: email
            };
            return postJSON(this.apiUrl + "users/register", user)
				.then(function (data) {
				    localStorage.setItem("token", data.accessToken);
				    localStorage.setItem("username", data.username);
				    token = data.accessToken;
				    username = data.username;
				    return data.username;
				});
        },
        logout: function () {
            if (!token) {
                //gyrmi
            }
            var headers = generateHeader();
            localStorage.removeItem("token");
            token = "";
            localStorage.removeItem("username");
            username = "";
            $('#main-menu').remove();
            $('#content > div').remove();
            // debugger;
            return putJSON(this.apiUrl + "users", null, headers);
        },
        currentUser: function () {
            return localStorage.getItem("username");
        }
    });

    var AppointmentsPersister = Class.create({
        init: function (apiUrl) {
            this.apiUrl = apiUrl;
        },
        create: function (appointment) {
            
            var headers = generateHeader();

            return postJSON(this.apiUrl, appointment, headers);
        },
        all: function () {

            var headers = generateHeader();

            return getJSON(this.apiUrl + 'all', headers);
        },
        comming: function () {

            var headers = generateHeader();

            return getJSON(this.apiUrl + 'comming', headers);
        },
        byDate: function (date) {

            var headers = generateHeader();

            return getJSON(this.apiUrl + '?date=' + date, headers);
        },
        today: function () {

            var headers = generateHeader();

            return getJSON(this.apiUrl + 'today', headers);
        },
        current: function () {

            var headers = generateHeader();

            return getJSON(this.apiUrl + 'current', headers);
        }
    });

    var ListsPersister = Class.create({
        init: function (apiUrl) {
            this.apiUrl = apiUrl;
        },
        create: function (list) {

            var headers = generateHeader();

            return postJSON(this.apiUrl, list, headers);
        },
        all: function () {

            var headers = generateHeader();

            return getJSON(this.apiUrl, headers);
        },
        createTodo: function (listId, toDo) {

            var headers = generateHeader();

            return postJSON(this.apiUrl + listId + '/todos', toDo, headers);
        },
        allToDos: function (listId) {

            var headers = generateHeader();

            return getJSON(this.apiUrl + listId + '/todos', headers);
        }
    });

    var ToDosPersister = Class.create({
        init: function (apiUrl) {
            this.apiUrl = apiUrl;
        },
        changeStatus: function (toDoId) {

            var headers = generateHeader();

            return putJSON(this.apiUrl + toDoId, null, headers);
        }
    });

    var DataPersister = Class.create({
        init: function (apiUrl) {
            this.apiUrl = apiUrl;
            this.users = new UsersPersister(apiUrl);
            this.appointments = new AppointmentsPersister(apiUrl + 'appointments/');
            this.lists = new ListsPersister(apiUrl + 'lists/');
            this.todos = new ToDosPersister(apiUrl + 'todos/');
        }
    });

    return {
        get: function (apiUrl) {
            return new DataPersister(apiUrl);
        }
    }

}());
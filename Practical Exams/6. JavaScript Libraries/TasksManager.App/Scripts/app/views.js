/// <reference path="../libs/_references.js" />

window.viewsFactory = (function () {
    var rootUrl = "Scripts/partials/";

    var templates = {};

    function getTemplate(name) {
        var promise = new RSVP.Promise(function (resolve, reject) {
            if (templates[name]) {
                resolve(templates[name])
            }
            else {
                $.ajax({
                    url: rootUrl + name + ".html",
                    type: "GET",
                    success: function (templateHtml) {
                        templates[name] = templateHtml;
                        resolve(templateHtml);
                    },
                    error: function (err) {
                        reject(err)
                    }
                });
            }
        });
        return promise;
    }

    function getLoginView() {
        return getTemplate("login-form");
    }

    function getLogoutView() {
        return getTemplate('logout-form');
    }

    function getMainMenu() {
        return getTemplate('menu');
    }

    function getCreateAppointmentView() {
        return getTemplate('create-appointment');
    }

    function getAllAppointmentsView() {
        return getTemplate('appointments');
    }

    function getByDateAppointmentsView() {
        return getTemplate('by-date-appointments');
    }

    function getCreateToDoListView() {
        return getTemplate('create-todo-list');
    }

    function getAllListsView() {
        return getTemplate('alllists');
    }

    function getAllTodosView() {
        return getTemplate('alltodo');
    }

    return {
        getLoginView: getLoginView,
        getLogoutView: getLogoutView,
        getMainMenu: getMainMenu,
        getCreateAppointmentView: getCreateAppointmentView,
        getAllAppointmentsView: getAllAppointmentsView,
        getByDateAppointmentsView: getByDateAppointmentsView,
        getCreateToDoListView: getCreateToDoListView,
        getAllListsView: getAllListsView,
        getAllTodosView: getAllTodosView
    }
}());
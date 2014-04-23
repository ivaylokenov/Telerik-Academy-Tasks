/// <reference path="data.js" />
/// <reference path="../libs/_references.js" />

window.vmFactory = (function () {

    var data = null;

    function getUsersViewModel(successCallbackLogin, successCallbackLogout) {
        var viewModel = {
            username: localStorage.getItem("username") || "username",
            password: "password",
            email: "namaikati@zadnika.com",
            login: function () {
                data.users.login(this.get("username"), this.get("password"))
					.then(function () {
					    if (successCallbackLogin) {
					        successCallbackLogin();
					    }
					}, function (err) {
					    // debugger;
					    //this.set("message", err.responseJSON.Message);
					});
            },
            register: function () {
                var self = this;
                data.users.register(this.get("username"), this.get("password"), this.get('email'))
					.then(function () {
					    self.login();
					    if (successCallbackLogin) {
					        successCallbackLogin();
					    }
					});
            },
            message: "",
            logout: function () {
                data.users.logout()
                .then(function () {
                    // debugger;
                    if (successCallbackLogout) {
                        successCallbackLogout();
                    }
                }, function () {
                    // debugger;
                    if (successCallbackLogout) {
                        successCallbackLogout();
                    }
                });
            },
        };
        return kendo.observable(viewModel);
    }

    function getCreateAppointmentViewModel(successCallbackCreate) {
        var viewModel = {
            subject: "",
            description: "",
            appointmentDate: "",
            duration: "",
            submit: function () {
                var appointment = {
                    subject: this.get('subject'),
                    description: this.get('description'),
                    appointmentDate: this.get('appointmentDate'),
                    duration: parseInt(this.get('duration')),
                }

                data.appointments.create(appointment)
                .then(function () {
                    if (successCallbackCreate) {
                        successCallbackCreate();
                    }
                })
            }
        }

        return kendo.observable(viewModel);
    }

    function getAllAppointmentsViewModel() {
        return data.appointments.all()
            .then(function (apps) {
                
                var data = new kendo.data.DataSource({
                    data: apps,
                    pageSize: 10
                });

                var viewModel = {
                    appointments: data
                }

                return kendo.observable(viewModel);
            });
    }

    function getUpcommingAppointmentsViewModel() {
        return data.appointments.comming()
            .then(function (apps) {

                var data = new kendo.data.DataSource({
                    data: apps,
                    pageSize: 10
                });

                var viewModel = {
                    appointments: data
                }

                return kendo.observable(viewModel);
            });
    }

    function getTodayAppointmentsViewModel() {
        return data.appointments.today()
            .then(function (apps) {

                var data = new kendo.data.DataSource({
                    data: apps,
                    pageSize: 10
                });

                var viewModel = {
                    appointments: data
                }

                return kendo.observable(viewModel);
            });
    }

    function getCurrentAppointmentsViewModel() {
        return data.appointments.current()
            .then(function (apps) {

                var data = new kendo.data.DataSource({
                    data: apps,
                    pageSize: 10
                });

                var viewModel = {
                    appointments: data
                }

                return kendo.observable(viewModel);
            });
    }

    function getByDateAppointmentsViewModel() {
        var viewModel = {
            appointmentDate: "",
            onChange: function () {
                data.appointments.byDate(kendo.toString(this.get('appointmentDate'), "yyyy-MM-dd"))
                .then(function (apps) {

                    var data = new kendo.data.DataSource({
                        data: apps
                    });

                    $('#grid').kendoGrid({
                        dataSource: data,
                    });

                });
            }
        }

        return kendo.observable(viewModel);
    }

    function getCreateToDoListViewModel(successCallBackCreate) {
        var viewModel = {
            title: "",
            submit: function () {
                var list = {
                    title: this.get('title'),
                    todos: []
                }

                data.lists.create(list)
                .then(function () {
                    if (successCallBackCreate) {
                        successCallBackCreate();
                    }
                });
            }
        }

        return kendo.observable(viewModel);
    }

    function getAllListsViewModel() {
        return data.lists.all()
            .then(function (lists) {

                var data = new kendo.data.DataSource({
                    data: lists,
                    pageSize: 10
                });

                var viewModel = {
                    lists: data
                }

                return kendo.observable(viewModel);
            });
    }

    function getAllToDosViewModel(id) {
        return data.lists.allToDos(id)
            .then(function (todos) {

                var data = new kendo.data.DataSource({
                    data: todos,
                    pageSize: 10
                });

                var viewModel = {
                    todos: data
                }

                return kendo.observable(viewModel);
            });
    }

    return {
        getUsersViewModel: getUsersViewModel,
        getCreateAppointmentViewModel: getCreateAppointmentViewModel,
        getAllAppointmentsViewModel: getAllAppointmentsViewModel,
        getUpcommingAppointmentsViewModel: getUpcommingAppointmentsViewModel,
        getCurrentAppointmentsViewModel: getCurrentAppointmentsViewModel,
        getTodayAppointmentsViewModel: getTodayAppointmentsViewModel,
        getByDateAppointmentsViewModel: getByDateAppointmentsViewModel,
        getCreateToDoListViewModel: getCreateToDoListViewModel,
        getAllListsViewModel: getAllListsViewModel,
        getAllToDosViewModel: getAllToDosViewModel,
        setPersister: function (persister) {
            data = persister
        }
    }
}());
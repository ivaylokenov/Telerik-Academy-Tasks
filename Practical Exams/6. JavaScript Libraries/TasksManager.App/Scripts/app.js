/// <reference path="libs/_references.js" />

(function () {
    var appLayout = new kendo.Layout('<div id="login-form"></div><div id="menu"></div><div id="content"></div>');
    var data = persisters.get('http://localhost:16183/api/');
    vmFactory.setPersister(data);

    var router = new kendo.Router();

    function renderMenu() {
        viewsFactory.getMainMenu()
        .then(function (mainMenuHtml) {
            var view = new kendo.View(mainMenuHtml);

            appLayout.showIn('#menu', view);

            $("#main-menu").kendoMenu({ orientation: "horizontal" });
        });
    }

    function renderLogout() {
        viewsFactory.getLogoutView()
        .then(function (logoutHtml) {
            if (data.users.currentUser()) {
                var logoutView = vmFactory.getUsersViewModel(function () {
                    router.navigate("/");
                }, function () {
                    router.navigate("/");
                });

                var view = new kendo.View(logoutHtml, { model: logoutView });

                appLayout.showIn("#login-form", view);

                view = new kendo.View(mainMenuHtml);
            }
            else {
                router.navigate('/');
            }
        });
    }

    router.route('/', function () {
        viewsFactory.getLoginView()
            .then(function (loginHtml) {
                var loginVm = vmFactory.getUsersViewModel(
						function () {
						    router.navigate("/logged");
						}, function () {
						    router.navigate("/");
						});

                var view = new kendo.View(loginHtml, { model: loginVm });

                appLayout.showIn("#login-form", view);
                
                if (data.users.currentUser()) {
                    router.navigate("/logged");
                }
                else {
                    router.navigate("/");
                }
            });

    });

    router.route('/logged', function () {

        renderLogout();

        renderMenu();

    });

    router.route('/newappointment', function(){
        
        if (data.users.currentUser()) {

            renderLogout();
            renderMenu();

            viewsFactory.getCreateAppointmentView()
            .then(function (createAppHtml) {
                var createAppVM = vmFactory.getCreateAppointmentViewModel(function () {
                    router.navigate('/allappointments');
                });

                var view = new kendo.View(createAppHtml, { model: createAppVM });

                appLayout.showIn('#content', view);
            });

        }
        else {
            router.navigate('/');
        }

    });

    router.route('/allappointments', function () {

        if (data.users.currentUser()) {

            renderLogout();
            renderMenu();

            viewsFactory.getAllAppointmentsView()
            .then(function (allAppHtml) {

                vmFactory.getAllAppointmentsViewModel()
                    .then(function (viewModel) {
                        
                        var view = new kendo.View(allAppHtml, { model: viewModel });

                        appLayout.showIn('#content', view);

                    });

            });

        }
        else {
            router.navigate('/');
        }

    });

    router.route('/commingappointments', function () {

        if (data.users.currentUser()) {

            renderLogout();
            renderMenu();

            viewsFactory.getAllAppointmentsView()
            .then(function (allAppHtml) {

                vmFactory.getUpcommingAppointmentsViewModel()
                    .then(function (viewModel) {

                        var view = new kendo.View(allAppHtml, { model: viewModel });

                        appLayout.showIn('#content', view);

                    });

            });

        }
        else {
            router.navigate('/');
        }

    });

    router.route('/todayappointments', function () {

        if (data.users.currentUser()) {

            renderLogout();
            renderMenu();

            viewsFactory.getAllAppointmentsView()
            .then(function (allAppHtml) {

                vmFactory.getTodayAppointmentsViewModel()
                    .then(function (viewModel) {

                        var view = new kendo.View(allAppHtml, { model: viewModel });

                        appLayout.showIn('#content', view);

                    });

            });

        }
        else {
            router.navigate('/');
        }

    });

    router.route('/currentappointments', function () {

        if (data.users.currentUser()) {

            renderLogout();
            renderMenu();

            viewsFactory.getAllAppointmentsView()
            .then(function (allAppHtml) {

                vmFactory.getCurrentAppointmentsViewModel()
                    .then(function (viewModel) {

                        var view = new kendo.View(allAppHtml, { model: viewModel });

                        appLayout.showIn('#content', view);

                    });

            });

        }
        else {
            router.navigate('/');
        }

    });

    router.route('/bydateappointments', function () {

        if (data.users.currentUser()) {

            renderLogout();
            renderMenu();

            viewsFactory.getByDateAppointmentsView()
            .then(function (allAppHtml) {

                var viewModel = vmFactory.getByDateAppointmentsViewModel();

                var view = new kendo.View(allAppHtml, { model: viewModel });

                appLayout.showIn('#content', view);

            });

        }
        else {
            router.navigate('/');
        }

    });

    router.route('/createtodolist', function () {

        if (data.users.currentUser()) {

            renderLogout();
            renderMenu();

            viewsFactory.getCreateToDoListView()
            .then(function (toDoListHtml) {

                var viewModel = vmFactory.getCreateToDoListViewModel(function () {
                    router.navigate('/allliststodos');
                });

                var view = new kendo.View(toDoListHtml, { model: viewModel });

                appLayout.showIn('#content', view);

            });

        }
        else {
            router.navigate('/');
        }

    });

    router.route('/allliststodos', function () {

        if (data.users.currentUser()) {

            renderLogout();
            renderMenu();

            viewsFactory.getAllListsView()
            .then(function (allListsHtml) {

                vmFactory.getAllListsViewModel()
                    .then(function (viewModel) {

                        var view = new kendo.View(allListsHtml, { model: viewModel });

                        appLayout.showIn('#content', view);

                    });

            });

        }
        else {
            router.navigate('/');
        }

    });

    router.route('/list/:id', function (id) {

        if (data.users.currentUser()) {

            renderLogout();
            renderMenu();

            viewsFactory.getAllTodosView()
            .then(function (allTodosHtml) {

                vmFactory.getAllToDosViewModel(id)
                    .then(function (viewModel) {

                        var view = new kendo.View(allTodosHtml, { model: viewModel });

                        appLayout.showIn('#content', view);

                    });

            });

        }
        else {
            router.navigate('/');
        }

    });

    $(function () {
        appLayout.render("#app");
        router.start();
    });
}());
var MainMenu = {

    create: function (hotel) {
        this.hotel = hotel;
        this.menu = $("<div></div>");
    },
    addRoom: function () {

    },
    addCat: function (name) {
        if (name == null || name.length > 10) {
            alert("wrong name");
            return;
        }
        name = safeTags(name);
        if (name == "Dragon" && !this.hotel.hasDragon) {
            var dragon = Object.create(Dragon);
            $('audio').attr('src', 'sound/CatMetal.mp3');
            dragon.initialize();
            this.hotel.hasDragon = true;
            this.hotel.addCat(dragon);
            this.hotel.render();

            $('#hotel-menu').css({ 'background': 'url("images/layout/bckgr-header-dark.jpg")' });
            $('#wrapper').css({ 'background': 'url("images/layout/bckgr-slice-dark.jpg")' });
            $('footer').attr("class", "dark-footer");
            $('#settings').attr('class', 'dark');
        }
        else {
            var cat = Object.create(Cat);
            cat.initialize(name, 10, 10, 10, 20);
            this.hotel.addCat(cat);
            this.hotel.render();
        }
        jQuery(settings).toggle();

        function safeTags(str) {
            return str.replace(/&/g, '&amp;').replace(/</g, '&lt;').replace(/>/g, '&gt;');
        }
    },
    renameHotel: function (newName) {
        newName = safeTags(newName);
        jQuery(settings).toggle();
        this.hotel.rename(newName);
        this.renderName();

        function safeTags(str) {
            return str.replace(/&/g, '&amp;').replace(/</g, '&lt;').replace(/>/g, '&gt;');
        }
    },
    renameHotelForm: function () {
        var _self = this;
        var form = $("<form />");
        var itemForm = $("<div></div>");
        var input = $("<input />");
        var button = $("<button />").text('Rename Hotel');
        button.on("click", function (ev) {
            ev.preventDefault();
            if (input.val().length > 0) {

                _self.renameHotel(input.val());
            }
            else {
                var alertWrongNameHotel = $("<div class='alert'>Hotel name cannot be empty!</div>");
                $("#settings").append(alertWrongNameHotel);
                setTimeout(function () {
                    $("#settings .alert").remove();
                }, 3000);

            }
        });
        form.append(input).append(button);
        itemForm.append(form);
        return itemForm;
    },
    addCatForm: function () {
        var _self = this;
        var form = $("<form />");
        var itemForm = $("<div></div>");
        var input = $("<input />");
        var button = $("<button />").text('Add Cat');
        button.on("click", function (ev) {
            ev.preventDefault();
            if (input.val().length > 0) {
                _self.addCat(input.val());
            }
            else {
                var alertWrongName = $("<div class='alert'>Cat name cannot be empty!</div>");
                $("#settings").append(alertWrongName);
                setTimeout(function () {
                    $("#settings .alert").remove();
                }, 3000);
            }
        });
        form.append(input).append(button);
        itemForm.append(form);
        return itemForm;
    },
    addScoreForm: function () {
        var button = $("<button />").text('Scoreboard').attr('id', 'scoreboard-btn');
        button.on("click", function (ev) {
            ev.preventDefault();
            if ($(".alert").length > 0) {
                return;
            }
            loadScoreGame();
        });

        return button;
    },
    renderName: function () {
        var hotelName = this.hotel.getName();
        $("h1").text(hotelName);
    },
    muteAutio: function () {
        var button = $("<button />").attr('id', 'audio-btn');

        button.on('click', function (ev) {
            ev.preventDefault();
            var audio = document.getElementById('audio-bc');
            $("#audio-btn").toggleClass("off");
            if (audio.muted == true) {

                audio.muted = false;
            }
            else {
                audio.muted = true;
            }

        });

        return button;
    },
    render: function () {
        var settings = $("<div>");
        settings.attr('id', 'settings');
        this.menu.attr('id', 'hotel-menu');
        var itemName = $("<h1></h1>");
        var settingsBtn = $("<button />");
        settingsBtn.attr('id', 'settings-btn');

        settingsBtn.on('click', function () {
            jQuery(settings).toggle();
        });

        this.menu
        .append(settingsBtn)
        .append(itemName);

        settings
        .append(this.addCatForm())
        .append(this.renameHotelForm())
        .append(this.muteAutio())
        .append(this.addScoreForm())
        .hide();

        var body = $("body");
        body.prepend(this.menu);
        body.prepend(settings);
        this.renderName();
        this.hotel.render();
    }

};
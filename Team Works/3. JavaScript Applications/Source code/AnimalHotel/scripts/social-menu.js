var SocialShareMenu = {
    create: function () {
        this.menu = $("<div></div>");
    },
    render: function () {
        this.menu.attr('id', 'social-menu');
        this.menu.append('<g:plusone size="standard" href="https://plus.google.com/u/0/109606018059232551511/posts"></g:plusone>');
        $("#hotel-menu").append(this.menu);
    }
};
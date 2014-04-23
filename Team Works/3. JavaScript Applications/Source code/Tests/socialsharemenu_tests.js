module("SocialShareMenu.create");
test("should create correct SocialShareMenu object",   
  function(){
	var name = "Hotel";
	var capacity = 12;
	var hotel =  Object.create(Hotel);
	hotel.initialize(name, capacity);
	
	var menu =  Object.create(MainMenu);
	menu.create(hotel);
	menu.render();
	
	var socialMenu = Object.create(SocialShareMenu);
    socialMenu.create();
	socialMenu.render();

	equal($("#hotel-menu").length, 1, "The social menu is successfully created and added to the main menu");
});
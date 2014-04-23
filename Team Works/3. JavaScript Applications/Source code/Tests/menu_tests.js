module("Menu.create");
test("should create correct menu object",   
  function(){
	var name = "Hotel";
	var capacity = 12;
	
	 var hotel =  Object.create(Hotel);
	 hotel.initialize(name, capacity);
	
	var menu =  Object.create(MainMenu);
	menu.create(hotel);

	equal(menu.hotel.name, "Hotel", "A hotel object has been successfully added to the menu");
  });
 
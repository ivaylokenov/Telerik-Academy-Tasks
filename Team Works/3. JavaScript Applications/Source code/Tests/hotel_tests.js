module("Hotel.initialize");
test("should set correct name and room number to the Hotel",   
  function(){
	var name = "Hotel";
	var capacity = 12;
	
	var hotel =  Object.create(Hotel);
	hotel.initialize(name, capacity);
	
	equal(hotel.name, "Hotel", "The name of the hotel is as expected - Hotel");
	equal(hotel.occupied, 0, "The number of occuppied rooms in the hotel is as expected - 0");
	equal(hotel.rooms.length, 12, "The number of rooms in the hotel is as expected - 12");	
  });
  
  test("should create different instances of Hotel",   
  function(){
	var name = "Hotel";
	var capacity = 10;
	
	var hotelFirst =  Object.create(Hotel);
	hotelFirst.initialize(name, capacity);
	hotelFirst.hasDragon = true;
	
	ok(hotelFirst.hasDragon, "hotelfirst.hasDragon = true");
	
	var hotelSecond =  Object.create(Hotel);
	hotelSecond.initialize(name, 12);
	
  notEqual(hotelFirst.capacity, hotelSecond.capacity, "The 2 hotels have different values of capacity");
  });
  
 module("Hotel.addRoom");
 test("should increase the number of rooms in the hotel",   
  function(){
	var name = "Hotel";
	var capacity = 10;
	
	var hotel =  Object.create(Hotel);
	hotel.initialize(name, capacity);
	
	equal(hotel.rooms.length, 10, "The number of rooms is currently 10");	
	
	var room =  Object.create(Room);
	room.initialize();
	hotel.addRoom(room);
	
	equal(hotel.rooms.length, 11, "The number of rooms has been increased to 11");
  });
  
  test("should add an occupied room in the hotel",   
  function(){
	var name = "Hotel";
	var capacity = 10;
	
	var hotel =  Object.create(Hotel);
	hotel.initialize(name, capacity);
	
	equal(hotel.rooms.length, 10, "The number of rooms is currently 10");	
	
	var room =  Object.create(Room);
	room.initialize();
	
	var cat = Object.create(Cat);
	cat.initialize("Cat", 1, 10, 10, 10);
	
	room.addRoomer(cat);
	hotel.addRoom(room);
	hotel.occupied +=1;
	
	equal(hotel.rooms.length, 11, "The number of rooms has been increased to 11");
	equal(hotel.occupied, 1, "There is 1 occupied room in the hotel");
  });
  
module("Hotel.addCat");
test("should add a cat to the Hotel",   
  function(){
	var name = "Hotel";
	var capacity = 12;
	
	var hotel =  Object.create(Hotel);
	hotel.initialize(name, capacity);
	
	var cat = Object.create(Cat);
	cat.initialize("Cat", 1, 10, 10, 10);
	
	hotel.addCat(cat);
		
	equal(hotel.occupied, 1, "The number of occuppied rooms in the hotel is as expected - 1");
	equal(hotel.rooms.length, 12, "The number of rooms in the hotel is as expected - 12");	
  });
  
  test("should add a dragon to the Hotel",   
  function(){
	var name = "Hotel";
	var capacity = 12;
	
	var hotel =  Object.create(Hotel);
	hotel.initialize(name, capacity);
	
	var dragon = Object.create(Dragon);
	dragon.initialize();
	
	hotel.addCat(dragon);
	
	equal(hotel.occupied, 1, "The number of occuppied rooms in the hotel is as expected - 1");
	equal(hotel.rooms.length, 12, "The number of rooms in the hotel is as expected - 12");	
  });
  
  test("should add both a cat and a dragon to the Hotel",   
  function(){
	var name = "Hotel";
	var capacity = 12;
	
	var hotel =  Object.create(Hotel);
	hotel.initialize(name, capacity);
	
	var cat = Object.create(Cat);
	cat.initialize("Cat", 1, 10, 10, 10);
	
	var dragon = Object.create(Dragon);
	dragon.initialize();
	
	hotel.addCat(cat);
	hotel.addCat(dragon);
	
	equal(hotel.occupied, 2, "The number of occuppied rooms in the hotel is as expected - 2");
	equal(hotel.rooms.length, 12, "The number of rooms in the hotel is as expected - 12");
  });
  
module("Hotel.rename");
test("should rename the hotel",   
  function(){
	var name = "Hotel";
	var capacity = 12;
	
	var hotel =  Object.create(Hotel);
	hotel.initialize(name, capacity);
	equal(hotel.name, "Hotel", "The name of the hotel is as expected - Hotel");
	
	hotel.rename("AnimalHotel");
	equal(hotel.name, "AnimalHotel", "The name of the hotel is as expected - AnimalHotel");
	hotel.rename("GameHotel");
	equal(hotel.name, "GameHotel", "The name of the hotel is as expected - GameHotel");
  });
  
// module("Hotel.removeRoom");
// test("should remove rooms from the hotel",   
  // function(){
	// var name = "Hotel";
	// var capacity = 12;
	
	// var hotel =  Object.create(Hotel);
	// hotel.initialize(name, capacity);
	// equal(hotel.capacity, 12, "The hotel has 12 rooms");
	
	// var room =  Object.create(Room);
	// room.initialize();
	// hotel.addRoom(room);
	
	// equal(hotel.rooms.length, 13, "The hotel has 13 rooms");
	// if (hotel.rooms.length > 0) {
            // hotel.rooms.pop(rooms[rooms.length - 1]);}
	//hotel.removeRoom();
	// equal(hotel.rooms.length, 12, "The hotel has 12 rooms");
  // });

module("Hotel.numOccupiedRooms");
test("should return correctly the number of occupied rooms in the hotel",   
  function(){
	var name = "Hotel";
	var capacity = 12;
	
	var hotel =  Object.create(Hotel);
	hotel.initialize(name, capacity);
	
	var room =  Object.create(Room);
	room.initialize();
	equal(hotel.occupied, 0, "There is 0 occupied rooms in the hotel");
	
	var catFirst = Object.create(Cat);
	catFirst.initialize("Cat", 1, 10, 10, 10);
	
	var catSecond = Object.create(Cat);
	catSecond.initialize("Cat Mew", 1, 10, 10, 10);
	
	hotel.addCat(catFirst);
	hotel.addCat(catSecond);
	
	equal(hotel.occupied, 2, "There are 2 occupied rooms in the hotel");
	
	hotel.occupied++;
	
	equal(hotel.occupied, 3, "There are 3 occupied rooms in the hotel");
  });
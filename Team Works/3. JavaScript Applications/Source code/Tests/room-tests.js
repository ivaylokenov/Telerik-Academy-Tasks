module("Room Initialize");
test("Creating a Room, should return an object of type Room", function() {
  var room = Object.create(Room);
  var actual = Room.isPrototypeOf(room);
  var expected = true;
  equal(actual, expected);
});

test("Initializing a Room, the room should be empty", function() {
  var newroom = Object.create(Room);
  newroom.initialize();
  var actual = newroom.occupied;
  var expected = false;
  equal(newroom.isFree(), true);
  equal(actual, expected);
});

test("Initializing a Room, the roomer should be null", function() {
  var newroom = Object.create(Room);
  newroom.initialize();
  var actual = newroom.roomer;
  var expected = null;
  equal(actual, expected);
});

test("Initializing a Room, the id should be null", function() {
  var newroom = Object.create(Room);
  newroom.initialize();
  var actual = newroom.id;
  var expected = null;
  equal(actual, expected);
});
module("Room.addRoomer");
test("Check if we have a correct roomer, after placing one", function() {
  var cat = Object.create(Cat);
  cat.initialize("Sisi", 10, 10, 10, 20);

  var newroom = Object.create(Room);
  newroom.initialize();
  newroom.addRoomer(cat);
  var actual = newroom.roomer.introduce();
  var expected = "Sisi";
  equal(newroom.isFree(), false);
  equal(actual, expected);
});
module("Room.isFree");
test("Check if we successfully remove a cat from its room", function() {
  var cat = Object.create(Cat);
  cat.initialize("Sisi", 10, 10, 10, 20);

  var newroom = Object.create(Room);
  newroom.initialize();
  newroom.addRoomer(cat);
  newroom.removeRoomer();
  equal(newroom.occupied, false);
  equal(newroom.isFree(), true);
  equal(newroom.roomer, null);
});
module("Room.render");
test("Rendering a Room, the container should be a DIV", function() {
  var newroom = Object.create(Room);
  newroom.initialize();
  var actual = newroom.render().is("div");
  var expected = true;
  equal(actual, expected);
});
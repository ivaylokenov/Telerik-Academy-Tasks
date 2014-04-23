module("Create Objects");
test("Creating a Cat, should return an object of type Cat", function() {
  var firstCat = Object.create(Cat);
  var actual = Cat.isPrototypeOf(firstCat);
  var expected = true;
  equal(actual, expected);
});
test("Creating a Hotel, should return an object of type Hotel", function() {
  var hotel = Object.create(Hotel);
  var actual = Hotel.isPrototypeOf(hotel);
  var expected = true;
  equal(actual, expected);
});
test("Creating a Social Share Menu, should return an object of type SocialShareMenu", function() {
  var menu = Object.create(SocialShareMenu);
  var actual = SocialShareMenu.isPrototypeOf(menu);
  var expected = true;
  equal(actual, expected);
});

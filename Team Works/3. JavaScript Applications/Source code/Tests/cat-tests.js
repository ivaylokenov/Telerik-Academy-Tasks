module("Cat Initialize");
test("Setting correct cat name", function() {
  var cat = Object.create(Cat);
  var name = "Pepsi";
  cat.initialize(name, 10, 10, 10, 20);
  var actual = cat.introduce();
  var expected = name;
  equal(actual, expected);
});
test("Setting correct cat age", function() {
  var cat = Object.create(Cat);
  var catage = 5;
  cat.initialize("name", catage, 10, 10, 20);
  var actual = catage;
  var expected = cat._super.age;
  equal(actual, expected);
});
test("Setting correct cat hunger", function() {
  var cat = Object.create(Cat);
  var cathunger = 50;
  cat.initialize("name", 7, 10, cathunger, 20);
  var actual = cathunger;
  var expected = cat._super.hunger;
  equal(actual, expected);
});
test("Setting correct cat mood", function() {
  var cat = Object.create(Cat);
  var name = "Pepsi";
  var catmood = 20;
  cat.initialize(name, 10, 10, 10, catmood);
  var actual = cat.mood;
  var expected = catmood;
  equal(actual, expected);
});
test("Setting correct cat health", function() {
  var cat = Object.create(Cat);
  var name = "Pepsi";
  var catmood = 20;
  var cathealth = 10;
  cat.initialize(name, 10, cathealth, 10, catmood);
  var actual = cat._super.health;
  var expected = cathealth;
  equal(actual, expected);
});
module("Cat Portrait");
test("The portrait of a cat should be in DIV element", function() {
  var cat = Object.create(Cat);
  cat.initialize("Fifi", 10, 10, 10, 20);
  var catdiv = cat.portrait();
  var actual = catdiv.is("div");
  var expected = true;
  equal(actual, expected);
});

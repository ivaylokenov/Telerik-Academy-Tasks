module("Dragon Tests");
test("Set dragon name", function () {
    var dragon = Object.create(Dragon);
    var name = "Dragon";
    dragon.initialize();
    var actual = dragon.introduce();
    var expected = name;

    equal(actual, expected);
});

test("Check dragon id", function () {
    var dragon = Object.create(Dragon);
    dragon.initialize();
    var actual = dragon.catid;
    var expected = "dragon";

    equal(actual, expected);
});

test("Check dragon health", function () {
    var dragon = Object.create(Dragon);
    dragon.initialize();
    var actual = dragon._super.health;
    var expected = 1;

    equal(actual, expected);
});

test("Check dragon hunger", function () {
    var dragon = Object.create(Dragon);
    dragon.initialize();
    var actual = dragon._super.hunger;
    var expected = 1000;

    equal(actual, expected);
});
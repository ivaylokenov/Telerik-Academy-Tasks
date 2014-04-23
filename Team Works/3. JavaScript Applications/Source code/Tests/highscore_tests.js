module("highscore.initialize");
test("Creating a High Score, should return an object of type HighScore", function() {
  var highscore = Object.create(HighScore);
  var actual = HighScore.isPrototypeOf(highscore);
  var expected = true;
  equal(actual, expected);
});
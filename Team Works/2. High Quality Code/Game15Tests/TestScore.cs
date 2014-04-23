using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameFifteen;

namespace Game15Tests
{
    [TestClass]
    public class TestScore
    {
        [TestMethod]
        public void TestScoreConstructor_ValidParameters()
        {
            Score scoreForTest = new Score("testName", 200, 4, "testFileName.txt");
            Assert.AreEqual(scoreForTest.Name, "testName");
            Assert.AreEqual(scoreForTest.Points, 200);
            Assert.AreEqual(scoreForTest.TopScoresCount, 4);
            Assert.AreEqual(scoreForTest.FileNameForExternalSave, "testFileName.txt");
            Assert.AreEqual(scoreForTest.TopScoresPersonPattern, @"^\d+\. (.+) --> (\d+) moves?$");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestScoreConstructor_InvalidName()
        {
            Score scoreForTest = new Score(null, 200, 4, "testFileName.txt");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestScoreConstructor_InvalidFileName()
        {
            Score scoreForTest = new Score("testName", 200, 4, null);
        }
    }
}

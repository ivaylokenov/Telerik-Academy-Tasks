using System;
using SchoolClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestSchoolClassLibrary
{
    [TestClass]
    public class TestStudent
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestStudentNullName()
        {
            Student student = new Student(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestStudentEmptyName()
        {
            Student student = new Student(string.Empty);
        }

        [TestMethod]
        public void TestStudentName()
        {
            Student student = new Student("Agro");
            Assert.AreEqual(student.Name, "Agro");
        }
    }
}

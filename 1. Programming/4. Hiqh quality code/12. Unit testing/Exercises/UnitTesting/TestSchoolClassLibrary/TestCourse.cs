namespace TestSchoolClassLibrary
{
    using System;
    using SchoolClassLibrary;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestCourse
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestCourseNullName()
        {
            Course course = new Course(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCourseEmptyName()
        {
            Course course = new Course(string.Empty);
        }

        [TestMethod]
        public void TestCourseName()
        {
            Course course = new Course("Agro");
            Assert.AreEqual(course.Name, "Agro");
        }

        [TestMethod]
        public void TestCourseAddStudent()
        {
            Course course = new Course("Agro");
            Student student = new Student("Pesho");
            course.AddStudent(student);
            Assert.AreEqual(course.Students[0], student);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestMoreThan30Students()
        {
            Course course = new Course("Agro");
            for (int i = 1; i <= 31; i++)
            {
                Student student = new Student("Pesho");
                course.AddStudent(student);
            }
        }

        [TestMethod]
        public void TestRemoveStudent()
        {
            Course course = new Course("Agro");
            Student student = new Student("Pesho");

            course.AddStudent(student);
            course.RemoveStudent(student);

            Assert.AreEqual(course.Students.Count, 0); 
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRemoveStudentNotInTheList()
        {
            Course course = new Course("Agro");
            Student student = new Student("Pesho");
            course.RemoveStudent(student);
        }
    }
}

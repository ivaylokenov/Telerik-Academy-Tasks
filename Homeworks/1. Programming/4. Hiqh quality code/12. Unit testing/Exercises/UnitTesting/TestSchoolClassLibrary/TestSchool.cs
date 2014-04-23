namespace TestSchoolClassLibrary
{
    using System;
    using SchoolClassLibrary;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestSchool
    {
        [TestMethod]
        public void TestAddStudentToSchool()
        {
            School school = new School();
            Student student = new Student("Pesho");
            school.AddStudent(student);
            Assert.AreEqual(school.Students.ContainsKey(student), true);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddExistingStudentToSchool()
        {
            School school = new School();
            Student student = new Student("Pesho");
            school.AddStudent(student);
            school.AddStudent(student);
        }

        /*
        I could not get this test to run, if you can, show me how in the homework review :)
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Timeout(60000)]
        public void TestSchoolCapacity()
        {
            School school = new School();
            for (int i = 1; i <= 90000; i++)
            {
                Student student = new Student("Pesho");
                school.AddStudent(student);
            }
        }
        */

        [TestMethod]
        public void TestRemoveStudentFromSchool()
        {
            School school = new School();
            Student student = new Student("Pesho");
            school.AddStudent(student);
            school.RemoveStudent(student);
            Assert.AreEqual(school.Students.Count, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRemoveNotExistingStudentFromSchool()
        {
            School school = new School();
            Student student = new Student("Pesho");
            school.RemoveStudent(student);
        }

        [TestMethod]
        public void TestRemoveStudentFromSchoolAndCourses()
        {
            School school = new School();
            Student student = new Student("Pesho");
            school.AddStudent(student);
            Course course = new Course("KPK");
            Course oop = new Course("OOP");
            school.AddCourse(course);
            school.AddCourse(oop);
            course.AddStudent(student);
            oop.AddStudent(student);
            school.RemoveStudent(student);
            Assert.AreEqual(course.Students.Count, 0);
            Assert.AreEqual(oop.Students.Count, 0);
        }

        [TestMethod]
        public void TestGetID()
        {
            School school = new School();
            Student student = new Student("Pesho");
            Student anotherStudent = new Student("Gosho");
            Student yetAnotherStudent = new Student("Ivan");
            school.AddStudent(student);
            school.AddStudent(anotherStudent);
            school.AddStudent(yetAnotherStudent);
            int? idPesho = school.GetID(student);
            int? idGosho = school.GetID(anotherStudent);
            int? idIvan= school.GetID(yetAnotherStudent);
            Assert.AreEqual(idPesho, 10000);
            Assert.AreEqual(idGosho, 10001);
            Assert.AreEqual(idIvan, 10002);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestGetIDOfNonExistingStudent()
        {
            School school = new School();
            Student student = new Student("Pesho");
            int? idPesho = school.GetID(student);
        }

        [TestMethod]
        public void TestAddCourse()
        {
            School school = new School();
            Course course = new Course("KPK");
            school.AddCourse(course);
            Assert.AreEqual(school.Courses[0].Name, "KPK");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddExistingCourse()
        {
            School school = new School();
            Course course = new Course("KPK");
            school.AddCourse(course);
            school.AddCourse(course);
        }

        [TestMethod]
        public void TestRemoveCourse()
        {
            School school = new School();
            Course course = new Course("KPK");
            school.AddCourse(course);
            school.RemoveCourse(course);
            Assert.AreEqual(school.Courses.Count, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRemoveNonExistingCourse()
        {
            School school = new School();
            Course course = new Course("KPK");
            school.RemoveCourse(course);
        }
    }
}

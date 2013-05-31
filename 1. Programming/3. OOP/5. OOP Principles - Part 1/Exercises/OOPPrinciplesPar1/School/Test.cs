using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    class Test
    {
        //01. We are given a school. In the school there are 
        //classes of students. Each class has a set of teachers.
        //Each teacher teaches a set of disciplines. Students have 
        //name and unique class number. Classes have unique text identifier.
        //Teachers have name. Disciplines have name, number of lectures and
        //number of exercises. Both teachers and students are people. Students,
        //classes, teachers and disciplines could have optional comments (free text block).

        //Your task is to identify the classes (in terms of  OOP) and their attributes
        //and operations, encapsulate their fields, define the class hierarchy and create
        //a class diagram with Visual Studio.

        static void Main()
        {
            School PMG = new School("PMG");

            ClassOfStudents _11a = new ClassOfStudents("11 A");

            Student pesho = new Student("Pesho", 1);
            Student gosho = new Student("Gosho", 2);

            _11a.AddStudent(pesho);
            _11a.AddStudent(gosho);

            Discipline math = new Discipline("Mathematics", 5, 10);
            Discipline physics = new Discipline("Physics", 5, 15);

            Teacher rangelova = new Teacher("Rangelova");

            rangelova.AddComment("Az imam kozi");
            rangelova.AddDiscipline(math);
            rangelova.AddDiscipline(physics);

            _11a.AddStudent(pesho);
            _11a.AddStudent(gosho);
            _11a.AddTeacher(rangelova);

            PMG.AddClass(_11a);
        }
    }
}

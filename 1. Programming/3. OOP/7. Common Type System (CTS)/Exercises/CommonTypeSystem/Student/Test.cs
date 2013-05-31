using System;

namespace Student
{
    class Test
    {
        static void Main()
        {
            Student student = new Student("Ifaka", "Ne4ii", "Si", "math", Specialty.IT, University.TelerikAcademy, Faculty.SSS);
            Console.WriteLine(student.ToString());
            Student copiedStudent = student.Clone();
            Console.WriteLine(copiedStudent);
        }
    }
}

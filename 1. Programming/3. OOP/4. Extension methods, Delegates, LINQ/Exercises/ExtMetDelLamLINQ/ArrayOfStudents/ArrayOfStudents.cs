using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayOfStudents
{
    class ArrayOfStudents
    {
        //3. Write a method that from a given array of students finds 
        //all students whose first name is before its last name
        //alphabetically. Use LINQ query operators.

        static void Main()
        {
            var students = new[]
            {
                new { FirstName = "Arnold", LastName = "Belia"},
                new { FirstName = "Bruce", LastName = "Lee"},
                new { FirstName = "Goshkata", LastName = "Peshov"},
                new { FirstName = "Peshkata", LastName = "Goshov"},
                new { FirstName = "Ivan", LastName = "Boikov"},
            };

            //query
            var queryNames =
                from student in students
                where student.FirstName.CompareTo(student.LastName) < 0
                select student;

            //printing
            foreach (var element in queryNames)
            {
                Console.WriteLine("{0} {1}", element.FirstName, element.LastName);
            }
        }
    }
}

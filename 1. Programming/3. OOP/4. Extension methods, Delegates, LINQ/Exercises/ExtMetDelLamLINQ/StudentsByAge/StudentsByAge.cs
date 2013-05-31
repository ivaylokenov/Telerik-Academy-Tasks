using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsByAge
{
    //4. Write a LINQ query that finds the first name 
    //and last name of all students with age between 18 and 24.

    class StudentsByAge
    {
        static void Main()
        {
            var students = new[]
            {
                new { FirstName = "Arnold", LastName = "Belia", age = 16},
                new { FirstName = "Bruce", LastName = "Lee", age = 43},
                new { FirstName = "Goshkata", LastName = "Peshov", age = 22},
                new { FirstName = "Peshkata", LastName = "Goshov", age = 24},
                new { FirstName = "Ivan", LastName = "Boikov", age = 23},
            };

            //query
            var queryByAges =
                from student in students
                where (student.age >= 18 && student.age <= 24)
                select student;

            //printing
            foreach (var element in queryByAges)
            {
                Console.WriteLine("{0} {1}", element.FirstName, element.LastName);
            }
        }
    }
}

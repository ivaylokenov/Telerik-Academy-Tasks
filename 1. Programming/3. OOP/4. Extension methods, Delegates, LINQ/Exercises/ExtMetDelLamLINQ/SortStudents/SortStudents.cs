using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortStudents
{
    class SortStudents
    {
        //5. Using the extension methods OrderBy() and ThenBy() with lambda
        //expressions sort the students by first name and last name 
        //in descending order. Rewrite the same with LINQ.

        static void Main()
        {
            var students = new[]
            {
                new { FirstName = "Arnold", LastName = "Negyra", age = 16},
                new { FirstName = "Arnold", LastName = "Beliq", age = 16},
                new { FirstName = "Bruce", LastName = "Lee", age = 43},
                new { FirstName = "Bruce", LastName = "Chompila", age = 43},
                new { FirstName = "Goshkata", LastName = "Peshov", age = 22},
                new { FirstName = "Goshkata", LastName = "Fostata", age = 22},
                new { FirstName = "Peshkata", LastName = "Goshov", age = 24},
                new { FirstName = "Ivan", LastName = "Boikov", age = 23},
            };

            //using lambda expressions
            var sortedStudents = students.OrderByDescending(student => student.FirstName).ThenByDescending(student => student.LastName);

            foreach (var item in sortedStudents)
            {
                Console.WriteLine(item.FirstName + " " + item.LastName);
            }

            Console.WriteLine();

            //using LINQ
            var LINQSortingOfStudents =
                from student in students
                orderby student.FirstName descending, student.LastName descending
                select student;

            //printing
            foreach (var item in LINQSortingOfStudents)
            {
                Console.WriteLine(item.FirstName + " " + item.LastName);
            }
        }
    }
}

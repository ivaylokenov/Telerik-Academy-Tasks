using System;
using System.Collections.Generic;
using System.Linq;

namespace Humans
{
    class Test
    {
        /*
        Define abstract class Human with first name and last name. 
        Define new class Student which is derived from 
        Human and has new field – grade. Define class Worker 
        derived from Human with new property WeekSalary and WorkHoursPerDay 
        and method MoneyPerHour() that returns money earned by hour by the worker. 
        Define the proper constructors and properties for this hierarchy. Initialize a 
        list of 10 students and sort them by grade in ascending order (use LINQ or 
        OrderBy() extension method). Initialize a list of 10 workers and sort them 
        by money per hour in descending order. Merge the lists and sort them by first 
        name and last name.
        */

        static void Main()
        {
            List<Student> students = new List<Student>();
            students.Add(new Student("pesho", "goshev", 5.6m));
            students.Add(new Student("hoicho", "moichov", 5.4m));
            students.Add(new Student("grencho", "gudmanov", 5.2m));
            students.Add(new Student("vlado", "pyrvanov", 4.8m));
            students.Add(new Student("gucaro", "svinarov", 6.0m));
            students.Add(new Student("negcho", "belchov", 5.3m));
            students.Add(new Student("belcho", "negchov", 5.6m));
            students.Add(new Student("neofit", "georgiev", 4.9m));
            students.Add(new Student("aspardjik", "domatov", 5.9m));
            students.Add(new Student("muncho", "zealotov", 5.6m));

            List<Worker> workers = new List<Worker>();
            workers.Add(new Worker("matematikcho", "algebri4kov", 200m, 5));
            workers.Add(new Worker("fizi4ko", "vselinov", 198m, 10));
            workers.Add(new Worker("kultirstcho", "nabirankov", 1500m, 8));
            workers.Add(new Worker("istorichko", "hitlerov", 2548m, 7));
            workers.Add(new Worker("filofcho", "edipov", 154m, 5));
            workers.Add(new Worker("bylgarichko", "planinarov", 2000m, 12));
            workers.Add(new Worker("gorcho", "grobarov", 124m, 4));
            workers.Add(new Worker("typcho", "umnikarov", 440, 4));
            workers.Add(new Worker("pesho", "abepeshov", 1589m, 2));
            workers.Add(new Worker("gosho", "abegoshov", 200m, 15));

            var sortedStudents =
                from student in students
                orderby student.Grade
                select student;

            foreach (var student in sortedStudents)
            {
                Console.WriteLine("{0} {1} - Grade: {2}", student.FirstName, student.LastName, student.Grade);
            }

            Console.WriteLine();

            var sortedWorkers =
                from worker in workers
                orderby worker.MoneyPerHour() descending
                select worker;

            foreach (var worker in sortedWorkers)
            {
                Console.WriteLine("{0} {1} - Cash: {2}", worker.FirstName, worker.LastName, worker.MoneyPerHour());
            }

            Console.WriteLine();

            var mergedList = workers.Concat<Human>(students);

            mergedList =
                from person in mergedList
                orderby person.FirstName, person.LastName
                select person;

            foreach (var person in mergedList)
            {
                Console.WriteLine("{0} {1}", person.FirstName, person.LastName);
            }
        }
    }
}

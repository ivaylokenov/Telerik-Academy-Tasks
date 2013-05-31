using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_3_Employees
{
    class Position : IComparable
    {
        public string Name { get; set; }
        public ushort Rating { get; set; }

        public Position(string position)
        {
            string[] positionParts = position.Split(new string[] { " - " }, StringSplitOptions.None);
            this.Name = positionParts[0];
            this.Rating = ushort.Parse(positionParts[1]);
        }

        public int CompareTo(object obj)
        {
            Position compareTo = obj as Position;
            return -this.Rating.CompareTo(compareTo.Rating);
        }
    }

    class Employee : IComparable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Position Position { get; set; }

        public Employee(string names, Position position)
        {
            string[] namesParts = names.Split(' ');
            this.FirstName = namesParts[0];
            this.LastName = namesParts[1];
            this.Position = position;
        }

        public int CompareTo(object obj)
        {
            Employee compareTo = obj as Employee;
            if (this.Position.CompareTo(compareTo.Position) == 0)
            {
                if (this.LastName.CompareTo(compareTo.LastName) == 0)
                {
                    return this.FirstName.CompareTo(compareTo.FirstName);
                }
                else return this.LastName.CompareTo(compareTo.LastName);
            }
            else return this.Position.CompareTo(compareTo.Position);
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", this.FirstName, this.LastName);
        }
    }


    class Program
    {
        static void Main()
        {
            // TestsGenerator.GenerateTests(); return;

            int N = int.Parse(Console.ReadLine());
            List<Position> positions = new List<Position>();
            for (int i = 1; i <= N; i++)
            {
                string positionString = Console.ReadLine();
                positions.Add(new Position(positionString));
            }

            int M = int.Parse(Console.ReadLine());
            List<Employee> employees = new List<Employee>();
            for (int i = 1; i <= M; i++)
            {
                string employeeString = Console.ReadLine();
                string[] employeeParts = employeeString.Split(new string[] { " - " }, StringSplitOptions.None);
                Position employeePosition = positions.First(x => x.Name == employeeParts[1]);
                employees.Add(new Employee(employeeParts[0], employeePosition));
            }

            employees.Sort();

            foreach (Employee employee in employees)
            {
                Console.WriteLine(employee.ToString());
            }
        }
    }
}

using System;

namespace Humans
{
    class Worker : Human
    {
        private readonly decimal weekSalary;
        private readonly uint workHoursPerDay;

        public Worker(string firstName, string lastName, decimal salary, uint workHours)
        {
            this.FirstName = firstName;
            this.LastName = lastName;

            if (salary >= 0)
            {
                this.weekSalary = salary;
            }
            else
            {
                throw new ArgumentException();
            }

            if (workHours >= 0 && workHours <= 24)
            {
                this.workHoursPerDay = workHours;
            }
            else
            {
                throw new ArgumentException();
            }
            
        }

        public decimal WeekSalary
        {
            get { return this.weekSalary; }
        }

        public uint WorkHoursPerDay
        {
            get { return this.workHoursPerDay; }
        }

        //assuming weekends are non-working days
        public decimal MoneyPerHour()
        {
            return (weekSalary / 5 / workHoursPerDay);
        }
    }
}

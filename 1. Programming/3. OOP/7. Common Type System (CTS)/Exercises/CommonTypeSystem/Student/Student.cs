using System;

namespace Student
{
    class Student : ICloneable, IComparable<Student>
    {
        #region Properties & Fields

        //fields & properties
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public ulong? SSN { get; set; }
        public string Address { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public string Course { get; set; }
        public Specialty StudentSpecialty { get; set; }
        public University StudentUnivesity { get; set; }
        public Faculty StudentFaculty { get; set; }

        #endregion

        #region Constructor

        //constructor - I left those fields that are not neccessary null (my opinion, it is not said in the task)
        public Student(string firstName, string middleName, string lastName, string course, Specialty speciality,
            University university, Faculty faculty, ulong? ssn = null, string address = null,
            string mobilePhone = null, string email = null)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.SSN = ssn;
            this.Address = address;
            this.MobilePhone = mobilePhone;
            this.Email = email;
            this.Course = course;
            this.StudentSpecialty = speciality;
            this.StudentUnivesity = university;
            this.StudentFaculty = faculty;
        }

        #endregion

        #region Methods

        //this is generated with JustCode and then checked and corrected here and there
        public override bool Equals(object obj)
        {
            Student tempStudent = obj as Student;
            if (tempStudent == null)
                return false;
            return this.Equals(tempStudent);
        }

        public bool Equals(Student value)
        {
            if (ReferenceEquals(null, value))
            {
                return false;
            }
            if (ReferenceEquals(this, value))
            {
                return true;
            }
            return Equals(this.FirstName, value.FirstName) &&
                   Equals(this.MiddleName, value.MiddleName) &&
                   Equals(this.LastName, value.LastName) &&
                   this.SSN == value.SSN &&
                   Equals(this.Address, value.Address) &&
                   Equals(this.MobilePhone, value.MobilePhone) &&
                   Equals(this.Email, value.Email) &&
                   Equals(this.Course, value.Course) &&
                   this.StudentSpecialty.Equals(value.StudentSpecialty) &&
                   this.StudentUnivesity.Equals(value.StudentUnivesity) &&
                   this.StudentFaculty.Equals(value.StudentFaculty);
        }

        //this is generated with JustCode
        public override int GetHashCode()
        {
            unchecked
            {
                int result = 17;
                result = result * 23 + ((FirstName != null) ? this.FirstName.GetHashCode() : 0);
                result = result * 23 + ((MiddleName != null) ? this.MiddleName.GetHashCode() : 0);
                result = result * 23 + ((LastName != null) ? this.LastName.GetHashCode() : 0);
                result = result * 23 + this.SSN.GetHashCode();
                result = result * 23 + ((Address != null) ? this.Address.GetHashCode() : 0);
                result = result * 23 + ((MobilePhone != null) ? this.MobilePhone.GetHashCode() : 0);
                result = result * 23 + ((Email != null) ? this.Email.GetHashCode() : 0);
                result = result * 23 + ((Course != null) ? this.Course.GetHashCode() : 0);
                result = result * 23 + this.StudentSpecialty.GetHashCode();
                result = result * 23 + this.StudentUnivesity.GetHashCode();
                result = result * 23 + this.StudentFaculty.GetHashCode();
                return result;
            }
        }

        //tostring
        public override string ToString()
        {
            return string.Format("Student data\n\rFirst name: {0}\n\rMiddle name: {1}\n\rLast name: {2}\n\rSSN: {3}\n\rAddress: {4}\n\rMobile phone: {5}\n\rEmail: {6}\n\rCourse: {7}\n\rUniversity: {8}\n\rFaculty: {9}\n\rSpecialty: {10}\n\r",
                this.FirstName, this.MiddleName, this.LastName, this.SSN, this.Address, this.MobilePhone, this.Email, this.Course, this.StudentUnivesity, this.StudentFaculty, this.StudentSpecialty);
        }

        //== operator
        public static bool operator ==(Student first, Student second)
        {
            return Student.Equals(first, second);
        }

        //!= operator
        public static bool operator !=(Student first, Student second)
        {
            return !Student.Equals(first, second);
        }

        //Icloaneable interface method
        public Student Clone()
        {
            Student result = new Student(this.FirstName, this.MiddleName, this.LastName, this.Course, this.StudentSpecialty,
                this.StudentUnivesity, this.StudentFaculty, this.SSN, this.Address, this.MobilePhone, this.Email);
            return result;
        }

        object ICloneable.Clone()
        {
            return this.Clone();
        }

        //compare to
        public int CompareTo(Student other)
        {
            if (this.FirstName != other.FirstName)
            {
                return (String.Compare(this.FirstName, other.FirstName));
            }
            if (this.LastName != other.LastName)
            {
                return (String.Compare(this.LastName, other.LastName));
            }
            if (this.SSN != other.SSN)
            {
                return (int)(this.SSN - other.SSN);
            }
            return 0;
        }

        #endregion
    }
}

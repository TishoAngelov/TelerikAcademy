namespace HighQualityMethods
{
    using System;

    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string OtherInfo { get; set; }

        public Student(string firstName, string lastName, DateTime birthDate)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.BirthDate = birthDate;
        }

        public bool IsOlderThan(Student student)
        {
            return this.BirthDate > student.BirthDate;
        }
    }
}

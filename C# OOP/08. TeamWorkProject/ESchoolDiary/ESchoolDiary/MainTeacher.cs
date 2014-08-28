using System;

namespace ESchoolDiary
{
    public class MainTeacher : Teacher
    {
        // Fields
        protected int classManage;

        // Properties
        public int ClassManage
        {
            get { return this.classManage; }
            set { this.classManage = value; }
        }

        // Constructors
        public MainTeacher(string firstName, string middleName, string lastName, Sex sex, DateTime birthDate, long pin, int classManage)
            : base(firstName, middleName, lastName, sex, birthDate, pin)
        {
            this.ClassManage = classManage;
        }
        
        public MainTeacher(string firstName, string middleName, string lastName, Sex sex, DateTime birthDate, long pin, string phone, string eMail, string address,
            string[] subjectTeaching, string studentHour, string cabinet, int classManage, string password)
            : base(firstName, middleName, lastName, sex, birthDate, pin, phone, eMail, address, subjectTeaching, studentHour, cabinet, password)
        {
            this.ClassManage = classManage;
        }
    }
}
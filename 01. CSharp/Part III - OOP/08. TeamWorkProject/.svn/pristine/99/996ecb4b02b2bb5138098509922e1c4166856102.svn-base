using System;
using System.Text;

namespace ESchoolDiary
{
    public class Teacher : Person, ITeach
    {
        // Fields
        protected string[] subjectsTeaching;
        protected string studentHour;
        protected string cabinet;
        private string password;

        // Properties
        public string[] SubjectsTeaching
        {
            get { return this.subjectsTeaching; }
            protected set { this.subjectsTeaching = value; }
        }

        public string StudentHour
        {
            get { return this.studentHour; }
            protected set { this.studentHour = value; }
        }

        public string Cabinet
        {
            get { return this.cabinet; }
            protected set { this.cabinet = value; }
        }

        public string Password
        {
            get { return this.password; }
            set { this.password = value; }
        }

        // Constructors
        public Teacher(string firstName, string middleName, string lastName, Sex sex, DateTime birthDate, long pin)
            : base(firstName, middleName, lastName, sex, birthDate, pin)
        {
        }

        public Teacher(string firstName, string middleName, string lastName, Sex sex, DateTime birthDate, long pin, string phone, string eMail, string address,
            string[] subjectTeaching, string studentHour, string cabinet, string password)
            : base(firstName, middleName, lastName, sex, birthDate, pin, phone, eMail, address)
        {
            this.SubjectsTeaching = subjectTeaching;
            this.StudentHour = studentHour;
            this.Cabinet = cabinet;
            this.Password = password;
        }

        // Methods
        // Override methods
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            // #15A#ot 16:00 do 18:00#Geography,History,Math#3333 - Sample record

            StringBuilder subjTeaching = new StringBuilder();
            foreach (var subject in this.SubjectsTeaching)
            {
                subjTeaching.AppendFormat("{0},", subject);
            }

            // Removing the last ",".
            subjTeaching = subjTeaching.Remove(subjTeaching.Length - 1, 1);

            sb.AppendFormat("{0}#{1}#{2}#{3}#{4}#{5}#{6}#{7}#{8}#{9}#{10}#{11}#{12}",
                                this.FirstName,
                                this.MiddleName,
                                this.LastName,
                                this.Sex.ToString(),
                                this.BirthDate,
                                this.Pin,
                                this.Phone,
                                this.EMail,
                                this.Address,
                                this.Cabinet,
                                this.StudentHour,
                                subjTeaching.ToString(),
                                this.Password
                            );

            return sb.ToString();
        }

        // Interface methods implementation
        public void AddMark(Mark mark)
        {
            ESchoolDiaryData.Marks.Add(mark);
        }

        public void AddNote(Note note)
        {
            ESchoolDiaryData.Notes.Add(note);
        }
    }
}
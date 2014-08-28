using System;
using System.IO;
using System.Threading;

namespace ESchoolDiary
{
    // Headmaster who can add new students, teachers and school classes. Also he can punish students.
    public class Headmaster : Person, IManageSchool, IPunish
    {
        // Fields
        private static Headmaster instance;

        // Properties
        public static Headmaster Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = GetHeadmasterInstanceFromFile();
                }

                return instance;
            }
        }

        // Constructors
        private Headmaster(string firstName, string middleName, string lastName, Sex sex, DateTime birthDate, long pin, string password)
            : base(firstName, middleName, lastName, sex, birthDate, pin)
        {
            this.Password = password;
        }

        private Headmaster(string firstName, string middleName, string lastName, Sex sex, DateTime birthDate, long pin, string phone, string eMail, string address, string password)
            : base(firstName, middleName, lastName, sex, birthDate, pin, phone, eMail, address)
        {
            this.Password = password;
        }

        // Methods
        private static Headmaster GetHeadmasterInstanceFromFile()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

            StreamReader reader = new StreamReader(@"../../Data/headmaster.txt");
            using (reader)
            {
                string currentLine = reader.ReadLine();

                string[] currentLineArray = currentLine.Split('#');

                Sex sex = new Sex();
                if (currentLineArray[3] == Sex.Male.ToString())
                {
                    sex = Sex.Male;
                }
                else
                {
                    sex = Sex.Female;
                }

                Headmaster theHeadmaster = new Headmaster(currentLineArray[0], currentLineArray[1], currentLineArray[2], sex, DateTime.Parse(currentLineArray[4]),
                                                Convert.ToInt64(currentLineArray[5]), currentLineArray[6], currentLineArray[7], currentLineArray[8], currentLineArray[9]);

                return theHeadmaster;
            }
        }

        // Add methods
        public void AddStudent(Student student)
        {
            ESchoolDiaryData.Students.Add(student);
        }

        public void AddSubject(Subject subject)
        {
            ESchoolDiaryData.Subjects.Add(subject);
        }

        public void AddSchoolClasses(SchoolClass schoolClass)
        {
            ESchoolDiaryData.SchoolClasses.Add(schoolClass);
        }

        public void AddTeacher(Teacher teacher)
        {
            ESchoolDiaryData.Teachers.Add(teacher);
        }

        public void AddMainTeacher(MainTeacher mainTeacher)
        {
            ESchoolDiaryData.MainTeachers.Add(mainTeacher);
        }

        // Remove methods
        public void RemoveStudent(Student student)
        {
            ESchoolDiaryData.Students.Remove(student);
        }

        public void RemoveSubject(Subject subject)
        {
            ESchoolDiaryData.Subjects.Remove(subject);
        }

        public void RemoveSchoolClasses(SchoolClass schoolClass)
        {
            ESchoolDiaryData.SchoolClasses.Remove(schoolClass);
        }

        public void RemoveTeacher(Teacher teacher)
        {
            ESchoolDiaryData.Teachers.Remove(teacher);
        }

        public void RemoveMainTeacher(MainTeacher mainTeacher)
        {
            ESchoolDiaryData.MainTeachers.Remove(mainTeacher);
        }

        // Punishment methods
        public void PunishFor3Notes(Student student)
        {
            int counter = 0;

            foreach (var note in ESchoolDiaryData.Notes)
            {
                if (note.StudentPin == student.Pin)
                {
                    counter++;
                }
            }

            if (counter == 3)
            {
                // TODO: Punishment logic
            }
        }

        public void PunishFor5Notes(Student student)
        {
            int counter = 0;

            foreach (var note in ESchoolDiaryData.Notes)
            {
                if (note.StudentPin == student.Pin)
                {
                    counter++;
                }
            }

            if (counter == 5)
            {
                // TODO: Punishment logic
            }
        }

        public void PunishFor10Notes(Student student)
        {
            int counter = 0;

            foreach (var note in ESchoolDiaryData.Notes)
            {
                if (note.StudentPin == student.Pin)
                {
                    counter++;
                }
            }

            if (counter >= 10)
            {
                // Expel the student

                this.RemoveStudent(student);
            }
        }
    }
}
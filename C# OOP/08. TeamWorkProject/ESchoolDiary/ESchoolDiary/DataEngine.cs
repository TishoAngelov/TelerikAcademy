using System;
using System.IO;
using System.Threading;

namespace ESchoolDiary
{
    public static class DataEngine
    {
        // Loading data
        public static void LoadDatabase()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

            LoadStudents();
            LoadTeachers();
            LoadMarks();
            LoadNotes();
            LoadSchoolClasses();
        }

        private static void LoadStudents()
        {
            string filePath = @"../../Data/students.txt";

            StreamReader reader = new StreamReader(filePath);
            using (reader)
            {
                string currentLine = reader.ReadLine();
                
                while (currentLine != null)
                {
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

                    Student currStudent = new Student(currentLineArray[0], currentLineArray[1], currentLineArray[2], sex, DateTime.Parse(currentLineArray[4]),
                                                    Convert.ToInt64(currentLineArray[5]), currentLineArray[6], currentLineArray[7], currentLineArray[8], currentLineArray[9], int.Parse(currentLineArray[10]), char.Parse(currentLineArray[11]));

                    ESchoolDiaryData.Students.Add(currStudent);

                    currentLine = reader.ReadLine();
                }                
            }
        }

        private static void LoadTeachers()
        {
            string filePath = @"../../Data/teachers.txt";

            StreamReader reader = new StreamReader(filePath);
            using (reader)
            {
                string currentLine = reader.ReadLine();

                while (currentLine != null)
                {
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

                    Teacher currentTeacher = new Teacher(currentLineArray[0], currentLineArray[1], currentLineArray[2], sex, DateTime.Parse(currentLineArray[4]),
                                                    Convert.ToInt64(currentLineArray[5]), currentLineArray[6], currentLineArray[7], currentLineArray[8],
                                                    currentLineArray[11].Split(','), currentLineArray[10], currentLineArray[9], currentLineArray[12]);

                    ESchoolDiaryData.Teachers.Add(currentTeacher);
                    currentLine = reader.ReadLine();                    
                }
            }
        }

        private static void LoadMarks()
        {
            string filePath = @"../../Data/students_marks.txt";

            StreamReader reader = new StreamReader(filePath);
            using (reader)
            {
                string currentLine = reader.ReadLine();

                while (currentLine != null)
                {
                    string[] currentLineArray = currentLine.Split('#');

                    TypeOfMarks markType = new TypeOfMarks();
                    switch (currentLineArray[1])
                    {
                        case "Current": markType = TypeOfMarks.Current; break;
                        case "Term": markType = TypeOfMarks.Term; break;
                        case "Annual": markType = TypeOfMarks.Annual; break;
                    }

                    // 3,50#Current#1111111111#10#A#Math  -  Sample record of mark
                    Mark currMark = new Mark(decimal.Parse(currentLineArray[0]), markType, long.Parse(currentLineArray[2]), 
                                                  int.Parse(currentLineArray[3]), char.Parse(currentLineArray[4]), 
                                                  currentLineArray[5]);

                    ESchoolDiaryData.Marks.Add(currMark);

                    currentLine = reader.ReadLine();
                }
            }
        }

        private static void LoadNotes()
        {
            string filePath = @"../../Data/students_notes.txt";

            StreamReader reader = new StreamReader(filePath);
            using (reader)
            {
                string currentLine = reader.ReadLine();

                while (currentLine != null)
                {
                    string[] currentLineArray = currentLine.Split('#');

                    Note currentNote = new Note(long.Parse(currentLineArray[0]), currentLineArray[1]);

                    ESchoolDiaryData.Notes.Add(currentNote);

                    currentLine = reader.ReadLine();
                }
            }
        }

        private static void LoadSchoolClasses()
        {
            string filePath = @"../../Data/school_classes.txt";

            StreamReader reader = new StreamReader(filePath);
            using (reader)
            {
                string currentLine = reader.ReadLine();

                while (currentLine != null)
                {
                    string[] currentLineArray = currentLine.Split(' ');

                    SchoolClass currClass = new SchoolClass(int.Parse(currentLineArray[0]), char.Parse(currentLineArray[1]));

                    ESchoolDiaryData.SchoolClasses.Add(currClass);

                    currentLine = reader.ReadLine();
                }
            }
        }

        // Saving data
        public static void SaveDatabase()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

            SaveStudents();
            SaveTeachers();
            SaveMarks();
            SaveNotes();
            SaveSchoolClasses();
        }

        private static void SaveSchoolClasses()
        {
            string filePath = @"../../Data/school_classes.txt";

            StreamWriter writer = new StreamWriter(filePath);
            using (writer)
            {
                foreach (var schClass in ESchoolDiaryData.SchoolClasses)
                {
                    writer.WriteLine(schClass);
                }
            }
        }

        private static void SaveMarks()
        {
            string filePath = @"../../Data/students_marks.txt";

            StreamWriter writer = new StreamWriter(filePath);
            using (writer)
            {
                foreach (var mark in ESchoolDiaryData.Marks)
                {
                    writer.WriteLine("{0:0.00}#{1}#{2}#{3}#{4}#{5}", mark.MarkValue, mark.MarkType, 
                                        mark.StudentPin, mark.SchClass, mark.SchSubClass, mark.SubjectName);
                }
            }
        }

        private static void SaveTeachers()
        {
            string filePath = @"../../Data/teachers.txt";

            StreamWriter writer = new StreamWriter(filePath);
            using (writer)
            {
                foreach (var teacher in ESchoolDiaryData.Teachers)
                {
                    writer.WriteLine(teacher);
                }
            }
        }

        private static void SaveStudents()
        {
            string filePath = @"../../Data/students.txt";

            StreamWriter writer = new StreamWriter(filePath);
            using (writer)
            {
                foreach (var student in ESchoolDiaryData.Students)
                {
                    writer.WriteLine(student);
                }
            }
        }

        private static void SaveNotes()
        {
            string filePath = @"../../Data/students_notes.txt";

            StreamWriter writer = new StreamWriter(filePath);
            using (writer)
            {
                foreach (var note in ESchoolDiaryData.Notes)
                {
                    writer.WriteLine("{0}#{1}", note.StudentPin, note.NoteMsg);
                }
            }
        }

        // Methods for getting specific data
        public static Student GetStudent(string id)
        {
            foreach (Student student in ESchoolDiaryData.Students)
            {
                if (student.Pin.ToString().Equals(id))
                {
                    if (student.Pin.ToString() == id)
                    {
                        return student;
                    }
                }
            }

            return null;
        }

        public static Teacher GetTeacher(string id)
        {
            foreach (Teacher teacher in ESchoolDiaryData.Teachers)
            {
                if (teacher.Pin.ToString().Equals(id))
                {
                    if (teacher.Pin.ToString() == id)
                    {
                        return teacher;
                    }
                }
            }

            return null;
        }
    }    
}
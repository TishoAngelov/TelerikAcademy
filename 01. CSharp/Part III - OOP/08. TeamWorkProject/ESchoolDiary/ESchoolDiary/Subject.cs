using System;
using System.Collections.Generic;

namespace ESchoolDiary
{
    public class Subject
    {
        private List<Student> students;
        private List<Teacher> teachers;
        private SubjectName name;

        public SubjectName Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public List<Student> Students
        {
            get { return this.students; }
            set { this.students = value; }
        }

        public List<Teacher> Teachers
        {
            get { return this.teachers; }
            set { this.teachers = value; }
        }

        public Subject(SubjectName subjectName) 
        {
            this.Name = subjectName;
        }

        public void AddStudent(Student student)
        {
            this.Students.Add(student);
        }

        public void AddTeacher(Teacher teacher)
        {
            this.Teachers.Add(teacher);
        }
    }
}
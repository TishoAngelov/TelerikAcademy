using System;
using System.Collections.Generic;

namespace _01.School
{
    public class Class : ICommentable
    {
        // Fields
        private string textIdentifier;
        private readonly List<Student> students;
        private readonly List<Teacher> teachers;
        private List<string> comments = new List<string>();        

        // Properties
        public string TextIdentifier
        {
            get { return this.textIdentifier; }
            set { this.textIdentifier = value; }
        }

        public List<Student> Students
        {
            get { return this.students; }
        }

        public List<Teacher> Teachers
        {
            get { return this.teachers; }
        }

        public List<string> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        // Constructors
        public Class(string textIdentifier)
        {
            this.students = new List<Student>();
            this.teachers = new List<Teacher>();
            this.textIdentifier = textIdentifier;            
        }

        // Methods
        // for student
        public void AddStudent(Student newStudent)
        {
            this.students.Add(newStudent);
        }

        public void RemoveStudent(Student oldStudent)
        {
            this.students.Remove(oldStudent);
        }

        // for teachers
        public void AddTeacher(Teacher newTeacher)
        {
            this.teachers.Add(newTeacher);
        }

        public void RemoveTeacher(Teacher oldTeacher)
        {
            this.teachers.Remove(oldTeacher);
        }

        // for comments
        public void AddComment(string comment)
        {
            this.comments.Add(comment);
        }

        public void RemoveComment(string comment)
        {
            this.comments.Remove(comment);
        }
    }
}
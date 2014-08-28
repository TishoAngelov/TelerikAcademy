using System;
using System.Collections.Generic;
using System.Text;

namespace ESchoolDiary
{
    public class Student : Person
    {
        // Fields
        private List<string> notes = new List<string>();
        private string parrentEmail;

        private int schClass;
        private char schSubClass;

        // Properties
        public List<string> Notes
        {
            get { return this.notes; }
            protected set { this.notes = value; }
        }

        public string ParrentEmail
        {
            get { return this.parrentEmail; }
            protected set { this.parrentEmail = value; }
        }

        public int SchClass
        {
            get { return this.schClass; }
            protected set { this.schClass = value; }
        }

        public char SchSubClass
        {
            get { return this.schSubClass; }
            protected set { this.schSubClass = value; }
        }

        // Constructors        
        public Student(string firstName, string middleName, string lastName, Sex sex, DateTime birthDate, long pin, int schClass, char schSubClass)
            : base(firstName, middleName, lastName, sex, birthDate, pin)
        {
            base.Password = pin.ToString();

            this.SchClass = schClass;
            this.SchSubClass = schSubClass;
        }

        public Student(string firstName, string middleName, string lastName, Sex sex, DateTime birthDate, long pin, string phone, string eMail, string address, string parrentEmail, int schClass, char schSubClass)
            : base(firstName, middleName, lastName, sex, birthDate, pin, phone, eMail, address)
        {
            base.Password = pin.ToString();
            this.ParrentEmail = parrentEmail;

            this.SchClass = schClass;
            this.SchSubClass = schSubClass;
        }

        // Methods
        public List<Note> GetNotes()
        {
            List<Note> studentNotes = new List<Note>();

            foreach (Note note in ESchoolDiaryData.Notes)
            {
                if (note.StudentPin == this.pin)
                {
                    studentNotes.Add(note);
                }
            }

            if (studentNotes.Count != 0)
            {
                return studentNotes;
            }

            return null;
        }

        public List<Mark> GetMarks()
        {
            List<Mark> studentMarks = new List<Mark>();
            foreach (Mark mark in ESchoolDiaryData.Marks)
            {
                if (mark.StudentPin == this.pin)
                {
                    studentMarks.Add(mark);
                }
            }

            return studentMarks;
        }

        // Override methods
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            
            sb.AppendFormat("{0}#{1}#{2}#{3}#{4}#{5}#{6}#{7}#{8}#{9}#{10}#{11}", 
                                this.FirstName, 
                                this.MiddleName, 
                                this.LastName, 
                                this.Sex.ToString(), 
                                this.BirthDate, 
                                this.Pin, 
                                this.Phone, 
                                this.EMail, 
                                this.Address, 
                                this.ParrentEmail, 
                                this.SchClass, 
                                this.SchSubClass
                            );

            return sb.ToString();
        }
    }
}
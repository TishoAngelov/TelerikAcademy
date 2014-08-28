using System;

namespace ESchoolDiary
{
    public class Mark
    {
        // Fields
        protected decimal markValue;
        protected TypeOfMarks markType;
        protected long studentPin;
        protected int schClass;
        protected char schSubClass;
        protected string subjectName;

        // Properties
        public decimal MarkValue
        {
            get
            {
                return this.markValue;
            }
            protected set
            {
                this.markValue = value;
            }
        }

        public TypeOfMarks MarkType
        {
            get
            {
                return this.markType;
            }
            protected set
            {
                this.markType = value;
            }
        }

        public long StudentPin
        {
            get
            {
                return this.studentPin;
            }
            protected set
            {
                this.studentPin = value;
            }
        }

        public int SchClass
        {
            get
            {
                return this.schClass;
            }
            protected set
            {
                this.schClass = value;
            }
        }

        public char SchSubClass
        {
            get
            {
                return this.schSubClass;
            }
            protected set
            {
                this.schSubClass = value;
            }
        }

        public string SubjectName
        {
            get
            {
                return this.subjectName;
            }
            protected set
            {
                this.subjectName = value;
            }
        }

        // Constructors
        // Using it for reading the data in students_marks.txt - Tisho
        // 3,50#Current#1111111111#10#A#Math  -  Sample record of mark
        public Mark(decimal markValue, TypeOfMarks markType, long studentPin, int studSchClass, char studSchSubClass, string subjectName)
        {
            this.MarkValue = markValue;
            this.MarkType = markType;
            this.StudentPin = studentPin;
            this.SchClass = studSchClass;
            this.SchSubClass = studSchSubClass;
            this.SubjectName = subjectName;
        }        

        // Use it in the forms
        public Mark(decimal markValue, TypeOfMarks markType, Student student, Subject subject)
        {
            this.MarkValue = markValue;
            this.MarkType = markType;
            this.StudentPin = student.Pin;
            this.SchClass = student.SchClass;
            this.SchSubClass = student.SchSubClass;
            this.SubjectName = subject.Name.ToString();
        }
    }
}
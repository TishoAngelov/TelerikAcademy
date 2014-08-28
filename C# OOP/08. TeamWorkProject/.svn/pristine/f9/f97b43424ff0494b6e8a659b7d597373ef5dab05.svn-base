using System;

namespace ESchoolDiary
{
    public struct Note
    {
        // Fields
        private long studentPin;
        private string noteMsg;

        // Properties
        public long StudentPin
        {
            get { return this.studentPin; }
            set { this.studentPin = value; }
        }

        public string NoteMsg
        {
            get { return this.noteMsg; }
            set { this.noteMsg = value; }
        }

        // Constructors
        public Note(long studentPin, string noteMessage)
            : this()
        {
            this.studentPin = studentPin;
            this.NoteMsg = noteMessage;
        }

        // Methods
        public override string ToString()
        {
            return String.Format("{0}", NoteMsg) + "\n";
        }
    }
}
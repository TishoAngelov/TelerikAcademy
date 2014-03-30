using System;
using System.Text;

namespace ESchoolDiary
{
    public class SchoolClass
    {
        // Fields
        protected int schClass;
        protected char schSubClass;

        // Properties
        public int SchClass
        {
            get { return this.schClass; }
            set { this.schClass = value; }
        }

        public char SchSubClass
        {
            get { return this.schSubClass; }
            set { this.schSubClass = value; }
        }

        // Constructors
        public SchoolClass(int schClass, char schSubClass)
        {
            this.SchClass = schClass;
            this.SchSubClass = char.ToUpper(schSubClass);
        }

        // Methods
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();

            str.AppendFormat("{0} {1} Class", this.SchClass, this.SchSubClass);
            
            return str.ToString();
        }
    }
}
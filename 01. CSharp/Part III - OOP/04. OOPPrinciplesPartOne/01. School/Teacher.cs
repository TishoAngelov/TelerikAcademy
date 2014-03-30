using System;
using System.Collections.Generic;

namespace _01.School
{
    public class Teacher : People
    {
        // Fields
        private readonly List<Discipline> disciplines;

        // Properties
        public List<Discipline> Disciplines
        {
            get { return this.disciplines; }
        }

        // Constructors
        public Teacher(string firstName, string lastName)
        {
            disciplines = new List<Discipline>();

            base.FirstName = firstName;
            base.LastName = lastName;
        }

        // Methods
        public void AddDiscipline(Discipline discipline)
        {
            this.disciplines.Add(discipline);
        }

        public void RemoveDiscipline(Discipline discipline)
        {
            this.disciplines.Remove(discipline);
        }        
    }
}
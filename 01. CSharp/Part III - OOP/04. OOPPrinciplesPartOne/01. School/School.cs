using System;
using System.Collections.Generic;

namespace _01.School
{
    public class School
    {
        // Fields
        private readonly List<Class> classes;
        
        // Properties
        public List<Class> Classes
        {
            get { return this.classes; }
        }

        // Constructors
        public School()
        {
            this.classes = new List<Class>();
        }

        // Methods
        public void AddClass(Class newClass)
        {
            this.classes.Add(newClass);
        }

        public void RemoveClass(Class oldClass)
        {
            this.classes.Remove(oldClass);       
        }
    }
}
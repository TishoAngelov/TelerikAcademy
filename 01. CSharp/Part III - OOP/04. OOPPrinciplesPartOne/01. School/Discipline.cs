using System;
using System.Collections.Generic;

namespace _01.School
{
    public class Discipline : ICommentable
    {
        // Fields
        private string name;
        private int numLectures;
        private int numExercises;
        private List<string> comments = new List<string>();
        
        // Properties
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public int NumLectures
        {
            get { return this.numLectures; }
            set { this.numLectures = value; }
        }

        public int NumExercises
        {
            get { return this.numExercises; }
            set { this.numExercises = value; }
        }

        public List<string> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        // Constructors
        public Discipline(string name, int numLectures, int numExercises)
        {
            this.name = name;
            this.numLectures = numLectures;
            this.numExercises = numExercises;
        }

        // Methods
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
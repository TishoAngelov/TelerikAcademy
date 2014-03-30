using System;
using System.Collections.Generic;

namespace _01.School
{
    // The class is abstract to prohibit making instance of it
    public abstract class People : ICommentable
    {
        // Fields
        private string firstName;
        private string lastName;
        private List<string> comments = new List<string>();

        // Properties
        public string FirstName
        {
            get { return this.firstName; }
            set { this.firstName = value; }
        }

        public string LastName
        {
            get { return this.lastName; }
            set { this.lastName = value; }
        }

        public List<string> Comments
        {
            get { return this.comments; }
            set { this.comments = value;}
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
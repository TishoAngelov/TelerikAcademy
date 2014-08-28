﻿namespace CodeFormatting
{
    using System;
    using System.Text;

    internal class Event : IComparable
    {
        private readonly DateTime date;
        private readonly string title;
        private readonly string location;

        public Event(DateTime date, string title, string location)
        {
            this.date = date;
            this.title = title;
            this.location = location;
        }

        public int CompareTo(object obj)
        {
            Event other = obj as Event;
            int compareByDate = this.date.CompareTo(other.date);
            int comapreByTitle = this.title.CompareTo(other.title);
            int compareByLocation = this.location.CompareTo(other.location);

            if (compareByDate == 0)
            {
                if (comapreByTitle == 0)
                {
                    return compareByLocation;
                }
                else
                {
                    return comapreByTitle;
                }
            }
            else
            {
                return compareByDate;
            }
        }

        public override string ToString()
        {
            StringBuilder toString = new StringBuilder();

            toString.Append(this.date.ToString("yyyy-MM-ddTHH:mm:ss"));
            toString.Append(" | " + this.title);

            if (this.location != null && this.location != string.Empty)
            {
                toString.Append(" | " + this.location);
            }

            return toString.ToString();
        }
    }
}
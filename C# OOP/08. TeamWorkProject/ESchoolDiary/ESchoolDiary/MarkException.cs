using System;

namespace ESchoolDiary
{
    public class MarkException : Exception
    {
        // Short properties
        private const decimal MinMark = 2.00M;
        private const decimal MaxMark = 6.00M;

        // Constructors
        public MarkException() : base()
        {
        }

        // Methods
        public override string Message
        {
            get
            {
                return string.Format("The mark was in invalid range! Please enter a mark in the range [{0:0.00} - {1:0.00}]!",
                    MinMark, MaxMark);
            }
        }
    }
}
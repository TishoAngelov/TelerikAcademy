using System;

namespace _03.MyException
{
    // Define a class InvalidRangeException<T> that holds information about an error condition related 
    // to invalid range. It should hold error message and a range definition [start … end].
    public class InvalidRangeException<T> : Exception
    {
        // Short properties
        public T MinRange { get; private set; }
        public T MaxRange { get; private set; }

        // Constructors
        public InvalidRangeException(T minRange, T maxRange)
        {
            this.MinRange = minRange;
            this.MaxRange = maxRange;
        }

        // Methods
        public override string Message
        {
            get
            {
                return string.Format("The value was in invalid range! Please enter a value in the range [{0} - {1}]!", 
                    this.MinRange, this.MaxRange);
            }
        }
    }
}
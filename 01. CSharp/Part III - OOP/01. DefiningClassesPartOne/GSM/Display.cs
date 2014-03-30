using System;

namespace GSM
{
    public class Display
    {
        // Constants
        private const int MinColors = 2;

        // Fields
        private string size;
        private uint? numOfColors;

        // Constructors
        public Display()
            : this(null, null)
        {
        }

        public Display(string size)
            : this(size, null)
        {
        }

        public Display(string size, uint? numOfColors)
        {
            this.size = size;
            this.numOfColors = numOfColors;
        }

        // Properties
        public string Size
        {
            get { return this.size; }
            set
            {
                if (value == null)
                {
                    this.size = "unknown";
                }
                else
                {
                    this.size = value;
                }
            }
        }

        public uint? NumOfColors
        {
            get { return this.numOfColors; }
            set
            {
                if (value < MinColors)
                {
                    throw new ArgumentOutOfRangeException("The phone can't have less than 2 colors!");
                }

                this.numOfColors = value;
            }
        }
    }
}
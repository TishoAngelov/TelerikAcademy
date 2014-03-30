using System;

namespace GSM
{
    public enum Type
    {
        LiIon, NiMH, NiCd, Unknown
    }

    public class Battery
    {
        // Fields
        private string model;
        private uint? hoursIdle;
        private uint? hoursTalk;
        private Type? batteryType;

        // Constructors
        public Battery()
            : this(null, null, null, null)
        {
        }

        public Battery(string model, uint hoursTalk)
            : this(model, null, null, hoursTalk)
        {
        }

        public Battery(string model, Type? batteryType, uint? hoursIdle, uint? hoursTalk)
        {
            this.model = model;
            this.batteryType = batteryType;
            this.hoursIdle = hoursIdle;
            this.hoursTalk = hoursTalk;
        }

        // Properties
        public Type? BatteryType
        {
            get { return this.batteryType; }
            set { this.batteryType = value; }
        }

        public string Model
        {
            get { return this.model; }
            set
            {
                if (value == null)
                {
                    this.model = "unknown";
                }
                else
                {
                    this.model = value;
                }
            }
        }

        public uint? HoursIdle
        {
            get { return this.hoursIdle; }
            set
            {
                //uint correctValue = 0;

                //// Check if it's a number
                //try
                //{
                //    correctValue = decimal.Parse(value.ToString());
                //}
                //catch (ArgumentException)
                //{
                //    Console.WriteLine("Please enter valid price! Numbers only!");
                //}

                //// Check if it's negative
                //if (correctValue < 0)
                //{
                //    throw new ArgumentOutOfRangeException("The price can't be negative!");
                //}

                //this.price = correctValue;
                ///////////
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Hours idle can't be negative!");
                }

                this.hoursIdle = value;
            }
        }

        public uint? HoursTalk
        {
            get { return this.hoursTalk; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Hours talk can't be negative!");
                }

                this.hoursTalk = value;
            }
        }
    }
}
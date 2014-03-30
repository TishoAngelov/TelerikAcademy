using System;

namespace GSM
{
    public class GSM
    {
        // IPhone4S
        private static readonly GSM iPhone4S = new GSM("iPhone 4s", "Apple", 800M, "Pesho", "960 x 640 pixels", 16000000, "unknown", Type.LiIon, 60, 30);

        // Fields
        private string model;
        private string manufacturer;
        private decimal? price;
        private string owner;

        private Display display;
        private Battery battery;

        // Constructors
        public GSM(string model, string manufacturer)
            : this(model, manufacturer, null, null)
        {
        }

        public GSM(string model, string manufacturer, decimal price)
            : this(model, manufacturer, price, null)
        {
        }

        public GSM(string model, string manufacturer, decimal? price, string owner)
        {
            this.model = model;
            this.manufacturer = manufacturer;
            this.price = price;
            this.owner = owner;
        }

        public GSM(string model, string manufacturer, decimal? price, string owner, string displaySize,
            uint? displayNumOfColors, string batteryModel, Type batteryType, uint? batteryHoursIdle, uint? batteryHoursTalk)
        {
            this.display = new Display(displaySize, displayNumOfColors);
            this.battery = new Battery(batteryModel, batteryType, batteryHoursIdle, batteryHoursTalk);

            this.model = model;
            this.manufacturer = manufacturer;
            this.price = price;
            this.owner = owner;
        }

        // Properties
        public static GSM IPhone4S
        {
            get { return iPhone4S; }
        }

        public string Model
        {
            get { return this.model; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("The model can't be empty!");
                }

                this.model = value;
            }
        }

        public string Manufacturer
        {
            get { return this.manufacturer; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("The manufacturer can't be empty!");
                }

                this.manufacturer = value;
            }
        }

        public decimal? Price
        {
            get { return this.price; }
            set
            {
                decimal correctValue = 0;

                // Check if it's a number
                try
                {
                    correctValue = decimal.Parse(value.ToString());
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Please enter valid price! Numbers only!");
                }

                // Check if it's negative
                if (correctValue < 0)
                {
                    throw new ArgumentOutOfRangeException("The price can't be negative!");
                }

                this.price = correctValue;
            }
        }

        public string Owner
        {
            get { return this.owner; }
            set
            {
                if (value == null)
                {
                    this.owner = "unknown";
                }

                this.owner = value;
            }
        }

        // Methods
        public override string ToString()
        {
            string result = string.Format("Model: {0}\nManufacturer: {1}\nPrice: {2:0.00}лв.\nOwner: {3}",
                this.model, this.manufacturer, this.price, this.owner);

            return result;
        }
    }
}
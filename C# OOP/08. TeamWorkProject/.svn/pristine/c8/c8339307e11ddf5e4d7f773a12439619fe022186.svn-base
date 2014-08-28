using System;
using System.Windows;

namespace ESchoolDiary
{
    public abstract class Person
    {
        // Fields
        protected string firstName;
        protected string middleName;
        protected string lastName;
        protected string password;
        protected Sex sex;
        protected DateTime birthDate;
        protected long pin;
        protected string phone;
        protected string eMail;
        protected string address;

        // Properties
        public string FirstName
        {
            get { return this.firstName; }
            protected set
            {
                try
                {
                    Validation.ValidateName(value);
                    this.firstName = value;
                }
                catch (ArgumentException e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        public string MiddleName
        {
            get { return this.middleName; }
            protected set
            {
                try
                {
                    Validation.ValidateName(value);
                    this.middleName = value;
                }
                catch (ArgumentException e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            protected set
            {
                try
                {
                    Validation.ValidateName(value);
                    this.lastName = value;
                }
                catch (ArgumentException e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        public string Password
        {
            get
            {
                return this.password;
            }
            set
            {
                this.password = value;
            }
        }

        public Sex Sex
        {
            get { return this.sex; }
            protected set { Validation.ValidateSex(value); }

        }

        public DateTime BirthDate
        {
            get { return this.birthDate; }
            protected set
            { 
                Validation.ValidateBirthDate(value); 
            }
        }

        public long Pin
        {
            get { return this.pin; }
            protected set
            {
                try
                {
                    Validation.ValidatePin(value);
                    this.pin = value;
                }
                catch (ArgumentException e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        public string Phone
        {
            get { return this.phone; }
            protected set
            {
                try
                {
                    Validation.ValidatePhone(value);
                    this.phone = value;
                }
                catch (ArgumentException e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        public string EMail
        {
            get { return this.eMail; }
            protected set
            {
                try
                {
                    Validation.ValidateEmail(value);
                    this.eMail = value;
                }
                catch (ArgumentException e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        //TODO VALIDATE ADDRESS
        public string Address
        {
            get { return this.address; }
            protected set
            {
                try
                {
                    this.address = value;
                }
                catch (ArgumentException e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        public byte Age
        {
            get
            {
                return (byte)(DateTime.Now.Year - this.BirthDate.Year);
            }
        }

        //Constructors
        public Person(string firstName, string middleName, string lastName, Sex sex, DateTime birthDate, long pin)
            : this(firstName, middleName, lastName, sex, birthDate, pin, null, null, null)
        {
        }

        // Full constructor
        public Person(string firstName, string middleName, string lastName, Sex sex, DateTime birthDate, long pin, string phone, string eMail, string address)
        {
            this.firstName = firstName;
            this.middleName = middleName;
            this.lastName = lastName;
            this.sex = sex;
            this.birthDate = birthDate;
            this.pin = pin;
            this.phone = phone;
            this.eMail = eMail;
            this.address = address;
        }

        // Methods

    }
}
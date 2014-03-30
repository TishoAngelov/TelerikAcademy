using System;
using System.Text.RegularExpressions;

namespace ESchoolDiary
{
    public static class Validation
    {
        public static void ValidateName(String name)
        {
            if (name == null)
            {
                throw new ArgumentNullException("Name", "The name cannot be null!");
            }
            else if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentOutOfRangeException("Name", "The name cannot be an empty string or a sequence of white spaces!");
            }
            else if (!Regex.IsMatch(name, "^[a-z]+$", RegexOptions.IgnoreCase))
            {
                throw new ArgumentException("The name should be in letters [a-z] only!");
            }
        }

        public static void ValidateEmail(String email)
        {
            if (email == null)
            {
                throw new ArgumentNullException("Email", "The email cannot be null!");
            }
            else if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentOutOfRangeException("Email", "The email cannot be an empty string or a sequence of white spaces!");
            }

            if (!Regex.IsMatch(email, @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" + "@" + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$")
                || string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("Email", "The email is not in the correct format!");
            }
        }

        public static void ValidatePin(long pin)
        {                      
            if (pin.ToString().Length != 10)
            {
                throw new FormatException("The pin is not in the correct format.It should be a 10 digit number!");               
            }
        }

        public static void ValidatePhone(string phone)
        {
            if (phone == null)
            {
                throw new ArgumentNullException("Phone", "The phone cannot be null!");
            }
            else if (string.IsNullOrWhiteSpace(phone))
            {
                throw new ArgumentOutOfRangeException("Phone", "The phone cannot be an empty string or a sequence of white spaces!");
            }
            else if ((!Regex.IsMatch(phone, "^[0-9]+$")) || phone.Length > 15)
            {
                Console.WriteLine("The phone is not in the correct format");
            }
        }

        public static void ValidateSex(Sex sex)
        {
            // TODO: Sex validation
        }

        public static void ValidateBirthDate(DateTime birthDate)
        {
            DateTime today = DateTime.Today;

            if (birthDate > today)
            {
                throw new ArgumentException("Age", "This is not a valid age!");
            }
        }

        public static bool IsEmpty(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                return true;
            }
            return false;
        }

        public static void ValidateMark(Mark mark)
        {
            if (!(mark.MarkValue >= 2.00M && mark.MarkValue <= 6.00M))
            {
                throw new MarkException();
            }
        }
    }
}
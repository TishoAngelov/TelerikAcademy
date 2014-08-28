using System;
using System.Text;

namespace _01.Students
{
    // 01. Define a class Student, which contains data about a student – first, middle and last
    // name, SSN, permanent address, mobile phone e-mail, course, specialty, university, faculty.
    // Use an enumeration for the specialties, universities and faculties. Override the standard 
    // methods, inherited by  System.Object: Equals(), ToString(), GetHashCode() and operators == and !=.
    
    // Enumerations
    public enum Specialties { spec1, spec2, spec3 }
    public enum Universities { TU_Sofia, SU, UNSS }
    public enum Faculties { fac1, fac2, fac3 }
    
    public class Student : ICloneable, IComparable<Student>
    {        
        // Short properties
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public long? SSN { get; set; }
        public string PermAddress { get; set; }     // Permanent addres does not mean that it should be with private set!
        public string MobilePhone { get; set; }     // Can start with +, so we need string.
        public string EMail { get; set; }

        public string Course { get; set; }

        public Specialties? Specialty { get; set; }
        public Universities? University { get; set; }
        public Faculties? Faculty { get; set; }
        
        // Constructors
        public Student()
        {
        }

        public Student(string firstName, string middleName, string lastName)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
        }

        public Student(string firstName, string middleName, string lastName, long? SSN, string permAddress,
            string mobilePhone, string eMail, string course, Specialties? specialty, Universities? university, Faculties? faculty)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;

            this.SSN = SSN;
            this.PermAddress = permAddress;
            this.MobilePhone = mobilePhone;
            this.EMail = eMail;

            this.Course = course;
            this.Specialty = specialty;
            this.University = university;
            this.Faculty = faculty;
        }

        // Methods
        public override bool Equals(object obj)
        {
            Student student = obj as Student;

            // Check if the given obj can be used as Student. If not, return false;
            if (!(student is Student))
            {
                return false;
            }

            return this.SSN == student.SSN;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append("\tData about student\n");

            result.Append(string.Format("First name: {0}\n", this.FirstName ?? "<unknown>"));
            result.Append(string.Format("Middle name: {0}\n", this.MiddleName ?? "<unknown>"));
            result.Append(string.Format("Last name: {0}\n", this.LastName ?? "<unknown>"));

            result.Append(string.Format("SSN: {0}\n", this.SSN == null ? "<unknown>" : this.SSN.ToString()));
            result.Append(string.Format("Permanent address: {0}\n", this.PermAddress ?? "<unknown>"));
            result.Append(string.Format("Mobile phone: {0}\n", this.MobilePhone ?? "<unknown>"));
            result.Append(string.Format("E-mail: {0}\n", this.EMail ?? "<unknown>"));

            result.Append(string.Format("Course: {0}\n", this.Course ?? "<unknown>"));
            result.Append(string.Format("Specialty: {0}\n", this.Specialty == null ? "<unknown>" : this.Specialty.ToString()));
            result.Append(string.Format("University: {0}\n", this.University == null ? "<unknown>" : this.University.ToString()));
            result.Append(string.Format("Faculty: {0}\n", this.Faculty == null ? "<unknown>" : this.Faculty.ToString()));

            result.Append(Environment.NewLine);

            return result.ToString();
        }

        public override int GetHashCode()
        {
            return this.SSN.GetHashCode() ^ this.FirstName.GetHashCode() ^ this.SSN.GetHashCode();
        }

        // 02. Add implementations of the ICloneable interface. The Clone() method should deeply copy all object's fields into a new object of type Student.
        public object Clone()
        {
            return new Student(this.FirstName, this.MiddleName, this.LastName, this.SSN, this.PermAddress,
                                    this.MobilePhone, this.EMail, this.Course, this.Specialty, this.University, this.Faculty) as object;
        }

        // 03. Implement the  IComparable<Student> interface to compare students by names (as first criteria, 
        // in lexicographic order) and by social security number (as second criteria, in increasing order).
        public int CompareTo(Student other)
        {
            if (this.FirstName.CompareTo(other.FirstName) != 0)
            {
                return this.FirstName.CompareTo(other.FirstName);
            }
            else if (this.MiddleName.CompareTo(other.MiddleName) != 0)
            {
                this.MiddleName.CompareTo(other.MiddleName);
            }
            else if (this.LastName.CompareTo(other.LastName) != 0)
            {
                this.LastName.CompareTo(other.LastName);
            }
            else if (this.SSN < other.SSN)
            {
                return -1;
            }
            else if (this.SSN > other.SSN)
            {
                return 1;
            }

            return 0;
        }

        // Overriding of operators
        public static bool operator ==(Student st1, Student st2)
        {
            return st1.SSN == st2.SSN;
        }

        public static bool operator !=(Student st1, Student st2)
        {
            return st1.SSN != st2.SSN;
        }
    }
}
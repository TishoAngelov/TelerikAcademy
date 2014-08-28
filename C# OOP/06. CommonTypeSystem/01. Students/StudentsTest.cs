using System;

namespace _01.Students
{
    // Some simple tests (optional)
    public class StudentsTest
    {
        public static void Main()
        {
            Student st1 = new Student("Pesho", "Peshov", "Peshov");
            st1.SSN = 555;
            st1.Specialty = Specialties.spec2;

            Student st2 = st1.Clone() as Student;

            Console.WriteLine("\tOriginal student data\n");
            Console.WriteLine(st1);

            Console.WriteLine("\tCloned student data\n");
            Console.WriteLine(st2);

            Console.WriteLine("st1 == st2 ? - {0}", st1 == st2);
            Console.WriteLine();

            Console.WriteLine("Enter new SSN number for student 2 (different from 555)");
            Console.Write("SSN = ");
            st2.SSN = long.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("st1.CompareTo(st2) - {0}", st1.CompareTo(st2));

            Console.WriteLine();
        }
    }
}

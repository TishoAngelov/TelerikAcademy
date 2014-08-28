using System;
using System.Linq;
using System.Text;

namespace _03_05.StudentsAndLINQ
{
    public class StudentsAndLINQ
    {
        // 03. Write a method that from a given array of students finds all students whose first name is before its last name alphabetically. Use LINQ query operators.
        private static string FirstNameBeforeLast(dynamic[] students)
        {
            StringBuilder result = new StringBuilder();
            int counter = 0;

            var selected =
                from student in students
                where string.Compare(student.FirstName, student.LastName) == -1     // means that the first name is alpabetically lower than the last name
                select student;

            foreach (var student in selected)
            {
                result.Append(string.Format("{0}. {1}, {2}, Age - {3}\n", ++counter, student.FirstName, student.LastName, student.Age));
            }

            return result.ToString();
        }

        // 04. Write a LINQ query that finds the first name and last name of all students with age between 18 and 24.
        private static string AgeBetween18And24(dynamic[] students)
        {
            StringBuilder result = new StringBuilder();
            int counter = 0;

            var selected =
                from student in students
                where (student.Age >= 18 && student.Age <= 24)
                select student;

            foreach (var student in selected)
            {
                result.Append(string.Format("{0}. {1}, {2}, Age - {3}\n", ++counter, student.FirstName, student.LastName, student.Age));
            }

            return result.ToString();
        }

        static void Main()
        {
            var students = new[]
            {
                new {
                    FirstName = "Zoq", LastName = "Ivanova", Age = 17
                },
                new {
                    FirstName = "Dimityr", LastName = "Atanasov", Age = 20
                },
                new {
                    FirstName = "Atanas", LastName = "Zotev", Age = 24
                },
                new {
                    FirstName = "Dimityr", LastName = "Boqnov", Age = 18
                },
                new {
                    FirstName = "Georgi", LastName = "Angelov", Age = 100
                }
            };
            int counter = 0;
            
            // Print all students
            Console.WriteLine("Info for students");
            foreach (var student in students)
            {
                Console.WriteLine("{0}. {1}, {2}, Age - {3}", ++counter, student.FirstName, student.LastName, student.Age);
            }
            Console.WriteLine();

            string selected = FirstNameBeforeLast(students);
            Console.WriteLine("All students whose first name is before its last name alphabetically");
            Console.WriteLine(selected);

            selected = AgeBetween18And24(students);
            Console.WriteLine("First name and last name of all students with age between 18 and 24");
            Console.WriteLine(selected);

            // 05. Using the extension methods OrderBy() and ThenBy() with lambda expressions sort the students by first name and last name in descending order. Rewrite the same with LINQ.
            Console.WriteLine("Sort the students by first name and last name in descending order");

            Console.WriteLine("I. Using lambda expression");
            var orderedStudents = students.OrderByDescending(st => st.FirstName).ThenByDescending(st => st.LastName);
            counter = 0;

            foreach (var student in orderedStudents)
            {
                Console.WriteLine("{0}. {1}, {2}", ++counter, student.FirstName, student.LastName);
            }
            Console.WriteLine();

            Console.WriteLine("II. Using LINQ query");
            counter = 0;

            orderedStudents = 
                from student in students
                orderby student.FirstName descending, 
                        student.LastName descending                
                select student;

            foreach (var student in orderedStudents)
            {
                Console.WriteLine("{0}. {1}, {2}", ++counter, student.FirstName, student.LastName);
            }

            Console.WriteLine();
        }
    }
}
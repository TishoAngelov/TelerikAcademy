using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Humans
{
    public class Tests
    {
        public static void Main()
        {
            // Initialize a list of 10 students and sort them by grade in ascending order (use LINQ or OrderBy() extension method).
            List<Student> students = new List<Student>(10);
            students.Add(new Student("pesho", "peshov 1", 8));
            students.Add(new Student("pesho 8", "peshov 2", 10));
            students.Add(new Student("pesho 9", "peshov 3", 3));
            students.Add(new Student("pesho 7", "peshov 4", 12));
            students.Add(new Student("pesho 5", "peshov 5", 6));
            students.Add(new Student("pesho 6", "peshov 6", 2));
            students.Add(new Student("pesho 4", "peshov 7", 1));
            students.Add(new Student("pesho 2", "peshov 8", 3));
            students.Add(new Student("pesho 3", "peshov 9", 5));
            students.Add(new Student("pesho 1", "peshov", 4));

            var orderedStudents =
                from student in students
                orderby student.Grade ascending
                select student;

            Console.WriteLine("========== STUDENTS ==========\n");
            foreach (var student in orderedStudents)
            {
                Console.WriteLine(student);
            }

            Console.WriteLine();
            Console.WriteLine();

            // Initialize a list of 10 workers and sort them by money per hour in descending order.
            List<Worker> workers = new List<Worker>(10);
            workers.Add(new Worker("Ivan", "Petkov 1", 3215, 2));
            workers.Add(new Worker("Ivan 6", "Petkov 2", 100, 12));
            workers.Add(new Worker("Ivan 9", "Petkov 3", 550, 8));
            workers.Add(new Worker("Ivan 4", "Petkov 4", 800, 8));
            workers.Add(new Worker("Ivan 5", "Petkov 5", 600, 10));
            workers.Add(new Worker("Ivan 2", "Petkov 6", 2512, 1));
            workers.Add(new Worker("Ivan 7", "Petkov 7", 1000, 6));
            workers.Add(new Worker("Ivan 8", "Petkov 8", 990, 7));
            workers.Add(new Worker("Ivan 3", "Petkov 9", 600, 8));
            workers.Add(new Worker("Ivan 1", "Petkov", 250, 6));

            var orderedWorkers = workers.OrderByDescending(worker => worker.MoneyPerHour());

            Console.WriteLine("========== WORKERS ==========\n");
            foreach (var worker in orderedWorkers)
            {
                Console.WriteLine(worker);
            }
            
            Console.WriteLine();
            Console.WriteLine();

            // Merge the lists and sort them by first name and last name. (It's not specified which list has to be merged - original or sorted.)
            List<Human> merged = new List<Human>(20);

            merged.AddRange(students);
            merged.AddRange(workers);

            var mergedByName =
                from human in merged
                orderby human.FirstName ascending, human.LastName ascending
                select human;

            Console.WriteLine("========== Merge the lists and sort them by first name and last name. ==========");
            foreach (var human in mergedByName)
            {
                Console.WriteLine(human);
            }

            Console.WriteLine();
        }
    }
}
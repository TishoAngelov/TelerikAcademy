using System;

namespace MyList
{
    class GenericListTEST
    {
        // Some simple tests. They are OPTINAL.
        public static void Main()
        {
            // Create an integer list and add few elements. Also prints the size after each add.
            GenericList<int> list1 = new GenericList<int>(1);

            Console.WriteLine("Type of the list: {0}", list1.GetType());
            Console.WriteLine();

            Console.WriteLine("Current size of the list: {0}", list1.Size);
            Console.WriteLine("Current count of the elements in the list: {0}", list1.Count);
            Console.WriteLine("Adding 1 element...");
            list1.Add(1);
            Console.WriteLine("Current elements in the list:\n{0}", list1.ToString());

            Console.WriteLine("Current size of the list: {0}", list1.Size);
            Console.WriteLine("Current count of the elements in the list: {0}", list1.Count);
            Console.WriteLine("Adding 1 element...");
            list1.Add(2);
            Console.WriteLine("Current elements in the list:\n{0}", list1.ToString());

            Console.WriteLine("Current size of the list: {0}", list1.Size);
            Console.WriteLine("Current count of the elements in the list: {0}", list1.Count);
            Console.WriteLine("Adding 1 element...");
            list1.Add(3);
            Console.WriteLine("Current elements in the list:\n{0}", list1.ToString());

            Console.WriteLine("Current size of the list: {0}", list1.Size);
            Console.WriteLine("Current count of the elements in the list: {0}", list1.Count);
            Console.WriteLine();

            // Print the maximal element
            Console.WriteLine("Maximal element:");
            Console.WriteLine(list1.Max());
            Console.WriteLine();

            // Print an element by it's index
            Console.WriteLine("Printing the element at position 1 (starting from 0):\n{0}", list1[1].ToString());
            Console.WriteLine();

            // Remove an element by it's index
            Console.WriteLine("Removing the element at position 1 (starting from 0)\nand printing the result:");
            list1.RemoveAtIndex(1);

            Console.WriteLine();
            Console.WriteLine("Current size of the list: {0}", list1.Size);
            Console.WriteLine("Current count of the elements in the list: {0}", list1.Count);
            Console.WriteLine("Current elements in the list:\n{0}", list1.ToString());
            Console.WriteLine();

            // Clearing the list (the size won't change)
            Console.WriteLine("Clearing the list...");
            list1.Clear();
            Console.WriteLine("Current size of the list: {0}", list1.Size);
            Console.WriteLine("Current count of the elements in the list: {0}", list1.Count);
            Console.WriteLine("Current elements in the list:\n{0}", list1.ToString());
            Console.WriteLine();
            
            // Inserting an element at position 0. This will throw an exeption
            // because you can't use InsertAtIndex for empty list.
            Console.WriteLine("Exception will be thrown now...");
            list1.InsertAtIndex(0, 5);
        }
    }
}

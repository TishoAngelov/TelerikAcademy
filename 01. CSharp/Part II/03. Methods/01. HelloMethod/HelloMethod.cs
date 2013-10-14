using System;

class HelloMethod
{
    // Write a method that asks the user for his name and prints “Hello, <name>”
    // (for example, “Hello, Peter!”). Write a program to test this method.

    static void HelloUser()
    {
        Console.WriteLine("ME:  What is your name?\n");

        Console.Write("YOU:  ");
        string userName = Console.ReadLine();
        Console.WriteLine();

        Console.WriteLine("ME:  Hello, {0}!", userName);
    }

    static void Main()
    {
        HelloUser();

        Console.WriteLine();
    }
}
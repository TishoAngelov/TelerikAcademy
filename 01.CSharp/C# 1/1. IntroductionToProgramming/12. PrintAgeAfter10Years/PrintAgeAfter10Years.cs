/*
Write a program to read your age from the 
console and print how old you will be after 10 years.
*/

using System;

class PrintAgeAfter10Years
{
    static void Main()
    {
        int yourAge;
        int ageAfter10Years;

        Console.Write("Please write your age: ");
        yourAge = int.Parse(Console.ReadLine());
        ageAfter10Years = yourAge + 10;
        Console.WriteLine("After 10 years you will be " + ageAfter10Years + " years old!");
    }
}
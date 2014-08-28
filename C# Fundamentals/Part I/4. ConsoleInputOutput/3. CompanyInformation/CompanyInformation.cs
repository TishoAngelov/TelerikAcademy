using System;

class CompanyInformation
{
    // A company has name, address, phone number, fax number, web site and manager.
    // The manager has first name, last name, age and a phone number. Write a program
    // that reads the information about a company and its manager and prints them on the console.

    static void Main()
    {
        Console.Write("Enter company name: ");
        string companyName = Console.ReadLine();
        Console.Write("Enter company adress: ");
        string companyAddress = Console.ReadLine();
        Console.Write("Enter company phone number: ");
        long? companyPhoneNumber = long.Parse(Console.ReadLine());
        Console.Write("Enter company fax number: ");
        long? companyFaxNumber = long.Parse(Console.ReadLine());
        Console.Write("Enter company web site: ");
        string companyWebSite = Console.ReadLine();
        Console.Write("Enter company manager: ");
        string companyManager = Console.ReadLine();

        Console.WriteLine("{0}Enter information about the manager:", Environment.NewLine);
        Console.Write("First name: ");
        string companyManagerFirstName = Console.ReadLine();
        Console.Write("Last name: ");
        string companyManagerLastName = Console.ReadLine();
        Console.Write("Age: ");
        byte? companyManagerAge = byte.Parse(Console.ReadLine());
        Console.Write("Phone number: ");
        long? companyManagerPhoneNumber = long.Parse(Console.ReadLine());

        Console.Clear();
        Console.WriteLine("You have entered the following information about the company:");
        Console.WriteLine("Name: {0}" + 
                          "\nAdress: {1}" + 
                          "\nPhone number: {2}" +
                          "\nFax number: {3}" +
                          "\nWeb site: {4}" +
                          "\nManager: {5}", companyName, companyAddress, companyPhoneNumber,
                          companyFaxNumber, companyWebSite, companyManager);
        Console.WriteLine("{0}You have entered a manager for this company:", Environment.NewLine);
        Console.WriteLine("First name: {0}" +
                          "\nLast name: {1}" +
                          "\nAge: {2}" +
                          "\nPhone number: {3}", companyManagerFirstName, companyManagerLastName,
                          companyManagerAge, companyManagerPhoneNumber);
        Console.WriteLine();
    }
}
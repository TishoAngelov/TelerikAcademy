using System;

class PrimeNumbers
{
    // Write an expression that checks if given positive integer number n (n ≤ 100) is prime. E.g. 37 is prime.

    static void Main()
    {
        int intNum = 0;
        string isItPrime = "";
        bool primeUnderTen = false;
        bool primeOverTen = false;
        bool isNumInLimits = false;
        string numOutOfLimits = "";

        do
        {
            Console.WriteLine("----- For exit enter \"0\" -----");
            Console.Write("Please enter 1 number in the limit (0 < n <= 100): ");
            intNum = int.Parse(Console.ReadLine());
            isNumInLimits = (intNum > 0) && (intNum <= 100);
            numOutOfLimits = isNumInLimits == true ? "" : "\rThe number is out of the limit (0 < n <= 100)!!! Please pay attention!";
            primeUnderTen = (intNum == 1) || (intNum == 2) || (intNum == 3) || (intNum == 5) || (intNum == 7);
            primeOverTen = (intNum % 2 != 0) && (intNum % 3 != 0) && (intNum % 5 != 0) && (intNum % 7 != 0);
            isItPrime = primeUnderTen || primeOverTen ? "is" : "is not";
            Console.WriteLine("The number {0} {1} prime!{2}", intNum, isItPrime, numOutOfLimits);            
        } while (intNum != 0);
        Console.WriteLine();
    }
}
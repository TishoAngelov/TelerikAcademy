using System;

class AssignIntVarWithHexFormat
{
    /*
    Declare an integer variable and assign it with the value 
    254 in hexadecimal format. Use Windows Calculator to 
    find its hexadecimal representation.
    */

    static void Main()
    {
        int variable = 0xFE;

        Console.WriteLine("The hexadecimal format of the number is \"FE\".");
        System.Threading.Thread.Sleep(2000); 
        Console.WriteLine("Can you guess what is the number???\n. . .");
        System.Threading.Thread.Sleep(3500);
        Console.WriteLine("The number is: {0}! :)\n\n", variable);
    }
}
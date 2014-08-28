using System;

class ExchangeDefinedBits
{
    // * Write a program that exchanges bits {p, p+1, …, p+k-1) with
    // bits {q, q+1, …, q+k-1} of given 32-bit unsigned integer.

    static void Main()
    {
        uint uintNum = 0; // Number > 0
        uint mask = 0;
        int howMuchBits = 0;
        uint lowBitsValues = 0;
        uint highBitsValues = 0;
        int lowBitsSet_StartPosition = 0;       // The start position of a
        int highBitsSet_StartPosition = 0;      // set from bits.
        int lowBitsSet_EndPosition = 0;
        int highBitsSet_EndPosition = 0;
        bool bitsCountIsCorrect = false;
        bool bitPositionsAreCorrect = false;

        Console.Write("Enter 1 number: ");
        uintNum = uint.Parse(Console.ReadLine());
        
        // Choose how much bits you want to exchange (do it until its correct)
        do
        {
            Console.Write("Enter how much bits you want to exchange: ");
            howMuchBits = int.Parse(Console.ReadLine());

            // Check if bit count for exchange is correct
            if ((howMuchBits < 1) || (howMuchBits > 16))
            {
                Console.WriteLine("{0}You have entered wrong bit count!!!", Environment.NewLine);
                Console.WriteLine("The count must meet the CONDITIONS:");
                Console.WriteLine("\t1. You can't exchange 0 bits or less");
                Console.WriteLine("\t2. You can't exchange more than 16 {0}", Environment.NewLine);
            }
            else
            {
                bitsCountIsCorrect = true;
            }
            // End of check

        } 
        while (bitsCountIsCorrect == false);

        // Choose bits positions (do it until they are correct)
        do
        {            
            Console.WriteLine("Define which bit values you want to exchange:");
            Console.Write("Enter the start position of the lower bits: ");

            lowBitsSet_StartPosition = int.Parse(Console.ReadLine());
            lowBitsSet_EndPosition = lowBitsSet_StartPosition + howMuchBits - 1;

            Console.Write("Enter the start position of the higher bits: ");
            highBitsSet_StartPosition = int.Parse(Console.ReadLine());
            highBitsSet_EndPosition = highBitsSet_StartPosition + howMuchBits - 1;

            // Check if positions will break the program
            if (((lowBitsSet_StartPosition + howMuchBits) > highBitsSet_StartPosition) || 
                (lowBitsSet_StartPosition < 0) || (highBitsSet_StartPosition < lowBitsSet_EndPosition) ||
                (highBitsSet_StartPosition > 16))                
            {
                Console.WriteLine("{0}You have entered wrong bits positions!!!", Environment.NewLine);
                Console.WriteLine("Positions must meet the CONDITIONS:");
                Console.WriteLine("\t1. Lower position + {0} <= Higher position", howMuchBits);
                Console.WriteLine("\t2. Lower position >= 0");
                Console.WriteLine("\t3. Higer positions <= 29");
                Console.WriteLine("\t4. You can't exchange more than 15 or less than 1 bits {0}", Environment.NewLine);
            }
            else
            {
                bitPositionsAreCorrect = true;
            }
            // End of check

        } 
        while (bitPositionsAreCorrect == false);

        Console.WriteLine("{0}Binary code of the number: {1}", Environment.NewLine, Convert.ToString(uintNum, 2).PadLeft(32, '0'));
        Console.WriteLine("Take a look at those bits: {0}{1}{2}{3}",                    // To see easly which 
            new string(' ', 31 - highBitsSet_EndPosition),                              // bits are going
            new string('^', howMuchBits),                                               // to be exchanged
            new string(' ', highBitsSet_StartPosition - lowBitsSet_EndPosition - 1), 
            new string('^', howMuchBits)); 

        // Extract the lower bits
        mask = (uint)(Convert.ToUInt32(new string('1', howMuchBits), 2) << lowBitsSet_StartPosition);    // Move the mask to the bit values that you want to extract   
        lowBitsValues = (uintNum & mask) >> lowBitsSet_StartPosition;   // Extract the bit values
        uintNum = uintNum & ~mask;                                      // Set the extracted bit values of the number to 0

        // Extract the higher bits
        mask = (uint)(Convert.ToUInt32(new string('1', howMuchBits), 2) << highBitsSet_StartPosition);  // Move the mask to the bit values that you want to extract
        highBitsValues = (uintNum & mask) >> highBitsSet_StartPosition;     // Extract the bit values
        uintNum = uintNum & ~mask;                                          // Set the extracted bit values of the number to 0

        Console.WriteLine("{0}Values of the extracted lower bits: {1}", Environment.NewLine,
            Convert.ToString(lowBitsValues, 2).PadLeft(howMuchBits, '0'));
        Console.WriteLine("Values of the extracted higher bits: {0}",
            Convert.ToString(highBitsValues, 2).PadLeft(howMuchBits, '0'));

        // Exchange the lower and higher bit values in the number (uintNum)
        highBitsValues = highBitsValues << lowBitsSet_StartPosition;        // Move the high bits to the position of the low bits
        lowBitsValues = lowBitsValues << highBitsSet_StartPosition;         // Move the low bits to the position of the high bits  
        uintNum = (uintNum | lowBitsValues) | highBitsValues;               // Replace the number bits with the exchanged bits

        Console.WriteLine("{0}The number after exchanging it's bits: ", Environment.NewLine);
        Console.WriteLine("New number (decimal): {0}", uintNum);
        Console.WriteLine("New number (binary) : {0}", Convert.ToString(uintNum, 2).PadLeft(32, '0'));
        Console.WriteLine("They are exchanged! : {0}{1}{2}{3}",                         // To see easly which 
            new string(' ', 31 - highBitsSet_EndPosition),                              // bits are going
            new string('^', howMuchBits),                                               // to be exchanged
            new string(' ', highBitsSet_StartPosition - lowBitsSet_EndPosition - 1),
            new string('^', howMuchBits));
        Console.WriteLine();         
    }
}
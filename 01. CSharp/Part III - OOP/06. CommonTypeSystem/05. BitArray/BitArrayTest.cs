using System;

namespace _05.BitArray
{
    public class BitArrayTest
    {
        public static void Main()
        {
            Console.Write("Enter a number: ");
            ulong number = ulong.Parse(Console.ReadLine());

            BitArray64 bitsOfNumber = new BitArray64(number);

            Console.WriteLine();

            Console.WriteLine(".ToString() method of the class BitArray64:\n{0}", bitsOfNumber);
            Console.WriteLine();

            Console.WriteLine("Bits of the number(got by foreach):");
            foreach (var bit in bitsOfNumber)
            {
                Console.Write("{0}", bit);
            }

            Console.WriteLine("\n");

            // The bits index started from 0 (right to the left on the previous lines)
            Console.WriteLine("Bit[3] = {0}", bitsOfNumber[3]);

            Console.WriteLine("\nHash code of the number {0} is {1}", bitsOfNumber.DecimalNumber, bitsOfNumber.GetHashCode());

            Console.WriteLine();
        }
    }
}

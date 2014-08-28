using System;

class FloatNumToBinary
{
    /*
        * Write a program that shows the internal binary representation of
         given 32-bit signed floating-point number in IEEE 754 format 
         (the C# type float).
            Example: 
            -27,25 -> sign = 1, exponent = 10000011, mantissa = 10110100000000000000000.
    */

    static int GetLeftSide(byte mask)
    {
        return (mask >> 4);
    }

    static int GetRightSide(byte mask)
    {
        return (mask & 15);
    }

    static string SideToBin(int mask)
    {
        string result = "";

        for (int i = 3; i >= 0; --i)
        {
            result += (mask >> i) & 1;
        }

        return result;
    }

    static string FloatToBinNum(float floatNum)
    {
        string result = "";
        byte[] floatBytes = BitConverter.GetBytes(floatNum);

        for (int i = 3; i >= 0; --i)
        {
            result += SideToBin(GetLeftSide(floatBytes[i]));
            result += SideToBin(GetRightSide(floatBytes[i]));
        }

        return result;
    }

    static void Main()
    {
        Console.WriteLine("Enter one number with floating point (float type)");
        Console.Write("Float number = ");
        float floatNum = float.Parse(Console.ReadLine());

        string floatNumToBin = FloatToBinNum(floatNum);
        char sign = '+';
      
        if (floatNumToBin[0] == '1')
        {
            sign = '-';
        }

        Console.WriteLine("\nBinary representation");
        Console.WriteLine(new string('=', 60));

        Console.WriteLine("{0}(10) = {1}(2)", floatNum, floatNumToBin);
        Console.WriteLine("Sign: {0} ({1})", floatNumToBin[0], sign);
        Console.WriteLine("Exponent: {0}", floatNumToBin.Substring(1, 8));
        Console.WriteLine("Mantissa: {0}", floatNumToBin.Substring(9));
        Console.WriteLine();
    }
}

﻿using System;

class BonusScores
{
    /*
    Write a program that applies bonus scores to given scores in the range [1..9]. The program
    reads a digit as an input. If the digit is between 1 and 3, the program multiplies it by 10;
    if it is between 4 and 6, multiplies it by 100; if it is between 7 and 9, multiplies it by 1000.
    If it is zero or if the value is not a digit, the program must report an error.
		*Use a switch statement and at the end print the calculated new value in the console.
    */

    static void Main()
    {
        Console.Write("Please enter a score in the range 1-9: ");
        int score = int.Parse(Console.ReadLine());        

        if (score > 0 && score < 10)
        {
            int bonusScore = 0;

            switch (score)
            {
                case 1:
                case 2:
                case 3:
                    bonusScore = score * 10;
                    break;
                case 4:
                case 5:
                case 6:
                    bonusScore = score * 100;
                    break;
                case 7:
                case 8:
                case 9:
                    bonusScore = score * 1000;
                    break;                
            }
            Console.WriteLine("Score: {0}", score);
            Console.WriteLine("Bonus score: {0}", bonusScore);
        }
        else
        {
            Console.WriteLine("Error! The digit should be between 1 and 9!");
        } 
        Console.WriteLine();
    }
}
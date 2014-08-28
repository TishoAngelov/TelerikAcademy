using System;

class NumbersToText
{
    /*
    * Write a program that converts a number in the range [0...999] to a text
    corresponding to its English pronunciation. Examples:
	0 -> "Zero"
	273 -> "Two hundred seventy three"
	400 -> "Four hundred"
	501 -> "Five hundred and one"
	711 -> "Seven hundred and eleven"
    */

    static void Main()
    {
        Console.Write("Enter a number between 0 and 999: ");
        int intNum = int.Parse(Console.ReadLine());
        int tempNum = intNum;

        string hundreds = "";
        string tens = "";
        string units = "";

        bool hasHundreds = true;
        bool hasTens = true;
        bool hasTensLessThanTwo = false;

        switch (tempNum / 100)
        {
            case 1:
                hundreds = "One hundred";
                tempNum -= 100;
                break;
            case 2:
                hundreds = "Two hundred";
                tempNum -= 200;
                break;
            case 3:
                hundreds = "Three hundred";
                tempNum -= 300;
                break;
            case 4:
                hundreds = "Four hundred";
                tempNum -= 400;
                break;
            case 5:
                hundreds = "Five hundred";
                tempNum -= 500;
                break;
            case 6:
                hundreds = "Six hundred";
                tempNum -= 600;
                break;
            case 7:
                hundreds = "Seven hundred";
                tempNum -= 700;
                break;
            case 8:
                hundreds = "Eight hundred";
                tempNum -= 800;
                break;
            case 9:
                hundreds = "Nine hundred";
                tempNum -= 900;
                break;
            default:
                hasHundreds = false;
                break;
        }

        switch (tempNum / 10)
        {
            case 0:
                if (hasHundreds == true && tempNum != 0)
                {
                    hundreds += " and";
                }
                hasTens = false;
                break;
            case 1:
                hasTensLessThanTwo = true;
                if (hasHundreds == true && tempNum != 0)
                {
                    hundreds += " and";
                }
                tempNum -= 10;

                switch (tempNum)
                {
                    case 0:
                        tens = "ten";
                        break;
                    case 1:
                        tens = "eleven";
                        break;
                    case 2:
                        tens = "twelve";
                        break;
                    case 3:
                        tens = "thirteen";
                        break;
                    case 4:
                        tens = "fourteen";
                        break;
                    case 5:
                        tens = "fifteen";
                        break;
                    case 6:
                        tens = "sixteen";
                        break;
                    case 7:
                        tens = "seventeen";
                        break;
                    case 8:
                        tens = "eighteen";
                        break;
                    case 9:
                        tens = "nineteen";
                        break;
                }
                break;
            case 2:
                tens = "twenty";
                tempNum -= 20;
                break;
            case 3:
                tens += "thirty";
                tempNum -= 30;
                break;
            case 4:
                tens += "fourty";
                tempNum -= 40;
                break;
            case 5:
                tens += "fifty";
                tempNum -= 50;
                break;
            case 6:
                tens += "sixty";
                tempNum -= 60;
                break;
            case 7:
                tens += "seventy";
                tempNum -= 70;
                break;
            case 8:
                tens += "eighty";
                tempNum -= 80;
                break;
            case 9:
                tens += "ninety";
                tempNum -= 90;
                break;
            default:
                hasTens = false;
                break;
        }

        if (hasTensLessThanTwo == false)
        {
            switch (tempNum)
            {
                case 0:
                    if (hasHundreds == false && hasTens == false)
                    {
                        units = "Zero";
                    }
                    break;
                case 1:
                    units = "one";
                    break;
                case 2:
                    units = "two";
                    break;
                case 3:
                    units = "three";
                    break;
                case 4:
                    units = "four";
                    break;
                case 5:
                    units = "five";
                    break;
                case 6:
                    units = "six";
                    break;
                case 7:
                    units = "seven";
                    break;
                case 8:
                    units = "eight";
                    break;
                case 9:
                    units = "nine";
                    break;
            }
        }

        Console.WriteLine("{0} - {1} {2} {3}", intNum, hundreds, tens, units);
        Console.WriteLine();
    }
}
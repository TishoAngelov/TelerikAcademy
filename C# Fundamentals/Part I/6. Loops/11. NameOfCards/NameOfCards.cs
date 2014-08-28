using System;

class NameOfCards
{
    // Write a program that prints all possible cards from a standard deck of 52 cards (without jokers).
    // The cards should be printed with their English names. Use nested for loops and switch-case.

    static void Main()
    {
        string cardSuit = "";
        string cardRank = "";
        int cardCounter = 0;

        Console.WriteLine("One standart deck of 52 cards has:");
        for (int i = 1; i <= 4; i++)
        {
            Console.WriteLine();
            switch (i)
            {
                case 1 :
                    cardSuit = " of Black Clubs";
                    break;
                case 2 :
                    cardSuit = " of Red Diamonds";
                    break;
                case 3 :
                    cardSuit = " of Red Hearts";
                    break;
                case 4 :
                    cardSuit = " of Black Spades";
                    break;                
            }

            for (int j = 2; j <= 14; j++)
            {
                cardCounter++;

                switch (j)
                {                    
                    case 2 :
                        cardRank = "Deuce";
                        break;
                    case 3 :
                        cardRank = "Three";
                        break;
                    case 4 :
                        cardRank = "Four";
                        break;
                    case 5 :
                        cardRank = "Five";
                        break;
                    case 6 :
                        cardRank = "Six";
                        break;
                    case 7 :
                        cardRank = "Seven";
                        break;
                    case 8 :
                        cardRank = "Eight";
                        break;
                    case 9 :
                        cardRank = "Nine";
                        break;
                    case 10 :
                        cardRank = "Ten";
                        break;
                    case 11 :
                        cardRank = "Jack";
                        break;
                    case 12 :
                        cardRank = "Queen";
                        break;
                    case 13 :
                        cardRank = "King";
                        break;
                    case 14:
                        cardRank = "Ace";
                        break;
                }

                Console.WriteLine(cardCounter + ". " + cardRank + cardSuit);
            }            
        }

        Console.WriteLine();
    }
}
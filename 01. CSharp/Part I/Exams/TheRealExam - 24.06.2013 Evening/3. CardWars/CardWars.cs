using System;

class CardWars
{

    public static int NormalCardsChoose(string cardType)
    {
        int cardPoints = 0;

        switch (cardType)
                {
                    case "2":
                        cardPoints = 10;
                        break;
                    case "3":
                        cardPoints = 9;
                        break;
                    case "4":
                        cardPoints = 8;
                        break;
                    case "5":
                        cardPoints = 7;
                        break;
                    case "6":
                        cardPoints = 6;
                        break;
                    case "7":
                        cardPoints = 5;
                        break;
                    case "8":
                        cardPoints = 4;
                        break;
                    case "9":
                        cardPoints = 3;
                        break;
                    case "10":
                        cardPoints = 2;
                        break;
                    case "A":
                        cardPoints = 1;
                        break;
                    case "J":
                        cardPoints = 11;
                        break;
                    case "Q":
                        cardPoints = 12;
                        break;
                    case "K":
                        cardPoints = 13;
                        break;
        }
        return cardPoints;
    }

    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int handPesho = 0;
        int peshoScore = 0;

        int handGosho = 0;
        int goshoScore = 0;

        bool peshoDraw = false;
        bool goshoDraw = false;
        string card = "";

        int peshoWon = 0;
        int goshoWon = 0;

        bool peshoDrawX = false;
        bool goshoDrawX = false;

        int X = 0;
        int Y = 0;
        int Z = 0;

        for (int i = 1; i <= N; i++)
        {
            peshoDrawX = false;
            goshoDrawX = false;

            for (int j = 1; j <= 6; j++)
            {
                Z = 0;
                X = 0;
                Y = 0;

                if (j <= 3)
                {
                    peshoDraw = true;
                    goshoDraw = false;

                    card = Console.ReadLine();

                    if (!(card.Equals("Z") || card.Equals("Y") || card.Equals("X")))
                    {
                        handPesho += NormalCardsChoose(card);
                    }
                    else
                    {
                        if (card.Equals("Z"))
                        {
                            Z++;
                            if (Z == 1)
                            {
                                peshoScore *= 2;
                            }

                            if (Z == 2)
                            {
                                peshoScore *= 2;
                            }
                            if (Z == 3)
                            {
                                peshoScore *= 4;
                            }                
                        }
                        if (card.Equals("Y"))
                        {
                            Y++;

                            if (Y == 1)
                            {
                                peshoScore -= 200;
                            }
                            if (Y == 2)
                            {
                                peshoScore -= 200;
                            }
                            if (Y == 3)
                            {
                                peshoScore -= 200;
                            }
                            
                        }
                        if (card.Equals("X"))
                        {
                            peshoDrawX = true;
                        }
                    }
                    

                }
                else
                {
                    peshoDraw = false;
                    goshoDraw = true;

                    card = Console.ReadLine();

                    if (!(card.Equals("Z") || card.Equals("Y") || card.Equals("X")))
                    {
                        handGosho += NormalCardsChoose(card);
                    }
                    else
                    {
                        if (card.Equals("Z"))
                        {
                            Z++;
                            if (Z == 1)
                            {
                                goshoScore *= 2;
                            }

                            if (Z == 2)
                            {
                                goshoScore *= 2;
                            }
                            if (Z == 3)
                            {
                                goshoScore *= 4;
                            }
                            
                        }
                        if (card.Equals("Y"))
                        {
                            Y++;

                            if (Y == 1)
                            {
                                goshoScore -= 200;
                            }
                            if (Y == 2)
                            {
                                goshoScore -= 200;
                            }
                            if (Y == 3)
                            {
                                goshoScore -= 200;
                            }
                        }
                        if (card.Equals("X"))
                        {
                            goshoDrawX = true;
                        }
                    }
                }
                
            }

            // proverka za rycete

            if (peshoDrawX == true ^ goshoDrawX == true)
            {
                if (peshoDrawX == true && goshoDrawX == false)
                {
                    Console.WriteLine("X card drawn! Player one wins the match!");
                    peshoWon++;
                }
                if (peshoDrawX == false && goshoDrawX == true)
                {
                    Console.WriteLine("X card drawn! Player two wins the match!");
                    goshoWon++;
                }
                
            }
            else
            {
                if (peshoDrawX == true && goshoDrawX == true)
                {
                  //  i--;
                    peshoScore += 50;
                    goshoScore += 50;
                }

                if (handGosho == handPesho)
                {

                }
                else if (handGosho > handPesho)
                {
                    goshoScore += handGosho;
                }
                else
                {
                    peshoScore += handPesho;
                }

                if (peshoScore > goshoScore)
                {
                    peshoWon++;
                    if (i == N)
                    {
                        Console.WriteLine("First player wins!");
                        Console.WriteLine("Score: {0}", peshoScore);
                        Console.WriteLine("Games won: {0}", peshoWon);
                    }

                }
                else if (peshoScore < goshoScore)
                {
                    goshoWon++;


                    if (i == N)
                    {
                        Console.WriteLine("Second player wins!");
                        Console.WriteLine("Score: {0}", goshoScore);
                        Console.WriteLine("Games won: {0}", goshoWon);
                    }
                }
                else
                {
                    if (i == N)
                    {
                        Console.WriteLine("It's a tie!");
                        Console.WriteLine("Score: {0}", peshoScore);
                    }
                }
                handPesho = 0;
                handGosho = 0;
            }
        }
    }
}
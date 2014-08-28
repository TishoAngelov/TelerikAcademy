namespace RefactorIfStatements
{
    using System;

    public class Program
    {
        private const int MinX = 5;
        private const int MaxX = 10;

        private const int MinY = 7;
        private const int MaxY = 15;

        public static void Main()
        {
            // First if statement
            Potato potato = null;
            bool hasPotato = false;

            // ... 
            if (hasPotato)
            {
                Cook(potato);
            }
            else
            {
                // throw out of potato exception
            }

            // Second if statement
            int x = 0;
            int y = 0;
            bool shouldVisitCell = false;

            bool isInRangeX = MinX <= x && x <= MaxX;
            bool isInRangeY = MinY <= y && y <= MaxY;

            bool isPointInRange = isInRangeX && isInRangeY;

            if (shouldVisitCell && isPointInRange)
            {
                VisitCell();
            }
        }

        private static void Cook(Potato potato)
        {
            bool canBeCooked = potato.IsPeeled && !potato.IsRotten;
            if (!canBeCooked)
            {
                // throw trash potato exception
            }

            // continiue cooking
        }

        private static void VisitCell()
        {
            // some code
        }
    }
}

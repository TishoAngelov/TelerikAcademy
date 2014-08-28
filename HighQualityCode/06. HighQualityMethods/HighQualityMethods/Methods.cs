namespace HighQualityMethods
{
    using System;

    public class Methods
    {
        static double CalculateTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("Sides should be positive.");
            }

            if (a + b <= c || a + c <= b || b + c <= a)
            {
                throw new ArgumentException("Invalid triangle.");   
            }

            double p = (a + b + c) / 2;
            double area = Math.Sqrt(p * (p - a) * (p - b) * (p - c));

            return area;
        }

        static string DigitToWord(int digit)
        {
            switch (digit)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                default: throw new ArgumentException("Invalid digit!");
            }            
        }

        static int FindMax(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentException("Elements cannot be null or empty.");
            }

            int maxElement = elements[0];
            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > maxElement)
                {
                    maxElement = elements[i];
                }
            }

            return maxElement;
        }

        private static bool IsNumber(object obj)
        {
            bool isNumber = true;

            // Some code

            return isNumber;
        }

        static void PrintNumberInFormat(object number, Format format)
        {
            if (!IsNumber(number))
            {
                throw new ArgumentException("Invalid number.");
            }

            string result = string.Empty;
            switch (format)
            {
                case Format.Float:
                    result = string.Format("{0:f2}", number);
                    break;
                case Format.Percentage:
                    result = string.Format("{0:p0}", number);
                    break;
                case Format.RightAligned:
                    result = string.Format("{0,8}", number);
                    break;
                default:
                    throw new ArgumentException("Invalid format type.");
            }

            Console.WriteLine(result);
        }
        
        static double CalculateDistanceBetweenTwoPoints(double x1, double y1, double x2, double y2)
        {
            double xd = x2 - x1;
            double yd = y2 - y1;
            double distance = Math.Sqrt(xd * xd + yd * yd);

            return distance;
        }

        static bool IsLineHorizontal(double startY, double endY)
        {
            return startY == endY;
        }

        static bool IsLineVertical(double startX, double endX)
        {
            return startX == endX;
        }

        public static void Main()
        {
            Console.WriteLine(CalculateTriangleArea(3, 4, 5));
            
            Console.WriteLine(DigitToWord(5));
            
            Console.WriteLine(FindMax(5, -1, 3, 2, 14, 2, 3));
            
            PrintNumberInFormat(1.3, Format.Float);
            PrintNumberInFormat(0.75, Format.Percentage);
            PrintNumberInFormat(2.30, Format.RightAligned);

            double firstPointX = 3;
            double firstPointY = -1;
            double secondPointX = 3;
            double secondPointY = 2.5;

            Console.WriteLine(CalculateDistanceBetweenTwoPoints(firstPointX, firstPointY, secondPointX, secondPointY));
            Console.WriteLine("Horizontal? {0}", IsLineHorizontal(firstPointY, secondPointY));
            Console.WriteLine("Vertical? {0}", IsLineVertical(firstPointX, secondPointX));

            Student peter = new Student("Peter", "Ivanov", new DateTime(1992, 3, 17));
            peter.OtherInfo = "From Sofia";

            Student stella = new Student("Stella", "Markova", new DateTime(1993, 11, 3));
            stella.OtherInfo = "From Vidin, gamer, high results";

            Console.WriteLine("{0} older than {1} -> {2}",
                peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}

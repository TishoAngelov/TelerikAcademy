using System;

namespace _07.DelegatesAndTimer
{
    class TimerTest
    {
        // Any method
        private static void TestMethod()
        {
            Console.WriteLine("Method called.");
            Console.WriteLine();
        }

        public static void Main()
        {
            int seconds = 2;

            Console.WriteLine("The program will start soon...");
            Console.WriteLine();

            Timer t = new Timer();
            t.Start(TestMethod, seconds);
        }
    }
}
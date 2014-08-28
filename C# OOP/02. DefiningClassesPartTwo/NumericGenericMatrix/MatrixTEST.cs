using System;

namespace NumericGenericMatrix
{
    class MatrixTEST
    {
        public static void Main()
        {
            Matrix<int> m1 = new Matrix<int>(2, 2);
            Matrix<int> m2 = new Matrix<int>(2, 2);

            for (int i = 0; i < m1.Rows; i++)
            {
                for (int j = 0; j < m1.Cols; j++)
                {
                    m1[i, j] = 1;
                    m2[i, j] = 2;
                }
            }

            Console.WriteLine("Matrix 1:\n{0}", m1);
            Console.WriteLine();
            Console.WriteLine("Matrix 2:\n{0}", m2);
            Console.WriteLine();

            Matrix<int> m3 = m1 - m2;
            Console.WriteLine("Difference:\n{0}", m3);
            Console.WriteLine();

            Matrix<int> m4 = m1 + m2;
            Console.WriteLine("Sum:\n{0}", m4);
            Console.WriteLine();

            Matrix<int> m5 = m1 * m2;
            Console.WriteLine("Product:\n{0}", m5);
            Console.WriteLine();
        }
    }
}
using System;

namespace NumericGenericMatrix
{
    public class Matrix<T>
    {
        // Fields
        private readonly T[,] matrix;
        private readonly int rows;
        private readonly int cols;

        // Properties
        public int Rows
        {
            get { return this.rows; }
        }

        public int Cols
        {
            get { return this.cols; }
        }

        public T this[int row, int col]     // Indexer
        {
            get { return this.matrix[row, col]; }
            set { this.matrix[row, col] = value; }
        }

        // Constructors
        public Matrix(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;

            this.matrix = new T[this.rows, this.cols];
        }

        // Methods
        public static Matrix<T> operator +(Matrix<T> m1, Matrix<T> m2)
        {
            if (!(m1.rows == m2.rows && m1.cols == m2.cols))
            {
                throw new ArgumentException("The rows and columns of the both matrix must be the same!");
            }

            Matrix<T> m3 = new Matrix<T>(m1.rows, m1.cols);

            for (int row = 0; row < m1.rows; row++)
            {
                for (int col = 0; col < m1.cols; col++)
                {
                    m3[row, col] = (dynamic)m1[row, col] + (dynamic)m2[row, col];
                }
            }

            return m3;
        }

        public static Matrix<T> operator -(Matrix<T> m1, Matrix<T> m2)
        {
            if (!(m1.rows == m2.rows && m1.cols == m2.cols))
            {
                throw new ArgumentException("The rows and columns of the both matrix must be the same!");
            }

            Matrix<T> m3 = new Matrix<T>(m1.rows, m1.cols);

            for (int row = 0; row < m1.rows; row++)
            {
                for (int col = 0; col < m1.cols; col++)
                {
                    m3[row, col] = (dynamic)m1[row, col] - (dynamic)m2[row, col];
                }
            }

            return m3;
        }

        public static Matrix<T> operator *(Matrix<T> m1, Matrix<T> m2)
        {
            if (m1.cols != m2.rows)
            {
                throw new ArgumentException("The rows of one of the matrixes must be equal to the columns to the other! (their count)");
            }

            Matrix<T> m3 = new Matrix<T>(m1.rows, m1.cols);

            for (int row = 0; row < m1.rows; row++)
            {
                for (int col = 0; col < m1.cols; col++)
                {
                    for (int i = 0; i < m1.cols; i++)
                    {
                        m3[row, col] += (dynamic)m1[row, i] * (dynamic)m2[i, col];
                    }
                }
            }

            return m3;
        }

        public static bool operator true(Matrix<T> m)
        {
            foreach (T element in m.matrix)
            {
                if ((dynamic)element != 0)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool operator false(Matrix<T> m)
        {
            foreach (T element in m.matrix)
            {
                if ((dynamic)element != 0)
                {
                    return false;
                }
            }

            return true;
        }

        public override string ToString()
        {
            string result = string.Empty;

            for (int row = 0; row < this.rows; row++)
            {
                for (int col = 0; col < this.cols; col++)
                {
                    result += this.matrix[row, col] +  "   ";
                }

                result += "\n\n";
            }

            return result;
        }
    }
}
using System;

class Matrix
{
    // Write a class Matrix, to holds a matrix of integers. Overload the operators 
    // for adding, subtracting and multiplying of matrices, indexer for 
    // accessing the matrix content and ToString().

    private int[,] matrix;
    private int rows;
    private int cols;

    // constructor
    public Matrix(int rows, int cols)
    {
        this.rows = rows;
        this.cols = cols;

        matrix = new int[rows, cols];
    }

    // getter and setter
    public int this[int row, int col]
    {
        get { return matrix[row, col]; }
        set { matrix[row, col] = value; }
    }

    // + operator
    public static Matrix operator +(Matrix m1, Matrix m2)
    {
        Matrix m = new Matrix(m1.rows, m1.cols);

        for (int row = 0; row < m.rows; row++)
        {
            for (int col = 0; col < m.cols; col++)
            {
                m[row, col] = m1[row, col] + m2[row, col];
            }
        }

        return m;        
    }

    // - operator
    public static Matrix operator -(Matrix m1, Matrix m2)
    {
        Matrix m = new Matrix(m1.rows, m1.cols);

        for (int row = 0; row < m.rows; row++)
        {
            for (int col = 0; col < m.cols; col++)
            {
                m[row, col] = m1[row, col] - m2[row, col];
            }
        }

        return m;
    }

    // * operator
    public static Matrix operator *(Matrix m1, Matrix m2)
    {
        Matrix m = new Matrix(m1.rows, m2.cols);

        for (int row = 0; row < m.rows; row++)
        {
            for (int col = 0; col < m.cols; col++)
            {
                for (int k = 0; k < m1.cols; k++)
                {
                    m[row, col] += m1[row, k] * m2[k, col];
                }                    
            }                
        }            

        return m;
    }

    // override toString() method
    public override string ToString()
    {
        int max = this.matrix[0, 0];
        foreach (int cell in this.matrix) max = Math.Max(max, cell);
        int cellSize = Convert.ToString(max).Length;

        string resultString = "";

        for (int row = 0; row < this.rows; row++)
        {
            for (int col = 0; col < this.cols; col++)
            {
                resultString += Convert.ToString(this.matrix[row, col]).PadRight(4, ' ');

                if (col != this.cols - 1)
                {
                    resultString += " ";
                }
                else
	            {
                    resultString += "\n";
	            }
            }                
        }            

        return resultString;
    }
}
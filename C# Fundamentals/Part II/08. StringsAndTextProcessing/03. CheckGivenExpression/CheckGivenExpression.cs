using System;

class CheckGivenExpression
{
    // Write a program to check if in a given expression the brackets are put correctly.
    //     Example of correct expression: ((a+b)/5-d).
    //     Example of incorrect expression: )(a+b)).

    static bool CheckExpression(string expr)
    {
        bool isCorrect = true;
        int tempSum = 0;

        for (int i = 0; i < expr.Length; i++)
        {
            if (expr[i] == '(')
            {
                tempSum++;
            }
            else if (expr[i] == ')')
            {
                tempSum--;
            }

            // break at the first incorrect bracket
            if (tempSum < 0)
            {
                isCorrect = false;

                return isCorrect;
            }
        }

        if (tempSum != 0)
        {
            isCorrect = false;
        }

        return isCorrect;
    }

    static void Main()
    {
        string givenCorrExpr = "((a+b)/5-d)";
        Console.WriteLine("The expression: {0} is correct - {1}.", givenCorrExpr, CheckExpression(givenCorrExpr));      // true

        string givenIncorrExpre = ")(a+b))";
        Console.WriteLine("The expression: {0} is correct - {1}.", givenIncorrExpre, CheckExpression(givenIncorrExpre));      // false

        Console.WriteLine();
    }
}
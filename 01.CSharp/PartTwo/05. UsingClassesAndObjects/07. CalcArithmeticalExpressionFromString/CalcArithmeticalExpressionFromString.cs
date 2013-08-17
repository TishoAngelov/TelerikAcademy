using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;

class CalcArithmeticalExpressionFromString
{
    /*
        * Write a program that calculates the value of given arithmetical
          expression. The expression can contain the following elements only:
            Real numbers, e.g. 5, 18.33, 3.14159, 12.6
            Arithmetic operators: +, -, *, / (standard priorities)
            Mathematical functions: ln(x), sqrt(x), pow(x,y)
            Brackets (for changing the default priorities)
	      Examples:
	        (3+5.3) * 2.7 - ln(22) / pow(2.2, -1.7) -> ~ 10.6
	        pow(2, 3.14) * (3 - (3 * sqrt(2) - 3.2) + 1.5*0.3) -> ~ 21.22

	      Hint: Use the classical "shunting yard" algorithm and "reverse Polish notation".
    */

    public static List<char> arithmeticOperators = new List<char>() { '+', '-', '*', '/' };
    public static List<char> brackets = new List<char>() { '(', ')' };
    public static List<string> functions = new List<string>() { "pow", "sqrt", "ln" };

    public static string TrimExpression(string expression)
    {
        string expr = expression.Replace(" ", string.Empty);

        return expr;
    }

    public static List<string> SeparateTokens(string str)
    {
        var result = new List<string>();
        var number = new StringBuilder();

        for (int i = 0; i < str.Length; i++)
        {
            if (str[i] == '-' && (i == 0 || str[i - 1] == ',' || str[i - 1] == '('))
            {
                number.Append('-');
            }
            else if (char.IsDigit(str[i]) || str[i] == '.')
            {
                number.Append(str[i]);
            }
            else if (!char.IsDigit(str[i]) && str[i] != '.' && number.Length != 0)
            {
                result.Add(number.ToString());
                number.Clear();
                i--;
            }
            else if (brackets.Contains(str[i]))
            {
                result.Add(str[i].ToString());
            }
            else if (arithmeticOperators.Contains(str[i]))
            {
                result.Add(str[i].ToString());
            }
            else if (str[i] == ',')
            {
                result.Add(",");
            }
            else if (i + 1 < str.Length && str.Substring(i, 2).ToLower() == "ln")
            {
                result.Add("ln");
                i++;
            }
            else if (i + 2 < str.Length && str.Substring(i, 3).ToLower() == "pow")
            {
                result.Add("pow");
                i += 2;
            }
            else if (i + 3 < str.Length && str.Substring(i, 4).ToLower() == "sqrt")
            {
                result.Add("sqrt");
                i += 3;
            }
            else
            {
                throw new ArgumentException("Invalid expression");
            }
        }

        if (number.Length != 0)
        {
            result.Add(number.ToString());
        }

        return result;
    }

    public static int Precedence(string arithmeticOperator)
    {
        if (arithmeticOperator == "+" || arithmeticOperator == "-")
        {
            return 1;
        }
        else
        {
            return 2;
        }
    }

    public static Queue<string> RPN(List<string> tokens)         // "reverse Polish notation".
    {
        Stack<string> stack = new Stack<string>();
        Queue<string> queue = new Queue<string>();

        for (int i = 0; i < tokens.Count; i++)
        {
            var currentToken = tokens[i];
            double number;

            if (double.TryParse(currentToken, out number))
            {
                queue.Enqueue(currentToken);
            }
            else if (functions.Contains(currentToken))
            {
                stack.Push(currentToken);
            }
            else if (currentToken == ",")
            {
                if (!stack.Contains("(") || stack.Count == 0)
                {
                    throw new ArgumentException("Invalid brackets or function separator!");
                }

                while (stack.Peek() != "(")
                {
                    queue.Enqueue(stack.Pop());
                }
            }
            else if (arithmeticOperators.Contains(currentToken[0]))
            {
                while (stack.Count != 0 && arithmeticOperators.Contains(stack.Peek()[0])
                        && Precedence(currentToken) <= Precedence(stack.Peek()))
                {
                    queue.Enqueue(stack.Pop());
                }

                stack.Push(currentToken);
            }
            else if (currentToken == "(")
            {
                stack.Push("(");
            }
            else if (currentToken == ")")
            {
                if (!stack.Contains("(") || stack.Count == 0)
                {
                    throw new ArgumentException("Invalid brackets position");
                }

                while (stack.Peek() != "(")
                {
                    queue.Enqueue(stack.Pop());
                }

                stack.Pop();

                if (stack.Count != 0 && functions.Contains(stack.Peek()))
                {
                    queue.Enqueue(stack.Pop());
                }
            }
        }

        while (stack.Count != 0)
        {
            if (brackets.Contains(stack.Peek()[0]))
            {
                throw new ArgumentException("Invalid brackets position!");
            }

            queue.Enqueue(stack.Pop());
        }

        return queue;
    }

    public static double GetResultFromRPN(Queue<string> queue)
    {
        Stack<double> stack = new Stack<double>();

        while (queue.Count != 0)
        {
            string currentToken = queue.Dequeue();
            double number;

            if (double.TryParse(currentToken, out number))
            {
                stack.Push(number);
            }
            else if (arithmeticOperators.Contains(currentToken[0]) || functions.Contains(currentToken))
            {
                if (currentToken == "+")
                {
                    if (stack.Count < 2)
                    {
                        throw new ArgumentException("Invalid expression!");
                    }

                    double firstValue = stack.Pop();
                    double secondValue = stack.Pop();

                    stack.Push(firstValue + secondValue);
                }
                else if (currentToken == "-")
                {
                    if (stack.Count < 2)
                    {
                        throw new ArgumentException("Invalid expression!");
                    }

                    double firstValue = stack.Pop();
                    double secondValue = stack.Pop();

                    stack.Push(secondValue - firstValue);
                }
                else if (currentToken == "*")
                {
                    if (stack.Count < 2)
                    {
                        throw new ArgumentException("Invalid expression!");
                    }

                    double firstValue = stack.Pop();
                    double secondValue = stack.Pop();

                    stack.Push(secondValue * firstValue);
                }
                else if (currentToken == "/")
                {
                    if (stack.Count < 2)
                    {
                        throw new ArgumentException("Invalid expression!");
                    }

                    double firstValue = stack.Pop();
                    double secondValue = stack.Pop();

                    stack.Push(secondValue / firstValue);
                }
                else if (currentToken == "pow")
                {
                    if (stack.Count < 2)
                    {
                        throw new ArgumentException("Invalid expression!");
                    }

                    double firstValue = stack.Pop();
                    double secondValue = stack.Pop();

                    stack.Push(Math.Pow(secondValue, firstValue));
                }
                else if (currentToken == "sqrt")
                {
                    if (stack.Count < 1)
                    {
                        throw new ArgumentException("Invalid expression!");
                    }

                    double value = stack.Pop();

                    stack.Push(Math.Sqrt(value));
                }
                else if (currentToken == "ln")
                {
                    if (stack.Count < 1)
                    {
                        throw new ArgumentException("Invalid expression!");
                    }

                    double value = stack.Pop();

                    stack.Push(Math.Log(value));
                }
            }
        }

        if (stack.Count == 1)
        {
            return stack.Pop();
        }
        else
        {
            throw new ArgumentException("Invalid expression");
        }
    }
    
    public static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        //string input = Console.ReadLine();
        string mathExpression = "(3 + 5.3) * 2.7 - ln(22) / pow(2.2, -1.7)";         // test input
        Console.Write("{0} ~ ", mathExpression);

        try
        {
            string trimmedInput = mathExpression.Replace(" ", string.Empty);
            var separatedTokens = SeparateTokens(trimmedInput);
            var reversePolishNotation = RPN(separatedTokens);
            var finalResult = GetResultFromRPN(reversePolishNotation);
            Console.WriteLine(Math.Round(finalResult, 2));
        }
        catch (ArgumentException exeption)
        {
            Console.WriteLine(exeption.Message);
        }

        Console.WriteLine();
    }
}
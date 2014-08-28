namespace BooleanVariableToString
{
    using System;

    public class BooleanToString
    {
        public void Print(bool boolVariable)
        {
            string boolVarAsString = boolVariable.ToString();
            Console.WriteLine(boolVarAsString);
        }
    }
}
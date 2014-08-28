using System;

class JoroTheRabbit
{
    static void Main()
    {
        char[] separators = { ',', ' ' };
        string[] jumpingField = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);

        int[] numbers = new int[jumpingField.Length];

        for (int i = 0; i < numbers.Length; i++)
		{
            numbers[i] = int.Parse(jumpingField[i]);
		}

        int maxLength = int.MinValue;
        int currLength = 0;
        int currJumpNum = 0;
        int prevJumpNum = 0;
        //bool[] visited;
        int startIndex = 0;

        for (int j = 0; j < jumpingField.Length; j++)
        {
            for (int step = 1; step <= jumpingField.Length; step++)
            {
                //visited = new bool[jumpingField.Length];

                prevJumpNum = int.MinValue;
                startIndex = j + step - 1;
                int i = startIndex;

                if (i >= jumpingField.Length)
                {
                    i = i - jumpingField.Length;
                }

                currLength = 0;

                do
                {
                    currJumpNum = numbers[i];

                    if (currJumpNum <= prevJumpNum)
                    {
                        break;
                    }

                    prevJumpNum = currJumpNum;
                    //visited[i] = true;
                    
                    currLength++;

                    i += step;

                    if (i >= jumpingField.Length)
                    {
                        i = i - jumpingField.Length;
                    }                    

                } while (i != startIndex);   // !visited[i]

                maxLength = Math.Max(maxLength, currLength);
            }
        }

        Console.WriteLine(maxLength);
    }
}
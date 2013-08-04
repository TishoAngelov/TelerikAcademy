using System;

class BatGoikoTower
{
    static void Main()
    {
        int towerHeight = int.Parse(Console.ReadLine());
        int towerWidth = 2 * towerHeight;
        int spaceInsideTower = 0;
        int spaceOutsideTower = towerWidth - 2;
        int counter = 1;
        int br = 1;

        for (int i = 0; i < towerHeight; i++)
        {           
            if (counter == i)
            {
                br++;
                counter += br;

                Console.WriteLine(new string('.', (spaceOutsideTower - spaceInsideTower) / 2) +
                "/" + new string('-', spaceInsideTower) + "\\" + new string('.', (spaceOutsideTower - spaceInsideTower) / 2));
                spaceInsideTower += 2;
            }
            else
            {
                Console.WriteLine(new string('.', (spaceOutsideTower - spaceInsideTower) / 2) +
                "/" + new string('.', spaceInsideTower) + "\\" + new string('.', (spaceOutsideTower - spaceInsideTower) / 2));
                spaceInsideTower += 2;
            }            
        }
    }
}
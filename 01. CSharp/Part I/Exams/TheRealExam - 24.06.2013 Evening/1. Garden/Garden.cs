using System;

class Garden
{
    static void Main()
    {
        int totalArea = 250;

        int tomatoSeeds = int.Parse(Console.ReadLine());
        int tomatoArea = int.Parse(Console.ReadLine());
        decimal tomatoSeedCost = 0.5M;
        decimal tomatoTotalCost = (decimal)tomatoSeedCost * tomatoSeeds;

        int cucumberSeeds = int.Parse(Console.ReadLine());
        int cucumberArea = int.Parse(Console.ReadLine());
        decimal cucumberSeedCost = 0.4M;
        decimal cucumberTotalCost = (decimal)cucumberSeedCost * cucumberSeeds;

        int potatoSeeds = int.Parse(Console.ReadLine());
        int potatoArea = int.Parse(Console.ReadLine());
        decimal potatoSeedCost = 0.25M;
        decimal potatoTotalCost = (decimal)potatoSeedCost * potatoSeeds;

        int carrotSeeds = int.Parse(Console.ReadLine());
        int carrotArea = int.Parse(Console.ReadLine());
        decimal carrotSeedCost = 0.6M;
        decimal carrotTotalCost = (decimal)carrotSeedCost * carrotSeeds;

        int cabbageSeeds = int.Parse(Console.ReadLine());
        int cabbageArea = int.Parse(Console.ReadLine());
        decimal cabbageSeedCost = 0.3M;
        decimal cabbageTotalCost = (decimal)cabbageSeedCost * cabbageSeeds;

        int beansSeeds = int.Parse(Console.ReadLine());        
        int beansArea = totalArea - tomatoArea - cucumberArea - potatoArea - carrotArea - cabbageArea;
        decimal beansSeedCost = 0.4M;
        decimal beansTotalCost = (decimal)beansSeedCost * beansSeeds;

        
        decimal vegetablesTotalCost = tomatoTotalCost + cucumberTotalCost + potatoTotalCost + carrotTotalCost + cabbageTotalCost + beansTotalCost;




        Console.WriteLine("Total costs: {0:0.00}", vegetablesTotalCost);

        if (beansArea > 0)
        {
            Console.WriteLine("Beans area: {0}", beansArea);
        }
        else if (beansArea == 0)
        {
            Console.WriteLine("No area for beans");
        }
        else
        {
            Console.WriteLine("Insufficient area");
        }
    }
}
//Second puzzle

class Program
{
    static int numberOfIncreases = 0;

    static int PreviousGroup = 0;

    static bool FirstItem = true;

    public static void Main()
    {
        List<int> list = new List<int>();

        foreach (var item in System.IO.File.ReadLines(@"../input.txt"))
        {
            list.Add(int.Parse(item));
        }

        for (int startNode = 0; startNode < list.Count - 2; startNode++)
        {
            int group = 0;
            
            for (int node = startNode; node != startNode + 3; node++)
            {
                group += list.ElementAt(node);
            }

            compareGroup(group);
        }
        Console.WriteLine("Number og increases: " + numberOfIncreases);
    }

    private static void compareGroup(int CurrentGroup)
    {
        if (FirstItem)
        {
            PreviousGroup = CurrentGroup;
            FirstItem = false;
            Console.WriteLine("First item: " + PreviousGroup);
        }
        else
        {
            Console.WriteLine("Prev item: " + PreviousGroup);
            Console.WriteLine("Cur item: " + CurrentGroup);
            if (CurrentGroup > PreviousGroup)
            {
                numberOfIncreases++;
            }

            PreviousGroup = CurrentGroup;
            Console.WriteLine("New Prev item: " + PreviousGroup);
        }
        return;
    }

}
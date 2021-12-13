public class Program
{

    static long[] Fishes = new long[9];

    static long fishesTotal = 0;




    public static void Main()
    {
        foreach (var item in System.IO.File.ReadLines(@"../input.txt"))
        {
            string[] line = item.Split(",");

            fishesTotal = line.Length;

            foreach (var node in line)
            {
                Fishes[Convert.ToInt32(node)]++;
            }

        }

        // Console.WriteLine("Initial day:");
        // for (int i = 0; i < 9; i++)
        // {
        //     Console.WriteLine("There are " + Fishes[i] + " that are " + i + " years old");
        // }

        long prevtmp = Fishes[0];
        long curtmp;
        for (int i = 0; i < 257; i++)
        {
            //Console.WriteLine("After day number: " + (i));
            for (int j = 8; j > -1; j--)
            {
                curtmp = Fishes[j];
                //Console.WriteLine("There are " + Fishes[j] + "fishes that are " + j + " years old");

                if (j == 0)
                {
                    Fishes[6] += curtmp;
                    Fishes[8] = curtmp;
                }
                else if (j == 8)
                {
                    fishesTotal += curtmp;
                }
                //Console.WriteLine("There are " + Fishes[j] + "fishes that are " + j + " years old");
                Fishes[j] = prevtmp;
                prevtmp = curtmp;
            }
        }
        Console.WriteLine(fishesTotal);
    }
}
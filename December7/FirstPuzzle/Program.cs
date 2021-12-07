public class Program
{
    static int[] numbers;

    static int median = 0;
    static int avg = 0;


    static int total = 0;
    static int fuel = 0;
    public static void Main()
    {

        foreach (var item in System.IO.File.ReadLines(@"../input.txt"))
        {
            string[] line = item.Split(",");

            numbers = new int[line.Length];

            for (int i = 0; i < line.Length; i++)
            {
                numbers[i] = Convert.ToInt32(line[i]);
                total += numbers[i];
            }

            Array.Sort(numbers);

        }

        //Console.WriteLine(total);

        setMedian();
        setAverage();

        for (int i = 0; i < numbers.Length; i++)
        {
            int steps = Math.Abs(avg - numbers[i]);
            int tmpFuel = 0;
            int prev = 0;
            for (int j = 1; j < steps + 1; j++)
            {
                tmpFuel += j;
            }

            fuel += tmpFuel;
            //Console.WriteLine(fuel);
        }


        


        Console.WriteLine(fuel);
    }


    private static void setMedian()
    {
        median = numbers[numbers.Length / 2];
    }

    private static void setAverage()
    {
        avg = (int)Math.Round((double)total / numbers.Length) -2;
        Console.WriteLine(avg -2);
    }
}
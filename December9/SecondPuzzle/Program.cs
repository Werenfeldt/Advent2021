public class Program
{
    static int[] numbers;

    static List<int> lowest = new List<int>();

    static int rowLength = 0;
    public static void Main()
    {
        List<int> list = new List<int>();
        foreach (var item in System.IO.File.ReadLines(@"../test.txt"))
        {


            rowLength = item.Length;
            foreach (char ele in item)
            {
                var nb = ele.ToString();
                list.Add(int.Parse(nb));

            }


        }
        numbers = list.ToArray();

        //Console.WriteLine(rowLength);


        getNumber();

        int result = 0;

        List<int> BasinCounts = new List<int>();

        for (int i = 0; i < lowest.Count; i++)
        {
            Console.WriteLine("Basin number: " + 1);
            var tmplist = FindBasin(lowest.ElementAt(i));
            foreach (var item in tmplist)
            {

                Console.WriteLine(item);
            }
        }
        // foreach (var item in lowest)
        // {
        //     BasingCounts.Add(FindBasin(item).Count);
        // }

    }

    public static void getNumber()
    {
        int rowlengthNumber = rowLength;
        for (int i = 0; i < numbers.Length; i++)
        {
            if (i < rowLength)
            {
                //Console.WriteLine("row start: " + i + " Row length: " + rowLength);

                if (i == 0)
                {
                    //Console.WriteLine(i + ", " + i + 1 + "," + (i + rowLength));
                    if (numbers[i] < numbers[i + 1] && numbers[i] < numbers[i + rowLength])
                    {
                        lowest.Add(numbers[i] + 1);
                    }
                }
                else if (i == rowLength - 1)
                {
                    //Console.WriteLine(i + ", " + (i - 1) + "," + (i + rowLength));
                    if (numbers[i] < numbers[i - 1] && numbers[i] < numbers[i + rowLength])
                    {
                        lowest.Add(numbers[i] + 1);
                    }
                }
                else
                {
                    //Console.WriteLine(i + ", " + (i - 1) + "," + (i + 1) + "," + (i + rowLength));
                    if (numbers[i] < numbers[i - 1] && numbers[i] < numbers[i + 1] && numbers[i] < numbers[i + rowLength])
                    {
                        lowest.Add(numbers[i] + 1);
                    }
                }
            }
            else if (i > rowLength - 1 && i < numbers.Length - rowLength)
            {
                //Console.WriteLine("row middle: " + i + " Row length over: " + (rowLength - 1) + "row length under: " + (numbers.Length - rowLength));
                //Console.WriteLine("numbers[i] < numbers[i + 1]: " + (numbers[i] < numbers[i + 1]));
                //Console.WriteLine("numbers[i] < numbers[i - 1]" + (numbers[i] < numbers[i - 1]));
                //Console.WriteLine("numbers[i] < numbers[i + rowLength]" + (numbers[i] < numbers[i + rowLength]) );
                //Console.WriteLine("numbers[i] < numbers[i - rowLength]" + (numbers[i] < numbers[i - rowLength]));
                if (i == rowlengthNumber)
                {
                    //Console.WriteLine(rowlengthNumber);
                    if (numbers[i] < numbers[i + 1] && numbers[i] < numbers[i + rowLength] && numbers[i] < numbers[i - rowLength])
                    {
                        lowest.Add(numbers[i] + 1);
                    }
                    rowlengthNumber += rowLength;
                }
                else if (i == rowlengthNumber - 1)
                {
                    if (numbers[i] < numbers[i - 1] && numbers[i] < numbers[i + rowLength] && numbers[i] < numbers[i - rowLength])
                    {
                        lowest.Add(numbers[i] + 1);

                    }
                }
                else if (numbers[i] < numbers[i + 1] && numbers[i] < numbers[i - 1] && numbers[i] < numbers[i + rowLength] && numbers[i] < numbers[i - rowLength])
                {
                    //Console.WriteLine("number: " + numbers[i] + " place: " + i + ", " + (i + 1) + "," + (i - 1) + "," + (i + rowLength) + "," + (i - rowLength));
                    lowest.Add(numbers[i] + 1);
                }
            }
            else
            {
                if (i == numbers.Length - (rowLength))
                {
                    //Console.WriteLine("row end Edge start: " + i + " Row length: " + (numbers.Length - (rowLength - 1)));
                    //Console.WriteLine(i + ", " + (i + 1) + "," + (i - rowLength));
                    if (numbers[i] < numbers[i + 1] && numbers[i] < numbers[i - rowLength])
                    {
                        lowest.Add(numbers[i] + 1);
                    }
                }
                else if (i == numbers.Length - 1)
                {
                    //Console.WriteLine("row end Edge end: " + i + " Row length: " + (numbers.Length - 1));
                    if (numbers[i] < numbers[i - 1] && numbers[i] < numbers[i - rowLength])
                    {
                        Console.WriteLine(i + ", " + (i - 1) + "," + (i - rowLength));
                        lowest.Add(numbers[i] + 1);
                    }
                }
                else
                {
                    //Console.WriteLine("row end middle: " + i + " Row length over: " + (numbers.Length - (rowLength - 1)));
                    if (numbers[i] < numbers[i - 1] && numbers[i] < numbers[i + 1] && numbers[i] < numbers[i - rowLength])
                    {
                        Console.WriteLine(i + ", " + (i - 1) + ", " + (i + 1) + "," + (i - rowLength));
                        lowest.Add(numbers[i] + 1);
                    }
                }
            }
        }
    }

    private static List<int> FindBasin(int i)
    {
        int next = 0;
        bool horiNotDone = false;
        List<int> basin = new List<int>();
        basin.Add(i);

        for (int j = 0; j < basin.Count; j++)
        {
            basin.AddRange(CheckHoriRight(i));
        }

        return basin;

    }

    private static List<int> CheckHoriRight(int i)
    {
        List<int> inc = new List<int>();

        while (i != 9)
        {
            inc.Add(numbers[i + 1]);
            i = numbers[i + 1];
        }

        return inc;
    }

    private static List<int> CheckHoriLeft(int i)
    {
        List<int> inc = new List<int>();
        while (i != 9)
        {
            inc.Add(numbers[i - 1]);
            i = numbers[i - 1];
        }

        return inc;
    }

    private static List<int> CheckVertUp(int i)
    {
        List<int> inc = new List<int>();

        while (i != 9)
        {
            inc.Add(numbers[i - rowLength]);
            i = numbers[i - rowLength];
        }

        return inc;
    }

    private static List<int> CheckVertDown(int i)
    {
        List<int> inc = new List<int>();

        while (i != 9)
        {
            inc.Add(numbers[i + rowLength]);
            i = numbers[i + rowLength];
        }

        return inc;
    }
}
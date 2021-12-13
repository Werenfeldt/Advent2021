public class Program
{
    static int[] numbers;

    static List<int> lowest = new List<int>();

    static int rowLength = 0;
    public static void Main()
    {
        List<int> list = new List<int>();
        foreach (var item in System.IO.File.ReadLines(@"../input.txt"))
        {


            rowLength = item.Length;
            foreach (char ele in item)
            {
                var nb = ele.ToString();
                list.Add(int.Parse(nb));

            }


        }
        numbers = list.ToArray();

        Console.WriteLine(rowLength);


        getNumber();

        int result = 0;

        foreach (var ele in lowest)
        {
            result += ele;
        }

        Console.WriteLine(result);

    }

    public static void getNumber()
    {
        int rowlengthNumber = rowLength;
        for (int i = 0; i < numbers.Length; i++)
        {
            if (i < rowLength)
            {
                Console.WriteLine("row start: " + i + " Row length: " + rowLength);

                if (i == 0)
                {
                    Console.WriteLine(i + ", " + i + 1 + "," + (i + rowLength));
                    if (numbers[i] < numbers[i + 1] && numbers[i] < numbers[i + rowLength])
                    {
                        lowest.Add(numbers[i] + 1);
                    }
                }
                else if (i == rowLength - 1)
                {
                    Console.WriteLine(i + ", " + (i - 1) + "," + (i + rowLength));
                    if (numbers[i] < numbers[i - 1] && numbers[i] < numbers[i + rowLength])
                    {
                        lowest.Add(numbers[i] + 1);
                    }
                }
                else
                {
                    Console.WriteLine(i + ", " + (i - 1) + "," + (i + 1) + "," + (i + rowLength));
                    if (numbers[i] < numbers[i - 1] && numbers[i] < numbers[i + 1] && numbers[i] < numbers[i + rowLength])
                    {
                        lowest.Add(numbers[i] + 1);
                    }
                }
            }
            else if (i > rowLength - 1 && i < numbers.Length - rowLength)
            {
                Console.WriteLine("row middle: " + i + " Row length over: " + (rowLength - 1) + "row length under: " + (numbers.Length - rowLength));
                //Console.WriteLine("numbers[i] < numbers[i + 1]: " + (numbers[i] < numbers[i + 1]));
                //Console.WriteLine("numbers[i] < numbers[i - 1]" + (numbers[i] < numbers[i - 1]));
                //Console.WriteLine("numbers[i] < numbers[i + rowLength]" + (numbers[i] < numbers[i + rowLength]) );
                //Console.WriteLine("numbers[i] < numbers[i - rowLength]" + (numbers[i] < numbers[i - rowLength]));
                if (i == rowlengthNumber)
                {
                    Console.WriteLine(rowlengthNumber);
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
                    Console.WriteLine("number: " + numbers[i] + " place: " + i + ", " + (i + 1) + "," + (i - 1) + "," + (i + rowLength) + "," + (i - rowLength));
                    lowest.Add(numbers[i] + 1);
                }
            }
            else
            {
                if (i == numbers.Length - (rowLength))
                {
                Console.WriteLine("row end Edge start: " + i + " Row length: " + (numbers.Length - (rowLength - 1)));
                    Console.WriteLine(i + ", " + (i + 1) + "," + (i - rowLength));
                    if (numbers[i] < numbers[i + 1] && numbers[i] < numbers[i - rowLength])
                    {
                        lowest.Add(numbers[i] + 1);
                    }
                }
                else if (i == numbers.Length - 1)
                {
                    Console.WriteLine("row end Edge end: " + i + " Row length: " + (numbers.Length - 1));
                    if (numbers[i] < numbers[i - 1] && numbers[i] < numbers[i - rowLength])
                    {
                    Console.WriteLine(i + ", " + (i - 1) + "," + (i - rowLength));
                        lowest.Add(numbers[i] + 1);
                    }
                }
                else
                { Console.WriteLine("row end middle: " + i + " Row length over: " + (numbers.Length - (rowLength - 1)));
                    if (numbers[i] < numbers[i - 1] && numbers[i] < numbers[i + 1] && numbers[i] < numbers[i - rowLength])
                    {
                    Console.WriteLine(i + ", " + (i - 1) + ", " + (i + 1) + "," + (i - rowLength));
                        lowest.Add(numbers[i] + 1);
                    }
                }
            }
        }
    }
}
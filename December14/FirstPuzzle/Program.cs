public class Program
{

    static string StartingPoint;

    static string MidPoint;

    static string ThirdPoint;

    static string ForthPoint;

    static List<string> MainString = new List<string>();

    static List<string> SecondString = new List<string>();





    static List<(string, string)> ValueCodes = new List<(string, string)>();

    static List<(string, long)> LettersOccur = new List<(string, long)>();

    static string LastElementsSplit = "";


    static long max = 0;

    static long min = 0;
    public static void Main()
    {
        foreach (var item in System.IO.File.ReadLines(@"../input.txt"))
        {
            if (!item.Contains("->") && !string.IsNullOrEmpty(item))
            {
                StartingPoint = item;
                foreach (char c in item)
                {
                    string s = char.ToString(c);
                    AddLetters(s);
                    AddValueCount(s);
                    MainString.Add(s);
                }
            }
            else if (!string.IsNullOrEmpty(item))
            {
                string[] line = item.Split(" -> ");
                ValueCodes.Add((line[0], line[1]));
                AddLetters(line[1]);
            }
        }

        foreach (var let in LettersOccur)
        {
            Console.WriteLine("Letter : " + let);
        }

        // foreach (var ele in ValueCodes)
        // {
        //     Console.WriteLine(ele.Item1 + " -> " + ele.Item2);
        // }
        // foreach (var ele in MainString)
        // {
        //     Console.Write(ele);

        // }
        bool reset = false;

        for (int j = 0; j < 40; j++)
        {

            int insertIndex = 1;

            if (j == 20)
            {

                SplitString(j);
            }


            Console.WriteLine("After step Main: " + (j + 1));
            for (int i = 0; i < StartingPoint.Length - 1; i++)
            {

                //Console.WriteLine(StartingPoint);
                var pair = StartingPoint.Substring(i, 2);
                FindValue(pair, insertIndex, true);
                insertIndex += 2;
            }



            StartingPoint = string.Join("", MainString);
            //Console.WriteLine(StartingPoint.Length);
            //Console.WriteLine("New StartingPoint: " + StartingPoint + "length: " + StartingPoint.Length);

        }

        //SimulateStepsSecond();



        FindMax();
        FindMin();
        Console.WriteLine(max);
        Console.WriteLine(min);
        Console.WriteLine(max - min);
    }

    static void SimulateStepsSecond(int k)
    {
        //Console.WriteLine("SecondStringStart");
        for (int j = 0; j < k; j++)
        {
            //Console.WriteLine("After step Second: " + (j + 1));
            int insertIndex = 1;
            for (int i = 0; i < MidPoint.Length - 1; i++)
            {
                //Console.WriteLine(MidPoint);
                var pair = MidPoint.Substring(i, 2);
                FindValue(pair, insertIndex, false);
                insertIndex += 2;
            }

            MidPoint = string.Join("", SecondString);
            //Console.WriteLine(StartingPoint.Length);
            //Console.WriteLine("New MidPoint: " + MidPoint);

        }
    }

    static void SplitString(int j)
    {
        //Console.WriteLine("Start Split of: " + StartingPoint);
        int index = StartingPoint.Length / 2;
        MidPoint = StartingPoint.Substring(index, index + 1);
        StartingPoint = StartingPoint.Remove(index + 1, index);
        //LastElementsSplit = (string)MidPoint[0];
        int listIndex = MainString.Count / 2;
        var input = MainString.GetRange(listIndex, listIndex + 1);

        SecondString.AddRange(input);
        MainString.RemoveRange(index + 1, index);

        // var v = LettersOccur.Find(s => s.Item1 == MainString[0]);
        // var t = LettersOccur.FindIndex(s => s.Item1 == MainString[0]);
        // v.Item2 = v.Item2 - 2;
        // LettersOccur[t] = v;

        Console.WriteLine("Start: " + StartingPoint);
        Console.WriteLine("Mid: " + MidPoint);
        //Console.WriteLine("SecondStrin:");
        // foreach (var item in SecondString)
        // {
        //     Console.Write(item);
        // }
        SimulateStepsSecond(j);
        //SimulateFirstSecond();
    }

    static void AddLetters(string letter)
    {
        if (!LettersOccur.Exists(l => l.Item1 == letter))
        {
            LettersOccur.Add((letter, 0));
        }
    }

    static void FindMax()
    {
        foreach (var item in LettersOccur)
        {
            if (item.Item2 > max)
            {
                max = item.Item2;
                Console.WriteLine("Max : " + item.Item1);
            }
        }
    }

    static void FindMin()
    {
        min = LettersOccur.ElementAt(0).Item2;
        foreach (var item in LettersOccur)
        {
            if (item.Item2 < min)
            {
                min = item.Item2;
                Console.WriteLine("Min : " + item.Item1);
            }
        }
    }

    static void AddValueCount(string value)
    {
        var v = LettersOccur.Find(s => s.Item1 == value);
        var t = LettersOccur.FindIndex(s => s.Item1 == value);
        v.Item2++;
        LettersOccur[t] = v;
        //Console.WriteLine("Add Value: " + LettersOccur.Find(s => s.Item1 == value));
    }

    static void FindValue(string pair, int index, bool main)
    {
        string tmpValue = "";
        foreach (var item in ValueCodes)
        {
            if (item.Item1 == pair)
            {
                tmpValue = item.Item2;
            }
        }

        // Console.WriteLine("");
        // Console.WriteLine("Insert at: " + index + " item: " + tmpValue);

        AddValueCount(tmpValue);

        if (main)
        {

            MainString.Insert(index, tmpValue);
        }
        else
        {
            SecondString.Insert(index, tmpValue);
            // foreach (var ele in SecondString)
            // {
            //     Console.Write(ele);

            // }
        }

        //Console.WriteLine("");
        //Console.WriteLine("Insert at: " + index + " item: " + tmpValue);
    }
}
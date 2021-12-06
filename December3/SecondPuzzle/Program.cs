
class Program
{
    static string oxy = "";
    static string co = "";


    static bool firstIt = true;
    static List<string> OriList = new List<string>();
    static List<string> CoList = new List<string>();
    static List<string> OxyList = new List<string>();
    static List<int> indexZero = new List<int>();
    static List<int> indexOne = new List<int>();


    public static void Main()
    {

        foreach (var item in System.IO.File.ReadLines(@"../input.txt"))
        {
            OriList.Add(item);
        }
        // Console.WriteLine("OriList");
        // for (int i = 0; i < OriList.Count; i++)
        // {
        //     Console.WriteLine(OriList.ElementAt(i));

        // }


        for (int i = 0; i < 13; i++)
        {
            if (firstIt)
            {
                OxyList = SearchList(OriList, true, i);
                CoList = SearchList(OriList, false, i);
                firstIt = false;
                // Console.WriteLine("OxyList Round: " + i);
                // for (int x = 0; x < OxyList.Count; x++)
                // {

                //     Console.WriteLine(OxyList.ElementAt(x));

                // }
                // Console.WriteLine("CoList Round: " + i);
                // for (int c = 0; c < CoList.Count; c++)
                // {
                //     Console.WriteLine(CoList.ElementAt(c));

                // }
            }
            else
            {
                if (OxyList.Count > 1)
                {
                    OxyList = SearchList(OxyList, true, i);
                    // Console.WriteLine("OxyList Round: " + i);
                    // for (int x = 0; x < OxyList.Count; x++)
                    // {

                    //     Console.WriteLine(OxyList.ElementAt(x));

                    // }
                }
                else
                {
                    // Console.WriteLine("Oxy element at 0: " + OxyList.ElementAt(0));
                    oxy = OxyList.ElementAt(0);
                }

                if (CoList.Count > 1)
                {
                    CoList = SearchList(CoList, false, i);
                    // Console.WriteLine("CoList Round: " + i);
                    // for (int c = 0; c < CoList.Count; c++)
                    // {
                    //     Console.WriteLine(CoList.ElementAt(c));

                    // }

                }
                else
                {
                    // Console.WriteLine("Co element at 0: " + CoList.ElementAt(0));
                    co = CoList.ElementAt(0);
                }
            }
        }

        Console.WriteLine(Convert.ToInt32(oxy, 2) * Convert.ToInt32(co, 2));
    }

    private static List<string> SearchList(List<string> list, bool oxy, int i)
    {
        List<string> tmplist = new List<string>();


        indexOne.Clear();
        indexZero.Clear();
        int numberOfOnes = 0;
        int numberOfZeros = 0;

        for (int j = 0; j < list.Count; j++)
        {
            var tmp = list.ElementAt(j);
            var number = tmp.Substring(i, 1);
            if (number == "0")
            {
                numberOfZeros++;
                indexZero.Add(j);
            }
            else
            {
                numberOfOnes++;
                indexOne.Add(j);
            }

        }

        if (numberOfOnes > numberOfZeros || numberOfOnes == numberOfZeros)
        {
            if (oxy)
            {
                foreach (var item in indexOne)
                {
                    tmplist.Add(list.ElementAt(item));
                }

            }
            else
            {
                foreach (var item in indexZero)
                {
                    tmplist.Add(list.ElementAt(item));
                }
            }

            // if (OriList.Count == 1)
            // {
            //     oxy = OriList.ElementAt(0);
            // }
        }
        else
        {
            if (oxy)
            {
                foreach (var item in indexZero)
                {
                    tmplist.Add(list.ElementAt(item));
                }

            }
            else
            {
                foreach (var item in indexOne)
                {
                    tmplist.Add(list.ElementAt(item));
                }
            }

            // if (OriList.Count == 1)
            // {
            //     oxy = OriList.ElementAt(0);
            // }
        }

        return tmplist;
    }
}

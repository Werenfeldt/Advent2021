public class Program
{

    static string[] stack;

    static int top;

    static bool upward = true;

    static string startTag = "({[<";

    static string endTag = ")}]>";

    static int rowLength;

    static int currentRow;

    static int lineNumber = 0;

    static List<string> corrupted = new List<string>();
    static List<string> completion = new List<string>();
    static List<long> totalScore = new List<long>();



    public static void Main()
    {
        foreach (var item in System.IO.File.ReadLines(@"../input.txt"))
        {
            //Console.WriteLine("New line: " + lineNumber);
            lineNumber++;
            stack = new string[item.Length];

            //Console.WriteLine(item.Length);

            rowLength = item.Length;

            currentRow = 0;

            top = -1;

            upward = true;

            foreach (char ele in item)
            {
                var nb = ele.ToString();

                //Console.WriteLine("CurrentRow: " + currentRow);
                
                checkDirection(nb);
                
                if (upward)
                {
                    //Console.WriteLine("Cur Ellement: {0} Push: {1}", Peak(), nb);
                    var end = Push(nb);
                    if (end)
                    {
                        StartCompletion();
                    }
                }
                else
                {
                    //Console.WriteLine("Cur Ellement: {0} Peak with: {1}", Peak(), nb);
                    if (match(nb))
                    {
                        //Console.WriteLine("Cur Ellement: {0} Pop: {1}", Peak(), nb);
                        var end = Pop();
                        if (end)
                        {
                            StartCompletion();
                        }
                    }
                    else
                    {
                        //Console.WriteLine("Corrupt: Cur Element: {0}, ElementGot: {1}", Peak(), nb);
                        //corrupted.Add(nb);

                        break;
                    }
                }

                currentRow++;
            }
        }
        //int result = 0;
        // foreach (var item in corrupted)
        // {
        //     result += FindPoint(item);
        // }
        //Console.WriteLine(result);
        totalScore.Sort();

        foreach (var item in totalScore)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine(totalScore.ElementAt(totalScore.Count / 2));

    }

    public static void Calculate(){

    }

    public static void StartCompletion()
    {
        while (top > -1)
        {
            //Console.WriteLine("Completion: Cur Element: {0}, BetterHalf: {1}", Peak(), FindBetterHalf(Peak()));
            completion.Add(FindBetterHalf(Peak()));
            Pop();
        }
        long result = 0;
        foreach (var item in completion)
        {
            result = (result*5)+FindPoint(item);
        }

        totalScore.Add(result);

        completion.Clear();
    }

    public static int FindPoint(string nb)
    {
        switch (nb)
        {
            // case ")": return 3;
            // case "]": return 57;
            // case "}": return 1197;
            // case ">": return 25137;
            case ")": return 1;
            case "]": return 2;
            case "}": return 3;
            case ">": return 4;
        }
        return 0;
    }

    public static string FindBetterHalf(string nb)
    {
        switch (nb)
        {
            case "(": return ")";
            case "[": return "]";
            case "{": return "}";
            case "<": return ">";
        }
        return "";
    }
    public static bool match(string nb)
    {
        switch (nb)
        {
            case ")":
                {
                    if ("(" == Peak())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            case "]":
                {
                    if ("[" == Peak())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            case "}":
                {
                    if ("{" == Peak())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            case ">":
                {
                    if ("<" == Peak())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
        }
        return false;
    }

    public static void checkDirection(string data)
    {

        if (startTag.Contains(data))
        {
            upward = true;
        }
        else
        {
            upward = false;
        }

    }

    public static bool Push(string data)
    {
        if ((currentRow + 1) == rowLength)
        {
            stack[++top] = data;
            return true;
        }
        else
        {
            stack[++top] = data;
            return false;
        }
    }

    public static bool Pop()
    {
        if ((currentRow + 1) == rowLength)
        {
            var value = stack[top--];
            return true;

        }
        else if(top < 0)
        {
            
            return false;
        } else {
            var value = stack[top--];
            return false;
        }


    }

    public static string Peak()
    {
        if (top > -1)
        {
            var value = stack[top];
            return value;
        }
        return null;
    }
}

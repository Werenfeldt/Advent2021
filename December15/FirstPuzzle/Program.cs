public class Program
{

    //column
    static int column;

    //length
    static int row;

    static int[,] Grid;

    static (int, int) Pos = (0, 0);

    public static void Main()
    {

        int currentRow = 0;

        foreach (var item in System.IO.File.ReadLines(@"../test.txt"))
        {

            if (currentRow == 0)
            {

                column = item.Length;
                row = 10;
                Grid = new int[row, column];
            }

            int currentColumn = 0;

            foreach (char c in item)
            {

                var number = Int32.Parse(c.ToString());
                Grid[currentRow, currentColumn] = number;
                currentColumn++;
            }


            currentRow++;
        }


        for (int i = 0; i < row; i++)
        {

            for (int j = 0; j < column; j++)
            {
                Console.Write(Grid[i, j]);

            }
            Console.WriteLine("");
        }
    }

    public static void CheckIfOuter(int i, int j)
    {

    }

    public static void Check(int i, int j)
    {
        if (currentPosition == (0, 0))
        {

        }
    }

    //1 = firstConer, 2 = second coner and so on
    public static void GetNextPosition(int corner)
    {

        int lowestVal;

        (int, int) lowestPos = (Pos.Item1, Pos.Item2 + 1);

        List<(int, int)> LowestList = new List<(int, int)>();
        if (Pos.Item1 == 0)
        {

            if (corner != 1)
            {
                lowestVal = GetRightPos();
            }
            else if (corner == 1)
            {

                if (GetLeft() < lowestVal)
                {
                    lowestPos = GetLeftPos();
                }
                else if (GetLeft() == lowestVal)
                {
                    LowestList.Add(GetLeftPos());
                }
            }
            else
            {
                if (GetRight() < lowestVal)
                {
                    lowestPos = GetRightPos();
                }
                else if (GetRight() == lowestVal)
                {
                    LowestList.Add(GetRightPos());
                }
                if (GetLeft() < lowestVal)
                {
                    lowestPos = GetLeftPos();
                }
                else if (GetLeft() == lowestVal)
                {
                    LowestList.Add(GetLeftPos());
                }
                lowestPos = GetRight() < lowestVal ? GetRightPos() : lowestPos;
                lowestPos = GetLeft() < lowestVal ? GetLeftPos() : lowestPos;
            }
            lowestPos = GetDown() < lowestVal ? GetDownPos() : lowestPos;
        }
        else if (Pos.Item1 == 9)
        {
            if (corner == 2)
            {
                lowestPos = GetRight() < lowestVal ? GetRightPos() : lowestPos;
            }
            else if (corner == 3)
            {
                lowestPos = GetLeft() < lowestVal ? GetLeftPos() : lowestPos;
            }
            else
            {
                lowestPos = GetRight() < lowestVal ? GetRightPos() : lowestPos;
                lowestPos = GetLeft() < lowestVal ? GetLeftPos() : lowestPos;
            }
            lowestPos = GetUp() < lowestVal ? GetDownPos() : lowestPos;
        }
        else if (Pos.Item2 == 0)
        {
            lowestPos = GetRight() < lowestVal ? GetRightPos() : lowestPos;
            lowestPos = GetUp() < lowestVal ? GetUpPos() : lowestPos;
            lowestPos = GetDown() < lowestVal ? GetDownPos() : lowestPos;

        }
        else if (Pos.Item2 == 9)
        {
            lowestPos = GetLeft() < lowestVal ? GetLeftPos() : lowestPos;
            lowestPos = GetUp() < lowestVal ? GetUpPos() : lowestPos;
            lowestPos = GetDown() < lowestVal ? GetDownPos() : lowestPos;
        }
        else
        {
            lowestPos = GetLeft() < lowestVal ? GetLeftPos() : lowestPos;
            lowestPos = GetUp() < lowestVal ? GetUpPos() : lowestPos;
            lowestPos = GetDown() < lowestVal ? GetDownPos() : lowestPos;
            lowestPos = GetRight() < lowestVal ? GetRightPos() : lowestPos;
        }
    }

    public static int GetUp()
    {
        return Grid[Pos.Item1, Pos.Item2 - 1];
    }

    public static int GetDown()
    {
        return Grid[Pos.Item1, Pos.Item2 + 1];
    }

    public static int GetLeft()
    {
        return Grid[Pos.Item1 - 1, Pos.Item2];
    }

    public static int GetRight()
    {
        return Grid[Pos.Item1 + 1, Pos.Item2];
    }

    public static (int, int) GetUpPos()
    {
        return (Pos.Item1, Pos.Item2 - 1);
    }

    public static (int, int) GetDownPos()
    {
        return (Pos.Item1, Pos.Item2 + 1);
    }

    public static (int, int) GetLeftPos()
    {
        return (Pos.Item1 - 1, Pos.Item2);
    }

    public static (int, int) GetRightPos()
    {
        return (Pos.Item1 + 1, Pos.Item2);
    }
}
public class Program
{
    static int column;
    static int row;

    static string[,] Grid;

    static List<(string, int)> coords = new List<(string, int)>();

    static int total = 0;

    static int maxY = 0;

    static int maxX = 0;





    public static void Main()
    {
        foreach (var item in System.IO.File.ReadLines(@"../input.txt"))
        {
            if (string.IsNullOrEmpty(item))
            {
                break;
            }
            string[] line = item.Split(",");

            var tmpx = Int32.Parse(line[0]);
            var tmpy = Int32.Parse(line[1]);
            if (tmpx > maxX)
            {
                maxX = tmpx;
            }

            if (tmpy > maxY)
            {
                maxY = tmpy;
            }
        }
        column = maxX + 1;
        row = maxY + 1;

        Console.WriteLine(column);
        Console.WriteLine(row);

        Grid = new string[row, column];

        foreach (var item in System.IO.File.ReadLines(@"../input.txt"))
        {
            if (item.Contains("fold"))
            {
                string[] coord = item.Split(" ");
                string[] tmp = coord[2].Split("=");

                if (tmp[0] == "y")
                {
                    coords.Add(("y", Int32.Parse(tmp[1])));
                }
                else
                {
                    coords.Add(("x", Int32.Parse(tmp[1])));
                }
            }
            else if (!string.IsNullOrEmpty(item))
            {

                string[] line = item.Split(",");

                //var index = (Int32.Parse(line[1]) * 11) + Int32.Parse(line[0]);

                Grid[Int32.Parse(line[1]), (Int32.Parse(line[0]))] = "#";


            }

        }

        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < column; j++)
            {
                if (Grid[i, j] == null)
                {
                    Grid[i, j] = ".";
                }

            }
        }


        foreach (var item in coords)
        {
            if(item.Item1=="x"){
                FoldX(item.Item2);
            } else {
                FoldY(item.Item2);
            }
        }
        // FoldY(coords.ElementAt(0).Item2);
        // Console.WriteLine(coords.ElementAt(0).Item2);
        // FoldX(coords.ElementAt(0).Item2);

        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < column; j++)
            {
                Console.Write(Grid[i, j]);
                // if (Grid[i, j] == "#")
                // {
                //     total++;
                // }

            }
            Console.WriteLine(" ");
        }

        //Console.WriteLine(total);

    }

    public static void LoadDifference(string[,] tmpArray)
    {
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < column; j++)
            {
                if (tmpArray[i, j] == "#")
                {
                    Grid[i, j] = "#";
                }
            }
        }

    }
    public static void FoldX(int x)
    {
        int tmpCollumn = column - (x+1);
        column = x ;
        Console.WriteLine(column + " " + tmpCollumn);
        string[,] tmpArray = new string[row, tmpCollumn];
        string[,] newArray = new string[row, column];
        int columnStart = column + 1;

        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < column; j++)
            {
                tmpArray[i, j] = Grid[i, columnStart];
                newArray[i, j] = Grid[i, j];
                columnStart++;
            }
            columnStart = column + 1;
        }

        tmpArray = FlipX(tmpArray);


        Grid = newArray;


        // for (int i = 0; i < row; i++)
        // {
        //     for (int j = 0; j < column; j++)
        //     {
        //         Console.Write(Grid[i, j]);

        //     }
        //     Console.WriteLine(" ");
        // }

        // Console.WriteLine(" ");
        // Console.WriteLine(" ");
        // for (int i = 0; i < row; i++)
        // {
        //     for (int j = 0; j < column; j++)
        //     {
        //         Console.Write(tmpArray[i, j]);

        //     }
        //     Console.WriteLine(" ");
        // }

        LoadDifference(tmpArray);
    }

    public static void FoldY(int y)
    {
        row = row - (y+1);
        string[,] tmpArray = new string[row, column];
        string[,] newArray = new string[row, column];
        int startIndex = row + 1;

        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < column; j++)
            {
                tmpArray[i, j] = Grid[startIndex, j];
                newArray[i, j] = Grid[i, j];
            }
            startIndex++;
        }

        tmpArray = FlipY(tmpArray);


        Grid = newArray;

        // for (int i = 0; i < row; i++)
        // {
        //     for (int j = 0; j < column; j++)
        //     {
        //         Console.Write(Grid[i,j]);

        //     }
        //     Console.WriteLine(" ");
        // }

        // Console.WriteLine(" ");
        // Console.WriteLine(" ");
        // for (int i = 0; i < row; i++)
        // {
        //     for (int j = 0; j < column; j++)
        //     {
        //         Console.Write(tmpArray[i,j]);

        //     }
        //     Console.WriteLine(" ");
        // }

        LoadDifference(tmpArray);
    }


    public static string[,] FlipX(string[,] array)
    {
        string[,] flip = new string[row, column];
        int startcolumn = column - 1;

        //Console.WriteLine(row);

        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < column; j++)
            {
                flip[i, j] = array[i, startcolumn];
                startcolumn--;
            }

            startcolumn = column - 1;
        }
        return flip;
    }

    public static string[,] FlipY(string[,] array)
    {
        string[,] flip = new string[row, column];
        int startRow = row - 1;

        //Console.WriteLine(row);

        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < column; j++)
            {
                flip[i, j] = array[startRow, j];
            }
            startRow--;
        }
        return flip;

    }

}



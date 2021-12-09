public class Program
{
    static string[]? NumbersToBeDrawn;

    static Board board = new Board();

    static List<Board> boards = new List<Board>();

    static int numberOfBoards = 0;

    static bool[]? wins;

    static bool bingo = false;
    public static void Main()
    {
        bool first = true;
        int fullBoard = 0;
        foreach (var item in System.IO.File.ReadLines(@"../input.txt"))
        {
            if (first)
            {
                string[] line = item.Split(',');
                NumbersToBeDrawn = new string[line.Length];
                NumbersToBeDrawn = line;
                first = false;
            }
            else
            {
                board.populate(item);
                fullBoard++;
                if (fullBoard == 6)
                {
                    board.setBoardnumber(numberOfBoards);
                    boards.Add(board);

                    numberOfBoards++;

                    board = new Board();
                    fullBoard = 0;
                }
            }           //string[] line = item.Split(',');
        }
        wins = new bool[boards.Count];
        for (int i = 0; i < boards.Count; i++)
        {
            boards.ElementAt(i).Print();
        }

        Console.WriteLine("Number Of boards: " + numberOfBoards);

        bingo = checkBingo();
    }

    public static bool checkBingo()
    {
        List<Board> bingoelement = new List<Board>();
        for (int i = 0; i < NumbersToBeDrawn.Length; i++)
        {
            Console.WriteLine("Number To be Drawn: " + NumbersToBeDrawn.ElementAt(i));
            for (int j = 0; j < boards.Count; j++)
            {
                Console.WriteLine("Board nummer {0}:", boards.ElementAt(j).getBoardnumber());
                bingo = boards.ElementAt(j).DrawNumbers(Convert.ToInt32(NumbersToBeDrawn.ElementAt(i)));

                Console.WriteLine("Program: " + bingo);

                if (bingo)
                {
                    if (boards.Count > 1)
                    {
                        Console.WriteLine("Bingo therefore remove board: " + boards.ElementAt(j).getBoardnumber());
                        Console.WriteLine("index: " + j);
                        bingoelement.Add(boards.ElementAt(j));


                    }
                    else
                    {

                        Console.WriteLine("Bingo");
                        boards.ElementAt(j).Print();
                        int tmp = boards.ElementAt(j).getSumOfUnmarked();
                        Console.WriteLine("Sum: " + Convert.ToInt32(NumbersToBeDrawn.ElementAt(i)) * tmp);
                        return bingo;
                    }

                }

            }
            if (bingoelement.Any())
            {
                Console.WriteLine("Removing board number: " + bingoelement.ElementAt(0).getBoardnumber());
                boards.RemoveAll(bingoelement.Contains);
                bingoelement.RemoveRange(0, bingoelement.Count);
            }
        }
        return bingo;
    }
}
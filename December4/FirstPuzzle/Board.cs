
public class Board
{
    List<Node> boardNumbers;

    int boardsNumber;
    bool bingo;
    public Board()
    {
        this.boardNumbers = new List<Node>();
        this.bingo = false;

    }

    public void setBoardnumber(int number)
    {
        this.boardsNumber = number;
    }
    public int getBoardnumber()
    {
        return boardsNumber;
    }
    public void populate(string stringOfNodes)
    {

        string[] line = stringOfNodes.Split(' ');
        foreach (var item in line)
        {
            if (item.Any())
            {
                //Console.WriteLine(item);
                Node node = new Node(Convert.ToInt32(item));

                Console.WriteLine("The Node being added:" + node.drawn + " " + node.number);
                boardNumbers.Add(node);
            }
        }
    }

    public bool DrawNumbers(int number)
    {

        for (int i = 0; i < boardNumbers.Count; i++)
        {
            if (boardNumbers.ElementAt(i).number == number)
            {
                Console.WriteLine("The Number that is drawn: " + number + "does exist?");
                boardNumbers.ElementAt(i).NodeIsDrawn();
                Console.WriteLine(boardNumbers.ElementAt(i).drawn);

                bool row = checkRows();
                Console.WriteLine("Row bingo?: " + row);
                bool col = checkCol();
                Console.WriteLine("col bingo?: " + col);


                if (row || col)
                {
                    bingo = true;
                    return bingo;
                }
            }
        }
        return bingo;
    }

    public bool checkRows()
    {
        bool tmpBingo = true;
        int rowEnd = 0;
        Console.WriteLine("Checking rows:" + boardNumbers.Count);
        for (int i = 0; i < boardNumbers.Count; i++)
        {
            //Console.WriteLine("Number: " + boardNumbers.ElementAt(i).number);
            //Console.WriteLine(boardNumbers.ElementAt(i).drawn);
            Console.WriteLine("{0} Number at row", boardNumbers.ElementAt(i).number);
            if (!boardNumbers.ElementAt(i).drawn)
            {
                Console.WriteLine("row: {0} Number not drawn", boardNumbers.ElementAt(i).number);
                tmpBingo = false;
            }


            rowEnd++;
            if (rowEnd == 5)
            {
                Console.WriteLine("TempBingo: " + tmpBingo);
                Console.WriteLine(" ");
                if (tmpBingo)
                {
                    bingo = tmpBingo;
                    return bingo;
                } 

                tmpBingo = true;


                rowEnd = 0;
            }

        }
        return bingo;

    }



    public bool checkCol()
    {
        bool tmpBingo = true;
        int colEnd = 0;
        Console.WriteLine("Checking col:" + boardNumbers.Count);
        for (int t = 0; t < 5; t++)
        {
            Console.WriteLine("Col start index: " + t);
            for (int i = t; i < boardNumbers.Count; i += 5)
            {
                if (!boardNumbers.ElementAt(i).drawn)
                {
                    Console.WriteLine("col: {0} Number not drawn", boardNumbers.ElementAt(i).number);
                    tmpBingo = false;
                }
                Console.WriteLine("{0} Number at column", boardNumbers.ElementAt(i).number);
                colEnd++;
                if (colEnd == 5)
                {
                    Console.WriteLine(" ");
                    if (tmpBingo)
                    {
                        bingo = tmpBingo;
                        return bingo;

                    }

                    tmpBingo = true;

                    colEnd = 0;

                }
            }
        }
        return bingo;
    }

    public bool Bingo()
    {
        return bingo;
    }

    public void Print()
    {
        Console.WriteLine("Printing Board");
        for (int i = 0; i < boardNumbers.Count(); i++)
        {

            if (i % 5 == 0)
            {
                Console.WriteLine(" ");

            }

            Console.Write(boardNumbers.ElementAt(i).number + " ");

        }
        Console.WriteLine(" ");
    }

    public void PrintDrawn()
    {
        Console.WriteLine("Printing Drawn Board");
        for (int i = 0; i < boardNumbers.Count(); i++)
        {

            if (i % 5 == 0)
            {
                Console.WriteLine(" ");

            }

            Console.Write(boardNumbers.ElementAt(i).drawn + " ");

        }
        Console.WriteLine(" ");
    }

    public int getSumOfUnmarked()
    {
        int sum = 0;
        for (int i = 0; i < boardNumbers.Count; i++)
        {
            if (!boardNumbers.ElementAt(i).drawn)
            {
                sum += boardNumbers.ElementAt(i).number;
            }
        }
        return sum;
    }

    // public bool checkColumn()
    // {
    //     int startCount = 0;

    // }
}
public class Program
{
    //1= start row, 2= mid row, 3= end row
    static (int, bool, int)[] grid = new (int, bool, int)[100];

    // adjacentFields = { -11, -10, -9, -1, 1, 9, 10, 11 };

    public static int flashes = 0;

    public static void Main()
    {
        int index = 0;
        int row = 0;
        foreach (var item in System.IO.File.ReadLines(@"../input.txt"))
        {
            row = 0;
            foreach (var ele in item)
            {
                var nb = ele.ToString();
                if (row == 0)
                {
                    grid[index] = (int.Parse(nb), false, 1);

                }
                else if (row == 9)
                {
                    grid[index] = (int.Parse(nb), false, 3);

                }
                else
                {
                    grid[index] = (int.Parse(nb), false, 2);
                }
                row++;
                index++;
            }
        }



        SimulateSteps();

        // for (int i = 0; i < grid.Length; i++)
        // {
        //     if (grid[i].Item3 == 1)
        //     {
        //         Console.WriteLine(i + " Start Row" + grid[i]);
        //     }
        //     else if (grid[i].Item3 == 2)
        //     {
        //         Console.WriteLine(i + " Mid Row" + grid[i]);
        //     }
        //     else if (grid[i].Item3 == 3)
        //     {
        //         Console.WriteLine(i + " End Row" + grid[i]);
        //         Console.WriteLine();
        //     }
        // }

        //Console.WriteLine(flashes);

    }


    public static void SimulateSteps()
    {
        int step = 0;
        while (!ResetVisit())
        {
            IncreaseEnergy();
            CheckForFlash();
            step++;
        }

        Console.WriteLine("Synchornized!! at step: " + step);
        // for (int j = 0; j < 200; j++)
        // {

        //     IncreaseEnergy();
        //     CheckForFlash();
        // if ((j+1) == 195)
        // {
        //     Console.WriteLine("After step: " + (j + 1));

        //     for (int i = 0; i < grid.Length; i++)
        //     {
        //         if (grid[i].Item3 == 3)
        //         {
        //             Console.Write(grid[i].Item1 + " " + grid[i].Item2);
        //             Console.WriteLine();
        //         }
        //         else
        //         {
        //             Console.Write(grid[i].Item1 + " " + grid[i].Item2 + " ");
        //         }
        //     }
        // }
        // if(ResetVisit()){
        //     Console.WriteLine("Synchornized!! at step: " + (j+1));
        //     break;
        // }

        // }
    }


    public static void IncreaseEnergy()
    {
        for (int i = 0; i < grid.Length; i++)
        {
            grid[i].Item1 = grid[i].Item1 + 1;
        }
    }



    public static void CheckForFlash()
    {
        for (int i = 0; i < grid.Length; i++)
        {
            if (grid[i].Item1 > 9 && grid[i].Item2 == false)
            {
                grid[i] = (0, true, grid[i].Item3);
                flashes++;

                FlashAdjacent(i);
            }
        }
    }

    public static bool ResetVisit()
    {
        int synconized = 0;
        for (int i = 0; i < grid.Length; i++)
        {
            if (grid[i].Item2)
            {
                synconized++;
            }
            grid[i].Item2 = false;
        }


        if (synconized == grid.Length)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public static void FlashAdjacent(int i)
    {
        if (i < 10)
        {
            if (grid[i].Item3 == 1)
            {
                grid[i + 1].Item1 = grid[i + 1].Item2 ? grid[i + 1].Item1 : grid[i + 1].Item1 + 1;
                grid[i + 10].Item1 = grid[i + 10].Item2 ? grid[i + 10].Item1 : grid[i + 10].Item1 + 1;
                grid[i + 11].Item1 = grid[i + 11].Item2 ? grid[i + 11].Item1 : grid[i + 11].Item1 + 1;

            }
            else if (grid[i].Item3 == 3)
            {
                grid[i - 1].Item1 = grid[i - 1].Item2 ? grid[i - 1].Item1 : grid[i - 1].Item1 + 1;
                grid[i + 9].Item1 = grid[i + 9].Item2 ? grid[i + 9].Item1 : grid[i + 9].Item1 + 1;
                grid[i + 11].Item1 = grid[i + 11].Item2 ? grid[i + 11].Item1 : grid[i + 11].Item1 + 1;
            }
            else
            {
                grid[i - 1].Item1 = grid[i - 1].Item2 ? grid[i - 1].Item1 : grid[i - 1].Item1 + 1;
                grid[i + 1].Item1 = grid[i + 1].Item2 ? grid[i + 1].Item1 : grid[i + 1].Item1 + 1;
                grid[i + 9].Item1 = grid[i + 9].Item2 ? grid[i + 9].Item1 : grid[i + 9].Item1 + 1;
                grid[i + 10].Item1 = grid[i + 10].Item2 ? grid[i + 10].Item1 : grid[i + 10].Item1 + 1;
                grid[i + 11].Item1 = grid[i + 11].Item2 ? grid[i + 11].Item1 : grid[i + 11].Item1 + 1;

            }
        }
        else if (89 < i && i < 100)
        {
            if (grid[i].Item3 == 1)
            {
                grid[i - 10].Item1 = grid[i - 10].Item2 ? grid[i - 10].Item1 : grid[i - 10].Item1 + 1;
                grid[i - 9].Item1 = grid[i - 9].Item2 ? grid[i - 9].Item1 : grid[i - 9].Item1 + 1;
                grid[i + 1].Item1 = grid[i + 1].Item2 ? grid[i + 1].Item1 : grid[i + 1].Item1 + 1;
            }
            else if (grid[i].Item3 == 3)
            {


                grid[i - 11].Item1 = grid[i - 11].Item2 ? grid[i - 11].Item1 : grid[i - 11].Item1 + 1;
                grid[i - 10].Item1 = grid[i - 10].Item2 ? grid[i - 10].Item1 : grid[i - 10].Item1 + 1;
                grid[i - 1].Item1 = grid[i - 1].Item2 ? grid[i - 1].Item1 : grid[i - 1].Item1 + 1;
            }
            else
            {
                grid[i - 11].Item1 = grid[i - 11].Item2 ? grid[i - 11].Item1 : grid[i - 11].Item1 + 1;
                grid[i - 10].Item1 = grid[i - 10].Item2 ? grid[i - 10].Item1 : grid[i - 10].Item1 + 1;
                grid[i - 9].Item1 = grid[i - 9].Item2 ? grid[i - 9].Item1 : grid[i - 9].Item1 + 1;
                grid[i - 1].Item1 = grid[i - 1].Item2 ? grid[i - 1].Item1 : grid[i - 1].Item1 + 1;
                grid[i + 1].Item1 = grid[i + 1].Item2 ? grid[i + 1].Item1 : grid[i + 1].Item1 + 1;
            }
        }
        else
        {
            if (grid[i].Item3 == 1)
            {
                grid[i - 10].Item1 = grid[i - 10].Item2 ? grid[i - 10].Item1 : grid[i - 10].Item1 + 1;
                grid[i - 9].Item1 = grid[i - 9].Item2 ? grid[i - 9].Item1 : grid[i - 9].Item1 + 1;
                grid[i + 1].Item1 = grid[i + 1].Item2 ? grid[i + 1].Item1 : grid[i + 1].Item1 + 1;
                grid[i + 10].Item1 = grid[i + 10].Item2 ? grid[i + 10].Item1 : grid[i + 10].Item1 + 1;
                grid[i + 11].Item1 = grid[i + 11].Item2 ? grid[i + 11].Item1 : grid[i + 11].Item1 + 1;
            }
            else if (grid[i].Item3 == 3)
            {
                grid[i - 11].Item1 = grid[i - 11].Item2 ? grid[i - 11].Item1 : grid[i - 11].Item1 + 1;
                grid[i - 10].Item1 = grid[i - 10].Item2 ? grid[i - 10].Item1 : grid[i - 10].Item1 + 1;
                grid[i - 1].Item1 = grid[i - 1].Item2 ? grid[i - 1].Item1 : grid[i - 1].Item1 + 1;
                grid[i + 9].Item1 = grid[i + 9].Item2 ? grid[i + 9].Item1 : grid[i + 9].Item1 + 1;
                grid[i + 10].Item1 = grid[i + 10].Item2 ? grid[i + 10].Item1 : grid[i + 10].Item1 + 1;
            }
            else
            {
                grid[i - 11].Item1 = grid[i - 11].Item2 ? grid[i - 11].Item1 : grid[i - 11].Item1 + 1;
                grid[i - 10].Item1 = grid[i - 10].Item2 ? grid[i - 10].Item1 : grid[i - 10].Item1 + 1;
                grid[i - 9].Item1 = grid[i - 9].Item2 ? grid[i - 9].Item1 : grid[i - 9].Item1 + 1;
                grid[i - 1].Item1 = grid[i - 1].Item2 ? grid[i - 1].Item1 : grid[i - 1].Item1 + 1;
                grid[i + 1].Item1 = grid[i + 1].Item2 ? grid[i + 1].Item1 : grid[i + 1].Item1 + 1;
                grid[i + 9].Item1 = grid[i + 9].Item2 ? grid[i + 9].Item1 : grid[i + 9].Item1 + 1;
                grid[i + 10].Item1 = grid[i + 10].Item2 ? grid[i + 10].Item1 : grid[i + 10].Item1 + 1;
                grid[i + 11].Item1 = grid[i + 11].Item2 ? grid[i + 11].Item1 : grid[i + 11].Item1 + 1;
            }
        }
        CheckForFlash();
    }

    // public static void FlashAdjacent(int i)
    // {
    //     if (i < 10)
    //     {
    //         if (grid[i].Item3 == 1)
    //         {
    //             grid[i + 1].Item1 = grid[i + 1].Item2 ? grid[i + 1].Item1 : grid[i + 1].Item1 + 1;
    //             grid[i + 10].Item1 = grid[i + 10].Item2 ? grid[i + 10].Item1 : grid[i + 10].Item1 + 1;
    //             grid[i + 11].Item1 = grid[i + 11].Item2 ? grid[i + 11].Item1 : grid[i + 11].Item1 + 1;

    //         }
    //         else if (grid[i].Item3 == 3)
    //         {
    //             grid[i - 1].Item1 = grid[i - 1].Item2 ? grid[i - 1].Item1 : grid[i - 1].Item1 + 1;
    //             grid[i + 9].Item1 = grid[i + 9].Item2 ? grid[i + 9].Item1 : grid[i + 9].Item1 + 1;
    //             grid[i + 11].Item1 = grid[i + 11].Item2 ? grid[i + 11].Item1 : grid[i + 11].Item1 + 1;
    //         }
    //         else
    //         {
    //             grid[i - 1].Item1 = grid[i - 1].Item2 ? grid[i - 1].Item1 : grid[i - 1].Item1 + 1;
    //             grid[i + 1].Item1 = grid[i + 1].Item2 ? grid[i + 1].Item1 : grid[i + 1].Item1 + 1;
    //             grid[i + 9].Item1 = grid[i + 9].Item2 ? grid[i + 9].Item1 : grid[i + 9].Item1 + 1;
    //             grid[i + 10].Item1 = grid[i + 10].Item2 ? grid[i + 10].Item1 : grid[i + 10].Item1 + 1;
    //             grid[i + 11].Item1 = grid[i + 11].Item2 ? grid[i + 11].Item1 : grid[i + 11].Item1 + 1;

    //         }
    //     }
    //     else if (89 < i && i < 100)
    //     {
    //         if (grid[i].Item3 == 1)
    //         {
    //             grid[i - 10].Item1 = grid[i - 10].Item2 ? grid[i - 10].Item1 : grid[i - 10].Item1 + 1;
    //             grid[i - 9].Item1 = grid[i - 9].Item2 ? grid[i - 9].Item1 : grid[i - 9].Item1 + 1;
    //             grid[i + 1].Item1 = grid[i + 1].Item2 ? grid[i + 1].Item1 : grid[i + 1].Item1 + 1;
    //         }
    //         else if (grid[i].Item3 == 3)
    //         {


    //             grid[i - 11].Item1 = grid[i - 11].Item2 ? grid[i - 11].Item1 : grid[i - 11].Item1 + 1;
    //             grid[i - 10].Item1 = grid[i - 10].Item2 ? grid[i - 10].Item1 : grid[i - 10].Item1 + 1;
    //             grid[i - 1].Item1 = grid[i - 1].Item2 ? grid[i - 1].Item1 : grid[i - 1].Item1 + 1;
    //         }
    //         else
    //         {
    //             grid[i - 11].Item1 = grid[i - 11].Item2 ? grid[i - 11].Item1 : grid[i - 11].Item1 + 1;
    //             grid[i - 10].Item1 = grid[i - 10].Item2 ? grid[i - 10].Item1 : grid[i - 10].Item1 + 1;
    //             grid[i - 9].Item1 = grid[i - 9].Item2 ? grid[i - 9].Item1 : grid[i - 9].Item1 + 1;
    //             grid[i - 1].Item1 = grid[i - 1].Item2 ? grid[i - 1].Item1 : grid[i - 1].Item1 + 1;
    //             grid[i + 1].Item1 = grid[i + 1].Item2 ? grid[i + 1].Item1 : grid[i + 1].Item1 + 1;
    //         }
    //     }
    //     else
    //     {
    //         if (grid[i].Item3 == 1)
    //         {
    //             grid[i - 10].Item1 = grid[i - 10].Item2 ? grid[i - 10].Item1 : grid[i - 10].Item1 + 1;
    //             grid[i - 9].Item1 = grid[i - 9].Item2 ? grid[i - 9].Item1 : grid[i - 9].Item1 + 1;
    //             grid[i + 1].Item1 = grid[i + 1].Item2 ? grid[i + 1].Item1 : grid[i + 1].Item1 + 1;
    //             grid[i + 10].Item1 = grid[i + 10].Item2 ? grid[i + 10].Item1 : grid[i + 10].Item1 + 1;
    //             grid[i + 11].Item1 = grid[i + 11].Item2 ? grid[i + 11].Item1 : grid[i + 11].Item1 + 1;
    //         }
    //         else if (grid[i].Item3 == 3)
    //         {
    //             grid[i - 11].Item1 = grid[i - 11].Item2 ? grid[i - 11].Item1 : grid[i - 11].Item1 + 1;
    //             grid[i - 10].Item1 = grid[i - 10].Item2 ? grid[i - 10].Item1 : grid[i - 10].Item1 + 1;
    //             grid[i - 1].Item1 = grid[i - 1].Item2 ? grid[i - 1].Item1 : grid[i - 1].Item1 + 1;
    //             grid[i + 9].Item1 = grid[i + 9].Item2 ? grid[i + 9].Item1 : grid[i + 9].Item1 + 1;
    //             grid[i + 10].Item1 = grid[i + 10].Item2 ? grid[i + 10].Item1 : grid[i + 10].Item1 + 1;
    //         }
    //         else
    //         {
    //             grid[i - 11].Item1 = grid[i - 11].Item2 ? grid[i - 11].Item1 : grid[i - 11].Item1 + 1;
    //             grid[i - 10].Item1 = grid[i - 10].Item2 ? grid[i - 10].Item1 : grid[i - 10].Item1 + 1;
    //             grid[i - 9].Item1 = grid[i - 9].Item2 ? grid[i - 9].Item1 : grid[i - 9].Item1 + 1;
    //             grid[i - 1].Item1 = grid[i - 1].Item2 ? grid[i - 1].Item1 : grid[i - 1].Item1 + 1;
    //             grid[i + 1].Item1 = grid[i + 1].Item2 ? grid[i + 1].Item1 : grid[i + 1].Item1 + 1;
    //             grid[i + 9].Item1 = grid[i + 9].Item2 ? grid[i + 9].Item1 : grid[i + 9].Item1 + 1;
    //             grid[i + 10].Item1 = grid[i + 10].Item2 ? grid[i + 10].Item1 : grid[i + 10].Item1 + 1;
    //             grid[i + 11].Item1 = grid[i + 11].Item2 ? grid[i + 11].Item1 : grid[i + 11].Item1 + 1;
    //         }
    //     }
    //     CheckForFlash();
    // }
}

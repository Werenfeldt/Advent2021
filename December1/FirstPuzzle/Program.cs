//First puzzle
int numberOfIncreases = 0;

int PreviousInt = 0;

bool FirstItem = true;

foreach (var item in System.IO.File.ReadLines(@"../input.txt"))
{
    if (FirstItem)
    {
        PreviousInt = int.Parse(item);
        FirstItem = false;
    }
    else
    {
        var CurrentInt = int.Parse(item);

        if (CurrentInt > PreviousInt)
        {
            numberOfIncreases++;
        }

        PreviousInt = CurrentInt;
    }
}

Console.WriteLine(numberOfIncreases);

string gamma = "";
string epilon = "";



List<string> list = new List<string>();

foreach (var item in System.IO.File.ReadLines(@"../input.txt"))
{
    list.Add(item);
}


for (int i = 0; i < 12; i++)
{

    int numberOfOnes = 0;
    int numberOfZeros = 0;
    for (int j = 0; j < list.Count; j++)
    {
        var tmp = list.ElementAt(j);
        var number = tmp.Substring(i, 1);
        if (number == "0")
        {
            numberOfZeros++;
        }
        else
        {
            numberOfOnes++;
        }

    }
    if (numberOfOnes > numberOfZeros)
    {
        gamma += "1";
        epilon += "0";
    }
    else
    {
        gamma += "0";
        epilon += "1";
    }
}

Console.WriteLine(Convert.ToInt32(gamma, 2) * Convert.ToInt32(epilon, 2));

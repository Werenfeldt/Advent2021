
int horizontal = 0;
int depth = 0;
int aim = 0;
foreach (var item in System.IO.File.ReadLines(@"../input.txt"))
{
    string[] line = item.Split(' ');


    switch (line[0])
    {
        case "forward":
            int horIncrease = int.Parse(line[1]);
            horizontal += horIncrease;
            if (aim != 0)
            {
                int increase = horIncrease * aim;
                depth += increase;
            }
            break;
        case "down":
            aim += int.Parse(line[1]);
            break;
        case "up":
            aim -= int.Parse(line[1]);
            break;
        default:
            break;
    }
}

Console.WriteLine(horizontal * depth);



public class Program
{
    //False is horizontal
    //True is vertical
    static List<Vector> vectors = new List<Vector>();

    static Vector vector = new Vector();

    static List<string> AllPoints = new List<string>();

    static int NumberOfDub = 0;
    public static void Main()
    {


        foreach (var item in System.IO.File.ReadLines(@"../test.txt"))
        {
            string[] line = item.Split(" -> ");

            bool firstCoord = true;
            foreach (var ele in line)
            {

                string[] coor = ele.Split(",");

                if (firstCoord)
                {
                    vector.CoordOne = (Convert.ToInt32(coor[0]), Convert.ToInt32(coor[1]));
                    firstCoord = false;
                }
                else
                {
                    vector.CoordTwo = (Convert.ToInt32(coor[0]), Convert.ToInt32(coor[1]));
                    firstCoord = true;
                    //Console.WriteLine("V: CoordOne {0}, CoordTwo {1}", vector.CoordOne, vector.CoordTwo);
                    
                    vectors.Add(vector);
                    vector = new Vector();
                }

            }
        }
        // foreach (var vector in vectors)
        // {
        //     Console.WriteLine("Direction: {0}", vector.Direction);

        // }

        LoadVectors();

        FindDublicates();

        Console.WriteLine(NumberOfDub);
    }

    public static void LoadVectors()
    {
        foreach (var item in vectors)
        {
            AllPoints.AddRange(item.getPoints());
        }
    }

    public static void FindDublicates()
    {
        List<string> tmpList = new List<string>();

        foreach (var item in AllPoints)
        {
            if(!tmpList.Contains(item)){
                tmpList.Add(item);
            } else {
                NumberOfDub++;
            }
        }

    }
}


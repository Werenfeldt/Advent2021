using System.Linq;
public class Program
{

    //static List<((string, bool, bool)> PathBuilder = new List<((string, bool, bool))>();

    //name, name, visites
    //static Node[] PathIndex = new Node[20];

    static List<Node> PathIndex = new List<Node>();

    static Node[]? Path;

    static List<string> PathString = new List<string>();

    static string tmpPath = "";

    //name, is uppercase, has been visited  
    //static Node node;

    public static void Main()
    {
        //int pathIndex = 0;

        foreach (var item in System.IO.File.ReadLines(@"../test.txt"))
        {
            string[] line = item.Split("-");

            Node firstNode;
            Node secondNode;

            if (line[0] == "start" || !line[0].Any(char.IsUpper) || line[0] == "end")
            {
                firstNode = new Node(line[0], false, false);
            }
            else
            {
                firstNode = new Node(line[0], true, false);
            }

            if (line[1] == "start" || !line[1].Any(char.IsUpper) || line[1] == "end")
            {
                secondNode = new Node(line[1], false, false);
            }
            else
            {
                secondNode = new Node(line[1], true, false);
            }


            if (!PathIndex.Exists(x => x.Name == firstNode.Name))
            {
                // PathIndex[pathIndex] = firstNode;
                // pathIndex++;
                //Console.WriteLine("Does not contain: " + firstNode.Name);
                if (firstNode.Name != "end")
                {

                    firstNode.AddPointsAtNode(secondNode);
                    PathIndex.Add(firstNode);
                }

            }
            else
            {

                //Console.WriteLine("Does contain: " + firstNode.Name);
                PathIndex.Find(x => x.Name == firstNode.Name).AddPointsAtNode(secondNode);
            }

            if (!PathIndex.Exists(x => x.Name == secondNode.Name))
            {
                // PathIndex[pathIndex] = secondNode;
                // pathIndex++;
                //Console.WriteLine("Does not contain: " + secondNode.Name);



                if (firstNode.Name != "start")
                {
                    secondNode.AddPointsAtNode(firstNode);
                }
                if (secondNode.Name != "end")
                {
                    PathIndex.Add(secondNode);
                }
            }
            else
            {
                if (firstNode.Name != "start")
                {

                    PathIndex.Find(x => x.Name == secondNode.Name).AddPointsAtNode(firstNode);
                }
                //Console.WriteLine("Does contain: " + secondNode.Name);
            }

            Path = PathIndex.ToArray();

        }

        // if (CanVisitNode(0))
        // {
        //     VisitNode(0);
        // }

        //while (!CanVisitNode(PathIndex.ElementAt(0))) ;

        CanVisitNode(PathIndex.ElementAt(0));

        PathString.Add(tmpPath);

        if (PathString != null)
        {

            foreach (var node in PathString)
            {
                Console.WriteLine(node);

            }
        }

        // if (Path != null)
        // {

        //     foreach (var node in Path)
        //     {
        //         node.PrintInfo();

        //     }
        // }
    }

    public static void CanVisitNode(Node node)
    {
        if (node.Uppercase && node.Visited || !node.Visited)
        {
            Console.WriteLine("This node can be visited: " + node.Name);
            VisitNode(node);
            //return true;
        }
        else
        {
            //return false;
        }
    }

    public static void VisitNode(Node node)
    {
        Console.WriteLine("This node has been visited: " + node.Name);
        node.Visited = true;
        AddToPath(node);
    }


    public static void AddToPath(Node node)
    {
        if (visitEle == -1)
        {

            visitEle++;
        }
        Console.WriteLine(visitEle);
        tmpPath += node.Name;
        if (node.Name != "end")
        {
            if (!node.PointsAt.ElementAt(visitEle).Visited)
            {
                Console.WriteLine("hej");

                Console.WriteLine("This node points at: " + node.PointsAt.ElementAt(visitEle).Name);
                CanVisitNode(node.PointsAt.ElementAt(visitEle));
            }
            else
            {
                visitEle++;
            }


        }
    }

    public static int visitEle = -1;
}
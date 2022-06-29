
public class Program
{

    static Dictionary<String, List<Node>> dict = new Dictionary<string, List<Node>>();

    static int totalPath = 0;

    public static void Main()
    {
        //int pathIndex = 0;
        //Adds nodes to graph(dict)
        foreach (var item in System.IO.File.ReadLines(@"../test.txt"))
        {
            string[] line = item.Split("-");

            var first = line[0];
            var second = line[1];

            var firstNode = makeNode(first);
            var secondNode = makeNode(second);

            if (first == "start")
            {
                List<Node> listOfNode = new List<Node>();

                if (dict.TryGetValue(first, out listOfNode))
                {
                    listOfNode.Add(secondNode);
                    dict[first] = listOfNode;
                }
                else
                {
                    dict.Add(first, new List<Node>() { secondNode });
                }

            }
            else if (second == "start")
            {
                List<Node> listOfNode = new List<Node>();
                if (dict.TryGetValue(second, out listOfNode))
                {
                    listOfNode.Add(firstNode);
                    dict[second] = listOfNode;
                }
                else
                {
                    dict.Add(second, new List<Node>() { firstNode });
                }
            }
            else
            {
                List<Node> listOfNode = new List<Node>();

                if (dict.TryGetValue(first, out listOfNode))
                {
                    listOfNode.Add(secondNode);
                    dict[first] = listOfNode;
                }
                else
                {
                    dict.Add(first, new List<Node>() { secondNode });
                }

                List<Node> secondListOfNode = new List<Node>();
                if (dict.TryGetValue(second, out secondListOfNode))
                {
                    secondListOfNode.Add(firstNode);
                    dict[second] = secondListOfNode;
                }
                else
                {
                    dict.Add(second, new List<Node>() { firstNode });
                }
            }
        }

        foreach (var item in dict)
        {
            Console.Write(item.Key + " ");
            foreach (var val in item.Value)
            {
                Console.Write(val.Name + " ");
            }
            Console.WriteLine();
        }

        var startNode = new Node("start", false, false);
        FindToPath(startNode, 0);
        Console.WriteLine(totalPath);
    }

    public static Node makeNode(string str)
    {
        if (str.Any(char.IsUpper) || (str == "end" || str == "end"))
        {
            return new Node(str, true, false);
        }
        else
        {
            return new Node(str, false, false);
        }
    }

    public static bool CanVisitNode(Node node)
    {
        if (node.Visited && !node.Uppercase)
        {
            return false;
        }
        else { return true; }
    }

    public static void VisitNode(Node node)
    {
        Console.WriteLine("This node has been visited: " + node.Name);
        node.Visited = true;
    }


    public static void FindToPath(Node node, int idx)
    {

        if (node.Name != "end")
        {
            List<Node> adj = new List<Node>();
            dict.TryGetValue(node.Name, out adj);

            var nextNode = adj[idx];

            if (CanVisitNode(nextNode))
            {
                VisitNode(nextNode);
                FindToPath(nextNode, 0);
            }
            else
            {
                FindToPath(node, idx + 1);
            }
        }
        else
        {
            totalPath++;
            return;
        }
    }
}
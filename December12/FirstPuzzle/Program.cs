using System.Linq;
public class Program
{

    static Dictionary<Node, List<Node>> dict = new Dictionary<Node, List<Node>>();

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

                if (dict.TryGetValue(firstNode, out listOfNode))
                {
                    listOfNode.Add(secondNode);
                    dict[firstNode] = listOfNode;
                }
                else
                {
                    dict.Add(firstNode, new List<Node>() { secondNode });
                }

            }
            else if (second == "start")
            {
                List<Node> listOfNode = new List<Node>();
                if (dict.TryGetValue(secondNode, out listOfNode))
                {
                    listOfNode.Add(firstNode);
                    dict[secondNode] = listOfNode;
                }
                else
                {
                    dict.Add(secondNode, new List<Node>() { firstNode });
                }
            }
            else
            {
                List<Node> listOfNode = new List<Node>();

                if (dict.TryGetValue(firstNode, out listOfNode))
                {
                    listOfNode.Add(secondNode);
                    dict[firstNode] = listOfNode;
                }
                else
                {
                    dict.Add(firstNode, new List<Node>() { secondNode });
                }

                List<Node> secondListOfNode = new List<Node>();
                if (dict.TryGetValue(secondNode, out secondListOfNode))
                {
                    secondListOfNode.Add(firstNode);
                    dict[secondNode] = secondListOfNode;
                }
                else
                {
                    dict.Add(secondNode, new List<Node>() { firstNode });
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
        var localPath = new List<Node>();
        FindToPath(startNode, localPath);
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
        

        if (dict[node].Visited && !node.Uppercase)
        {
            return false;
        }
        else { return true; }
    }

    public static void VisitNode(Node node)
    {
        //Console.WriteLine("This node has been visited: " + node.Name);
        var newNode = new Node(node.Name, node.Uppercase, true);
        List<Node>? adj = new List<Node>();
        dict.TryGetValue(node, out adj);
        dict.Remove(node);
        dict.Add(newNode, adj);
    }

    public static void printPath(List<Node> path){
        foreach (var item in path)
        {
            Console.Write(item.Name + " ");
        }
        Console.WriteLine();
    }


    public static void FindToPath(Node node, List<Node> localPaths)
    {
        List<Node>? adj = new List<Node>();
        dict.TryGetValue(node, out adj);

        if (node.Name == "end")
        {   
            printPath(localPaths);
            totalPath++;
            return;
        }

        VisitNode(node);
        foreach (var localNode in adj)
        {
            if (CanVisitNode(localNode))
            {
                localPaths.Add(node);
                FindToPath(localNode, localPaths);
                localPaths.Remove(node);
            } 
        }
    }
}
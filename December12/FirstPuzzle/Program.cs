using System.Linq;
public class Program
{

    //static List<((string, bool, bool)> PathBuilder = new List<((string, bool, bool))>();

    //name, name, visites
    //static Node[] PathIndex = new Node[20];

    static Dictionary<String, List<Node>> dict = new Dictionary<string, List<Node>>();

    static List<string> PathString = new List<string>();

    static string tmpPath = "";

    //name, is uppercase, has been visited  
    //static Node node;

    public static void Main()
    {
        //int pathIndex = 0;
        //Adds nodes to graph(dict)
        foreach (var item in System.IO.File.ReadLines(@"../test.txt"))
        {
            string[] line = item.Split("-");

            foreach (var stringNode in line)
            {
                Node node;
                if (stringNode == "start" || stringNode.Any(char.IsUpper) || stringNode == "end")
                {
                    node = new Node(stringNode, false, false);
                }
                else
                {
                    node = new Node(stringNode, true, false);
                }

                List<Node> listOfNode = new List<Node>();

                dict.TryGetValue(stringNode, out listOfNode);

                listOfNode.Add(node);

                dict.Add(stringNode, listOfNode);
            }
        }
    }

    public static bool CanVisitNode(Node node)
    {
        if (node.Uppercase || !node.Visited)
        {
            Console.WriteLine("This node can be visited: " + node.Name);
            VisitNode(node);
            return true;
        }
        else
        {
            return false;
        }
    }

    public static void VisitNode(Node node)
    {
        Console.WriteLine("This node has been visited: " + node.Name);
        node.Visited = true;
    }

    public static void RemoveNodeBecauseVisited(Node node)
    {

    }


    public static void FindToPath(Node node)
    {

        if (node.Name != "end")
        {
            List<Node> adj = new List<Node>();
            dict.TryGetValue(node.Name, out adj);

            var nextNode = adj.First();

            if (CanVisitNode(node))
            {
                VisitNode(node);
                FindToPath(nextNode);
                // og så rekursivt kald
            }
            
            var newAdj = adj.Remove(nextNode);

        }
    }
}
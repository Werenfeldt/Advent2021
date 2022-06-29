
public class Program
{

    static Dictionary<String, Node> dict = new Dictionary<string, Node>();

    static List<string> visited = new List<string>();

    static HashSet<string> hashvisited = new HashSet<string>();

    static bool containsDub = false;

    static string dub = string.Empty;

    public static void Main()
    {
        //int pathIndex = 0;
        //Adds nodes to graph(dict)
        foreach (var item in System.IO.File.ReadLines(@"../test2.txt"))
        {
            string[] line = item.Split("-");

            var first = line[0];
            var second = line[1];

            var firstNode = makeNode(first);
            var secondNode = makeNode(second);

            if (first == "start")
            {
                if (!dict.ContainsKey(first))
                {
                    firstNode.Add(secondNode);
                    dict.Add(first, firstNode);
                }
                else
                {
                    Node node = dict[first];
                    node.Add(secondNode);
                    dict[first] = node;
                }

            }
            else if (second == "start")
            {
                if (!dict.ContainsKey(second))
                {
                    secondNode.Add(firstNode);
                    dict.Add(second, secondNode);
                }
                else
                {
                    Node node = dict[second];
                    node.Add(firstNode);
                    dict[second] = node;
                }
            }
            else
            {
                if (!dict.ContainsKey(first))
                {
                    firstNode.Add(secondNode);
                    dict.Add(first, firstNode);
                }
                else
                {
                    Node node = dict[first];
                    node.Add(secondNode);
                    dict[first] = node;
                }

                if (!dict.ContainsKey(second))
                {
                    secondNode.Add(firstNode);
                    dict.Add(second, secondNode);
                }
                else
                {
                    Node node = dict[second];
                    node.Add(firstNode);
                    dict[second] = node;
                }
            }
        }

        // foreach (var item in dict.Values)
        // {
        //     Console.WriteLine("Node:" + item.Name);
        //     Console.Write("Adj: ");
        //     foreach (var val in item.adj)
        //     {
        //         Console.Write(val.Name + " ");
        //     }
        //     Console.WriteLine();
        //     Console.WriteLine();
        // }

        //var startNode = new Node("start", false, false);
        var totalPath = StartFindPath();
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

        if (node.Uppercase || (visited.Count == visited.Distinct().Count()))
        {
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

    public static int StartFindPath()
    {
        var totalPaths = 0;

        totalPaths = FindPath("start", totalPaths);
        return totalPaths;
    }

    public static bool CanIVisit(Node node)
    {
        if (!containsDub)
        {
            if (visited.Contains(node.Name) && !node.Uppercase)
            {
                visited.Add(node.Name);
                containsDub = true;
                dub = node.Name;
                return true;
            }
            else
            {
                visited.Add(node.Name);
                return true;
            }
        }
        else
        {
            if (node.Uppercase)
            {
                visited.Add(node.Name);
                return true;
            }
            else
            {
                if (node.Name == dub)
                {
                    return false;
                }
                else
                {
                    if (visited.Contains(node.Name))
                    {
                        return false;
                    }
                    else
                    {
                        visited.Add(node.Name);
                        return true;
                    }
                }
            }
        }
    }

    public static void remove(Node node)
    {
        if (containsDub && dub == node.Name)
        {
            containsDub = false;
            visited.Remove(node.Name);
        }
        else
        {
            visited.Remove(node.Name);
        }
    }


    public static int FindPath(string u, int totalPath)
    {
        var localVisited = visited;
        var dubBool = containsDub;
        var localdub = dub;

        if (u == "end")
        {
            totalPath++;
            remove(dict[u]);
        }
        else
        {
            foreach (var i in dict[u].adj)
            {

                if (CanIVisit(i))
                {
                    totalPath = FindPath(i.Name, totalPath);
                }
            }
            remove(dict[u]);
        }
        return totalPath;
    }
}
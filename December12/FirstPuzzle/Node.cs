public class Node
{

    public string Name { get; set; }

    public bool Visited { get; set; }

    public bool Uppercase { get; set; }

    public List<Node>? PointsAt = new List<Node>();

    public Node(string _name, bool _upperCase, bool _visited)
    {
        this.Name = _name;
        this.Visited = _visited;
        this.Uppercase = _upperCase;

        //PrintInfo();

    }

    public void AddPointsAtNode(Node node)
    {
        PointsAt.Add(node);
    }

    public void RemovePointsAtNode(Node node)
    {
        PointsAt.Remove(node);
    }

    public void PrintInfo()
    {
        if (PointsAt != null)
        {
            Console.WriteLine("Start: ");

            Console.WriteLine("{0}, {1}, {2}: Points at nodes: ", Name, Visited, Uppercase);
            foreach (var node in PointsAt)
            {
                Console.WriteLine(node.Name + " which is visited: " + node.Visited);
            }
            Console.WriteLine();
        }
    }

    // public override bool Equals(object? obj)
    // {
    //     if ((obj == null) || !this.GetType().Equals(obj.GetType()))
    //     {
    //         return false;
    //     }
    //     else
    //     {
    //         Node n = (Node)obj;
    //         return (Name == n.Name) && (PointsAt == n.PointsAt);
    //     }
    // }


}
public class Node
{

    public string Name { get; set; }

    public bool Visited { get; set; }

    public bool Uppercase { get; set; }

    public List<Node> adj = new List<Node>();

    public Node(string _name, bool _upperCase, bool _visited)
    {
        this.Name = _name;
        this.Uppercase = _upperCase;
        this.Visited = _visited;
        this.adj = new List<Node>();
        //PrintInfo();
    }

    public void Add(Node node){
        adj.Add(node);
    }

    public void addNode(Node node){
        this.adj.Add(node);
    }

    public void PrintInfo()
    {
        Console.WriteLine("{0}, {1}, {2}", Name, Visited, Uppercase);
    }
}
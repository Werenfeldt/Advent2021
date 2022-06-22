public class Node
{

    public string Name { get; set; }

    public bool Visited { get; set; }

    public bool Uppercase { get; set; }

    public Node(string _name, bool _upperCase, bool _visited)
    {
        this.Name = _name;
        this.Uppercase = _upperCase;
        this.Visited = _visited;

        //PrintInfo();

    }

    public void PrintInfo()
    {
        Console.WriteLine("{0}, {1}, {2}", Name, Visited, Uppercase);
    }
}
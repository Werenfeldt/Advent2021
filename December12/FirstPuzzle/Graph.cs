using System;
using System.Collections.Generic;
 
 
// C# program to check if there is exist a path between
// two vertices of an undirected graph.
public class Graph
{

    //Total number of paths
    int Paths = 0;
   
    // This class represents an undirected graph
    // using adjacency list representation
    int V; // No. of vertices
 
    // Pointer to an array containing adjacency lists
    List<List<int>> adj;
 
    Graph(int V){
        this.V = V;
        adj = new List<List<int>>();
        for(int i = 0; i < V; i++)
            adj.Add(new List<int>());
    }
 
    // function to add an edge to graph
    void addEdge(int v, int w)
    {
        adj[v].Add(w);
        adj[w].Add(v);
    }
 
 
    // A BFS based function to check whether d is reachable from s.
    bool isReachable(int s, int d)
    {
        // Base case
        if (s == d)
            return true;
 
        // Mark all the vertices as not visited
        bool[] visited = new bool[V];
        for (int i = 0; i < V; i++)
            visited[i] = false;
 
        // Create a queue for BFS
        Queue<int> queue = new Queue<int>();
 
        // Mark the current node as visited and enqueue it
        visited[s] = true;
        queue.Enqueue(s);
 
        while (queue.Count != 0)
        {
           
            // Dequeue a vertex from queue and print it
            s = queue.Dequeue();
 
            // Get all adjacent vertices of the dequeued vertex s
            // If a adjacent has not been visited, then mark it
            // visited  and enqueue it
            for (int i = 0; i < adj[s].Count; i++) {
 
                // If this adjacent node is the destination node,
                // then return true
                if (adj[s][i] == d)
                return true;
 
                // Else, continue to do BFS
                if (!visited[adj[s][i]]) {
                    visited[adj[s][i]] = true;
                    queue.Enqueue(adj[s][i]);
                }
            }
        }
 
        // If BFS is complete without visiting d
        return false;
    }
 
    // Driver program to test methods of graph class
    public static void Main(String[] args)
    {
       
        // Create a graph given in the above diagram
        Graph g = new Graph(4);
        g.addEdge(0, 1);
        g.addEdge(0, 2);
        g.addEdge(1, 2);
        g.addEdge(2, 0);
        g.addEdge(2, 3);
        g.addEdge(3, 3);
 
        int u = 1, v = 3;
        if (g.isReachable(u, v))
            Console.WriteLine("\n There is a path from "+u+" to "+v);
        else
            Console.WriteLine("\n There is no path from "+u+" to "+v);
    }
}
 
// This code is contributed by umadevi9616
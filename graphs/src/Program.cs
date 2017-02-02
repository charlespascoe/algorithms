using System;

public static class Program {
    public static void Main(string[] args) {
        Graph<string> graph = new Graph<string>();

        Vertex<string> a = graph.CreateVertex("A");
        Vertex<string> b = graph.CreateVertex("B");
        Vertex<string> c = graph.CreateVertex("C");
        Vertex<string> d = graph.CreateVertex("D");

        Console.WriteLine(graph);
        Console.WriteLine();

        graph.AddEdge(a, b, 2);
        graph.AddEdge(a, d, 1);
        graph.AddEdge(b, d, 2);
        graph.AddEdge(c, d, 3);

        Console.WriteLine(graph);
        Console.WriteLine();

        Console.WriteLine(new PrimsAlgorithm().MinimumSpanningTree(graph));
    }
}

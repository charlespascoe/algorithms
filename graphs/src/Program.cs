using System;
using System.Linq;

public static class Program {
    public static void Main(string[] args) {
        Program.Prims();
    }

    public static void Prims() {
        Console.WriteLine("===== PRIM'S ALGORITHM =====");
        UndirectedGraph<string> graph = new UndirectedGraph<string>();
        Console.WriteLine();

        UndirectedVertex<string> a = graph.CreateVertex("A");
        UndirectedVertex<string> b = graph.CreateVertex("B");
        UndirectedVertex<string> c = graph.CreateVertex("C");
        UndirectedVertex<string> d = graph.CreateVertex("D");
        UndirectedVertex<string> e = graph.CreateVertex("E");
        UndirectedVertex<string> f = graph.CreateVertex("F");
        UndirectedVertex<string> g = graph.CreateVertex("G");
        UndirectedVertex<string> h = graph.CreateVertex("H");
        UndirectedVertex<string> i = graph.CreateVertex("I");
        UndirectedVertex<string> j = graph.CreateVertex("J");

        Console.WriteLine(graph);
        Console.WriteLine();

        graph.AddEdge(a, b, 6);
        graph.AddEdge(a, c, 3);
        graph.AddEdge(a, e, 9);
        graph.AddEdge(b, c, 4);
        graph.AddEdge(b, d, 2);
        graph.AddEdge(b, f, 9);
        graph.AddEdge(c, d, 2);
        graph.AddEdge(c, e, 9);
        graph.AddEdge(c, g, 9);
        graph.AddEdge(d, f, 9);
        graph.AddEdge(d, g, 8);
        graph.AddEdge(e, g, 8);
        graph.AddEdge(e, j, 18);
        graph.AddEdge(f, g, 7);
        graph.AddEdge(f, h, 4);
        graph.AddEdge(f, i, 5);
        graph.AddEdge(g, i, 9);
        graph.AddEdge(g, j, 10);
        graph.AddEdge(h, i, 1);
        graph.AddEdge(h, j, 4);
        graph.AddEdge(i, j, 3);

        Console.WriteLine(graph);
        Console.WriteLine();

        UndirectedGraph<string> minimumSpanningTree = new PrimsAlgorithm().MinimumSpanningTree(graph);
        Console.WriteLine(minimumSpanningTree);
        Console.WriteLine(minimumSpanningTree.Edges.Sum(edge => edge.Weight));
    }
}

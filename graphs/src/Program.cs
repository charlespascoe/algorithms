using System;

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

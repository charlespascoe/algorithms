using System;
using System.Linq;
using System.Collections.Generic;

public class PrimsAlgorithm {
    public Graph<T> MinimumSpanningTree<T>(Graph<T> graph) {
        if (!graph.IsUndirected()) {
            throw new Exception("Undirected graph required");
        }

        Graph<T> result = new Graph<T>();

        Vertex<T> root = graph.Vertices.FirstOrDefault();

        if (root == null) return result;

        result.CreateVertex(root.Key);

        List<Edge<T>> edges = new List<Edge<T>>(graph.Edges.OrderBy(edge => edge.Weight));

        bool added;

        do {
            added = false;

            foreach (Edge<T> edge in edges) {
                Vertex<T> from = result.GetVertex(edge.From.Key);
                Vertex<T> to = result.GetVertex(edge.To.Key);

                if (from != null && to == null) {
                    to = result.CreateVertex(edge.To.Key);
                    result.AddEdge(from, to, edge.Weight);
                    added = true;
                    edges.Remove(edge);
                    break;
                } else if (from == null && to != null) {
                    from = result.CreateVertex(edge.From.Key);
                    result.AddEdge(from, to, edge.Weight);
                    added = true;
                    edges.Remove(edge);
                    break;
                }
            }
        } while (added);

        return result;
    }
}

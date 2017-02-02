using System;
using System.Linq;
using System.Collections.Generic;

public class PrimsAlgorithm {
    public UndirectedGraph<T> MinimumSpanningTree<T>(UndirectedGraph<T> graph) {
        UndirectedGraph<T> result = new UndirectedGraph<T>();

        UndirectedVertex<T> root = graph.Vertices.FirstOrDefault();

        if (root == null) return result;

        result.CreateVertex(root.Key);

        List<UndirectedEdge<T>> edges = new List<UndirectedEdge<T>>(graph.Edges.OrderBy(edge => edge.Weight));

        bool added;

        do {
            added = false;

            foreach (UndirectedEdge<T> edge in edges) {
                UndirectedVertex<T> vertexA = result.GetVertex(edge.VertexA.Key);
                UndirectedVertex<T> vertexB = result.GetVertex(edge.VertexB.Key);

                if (vertexA != null && vertexB == null) {
                    vertexB = result.CreateVertex(edge.VertexB.Key);
                    result.AddEdge(vertexA, vertexB, edge.Weight);
                    added = true;
                    edges.Remove(edge);
                    break;
                } else if (vertexA == null && vertexB != null) {
                    vertexA = result.CreateVertex(edge.VertexA.Key);
                    result.AddEdge(vertexA, vertexB, edge.Weight);
                    added = true;
                    edges.Remove(edge);
                    break;
                }
            }
        } while (added);

        return result;
    }
}

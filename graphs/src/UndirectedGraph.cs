using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;

public class UndirectedGraph<T> : Graph<T,UndirectedVertex<T>> {
    private HashSet<UndirectedEdge<T>> edges = new HashSet<UndirectedEdge<T>>();

    public IEnumerable<UndirectedEdge<T>> Edges => this.edges;

    public UndirectedVertex<T> CreateVertex(T key) {
        if (this.vertices.ContainsKey(key)) throw new Exception("Key exists");

        UndirectedVertex<T> vertex = new UndirectedVertex<T>(key);

        this.vertices[key] = vertex;

        return vertex;
    }

    public UndirectedEdge<T> AddEdge(UndirectedVertex<T> vertexA, UndirectedVertex<T> vertexB, double weight) {
        if (this.GetVertex(vertexA.Key) != vertexA || this.GetVertex(vertexB.Key) != vertexB) throw new Exception("Vertices must be in the graph");

        UndirectedEdge<T> edge = new UndirectedEdge<T>(vertexA, vertexB, weight);
        vertexA.AddEdge(edge);
        vertexB.AddEdge(edge);
        this.edges.Add(edge);
        return edge;
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

public class Vertex<T> {
    private HashSet<Edge<T>> edges = new HashSet<Edge<T>>();
    public IEnumerable<Edge<T>> Edges => this.edges;

    public T Key { get; private set; }

    public Vertex(T key) {
        this.Key = key;
    }

    public void AddEdge(Edge<T> edge) {
        if (edge.From != this && edge.To != this) throw new InvalidOperationException("Invalid edge");

        this.edges.Add(edge);
    }
}

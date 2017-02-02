using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;

public class Graph<T> {
    private HashSet<Edge<T>> edges = new HashSet<Edge<T>>();

    private Dictionary<T,Vertex<T>> vertices = new Dictionary<T,Vertex<T>>();

    public IEnumerable<Edge<T>> Edges => this.edges;

    public IEnumerable<Vertex<T>> Vertices => this.vertices.Values;

    public Vertex<T> CreateVertex(T key) {
        if (this.vertices.ContainsKey(key)) throw new Exception("Key exists");

        Vertex<T> vertex = new Vertex<T>(key);

        this.vertices[key] = vertex;

        return vertex;
    }

    public Edge<T> AddEdge(Vertex<T> from, Vertex<T> to, double weight, bool directed = false) {
        if (this.GetVertex(from.Key) != from || this.GetVertex(to.Key) != to) throw new Exception("Vertices must be in the graph");

        Edge<T> edge = new Edge<T>(from, to, weight, directed);
        from.AddEdge(edge);
        to.AddEdge(edge);
        this.edges.Add(edge);
        return edge;
    }

    public Vertex<T> GetVertex(T key) {
        Vertex<T> vertex;
        if (this.vertices.TryGetValue(key, out vertex)) return vertex;
        return null;
    }

    public bool IsUndirected() {
        return this.Edges.All(edge => !edge.Directed);
    }

    public bool IsCompletelyDirected() {
        return this.Edges.All(edge => edge.Directed);
    }

    public override string ToString() {
        StringBuilder str = new StringBuilder();

        foreach (Edge<T> edge in this.Edges) {
            str.AppendLine(edge.ToString());
        }

        foreach (Vertex<T> vertex in this.Vertices) {
            if (vertex.Edges.Count() == 0) {
                str.AppendLine(vertex.Key.ToString());
            }
        }

        return str.ToString();
    }
}

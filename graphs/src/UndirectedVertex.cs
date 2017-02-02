using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Collections.ObjectModel;

public class UndirectedVertex<T> : Vertex<T> {
    private HashSet<UndirectedEdge<T>> edges = new HashSet<UndirectedEdge<T>>();
    public IEnumerable<UndirectedEdge<T>> Edges => this.edges;

    public UndirectedVertex(T key) {
        this.Key = key;
    }

    public void AddEdge(UndirectedEdge<T> edge) {
        if (edge.VertexA != this && edge.VertexB != this) throw new InvalidOperationException("Invalid edge");

        this.edges.Add(edge);
    }

    public override IEnumerable<NextVertex<T>> GetNextVetices() {
        return this.Edges.Select(edge => new NextVertex<T>(edge.VertexA == this ? edge.VertexB : edge.VertexA, edge.Weight));
    }

    public override void ToString(StringBuilder str) {
        if (this.Edges.Count() == 0) {
            str.AppendLine(this.Key.ToString());
            return;
        }

        foreach (UndirectedEdge<T> edge in this.Edges) {
            if (edge.VertexA == this) {
                str.AppendLine(edge.ToString());
            }
        }
    }
}

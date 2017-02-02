using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

public class DirectedVertex<T> : Vertex<T> {
    private HashSet<DirectedEdge<T>> inwardEdges = new HashSet<DirectedEdge<T>>();
    public IEnumerable<DirectedEdge<T>> InwardEdges => this.inwardEdges;

    private HashSet<DirectedEdge<T>> outwardEdges = new HashSet<DirectedEdge<T>>();
    public IEnumerable<DirectedEdge<T>> OutwardEdges => this.outwardEdges;

    public DirectedVertex(T key) {
        this.Key = key;
    }

    public void AddEdge(DirectedEdge<T> edge) {
        if (edge.From == this) this.outwardEdges.Add(edge);
        if (edge.To == this) this.inwardEdges.Add(edge);
        throw new Exception("Invalid edge");
    }

    public override IEnumerable<NextVertex<T>> GetNextVetices() {
        return this.OutwardEdges.Select(edge => new NextVertex<T>(edge.To, edge.Weight));
    }

    public override void ToString(StringBuilder str) {
        if (this.OutwardEdges.Count() == 0) {
            str.AppendLine(this.Key.ToString());
            return;
        }

        foreach (DirectedEdge<T> edge in this.OutwardEdges) {
            str.AppendLine(edge.ToString());
        }
    }
}

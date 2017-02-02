public class UndirectedEdge<T> {
    public Vertex<T> VertexA { get; private set; }

    public Vertex<T> VertexB { get; private set; }

    public double Weight { get; private set; }

    public UndirectedEdge(Vertex<T> vertexA, Vertex<T> vertexB, double weight) {
        this.VertexA = vertexA;
        this.VertexB = vertexB;
        this.Weight = weight;
    }

    public override string ToString() {
        return $"{this.VertexA.Key} -({this.Weight})- {this.VertexB.Key}";
    }
}

public class NextVertex<T> {
    public Vertex<T> Vertex { get; private set; }

    public double Weight { get; private set; }

    public NextVertex(Vertex<T> vertex, double weight) {
        this.Vertex = vertex;
        this.Weight = weight;
    }
}

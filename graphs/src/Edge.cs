public class Edge<T> {
    public Vertex<T> From { get; private set; }

    public Vertex<T> To { get; private set; }

    public double Weight { get; private set; }

    public bool Directed { get; private set; }

    public Edge(Vertex<T> from, Vertex<T> to, double weight, bool directed = false) {
        this.From = from;
        this.To = to;
        this.Weight = weight;
        this.Directed = directed;
    }

    public override string ToString() {
        return $"{this.From.Key} -({this.Weight})-{this.Directed ? ">" : ""} {this.To.Key}";
    }
}

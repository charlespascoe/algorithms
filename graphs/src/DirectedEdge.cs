public class DirectedEdge<T> {
    public DirectedVertex<T> From { get; private set; }

    public DirectedVertex<T> To { get; private set; }

    public double Weight { get; private set; }

    public DirectedEdge(DirectedVertex<T> from, DirectedVertex<T> to, double weight) {
        this.From = from;
        this.To = to;
        this.Weight = weight;
    }

    public override string ToString() {
        return $"{this.From.Key} -({this.Weight})-> {this.To.Key}";
    }
}

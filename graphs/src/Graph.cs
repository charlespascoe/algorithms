using System.Text;
using System.Collections.Generic;

public abstract class Graph<T,V> where V : Vertex<T> {
    protected Dictionary<T,V> vertices = new Dictionary<T,V>();

    public IEnumerable<V> Vertices => this.vertices.Values;

    public V GetVertex(T key) {
        V vertex;
        if (this.vertices.TryGetValue(key, out vertex)) return vertex;
        return null;
    }

    public override string ToString() {
        StringBuilder str = new StringBuilder();

        foreach (V vertex in this.Vertices) {
            vertex.ToString(str);
        }

        return str.ToString();
    }
}

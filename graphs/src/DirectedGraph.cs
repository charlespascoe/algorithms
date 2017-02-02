using System;
using System.Collections.Generic;

public class DirectedGraph<T> : Graph<T,DirectedVertex<T>> {
    public DirectedVertex<T> CreateVertex(T key) {
        if (this.vertices.ContainsKey(key)) throw new Exception("Key exists");

        DirectedVertex<T> vertex = new DirectedVertex<T>(key);

        this.vertices[key] = vertex;

        return vertex;
    }

}

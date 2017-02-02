using System.Collections.Generic;
using System.Text;

public abstract class Vertex<T> {
    public T Key { get; protected set; }

    public abstract IEnumerable<NextVertex<T>> GetNextVetices();

    public abstract void ToString(StringBuilder str);
}

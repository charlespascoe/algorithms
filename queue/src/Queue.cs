public class Queue<T> {
    private LinkedList<T> list = new LinkedList<T>();

    public int Count => this.list.Count;

    public void Add(T item) {
        this.list.Add(item);
    }

    public T Next() {
        return this.list.Remove(0);
    }

    public T NextOrDefault() {
        if (this.list.Empty) return default(T);
        return this.Next();
    }

    public override string ToString() {
        return this.list.ToString();
    }
}

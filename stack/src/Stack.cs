public class Stack<T> {
    private LinkedList<T> list = new LinkedList<T>();

    public int Count => this.list.Count;

    public void Add(T item) {
        this.list.Add(item);
    }

    public T Pop() {
        return this.list.RemoveLast();
    }

    public T PopOrDefault() {
        if (this.list.Empty) return default(T);
        return this.Pop();
    }

    public override string ToString() {
        return this.list.ToString();
    }
}

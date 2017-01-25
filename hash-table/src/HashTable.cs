using System;
using System.Collections.Generic;
using System.Text;

public class HashTable<K,V> {
    private class Node<T, U> {
        public Node<T,U> Previous { get; set; }
        public Node<T,U> Next { get; set; }
        public T Key { get; set; }
        public U Value { get; set; }

        public Node(T key, U val) {
            this.Key = key;
            this.Value = val;
        }

        public void Append(Node<T,U> node) {
            if (this.Next == null) {
                this.Next = node;
                node.Previous = this;
            } else {
                this.Next.Append(node);
            }
        }

        public Node<T,U> FindNode(T key) {
            if (this.Key.Equals(key)) return this;
            if (this.Next != null) return this.Next.FindNode(key);
            return null;
        }
    }

    private Node<K,V>[] table;
    private int itemCount = 0;
    private const float RESIZE_THRESHOLD = 0.7f;

    public V this[K key] {
        get {
            Node<K,V> node = this.FindNode(key);

            if (node == null) throw new KeyNotFoundException();

            return node.Value;
        }
        set {
            int index = this.ComputeIndex(key, this.table.Length);

            if (this.table[index] == null) {
                this.table[index] = new Node<K,V>(key, value);
                this.itemCount++;
                this.Resize();
            } else {
                Node<K,V> node = this.table[index].FindNode(key);

                if (node == null) {
                    this.table[index].Append(new Node<K,V>(key, value));
                    this.itemCount++;
                    this.Resize();
                } else {
                    node.Value = value;
                }
            }
        }
    }

    public HashTable(int initialSize = 3) {
        if (initialSize < 3) initialSize = 3;

        int bits = (int)Math.Ceiling(Math.Log(initialSize - 1, 2));

        initialSize = (1 << bits) + 1;

        this.table = new Node<K,V>[initialSize];
    }

    public bool ContainsKey(K key) {
        return this.FindNode(key) != null;
    }

    public bool Remove(K key) {
        int index = this.ComputeIndex(key, this.table.Length);

        if (this.table[index] == null) return false;

        if (this.table[index].Key.Equals(key)) {
            this.table[index] = this.table[index].Next;
            if (this.table[index] != null) this.table[index].Previous = null;
            return true;
        }

        Node<K,V> node = this.table[index].FindNode(key);

        if (node == null) return false;

        node.Previous.Next = node.Next;
        if (node.Next != null) node.Next.Previous = node.Previous;

        return true;
    }

    public override string ToString() {
        StringBuilder str = new StringBuilder();

        str.Append("{");

        bool empty = true;

        foreach (Node<K,V> node in this.Nodes()) {
            str.Append($"\n  {node.Key}: {node.Value}");
            empty = false;
        }

        if (!empty) {
            str.Append("\n");
        }

        str.Append("}");

        return str.ToString();
    }

    private void Resize() {
        if ((float)this.itemCount / this.table.Length < RESIZE_THRESHOLD) return;

        Node<K,V>[] newTable = new Node<K,V>[(this.table.Length << 1) + 1];

        foreach (Node<K,V> node in this.Nodes()) {
            int newIndex = this.ComputeIndex(node.Key, newTable.Length);
            Node<K,V> newNode = new Node<K,V>(node.Key, node.Value);

            if (newTable[newIndex] == null) {
                newTable[newIndex] = newNode;
            } else {
                newTable[newIndex].Append(newNode);
            }
        }

        this.table = newTable;
    }

    private IEnumerable<Node<K,V>> Nodes() {
        for (int i = 0; i < this.table.Length; i++) {
            Node<K,V> node = this.table[i];

            while (node != null) {
                yield return node;
                node = node.Next;
            }
        }
    }

    private Node<K,V> FindNode(K key) {
        int index = this.ComputeIndex(key, this.table.Length);

        if (this.table[index] == null) return null;

        return this.table[index].FindNode(key);
    }

    private int ComputeIndex(K key, int tableSize) {
        return ((key.GetHashCode() % tableSize) + tableSize) % tableSize;
    }
}

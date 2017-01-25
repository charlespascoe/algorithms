using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

public class LinkedList<T> : IEnumerable<T> {
    private class Node<T> {
        public T Value { get; set; }

        public Node<T> Next { get; set; }

        public Node<T> Previous { get; set; }

        public Node(T val) {
            this.Value = val;
        }
    }

    private Node<T> head;
    private Node<T> tail;

    public int Count {
        get {
            Node<T> node = this.head;
            int count = 0;

            while (node != null) {
                node = node.Next;
                count++;
            }

            return count;
        }
    }

    public T this[int index] {
        get { return this.GetNode(index).Value; }
        set { this.GetNode(index).Value = value; }
    }

    public void Add(T item) {
        Node<T> node = new Node<T>(item);

        if (this.head == null) {
            this.head = node;
            this.tail = node;
        } else {
            this.tail.Next = node;
            node.Previous = this.tail;
            this.tail = node;
        }
    }

    public void Insert(T item, int index) {
        Node<T> node = this.GetNode(index);

        Node<T> newNode = new Node<T>(item);

        if (node.Previous != null) node.Previous.Next = newNode;
        newNode.Previous = node.Previous;
        node.Previous = newNode;
        newNode.Next = node;
    }

    public T Remove(int index) {
        return this.RemoveNode(this.GetNode(index));
    }

    public T RemoveLast() {
        return this.RemoveNode(this.tail);
    }

    private T RemoveNode(Node<T> node) {
        if (node.Previous == null) {
            this.head = node.Next;
        } else {
            node.Previous.Next = node.Next;
        }

        if (node.Next == null) {
            this.tail = node.Previous;
        } else {
            node.Next.Previous = node.Previous;
        }

        return node.Value;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IEnumerator<T> GetEnumerator() {
        Node<T> node = this.head;

        while (node != null) {
            yield return node.Value;
            node = node.Next;
        }
    }

    private Node<T> GetNode(int index) {
        Node<T> node = this.head;

        int i = 0;

        while (i < index) {
            if (node == null) {
                throw new IndexOutOfRangeException();
            }

            node = node.Next;

            i++;
        }

        return node;
    }

    public override string ToString() {
        StringBuilder str = new StringBuilder();
        str.Append("[");

        bool zeroItems = true;

        foreach (T item in this) {
            zeroItems = false;
            str.Append(item).Append(", ");
        }

        if (!zeroItems) {
            str.Remove(str.Length - 2, 2);
        }

        str.Append("]");

        return str.ToString();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class PriorityQueue<T> where T : IComparable<T> {
    private T[] heap = new T[1];
    private int heapSize = 0;

    public int QueueLength => this.heapSize;

    public T Next {
        get {
            if (this.heapSize == 0) return default(T);
            return this.heap[0];
        }
    }

    public PriorityQueue() { }

    public PriorityQueue(IEnumerable<T> items) {
        this.heap = items.ToArray();
        this.heapSize = this.heap.Length;

        for (int i = this.heap.Length / 2; i >= 1; i--) {
            this.FixMaxHeap(i);
        }
    }

    private int LeftIndex(int index) {
        // 2 * i for one-base array
        return (2 * (index + 1)) - 1;
    }

    private int RightIndex(int index) {
        // 2 * i + 1 for one-based array, -1 cancels
        return 2 * (index + 1);
    }

    private int ParentIndex(int index) {
        return (index + 1) / 2 - 1;
    }

    private void FixMaxHeap(int index) {
        int left = this.LeftIndex(index);
        int right = this.RightIndex(index);

        int largestIndex = index;

        if (left < this.heapSize && this.heap[left].CompareTo(this.heap[largestIndex]) > 0) {
            largestIndex = left;
        }

        if (right < this.heapSize && this.heap[right].CompareTo(this.heap[largestIndex]) > 0) {
            largestIndex = right;
        }

        if (largestIndex != index) {
            this.heap.Swap(largestIndex, index);
            this.FixMaxHeap(largestIndex);
        }
    }

    public void Insert(T item) {
        if (item == null) return;

        if (this.heapSize == this.heap.Length) {
            Array.Resize(ref this.heap, 2 * this.heap.Length + 1);
        }

        int index = this.heapSize;

        this.heap[index] = item;

        this.heapSize++;

        while (index > 0 && this.heap[index].CompareTo(this.heap[this.ParentIndex(index)]) > 0) {
            this.heap.Swap(index, this.ParentIndex(index));
            index = this.ParentIndex(index);
        }
    }

    public T PopNextOrDefault() {
        if (this.heapSize == 0) return default(T);

        return this.PopNext();
    }

    public T PopNext() {
        if (this.heapSize == 0) throw new InvalidOperationException("No items left");

        T item = this.heap[0];

        this.heap[0] = default(T);

        this.heap.Swap(0, this.heapSize - 1);

        this.heapSize--;

        this.FixMaxHeap(0);

        return item;
    }

    public override string ToString() {
        StringBuilder str = new StringBuilder();

        str.Append($"PriorityQueue (Next: {this.Next}) [");

        for (int i = 0; i < this.heapSize; i++) {
            if (i > 0) str.Append(", ");

            str.Append(this.heap[i]);
        }

        str.Append("]");

        return str.ToString();
    }
}

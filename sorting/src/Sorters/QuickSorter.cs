using System;
using System.Collections.Generic;
using System.Linq;

namespace Sorting.Sorters {
    public class QuickSorter : Sorter {
        public override IList<T> Sort<T>(IList<T> items, Comparison<T> comparer) {
            T[] array = items.ToArray();
            this.Recurse(array, 0, array.Length - 1, comparer);
            return new List<T>(array);
        }

        private void Recurse<T>(T[] array, int low, int high, Comparison<T> comparer) {
            if (low >= high) return;

            int leftPartitionEndIndex = this.Partition(array, low, high, comparer);
            this.Recurse(array, low, leftPartitionEndIndex, comparer);
            this.Recurse(array, leftPartitionEndIndex + 1, high, comparer);
        }

        private int Partition<T>(T[] array, int low, int high, Comparison<T> comparer) {
            int left = low - 1,
                right = high + 1;

            T pivot = array[(low + high) / 2];

            while (true) {
                do {
                    left++;
                } while (comparer(array[left], pivot) < 0);

                do {
                    right--;
                } while (comparer(pivot, array[right]) < 0);

                if (left >= right) return right;

                T item = array[left];
                array[left] = array[right];
                array[right] = item;
            }
        }
    }
}

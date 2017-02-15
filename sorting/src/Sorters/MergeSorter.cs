using System;
using System.Collections.Generic;
using System.Linq;

namespace Sorting.Sorters {
    public class MergeSorter : Sorter {
        public override IList<T> Sort<T>(IList<T> items, Comparison<T> comparer) {
            T[] array = items.ToArray();

            this.Recurse(array, 0, array.Length - 1, comparer);

            return new List<T>(array);
        }

        private void Recurse<T>(T[] array, int start, int end, Comparison<T> comparer) {
            if (end <= start) return; // 1 element (or 0) trivially sorted

            int middle = (start + end) / 2;

            this.Recurse(array, start, middle, comparer);
            this.Recurse(array, middle + 1, end, comparer);

            this.Merge(array, start, middle, end, comparer);
        }

        private void Merge<T>(T[] array, int start, int middle, int end, Comparison<T> comparer) {
            T[] sorted = new T[1 + end - start];

            int leftHead = start;
            int rightHead = middle + 1;

            for (int i = 0; i < sorted.Length; i++) {
                if (leftHead <= middle && (rightHead > end || comparer(array[leftHead], array[rightHead]) < 0)) {
                    // If there is at least one left element and it is less than the current right element
                    // OR there are no right elements, then set the left element
                    sorted[i] = array[leftHead];
                    leftHead++;
                } else {
                    // If the current right element is less than or equal to the current left element
                    // OR there are no left elements, then set the right element
                    sorted[i] = array[rightHead];
                    rightHead++;
                }
            }

            for (int i = 0; i < sorted.Length; i++) {
                array[i + start] = sorted[i];
            }
        }
    }
}

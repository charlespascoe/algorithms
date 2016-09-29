using System;
using System.Collections.Generic;

namespace Sorting.Sorters {
    public class InsertionSorter : ISorter {
        public void Sort<T>(IList<T> items) where T : IComparable<T> {
            this.Sort(items, (a, b) => a.CompareTo(b));
        }

        public void Sort<T>(IList<T> items, Comparison<T> comparer) {
            for (int i = 1; i < items.Count; i++) {
                T key = items[i];

                int j = i - 1;

                while (j >= 0 && comparer(items[j], key) > 0) {
                    items[j + 1] = items[j];
                    j--;
                }

                items[j + 1] = key;
            }
        }
    }
}

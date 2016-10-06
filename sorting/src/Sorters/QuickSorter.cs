using System;
using System.Collections.Generic;
using System.Linq;

namespace Sorting.Sorters {
    public class QuickSorter : Sorter {
        public override IList<T> Sort<T>(IList<T> items, Comparison<T> comparer) {
            return this.Recurse(items.ToList(), comparer);
        }

        private List<T> Recurse<T>(List<T> items, Comparison<T> comparer) {
            if (items.Count <= 1) return items;

            T pivot = items.Last();
            List<T> left = new List<T>(items.Count);
            List<T> right = new List<T>(items.Count);

            for (int i = 0; i < items.Count - 1; i++) {
                if (comparer(items[i], pivot) < 0) {
                    left.Add(items[i]);
                } else {
                    right.Add(items[i]);
                }
            }

            left = this.Recurse(left, comparer);
            right = this.Recurse(right, comparer);

            left.Add(pivot);
            left.AddRange(right);

            return left;
        }
    }
}

using System;
using System.Collections.Generic;

namespace Sorting.Sorters {
    public class InsertionSorter : Sorter {
        public override IList<T> Sort<T>(IList<T> originalItems, Comparison<T> comparer) {
            List<T> items = new List<T>(originalItems);

            for (int i = 1; i < items.Count; i++) {
                T key = items[i];

                int j = i - 1;

                while (j >= 0 && comparer(items[j], key) > 0) {
                    items[j + 1] = items[j];
                    j--;
                }

                items[j + 1] = key;
            }

            return items;
        }
    }
}

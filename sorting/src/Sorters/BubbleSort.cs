using System;
using System.Collections.Generic;

namespace Sorting.Sorters {
    public class BubbleSorter : Sorter {
        public override IList<T> Sort<T>(IList<T> items, Comparison<T> comparer) {
            List<T> list = new List<T>(items);

            for (int i = list.Count - 1; i > 0; i--) {
                for (int j = 0; j < i; j++) {
                    if (comparer(list[j], list[j + 1]) > 0) {
                        T item  = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = item;
                    }
                }
            }

            return list;
        }
    }
}

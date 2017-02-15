using System;
using System.Collections.Generic;

namespace Sorting.Sorters {
    public class BubbleSorter : Sorter {
        public override IList<T> Sort<T>(IList<T> items, Comparison<T> comparer) {
            List<T> list = new List<T>(items);

            int limit = list.Count,
                highestSwapped;

            while (limit > 0) {
                highestSwapped = 0;
                for (int i = 0; i < limit - 1; i++) {
                    if (comparer(list[i], list[i + 1]) > 0) {
                        T item  = list[i];
                        list[i] = list[i + 1];
                        list[i + 1] = item;
                        highestSwapped = i + 1;
                    }
                }

                limit = highestSwapped;
            }

            return list;
        }
    }
}

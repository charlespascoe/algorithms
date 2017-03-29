using System;
using System.Collections.Generic;
using System.Threading;

namespace Sorting.Sorters {
    // http://www.smbc-comics.com/comic/efficient-sorting
    public class ExistentialSorter : Sorter {
        public override IList<T> Sort<T>(IList<T> items, Comparison<T> comparer) {
            List<T> sorted;

            for (ulong i = 0; i < ulong.MaxValue; i++) {
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }

            sorted = new List<T>(items);

            return sorted;
        }
    }
}

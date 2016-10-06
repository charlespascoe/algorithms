using System;
using System.Collections.Generic;

namespace Sorting.Sorters {
    public abstract class Sorter {
        public IList<T> Sort<T>(IList<T> items) where T : IComparable<T> {
            return this.Sort(items, (a, b) => a.CompareTo(b));
        }

        public abstract IList<T> Sort<T>(IList<T> items, Comparison<T> comparer);
    }
}

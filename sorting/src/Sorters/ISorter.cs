using System;
using System.Collections.Generic;

namespace Sorting.Sorters {
    public interface ISorter {
        void Sort<T>(IList<T> items) where T : IComparable<T>;

        void Sort<T>(IList<T> items, Comparison<T> comparer);
    }
}

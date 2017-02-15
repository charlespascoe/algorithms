using System;
using System.Collections.Generic;

public static class Extensions {
    public static T Pop<T>(this List<T> items, int index) {
        T item = items[index];
        items.RemoveAt(index);
        return item;
    }

    public static T PopMin<T,V>(this List<T> items, Func<T,V> getKey) where V : IComparable {
        if (items.Count == 0) return default(T);

        int bestIndex = 0;

        for (int i = 1; i < items.Count; i++) {
            if (getKey(items[i]).CompareTo(getKey(items[bestIndex])) < 0) {
                bestIndex = i;
            }
        }

        return items.Pop(bestIndex);
    }
}

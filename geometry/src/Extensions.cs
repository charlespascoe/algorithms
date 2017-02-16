using System;
using System.Collections.Generic;

public static class Extensions {
    public static T PeekSecond<T>(this Stack<T> stack) {
        if (stack.Count < 2) return default(T);

        T top = stack.Pop();
        T second = stack.Peek();
        stack.Push(top);
        return second;
    }

	public static void ForEach<T>(this IEnumerable<T> enumeration, Action<T> action) {
		foreach(T item in enumeration) {
			action(item);
		}
	}
}

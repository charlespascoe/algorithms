using System;

public static class Program {
    public static void Main(string[] args) {
        Stack<int> stack = new Stack<int>();

        Console.WriteLine(stack);

        stack.Add(123);

        Console.WriteLine(stack.Count);
        Console.WriteLine(stack);

        stack.Add(456);

        Console.WriteLine(stack.Count);
        Console.WriteLine(stack);

        Console.WriteLine(stack.Pop());

        Console.WriteLine(stack.Count);
        Console.WriteLine(stack);

        Console.WriteLine(stack.PopOrDefault());
        Console.WriteLine(stack.PopOrDefault());
        Console.WriteLine(stack.PopOrDefault());
    }
}

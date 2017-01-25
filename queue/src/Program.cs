using System;

public static class Program {
    public static void Main(string[] args) {
        Queue<int> queue = new Queue<int>();

        queue.Add(123);

        Console.WriteLine(queue);

        queue.Add(456);
        queue.Add(789);

        Console.WriteLine(queue);

        Console.WriteLine(queue.Next());
        Console.WriteLine(queue);

        Console.WriteLine(queue.NextOrDefault());
        Console.WriteLine(queue.NextOrDefault());
        Console.WriteLine(queue.NextOrDefault());
        Console.WriteLine(queue.NextOrDefault());
    }
}

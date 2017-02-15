using System;

public static class Program {
    public static void Main(string[] args) {
        PriorityQueue<int> queue = new PriorityQueue<int>(new int[] { 1 });

        Console.WriteLine(queue);
        queue.Insert(2);
        Console.WriteLine(queue);
        queue.Insert(7);
        Console.WriteLine(queue);
        queue.Insert(9);
        Console.WriteLine(queue);
        queue.Insert(3);
        Console.WriteLine(queue);
        queue.Insert(4);
        Console.WriteLine(queue);
        Console.WriteLine(queue.PopNextOrDefault());
        Console.WriteLine(queue);
        Console.WriteLine(queue.PopNextOrDefault());
        Console.WriteLine(queue);
        Console.WriteLine(queue.PopNextOrDefault());
        Console.WriteLine(queue);
        Console.WriteLine(queue.PopNextOrDefault());
        Console.WriteLine(queue);
        Console.WriteLine(queue.PopNextOrDefault());
        Console.WriteLine(queue);
        Console.WriteLine(queue.PopNextOrDefault());
        Console.WriteLine(queue);
        Console.WriteLine(queue.PopNextOrDefault());
        Console.WriteLine(queue);
        Console.WriteLine(queue.PopNextOrDefault());
        Console.WriteLine(queue);
        Console.WriteLine(queue.PopNextOrDefault());
        Console.WriteLine(queue);

    }
}

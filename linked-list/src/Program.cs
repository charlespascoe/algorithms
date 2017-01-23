using System;

public static class Program {
    public static void Main(string[] args) {
        LinkedList<int> list = new LinkedList<int>();

        Console.WriteLine(list.Count);

        list.Add(123);

        Console.WriteLine(list.Count);
        Console.WriteLine(list.ToString());

        list.Add(456);
        list.Add(789);

        Console.WriteLine(list.ToString());

        Console.WriteLine(list[2]);
        list[2] = -1;
        Console.WriteLine(list.ToString());

        Console.WriteLine(list.Remove(1));
        Console.WriteLine(list.ToString());
    }
}

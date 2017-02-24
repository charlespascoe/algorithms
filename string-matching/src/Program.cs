using System;
using System.Text;

public static class Program {
    public static void Main(string[] args) {
        byte[] data = { 1, 2, 3, 4, 5, 3, 1, 2, 3, 1, 2, 3 };
        byte[] pattern = { 3, 1, 2, 3 };

        RabinKarpMatcher rkMatcher = RabinKarpMatcher.MatchAll(pattern, data);

        Console.Write("Data: ");
        Program.PrintArray(data);
        Console.Write("Pattern: ");
        Program.PrintArray(pattern);

        Console.WriteLine("Rabin-Karp Matching:");

        while (!rkMatcher.Done) {
            Console.WriteLine($"Match: {rkMatcher.NextMatch()}");
        }

        Console.WriteLine("Finite State Automata Matching:");

        FiniteStateAutomataMatcher fsaMatcher = FiniteStateAutomataMatcher.MatchAll(pattern, data);

        while (!fsaMatcher.Done) {
            Console.WriteLine($"Match: {fsaMatcher.NextMatch()}");
        }
    }

    private static void PrintArray(byte[] array) {
        StringBuilder str = new StringBuilder();

        str.Append("[");

        bool first = true;

        for (int i = 0; i < array.Length; i++) {
            if (!first) {
                str.Append(", ");
            }

            first = false;

            str.AppendLine().Append($"  {i.ToString().PadLeft((array.Length - 1).ToString().Length)}: {array[i]}");
        }

        if (array.Length > 0) {
            str.AppendLine();
        }

        str.Append("]");

        Console.WriteLine(str);
    }
}

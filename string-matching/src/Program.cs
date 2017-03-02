using System;
using System.IO;
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

        Console.WriteLine("Naive Matching:");

        NaiveMatcher nMatcher = NaiveMatcher.MatchAll(pattern, data);

        while (!nMatcher.Done) {
            Console.WriteLine($"Match: {nMatcher.NextMatch()}");
        }

        Program.PerformanceTests();
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

    private static void PerformanceTests() {
        byte[] data = File.ReadAllBytes("src/FiniteStateAutomataMatcher.cs");

        byte[] pattern = Encoding.UTF8.GetBytes("int");

        int rounds = 100000;

        DateTime start = DateTime.Now;

        for (int i = 0; i < rounds; i++) {
            NaiveMatcher matcher = NaiveMatcher.MatchAll(pattern, data);

            while (!matcher.Done) {
                matcher.NextMatch();
            }
        }

        Console.Write("NaiveMatcher: ");
        Console.WriteLine(DateTime.Now - start);

        start = DateTime.Now;

        for (int i = 0; i < rounds; i++) {
            RabinKarpMatcher matcher = RabinKarpMatcher.MatchAll(pattern, data);

            while (!matcher.Done) {
                matcher.NextMatch();
            }
        }

        Console.Write("RabinKarpMatcher: ");
        Console.WriteLine(DateTime.Now - start);

        start = DateTime.Now;

        for (int i = 0; i < rounds; i++) {
            FiniteStateAutomataMatcher matcher = FiniteStateAutomataMatcher.MatchAll(pattern, data);

            while (!matcher.Done) {
                matcher.NextMatch();
            }
        }

        Console.Write("FiniteStateAutomataMatcher: ");
        Console.WriteLine(DateTime.Now - start);
    }
}

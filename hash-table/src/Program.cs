using System;

public static class Program {
    public static void Main(string[] args) {
        HashTable<string,int> hashTable = new HashTable<string,int>();

        Console.WriteLine(hashTable);

        hashTable["test"] = 123;

        Console.WriteLine(hashTable);

        hashTable["example"] = 1234;

        Console.WriteLine(hashTable);

        hashTable["something else"] = -1;

        Console.WriteLine(hashTable);

        hashTable["something else"] = 7;

        Console.WriteLine(hashTable);

        hashTable["wut"] = 1234132;

        hashTable["something!!"] = 0;

        hashTable["Test"] = 1324;

        hashTable["Something!!"] = 99;

        Console.WriteLine(hashTable);

        Console.WriteLine(hashTable.Remove("test"));
        Console.WriteLine(hashTable);
        Console.WriteLine(hashTable.Remove("test"));
        Console.WriteLine(hashTable.Remove("example"));
        Console.WriteLine(hashTable.Remove("something else"));
        Console.WriteLine(hashTable.Remove("wut"));
        Console.WriteLine(hashTable.Remove("something!!"));
        Console.WriteLine(hashTable.Remove("Test"));
        Console.WriteLine(hashTable.Remove("Something!!"));
        Console.WriteLine(hashTable.Remove("Something!!"));
        Console.WriteLine(hashTable);
    }
}

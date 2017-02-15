using System;
using System.Text;
using System.Collections.Generic;
using Sorting.Sorters;

namespace Sorting {
    public static class Program {
        public static void Main(string [] args) {
            Sorter sorter = new MergeSorter();

            List<int> items = new List<int> {
                5, 9, 1, 12, 7, 9, 2, 3, 99, 0
            };

            Program.PrintList("Unsorted", items);

            Program.PrintList("Bubble Sort", new BubbleSorter().Sort(items));
            Program.PrintList("Insertion Sort", new InsertionSorter().Sort(items));
            Program.PrintList("Merge Sort", new MergeSorter().Sort(items));
            Program.PrintList("Quick Sort", new QuickSorter().Sort(items));

            Program.PrintList("Afterward", items);
        }

        public static void PrintList<T>(string type, IList<T> items) {
            StringBuilder str = new StringBuilder();
            str.Append($"{type}:".PadRight(16, ' ')).Append("[");

            bool firstItem = true;

            foreach (T item in items) {
                if (!firstItem) {
                    str.Append(", ");
                } else {
                    firstItem = false;
                }

                str.Append(item);
            }

            str.Append("]");

            Console.WriteLine(str);
        }
    }
}

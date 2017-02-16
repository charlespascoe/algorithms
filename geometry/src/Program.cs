using System;

public static class Program {
    public static void Main(string[] args) {
        // Cross products using matrix determinants

        Vector v1 = new Vector(7, 7);
        Vector v2 = new Vector(10, 5);
        Vector v3 = new Vector(11, 25);
        Vector v4 = new Vector(100, 100);

        Console.WriteLine($"v1 and v2: {Program.FormatDeterminant(Vector.Determinant(v1, v2))}");
        Console.WriteLine($"v1 and v3: {Program.FormatDeterminant(Vector.Determinant(v1, v3))}");
        Console.WriteLine($"v1 and v4: {Program.FormatDeterminant(Vector.Determinant(v1, v4))}");
    }

    private static string FormatDeterminant(decimal determinant) {
        if (determinant > 0) {
            return "Anticlockwise";
        } else if (determinant < 0) {
            return "Clockwise";
        } else {
            return "Colinear";
        }
    }
}

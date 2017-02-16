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
        Console.WriteLine($"|(3, 4)| = {new Vector(3, 4).Magnitude}");

        Line line1 = new Line(new Vector(1, 3), new Vector(4, 7));

        Console.WriteLine($"{line1}, (9, 30): {Program.FormatDirection(line1.Direction(new Vector(9, 30)))}");

        Line line2 = new Line(new Vector(10, 30), new Vector(4, 7));

        Console.WriteLine($"{line2}, (9, 3): {Program.FormatDirection(line2.Direction(new Vector(9, 30)))}");
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

    private static string FormatDirection(decimal direction) {
        if (direction < 0) {
            return "Anticlockwise";
        } else if (direction > 0) {
            return "Clockwise";
        } else {
            return "Colinear";
        }
    }
}

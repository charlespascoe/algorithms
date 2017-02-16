using System;
using System.Collections.Generic;

public static class Program {
    public static void Main(string[] args) {
        // Cross products using matrix determinants

        Vector v1 = new Vector(7, 7);
        Vector v2 = new Vector(10, 5);
        Vector v3 = new Vector(11, 25);
        Vector v4 = new Vector(10, 10);

        Console.WriteLine($"v1 and v2: {Program.FormatDeterminant(Vector.Determinant(v1, v2))}");
        Console.WriteLine($"v1 and v3: {Program.FormatDeterminant(Vector.Determinant(v1, v3))}");
        Console.WriteLine($"v1 and v4: {Program.FormatDeterminant(Vector.Determinant(v1, v4))}");
        Console.WriteLine($"|(3, 4)| = {new Vector(3, 4).Magnitude}");

        Line line1 = new Line(new Vector(1, 3), new Vector(4, 7));

        Console.WriteLine($"{line1}, (9, 30): {Program.FormatDeterminant(Vector.Determinant(line1.Point1, line1.Point2, new Vector(9, 30)))}");

        Line line2 = new Line(new Vector(10, 30), new Vector(4, 7));

        Console.WriteLine($"{line2}, (9, 30): {Program.FormatDeterminant(Vector.Determinant(line2.Point1, line2.Point2, new Vector(9, 30)))}");

        GeometricGraphics gg = new GeometricGraphics(300, 300, new Vector(10, 10), 10);

        gg.DrawGrid(5);
        gg.DrawAxes();
        gg.DrawPoint(v1);
        gg.DrawPoint(v2);
        gg.DrawPoint(v3);
        gg.DrawPoint(v4);
        gg.DrawPoint(new Vector(-5, -1));
        gg.DrawLine(line1, true);
        gg.DrawLine(line2, true);

        gg.Image.Save("out.png");

        Program.GrahamsScanExample();
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

    private static void GrahamsScanExample() {
        Console.WriteLine("===== GRAHAM'S SCAN EXAMPLE =====");

        HashSet<Vector> points = new HashSet<Vector>();

        Random random = new Random();

        for (int i = 0; i < 50; i++) {
            points.Add(new Vector((decimal)(18 * random.NextDouble() + 1), (decimal)(18 * random.NextDouble() + 1)));
        }

        GeometricGraphics gg = new GeometricGraphics(500, 500, new Vector(), 25);
        gg.DrawGrid(1).DrawAxes();

        Vector firstPoint = new Vector();
        Vector prevPoint = new Vector();
        bool first = true;

        foreach (Vector point in new GrahamsScan().ConvexHull(points)) {
            if (first) {
                firstPoint = point;
                prevPoint = point;
                first = false;
            } else {
                gg.DrawLine(new Line(prevPoint, point));
                prevPoint = point;
            }
        }

        gg.DrawLine(new Line(prevPoint, firstPoint));

        gg.DrawPoints(points);

        gg.Image.Save("convex-hull.png");
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

public class GrahamsScan {
    public Vector[] ConvexHull(HashSet<Vector> points) {
        Vector point0 = new Vector();
        bool first = true;

        foreach (Vector point in points) {
            if (first) {
                point0 = point;
                first = false;
                continue;
            }

            if (point.Y < point0.Y || (point.Y == point0.Y && point.X < point0.X)) {
                point0 = point;
            }
        }

        Vector xUnit = new Vector(1, 0);

        Stack<Vector> otherPoints = new Stack<Vector>();

        points
            .OrderBy(p => Vector.Determinant(p - point0, xUnit))
            .ForEach(p => {
                if (p != point0) otherPoints.Push(p);
            });

        Stack<Vector> convexHull = new Stack<Vector>();

        // Push inital 3 points for convex hull
        convexHull.Push(point0);
        convexHull.Push(otherPoints.Pop());
        convexHull.Push(otherPoints.Pop());

        // Loop goes anit-clockwise about p0 through points,
        // therefore any three consecutive convex hull points will always be anticlockwise with each other (+ve determinant)
        while (otherPoints.Count > 0) {
            Vector nextPoint = otherPoints.Pop();

            if (Vector.Determinant(convexHull.PeekSecond(), convexHull.Peek(), nextPoint) <= 0) {
                convexHull.Pop();
                convexHull.Push(nextPoint);
            }
        }

        return convexHull.ToArray();
    }
}

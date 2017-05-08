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

        Stack<Vector> otherPoints = new Stack<Vector>();

        // point0 is last in stack, to complete the hull
        otherPoints.Push(point0);

        points
            .OrderBy(p => p, Comparer<Vector>.Create((p1, p2) => Vector.Determinant(point0, p1, p2).CompareTo(0)))
            .ForEach(p => {
                if (p != point0) otherPoints.Push(p);
            });

        Stack<Vector> convexHull = new Stack<Vector>();

        // Push inital 3 points for convex hull
        convexHull.Push(point0);
        convexHull.Push(otherPoints.Pop());
        convexHull.Push(otherPoints.Pop());

        // Loop goes anti-clockwise about p0 through points,
        // therefore any three consecutive convex hull points will always be anticlockwise with each other (+ve determinant)
        while (otherPoints.Count > 0) {
            Vector nextPoint = otherPoints.Pop();

            while (Vector.Determinant(convexHull.PeekSecond(), convexHull.Peek(), nextPoint) <= 0) {
                convexHull.Pop();
            }

            convexHull.Push(nextPoint);
        }

        convexHull.Pop();

        return convexHull.ToArray();
    }
}

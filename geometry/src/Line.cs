using System;

public class Line {
    public Vector Point1 { get; private set; }

    public Vector Point2 { get; private set; }

    public Line(Vector p1, Vector p2) {
        this.Point1 = p1;
        this.Point2 = p2;
    }

    public bool InRectangle(Vector vector) {
        return (
            Math.Min(this.Point1.X, this.Point2.X) <= vector.X &&
            vector.X <= Math.Max(this.Point1.X, this.Point2.X) &&
            Math.Min(this.Point1.Y, this.Point2.Y) <= vector.Y &&
            vector.Y <= Math.Max(this.Point1.Y, this.Point2.Y)
        );
    }

    // +ve if p1 -> p2 -> vector is clockwise turn
    // -ve if p1 -> p2 -> vector is anticlockwise turn
    // 0 if colinear
    public decimal Direction(Vector vector) {
        return Vector.Determinant(vector - this.Point1, this.Point2 - this.Point1);
    }

    public override string ToString() {
        return $"{this.Point1}---{this.Point2}";
    }
}

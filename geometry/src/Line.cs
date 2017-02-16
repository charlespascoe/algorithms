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

    public bool Intersects(Line other) {
        decimal det0 = Vector.Determinant(this.Point1, this.Point2, other.Point1),
                det1 = Vector.Determinant(this.Point1, this.Point2, other.Point2),
                det2 = Vector.Determinant(other.Point1, other.Point2, this.Point1),
                det3 = Vector.Determinant(other.Point1, other.Point2, this.Point2);

        return (
            (det0 == 0 || det1 == 0 || Math.Sign(det0) != Math.Sign(det1)) && // Checks both points of other line fall either side of this line
            (det2 == 0 || det3 == 0 || Math.Sign(det2) != Math.Sign(det3))    // Checks both points of this line fall either side of other line
        );
    }

    public override string ToString() {
        return $"{this.Point1}---{this.Point2}";
    }
}

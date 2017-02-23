using System;

public class Line {
    public Vector Point1 { get; private set; }

    public Vector Point2 { get; private set; }

    public bool IsVertical => this.Point1.X == this.Point2.X;

    public bool IsHorizontal => this.Point1.Y == this.Point2.Y;

    public Line(Vector p1, Vector p2) {
        if (p1 == p2) throw new Exception("A line must have different end points");
        this.Point1 = p1;
        this.Point2 = p2;
    }

    public decimal ComputeGradient() {
        return (this.Point2.Y - this.Point1.Y) / (this.Point2.X - this.Point1.X);
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

    public Vector IntersectionPoint(Line other) {
        if (this.IsVertical && other.IsVertical) throw new Exception("Parallel Lines");

        if (this.IsVertical || other.IsVertical) {
            // Convert points to line equation y = m * x + c
            decimal x, m, c;

            if (this.IsVertical) {
                m = other.ComputeGradient();
                c = other.Point1.Y - m * other.Point1.X;
                x = this.Point1.X;
            } else {
                m = this.ComputeGradient();
                c = this.Point1.Y - m * this.Point1.X;
                x = other.Point1.X;
            }

            return new Vector(x, m * x + c);
        } else {
            // Convert points to line equation y = m * x + c
            decimal m1 = this.ComputeGradient(),
                    c1 = this.Point1.Y - m1 * this.Point1.X,
                    m2 = other.ComputeGradient(),
                    c2 = other.Point1.Y - m2 * other.Point1.X;

            if (m1 == m2) throw new Exception("Parallel Lines");

            // m1 * x + c1 = m2 * x + c2
            decimal x = (c2 - c1) / (m1 - m2),
                    y = m1 * x + c1;

            return new Vector(x, y);
        }
    }

    public override string ToString() {
        return $"{this.Point1}---{this.Point2}";
    }
}

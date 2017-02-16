using System;

public struct Vector {
    private readonly decimal x;
    private readonly decimal y;

    public decimal X => this.x;
    public decimal Y => this.y;

    public decimal MagnitudeSquared => this.X * this.X + this.Y * this.Y;

    public decimal Magnitude => Utils.Sqrt(this.MagnitudeSquared);

    public Vector(Vector v) : this(v.X, v.Y) {}

    public Vector(decimal x, decimal y) {
        this.x = x;
        this.y = y;
    }

    public static Vector operator +(Vector v1, Vector v2) {
        return new Vector(v1.X + v2.X, v1.Y + v2.Y);
    }

    public static Vector operator -(Vector v1, Vector v2) {
        return new Vector(v1.X - v2.X, v1.Y - v2.Y);
    }

    public static Vector operator *(decimal s, Vector v) {
        return new Vector(s * v.X, s * v.Y);
    }

    public static Vector operator *(Vector v, decimal s) {
        return s * v;
    }

    public static Vector operator /(Vector v, decimal s) {
        return new Vector(v.X / s, v.Y / s);
    }

    public static bool operator ==(Vector v1, Vector v2) {
        return v1.X == v2.X && v1.Y == v2.Y;
    }

    public static decimal Determinant(Vector v1, Vector v2) {
        return v1.X * v2.Y - v2.X * v1.Y;
    }

    public static bool operator !=(Vector v1, Vector v2) {
        return !(v1 == v2);
    }

    public override bool Equals(object o) {
        if (!(o is Vector)) return false;
        return this == (Vector)o;
    }

    public override int GetHashCode() {
        return this.X.GetHashCode() ^ this.Y.GetHashCode();
    }

    public override string ToString() {
        return $"({this.X}, {this.Y})";
    }
}

using System;

public static class Utils {
    public static decimal Sqrt(decimal x, decimal epsilon = 0.0M) {
        if (x < 0) throw new ArgumentOutOfRangeException("x", x, "Cannot be negative");

        // Math.Sqrt to get initial estimate
        decimal previous, sqrt = (decimal)Math.Sqrt((double)x);

        do {
            previous = sqrt;
            if (previous == 0) return 0;

            sqrt = (previous + x / previous) / 2;
        } while (Math.Abs(previous - sqrt) > epsilon);

        return sqrt;
    }
}

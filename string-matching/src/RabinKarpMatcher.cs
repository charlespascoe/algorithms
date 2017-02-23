public class RabinKarpMatcher {
    private const ulong Q = 72057594037927931; // Largest prime less than 2^56
    private const ulong BASE = 256;

    private byte[] pattern;
    private ulong p;
    private byte[] data;
    private int position;
    private ulong t;
    private ulong h;
    private bool done = false;

    public bool Done => this.done;

    private RabinKarpMatcher(byte[] pattern, byte[] data, int start) {
        this.pattern = pattern;
        this.data = data;

        if (this.pattern.Length > this.data.Length) {
            this.done = true;
        } else {
            this.position = start;
            this.h = this.ComputeH(this.pattern.Length);
            this.p = this.BytesToNumber(this.pattern, 0, this.pattern.Length);
            this.t = this.BytesToNumber(this.data, this.position, this.pattern.Length);
        }
    }

    public static RabinKarpMatcher MatchAll(byte[] pattern, byte[] data, int start = 0) {
        return new RabinKarpMatcher(pattern, data, start);
    }

    public static int Match(byte[] pattern, byte[] data, int start = 0) {
        return RabinKarpMatcher.MatchAll(pattern, data, start).NextMatch();
    }


    public int NextMatch() {
        while (!this.done) {
            if (this.p == this.t && this.NaiveMatch()) {
                int pos = this.position;
                this.Step();
                return pos;
            }

            this.Step();
        }

        return -1;
    }

    private void Step() {
        if (this.done) return;

        if (this.position + this.pattern.Length >= this.data.Length) {
            this.done = true;
        } else {
            this.t = (((this.t - this.h * this.data[this.position]) << 8) + this.data[this.position + this.pattern.Length]) % Q;
            this.position++;
        }
    }

    private bool NaiveMatch() {
        for (int i = 0; i < this.pattern.Length; i++) {
            if (this.pattern[i] != data[i + this.position]) return false;
        }

        return true;
    }

    private ulong BytesToNumber(byte[] input, int start, int length) {
        ulong result = 0;

        for (int i = length - 1; i >= 0; i--) {
            result = ((result << 8) + input[start + i]) % Q;
        }

        return result;
    }

    private ulong ComputeH(int patternLength) {
        ulong h = 1;

        // h = BASE^(patternLength - 1) mod Q
        // BASE power of 2, so bit shifts instead of multiplication

        for (int i = 0; i < patternLength - 1; i++) {
            h = (h << 8) % Q;
        }

        return h;
    }
}

public class NaiveMatcher {
    #region Private Fields
    private byte[] pattern;
    private byte[] data;
    private int position;
    #endregion

    #region Properties
    public bool Done { get; private set; }
    #endregion

    #region Constructors
    private NaiveMatcher(byte[] pattern, byte[] data, int start) {
        if (pattern.Length > data.Length - start) {
            this.Done = true;
        } else {
            this.pattern = pattern;
            this.data = data;
            this.position = start;
        }
    }
    #endregion

    #region Public Methods
    public static NaiveMatcher MatchAll(byte[] pattern, byte[] data, int start = 0) {
        return new NaiveMatcher(pattern, data, start);
    }

    public static int Match(byte[] pattern, byte[] data, int start = 0) {
        return NaiveMatcher.MatchAll(pattern, data, start).NextMatch();
    }

    public int NextMatch() {
        while (!this.Done) {
            if (this.IsMatch()) {
                int pos = this.position;
                this.Step();
                return pos;
            }

            this.Step();
        }

        return -1;
    }
    #endregion

    #region Private Methods
    private void Step() {
        if (this.Done) return;

        this.position++;

        if (this.position + this.pattern.Length > this.data.Length) {
            this.Done = true;
        }
    }

    private bool IsMatch() {
        for (int i = 0; i < this.pattern.Length; i++) {
            if (this.pattern[i] != this.data[i + this.position]) return false;
        }

        return true;
    }
    #endregion
}

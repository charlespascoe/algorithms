using System;

public class FiniteStateAutomataMatcher : IMatcher {
    private class State {
        private int[] transitions = new int[256];

        public bool AcceptableState { get; set; } = false;

        public int this[byte symbol] {
            get { return this.transitions[symbol]; }
            set { this.transitions[symbol] = value; }
        }

    }

    #region Private Fields
    private State[] states;
    private State state;
    private byte[] pattern;
    private byte[] data;
    private int position; // position is the next symbol to be processed
    #endregion

    #region Properties
    public bool Done { get; private set; } = false;
    #endregion

    #region Constructors
    private FiniteStateAutomataMatcher(byte[] pattern, byte[] data, int start) {
        if (pattern.Length > data.Length - start) {
            this.Done = true;
        } else {
            this.pattern = pattern;
            this.data = data;
            this.position = start;
            this.states = this.ComputeStates(pattern);
            this.states[this.states.Length - 1].AcceptableState = true;
            this.state = this.states[0];
        }
    }
    #endregion

    #region Public Methods
    public static FiniteStateAutomataMatcher MatchAll(byte[] pattern, byte[] data, int start = 0) {
        return new FiniteStateAutomataMatcher(pattern, data, start);
    }

    public static int Match(byte[] pattern, byte[] data, int start = 0) {
        return FiniteStateAutomataMatcher.MatchAll(pattern, data, start).NextMatch();
    }

    public int NextMatch() {
        while (!this.Done) {
            if (this.state.AcceptableState) {
                int pos = this.position;
                this.Step();
                return pos - this.pattern.Length;
            }

            this.Step();
        }

        return -1;
    }
    #endregion

    #region Private Methods
    private State[] ComputeStates(byte[] pattern) {
        State[] states = new State[pattern.Length + 1];

        for (int i = 0; i < states.Length; i++) {
            states[i] = new State();
        }

        for (int stateIndex = 0; stateIndex <= pattern.Length; stateIndex++) {
            for (short symbol = 0; symbol < 256; symbol++) {
                states[stateIndex][(byte)symbol] = this.FindNextState(pattern, stateIndex, (byte)symbol);
            }
        }

        return states;
    }

    private int FindNextState(byte[] pattern, int stateIndex, byte symbol) {
        int nextStateIndex = Math.Min(pattern.Length + 1, stateIndex + 2);

        bool foundSuffix = false;

        // Find the largest prefix of P that is a suffix of P[0..stateIndex-1] + symbol

        while (!foundSuffix) {
            nextStateIndex--;

            if (nextStateIndex == 0) return 0;

            if (pattern[nextStateIndex - 1] == symbol) {
                foundSuffix = true;
                for (int i = nextStateIndex - 2; i >= 0; i--) {
                    if (pattern[i] != pattern[stateIndex - (nextStateIndex - i) + 1]) {
                        foundSuffix = false;
                        break;
                    }
                }
            }
        }

        return nextStateIndex;
    }

    private void Step() {
        if (this.Done) return;

        if (this.position >= this.data.Length) {
            this.Done = true;
            return;
        }

        this.state = this.states[this.state[this.data[position]]];
        this.position++;
    }
    #endregion
}

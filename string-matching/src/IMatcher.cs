public interface IMatcher {
    bool Done { get; }

    int NextMatch();
}

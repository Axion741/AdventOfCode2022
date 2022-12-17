public interface IMove
{
    int Value { get; }
    char OpposingReference { get; }
    char PlayerReference { get; }
    IMove Beats { get; }
    IMove GenerateFullBeatsObject();
    IMove GenerateFullLosingObject();
}
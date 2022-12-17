public class Rock: IMove
{
    private int value = 1;
    private char opposingReference = 'A';
    private char playerReference = 'X';
    private IMove beats = null;

    public int Value { get { return this.value; } }
    public char OpposingReference { get { return this.opposingReference; } }
    public char PlayerReference { get { return this.playerReference; } }
    public IMove Beats { get { return this.beats; } }

    public Rock(bool populateBeats)
    {
        if (populateBeats)
            beats = new Scissors(false);
    }

    public IMove GenerateFullBeatsObject()
    {
        return new Scissors(true);
    }

    public IMove GenerateFullLosingObject()
    {
        return new Paper(true);
    }
}
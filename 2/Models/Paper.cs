public class Paper: IMove
{
    private int value = 2;
    private char opposingReference = 'B';
    private char playerReference = 'Y';
    private IMove beats = null;

    public int Value { get { return this.value; } }
    public char OpposingReference { get { return this.opposingReference; } }
    public char PlayerReference { get { return this.playerReference; } }
    public IMove Beats { get { return this.beats; } }

    public Paper(bool populateBeats)
    {
        if (populateBeats)
            beats = new Rock(false);
    }

    public IMove GenerateFullBeatsObject()
    {
        return new Rock(true);
    }

    public IMove GenerateFullLosingObject()
    {
        return new Scissors(true);
    }
}
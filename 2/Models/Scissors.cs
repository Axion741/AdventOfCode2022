public class Scissors: IMove
{
    private int value = 3;
    private char opposingReference = 'C';
    private char playerReference = 'Z';
    private IMove beats = null;

    public int Value { get { return this.value; } }
    public char OpposingReference { get { return this.opposingReference; } }
    public char PlayerReference { get { return this.playerReference; } }
    public IMove Beats { get { return this.beats; } }

    public Scissors(bool populateBeats)
    {
        if (populateBeats)
            beats = new Paper(false);
    }

    public IMove GenerateFullBeatsObject()
    {
        return new Paper(true);
    }

    public IMove GenerateFullLosingObject()
    {
        return new Rock(true);
    }
}
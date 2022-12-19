public class Pile
{
    public int Number { get; set; }
    public List<string> Crates { get; set; }

    public Pile()
    {
        this.Crates = new List<string>();
    }
}
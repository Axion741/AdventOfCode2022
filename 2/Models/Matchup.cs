public class Matchup
{
    IMove OpposingMove { get; set; }
    IMove PlayerMove { get; set; }
    public int Result { get; set; }

    public Matchup(IMove opposing, IMove player)
    {
        this.OpposingMove = opposing;
        this.PlayerMove = player;

        this.Result = CalculateResult();
    }

    private int CalculateResult() {
        if (this.PlayerMove.Beats.Value == this.OpposingMove.Value)
        {
            //Win
            return this.PlayerMove.Value + 6;
        }
        else if (this.PlayerMove.Value == this.OpposingMove.Value)
        {
            //Draw
            return this.PlayerMove.Value + 3;
        }
        else
        {
            //Lose
            return this.PlayerMove.Value;
        }
    }
}
public class PlayerScore
{
    public int rank { get; private set; }
    public int score { get; private set; }

    public PlayerScore(int rank, int score)
    {
        this.rank = rank;
        this.score = score;
    }
}

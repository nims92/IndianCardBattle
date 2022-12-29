public interface ILocationScoreManager
{
    public void AddScoreForPlayer(int score, int playerIndex);
    public int GetScoreForPlayer(int playerIndex);
}
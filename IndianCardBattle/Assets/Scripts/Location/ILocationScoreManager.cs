public interface ILocationScoreManager
{
    public void AddScoreForPlayer(int score, int playerIndex);
    public void DeductScoreForPlayer(int score, int playerIndex);
    public int GetScoreForPlayer(int playerIndex);
}
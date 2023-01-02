public class LocationScoreManager : ILocationScoreManager
{
    private int [] playerScores;

    public LocationScoreManager(int totalPlayers)
    {
        playerScores = new int[totalPlayers];
    }
    
    public void AddScoreForPlayer(int score, int playerIndex)
    {
        playerScores[playerIndex] += score;
    }
    
    public void DeductScoreForPlayer(int score, int playerIndex)
    {
        playerScores[playerIndex] -= score;
    }

    public int GetScoreForPlayer(int playerIndex)
    {
        return playerScores[playerIndex];
    }
}
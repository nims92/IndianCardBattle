public class ScoreManager
{
    private int [] playerScores;

    public ScoreManager(int totalPlayers)
    {
        playerScores = new int[totalPlayers];
    }
    
    public void AddToScoreForPlayer(int score, int playerIndex)
    {
        playerScores[playerIndex] += score;
    }

    public int GetScoreForPlayer(int playerIndex)
    {
        return playerScores[playerIndex];
    }
}
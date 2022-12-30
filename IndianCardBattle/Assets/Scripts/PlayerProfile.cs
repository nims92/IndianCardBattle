public class PlayerProfile
{
    private readonly string playerName;
    private readonly int playerID;

    public PlayerProfile(string playerName, int playerID)
    {
        this.playerName = playerName;
        this.playerID = playerID;
    }

    public int GetPlayerID()
    {
        return playerID;
    }

    public string GetPlayerName()
    {
        return playerName;
    }
}

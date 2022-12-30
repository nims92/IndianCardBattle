public class TurnManager
{
    private int currentTurnPlayerIndex;
    private int totalNumberOfPlayers;
    private int turnCounter;
    private int maxAllowedTurnsForGame;
    public int CurrentTurnPlayerIndex { get => currentTurnPlayerIndex; set => currentTurnPlayerIndex = value; }
    public int TotalNumberOfPlayers { get => totalNumberOfPlayers; set => totalNumberOfPlayers = value; }

    public int TurnCounter
    {
        get => turnCounter;
        set => turnCounter = value;
    }

    public TurnManager(int totalNumberOfPlayers, int maxAllowedTurnsForGame)
    {
        CurrentTurnPlayerIndex = 1;
        TotalNumberOfPlayers = totalNumberOfPlayers;
        this.maxAllowedTurnsForGame = maxAllowedTurnsForGame;
    }

    public void UpdateTurn()
    {
        TurnCounter++;
        CurrentTurnPlayerIndex++;

        if (CurrentTurnPlayerIndex == totalNumberOfPlayers)
            CurrentTurnPlayerIndex = 0;

        //TODO: fire event of turn updated
    }
    
    public bool IsMoreTurnAllowed()
    {
        if (TurnCounter == maxAllowedTurnsForGame)
            return false;

        return true;
    }
}

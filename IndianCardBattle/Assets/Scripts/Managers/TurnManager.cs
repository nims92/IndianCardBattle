public class TurnManager
{
    private int currentTurnIndex;
    private int totalNumberOfPlayers;

    public int CurrentTurnIndex { get => currentTurnIndex; set => currentTurnIndex = value; }
    public int TotalNumberOfPlayers { get => totalNumberOfPlayers; set => totalNumberOfPlayers = value; }

    public TurnManager(int totalNumberOfPlayers)
    {
        CurrentTurnIndex = 0;
        TotalNumberOfPlayers = totalNumberOfPlayers;
    }

    public void UpdateTurn()
    {
        currentTurnIndex++;

        if (currentTurnIndex == totalNumberOfPlayers)
            currentTurnIndex = 0;

        //TODO: fire event of turn updated
    }
}

public class TurnManager
{
    private int turnCounter;
    private readonly int maxAllowedTurnsForGame;
    private int TotalNumberOfPlayers { get; set; }
    public int CurrentTurnPlayerIndex { get; private set; }
    private int TurnCounter
    {
        get => turnCounter;
        set
        {
            turnCounter = value;
            if(IsMoreTurnAllowed())
                CustomEventManager.Instance.Invoke(TurnEvents.UPDATE_TURN_COST,TurnCounter);
        }
    }

    public TurnManager(int totalNumberOfPlayers, int maxAllowedTurnsForGame)
    {
        TotalNumberOfPlayers = totalNumberOfPlayers;
        this.maxAllowedTurnsForGame = maxAllowedTurnsForGame;
        CurrentTurnPlayerIndex = 0;
        TurnCounter = 1;
        CustomEventManager.Instance.AddListener(UIEvents.END_TURN_BUTTON_PRESSED,UpdateTurn);
    }

    private void UpdateTurn(params object [] args)
    {
        CurrentTurnPlayerIndex++;
        
        if (CurrentTurnPlayerIndex == TotalNumberOfPlayers)
        {
            CurrentTurnPlayerIndex = 0;
            TurnCounter++;
        }
        
        if(IsMoreTurnAllowed())
            CustomEventManager.Instance.Invoke(TurnEvents.TURN_UPDATED,CurrentTurnPlayerIndex);
        else
        {
            CustomEventManager.Instance.Invoke(GameFlowEvents.GAME_END_EVENT);
        }
    }

    private bool IsMoreTurnAllowed()
    {
        return TurnCounter <= maxAllowedTurnsForGame;
    }
}

using UnityEngine;

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
        CurrentTurnPlayerIndex = 0;
        TurnCounter = 1;
        TotalNumberOfPlayers = totalNumberOfPlayers;
        this.maxAllowedTurnsForGame = maxAllowedTurnsForGame;
        CustomEventManager.Instance.AddListener(UIEvents.END_TURN_BUTTON_PRESSED,UpdateTurn);
    }

    public void UpdateTurn(params object [] args)
    {
        CurrentTurnPlayerIndex++;
        
        if (CurrentTurnPlayerIndex == totalNumberOfPlayers)
        {
            CurrentTurnPlayerIndex = 0;
            TurnCounter++;
            CustomEventManager.Instance.Invoke(TurnEvents.UPDATE_TURN_COST,TurnCounter);
        }
        
        CustomEventManager.Instance.Invoke(TurnEvents.TURN_UPDATED,CurrentTurnPlayerIndex);
    }
    
    public bool IsMoreTurnAllowed()
    {
        if (TurnCounter == maxAllowedTurnsForGame)
            return false;

        return true;
    }
}

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
        get
        {
            return turnCounter;
        }
        private set
        {
            turnCounter = value;
            Debug.LogError($"Turn Counter {turnCounter}");
            if(IsMoreTurnAllowed())
                CustomEventManager.Instance.Invoke(TurnEvents.UPDATE_TURN_COST,TurnCounter);
            else
            {
                Debug.LogError($"No more turns allowed");
            }
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

    public void UpdateTurn(params object [] args)
    {
        CurrentTurnPlayerIndex++;
        
        if (CurrentTurnPlayerIndex == totalNumberOfPlayers)
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
    
    public bool IsMoreTurnAllowed()
    {
        if (TurnCounter > maxAllowedTurnsForGame)
            return false;

        return true;
    }
}

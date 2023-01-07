using UnityEngine;

public class RoundManager
{
    private readonly int maxAllowedRoundsForGame;
    //private TurnManager turnManager;

    private int RoundCounter { get; set; }

    //public TurnManager TurnManager => turnManager;

    public RoundManager(int numberOfRoundsForGame)
    {
        maxAllowedRoundsForGame = numberOfRoundsForGame;
        RoundCounter = 0;
        //turnManager = new TurnManager(Constants.NUMBER_OF_PLAYERS);
        
        //Subscribe to events
        CustomEventManager.Instance.AddListener(UIEvents.ROUND_COMPLETE_UI_ANIM_COMPLETE,OnRoundStartAnimComplete);
    }

    private void UpdateRoundCounter()
    {
        RoundCounter++;
    }
    
    public void OnRoundStart()
    {
        UpdateRoundCounter();
        CustomEventManager.Instance.Invoke(RoundEvents.ROUND_START,RoundCounter);
    }
    
    private void OnRoundStartAnimComplete(params object[] args)
    {
        CustomEventManager.Instance.Invoke(RoundEvents.ROUND_START_COMPLETE);
    }
    
    public void OnRoundEnd()
    {
        CustomEventManager.Instance.Invoke(RoundEvents.ROUND_END);
        CustomEventManager.Instance.Invoke(RoundEvents.ROUND_END_COMPLETE);
    }
}
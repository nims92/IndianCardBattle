public class TurnCostManager
{
    private readonly bool shouldFireUIUpdateEvents;
    public int CurrentCost { get; private set; }
    
    public TurnCostManager(bool shouldFireUIUpdateEvents)
    {
        this.shouldFireUIUpdateEvents = shouldFireUIUpdateEvents;
        CustomEventManager.Instance.AddListener(RoundEvents.ROUND_START,SetCost);
    }

    public void UpdateTurnCost(int costUpdateBy)
    {
        CurrentCost += costUpdateBy;
        
        if(shouldFireUIUpdateEvents)
            CustomEventManager.Instance.Invoke(UIEvents.UPDATE_TURN_COUNTER_UI,CurrentCost);
    }
    
    private void SetCost(params object [] args)
    {
        CurrentCost = (int)args[0];
        
        if(shouldFireUIUpdateEvents)
            CustomEventManager.Instance.Invoke(UIEvents.UPDATE_TURN_COUNTER_UI,CurrentCost);
    }
    
}

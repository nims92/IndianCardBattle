public class TurnCostManager
{
    private int currentCost;
    private bool shouldFireUIUpdateEvents;
    
    public TurnCostManager(bool shouldFireUIUpdateEvents)
    {
        this.shouldFireUIUpdateEvents = shouldFireUIUpdateEvents;
        CustomEventManager.Instance.AddListener(TurnEvents.UPDATE_TURN_COST,SetCost);
    }

    public int CurrentCost
    {
        get => currentCost;
        set => currentCost = value;
    }

    public void SetCost(params object [] args)
    {
        CurrentCost = (int)args[0];
        
        if(shouldFireUIUpdateEvents)
            CustomEventManager.Instance.Invoke(UIEvents.UPDATE_TURN_COUNTER_UI,CurrentCost);
    }
    
    public void UpdateTurnCost(int costUpdateBy)
    {
        CurrentCost += costUpdateBy;
        
        if(shouldFireUIUpdateEvents)
            CustomEventManager.Instance.Invoke(UIEvents.UPDATE_TURN_COUNTER_UI,CurrentCost);
    }
    
}

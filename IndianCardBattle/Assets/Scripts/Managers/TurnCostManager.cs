public class TurnCostManager
{
    private int costIncrement;
    
    public int CurrentCost { get; private set; }

    public TurnCostManager(int costIncrement)
    {
        this.costIncrement = costIncrement;
    }

    //TODO: attach with event
    public void OnTurnUpdated()
    {
        CurrentCost += costIncrement;
    }
}

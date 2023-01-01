public interface ILocation
{
    public ILocationScoreManager LocationScoreManager { get; set; }
    public ILocationViewManager LocationViewManager { get; set; }
    public ILocationCardPlacementManager LocationCardPlacementManager { get; set; }
    
    public void InitLocation(TurnManager turnManager,LocationID locationID,int turnUnlockNumber,int numberOfPlayers);
}



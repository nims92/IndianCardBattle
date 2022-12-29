public interface ILocation
{
    public ILocationScoreManager LocationScoreManager { get; set; }
    public ILocationViewManager LocationViewManager { get; set; }
    public ILocationCardPlacementManager LocationCardPlacementManager { get; set; }
    
    public void InitLocation(int turnUnlockNumber,int numberOfPlayers);
}



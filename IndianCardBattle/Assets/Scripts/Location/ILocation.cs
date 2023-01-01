public interface ILocation
{
    public ILocationScoreManager LocationScoreManager { get; set; }
    public ILocationViewManager LocationViewManager { get; set; }
    public ILocationCardPlacementManager LocationCardPlacementManager { get; set; }
    
    public void InitLocation(LocationID locationID,int turnUnlockNumber,int numberOfPlayers);
    void AddCardToLocation(int playerIndex, ICard card);
}



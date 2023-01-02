public interface ILocation
{
    public LocationID LocationID { get; set; }
    public ILocationScoreManager LocationScoreManager { get; set; }
    public ILocationViewManager LocationViewManager { get; set; }
    public ILocationCardPlacementManager LocationCardPlacementManager { get; set; }
    
    public void InitLocation(LocationID locationID,int turnUnlockNumber,int numberOfPlayers);
    void AddCardToLocation(int playerIndex, ICard card);

    void RemoveCardFromLocation(int playerIndex, ICard card);

    bool IsLocationFullForPlayer(int playerIndex);
}



public interface ILocationCardPlacementManager
{
    public void AddCardToLocation(int playerIndex,ICard cardToAdd);
    public void RemoveCardFromLocation(int playerIndex,ICard careToRemove);
}
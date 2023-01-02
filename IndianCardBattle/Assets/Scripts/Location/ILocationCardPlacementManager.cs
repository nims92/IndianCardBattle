public interface ILocationCardPlacementManager
{
    void Init();
    public void AddCardToLocation(int playerIndex,ICard cardToAdd);
    public void RemoveCardFromLocation(int playerIndex,ICard careToRemove);

    void LockCardsAtAllPlacement();
    bool IsCardPlacementAreaFullForPlayer(int playerIndex);
}
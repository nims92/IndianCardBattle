public interface ICardHandManager
{
    public bool CanAddCard { get; }
    void AddCardToHand(ICard cardToAdd);
    void RemoveCardFromHand(ICard cardToRemove);
    
    //TODO remove this cod
    ICard GetFirstCard();
}
using System;

public interface ICardHandManager
{
    public bool CanAddCard { get; }
    void AddCardToHand(ICard cardToAdd, Action callback);
    void RemoveCardFromHand(ICard cardToRemove);
    void UpdateCardsInHandActiveState(int cost);
    ICard GetRandomPlaybleCardFromHand();
}
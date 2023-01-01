using System;

public interface ICardHandManager
{
    public bool CanAddCard { get; }
    void AddCardToHand(ICard cardToAdd, Action callback);
    void RemoveCardFromHand(ICard cardToRemove);
    
    //TODO remove this 
    ICard GetRandomCardFromHand();
}
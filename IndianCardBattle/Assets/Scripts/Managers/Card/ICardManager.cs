using System;

public interface ICardManager
{
    void DrawNextCard(int cost, Action callback);
    void AddCardToHand(ICard card, Action callback);
    void RemoveCardFromHand(ICard card);
    ICard GetRandomPlayableCardFromHand();
    void UpdateCardsInHandActiveState(int currentCost);
}
using UnityEngine;

public interface ICardDeckManager
{
    void AddCardToDeck(Card card);
    void RemoveCardFromDeck(Card cardID);
    ICard DrawCardFromDeck(int energyCost);
}
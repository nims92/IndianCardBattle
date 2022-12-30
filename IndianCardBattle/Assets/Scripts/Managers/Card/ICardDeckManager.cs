using UnityEngine;

public interface ICardDeckManager
{
    void AddCardToDeck(Card card);
    void RemoveCardFromDeck(Card cardID);
    Card DrawCardFromDeck(int energyCost);
}
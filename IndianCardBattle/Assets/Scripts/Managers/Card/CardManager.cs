using System;
using UnityEngine;

public class CardManager
{
    private ICardDeckManager cardDeckManager;
    private ICardHandManager cardHandManager;

    public CardManager(IObjectSpawner objectSpawner,
        Deck deck,Transform deckTransform, Transform handTransform, int maxCardInHand)
    {
        cardDeckManager = new CardDeckManager(objectSpawner,deck,deckTransform);
        cardHandManager = new CardInHandManager(handTransform,maxCardInHand);
    }


    public void DrawNextCard(int cost, Action callback)
    {
        if (cardHandManager.CanAddCard)
        {
            Card card = cardDeckManager.DrawCardFromDeck(cost);
            cardHandManager.AddCardToHand(card, callback);
        }
        else
        {
            //TODO: implement logic to reset hand
        }
    }

    public void RemoveCardFromHand(ICard card)
    {
        cardHandManager.RemoveCardFromHand(card);
    }

    public ICard GetRandomCardFromHand()
    {
        return cardHandManager.GetRandomCardFromHand();
    }

    public void UpdateCardActiveState(int currentCost)
    {
        cardHandManager.UpdateCardsInHandActiveState(currentCost);
    }
}

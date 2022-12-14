using System;
using System.Collections;
using UnityEngine;

public class CardManager : ICardManager
{
    private readonly ICardDeckManager cardDeckManager;
    private readonly ICardHandManager cardHandManager;

    public CardManager(IObjectSpawner objectSpawner,
        Deck deck,Transform deckTransform, Transform handTransform, int maxCardInHand)
    {
        cardDeckManager = new CardDeckManager(objectSpawner,deck,deckTransform);
        cardHandManager = new CardInHandManager(handTransform,maxCardInHand);
    }

    public void DrawNextCard(int cost,Action callback,bool isForStartingDeck)
    {
        if (cardHandManager.CanAddCard)
        {
            var card = cardDeckManager.DrawCardFromDeck(cost,isForStartingDeck);
            AddCardToHand(card, callback);
        }
        else
        {
            callback?.Invoke();
        }
    }
    
    public void AddCardToHand(ICard card,Action callback )
    {
        cardHandManager.AddCardToHand(card,callback);
    }

    public void RemoveCardFromHand(ICard card)
    {
        cardHandManager.RemoveCardFromHand(card);
    }

    public ICard GetRandomPlayableCardFromHand()
    {
        return cardHandManager.GetRandomPlaybleCardFromHand();
    }

    public void UpdateCardsInHandActiveState(int currentCost)
    {
        cardHandManager.UpdateCardsInHandActiveState(currentCost);
    }
}

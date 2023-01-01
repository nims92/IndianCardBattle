using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Random = UnityEngine.Random;

public class CardManager
{
    private ICardDeckManager cardDeckManager;
    private ICardHandManager cardHandManager;
    private LocationManager locationManager;
    
    public LocationManager LocationManager
    {
        get => locationManager;
        set => locationManager = value;
    }
    
    public CardManager(IObjectSpawner objectSpawner,
        Player player,
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
}

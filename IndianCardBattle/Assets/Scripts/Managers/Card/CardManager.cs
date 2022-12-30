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
    
    public CardManager(IObjectSpawner objectSpawner,
        Deck deck,Transform deckTransform, Transform handTransform, int maxCardInHand)
    {
        cardDeckManager = new CardDeckManager(objectSpawner,deck,deckTransform);
        cardHandManager = new CardInHandManager(handTransform,maxCardInHand);
    }
    
    public void DrawNextCard()
    {
        if (cardHandManager.CanAddCard)
        {
            int cost = Random.Range(1, 6);
            Card card = cardDeckManager.DrawCardFromDeck(cost);
            cardHandManager.AddCardToHand(card);
        }
        else
        {
            //TODO: implement logic to reset hand
        }
    }

    /*void TestCardDrawLogic()
    {
        int turnCount = GameData.Instance.GameConfiguration.numberOfTurns;
        for (int i = 0; i < turnCount; i++)
        {
            Card card = cardDeckManager.DrawCardFromDeck(i + 1);
            Debug.Log($"Cost: {i+1},Drawn Card: {card} " +
                      $"with enery {GameData.Instance.GetCardStatsByID(card.CardID).energyCost}"); ;
        }
    }*/
    
    //TODO remove this code
    public ICard GetFirstCard()
    {
        return cardHandManager.GetFirstCard();
    }
}

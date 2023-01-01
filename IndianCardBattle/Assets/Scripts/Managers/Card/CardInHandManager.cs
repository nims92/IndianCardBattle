using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class CardInHandManager : ICardHandManager
{
    private List<ICard> cardsInHand;
    private Transform selfTransform;
    private int CurrentCardCount => cardsInHand.Count;
    private CardHorizontalLayoutHandler horizontalLayoutHandler;
    private int MaxCardCountInHand { get; set; }
    
    public bool CanAddCard => cardsInHand.Count < MaxCardCountInHand;

    public CardInHandManager(Transform transform, int maxCardCountInHand)
    {
        selfTransform = transform;
        MaxCardCountInHand = maxCardCountInHand;
        cardsInHand = new List<ICard>();
        horizontalLayoutHandler = new CardHorizontalLayoutHandler(selfTransform,16f,-30f);
    }
    
    public void AddCardToHand(ICard cardToAdd, Action callback)
    {
        cardToAdd.CardMovementManager.ChangeParent(selfTransform);
        Vector3 targetPos = horizontalLayoutHandler.GetCardPositionForIndex(cardsInHand.Count);
        cardToAdd.CardMovementManager.MoveToLocalPosition(targetPos, callback);
        cardToAdd.CardStateManager.SetCardState(CardState.Hand);
        cardsInHand.Add(cardToAdd);
    }

    public void RemoveCardFromHand(ICard cardToRemove)
    {
        cardsInHand.Remove(cardToRemove);
    }

    public ICard GetRandomCardFromHand()
    {
        return cardsInHand[0];
    }

    public void UpdateCardsInHandActiveState(int currentCost)
    {
        foreach (var card in cardsInHand)
        {
            if (card.CardStatsManager.GetCardCost()<= currentCost)
                card.CardViewManager.SetCardActive(true);
            else
            {
                card.CardViewManager.SetCardActive(false);
            }
        }
    }
}
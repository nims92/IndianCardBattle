using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

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
        //horizontalLayoutHandler = new CardHorizontalLayoutHandler(selfTransform,16f,-30f);
        horizontalLayoutHandler = new CardHorizontalLayoutHandler(selfTransform,16f,0f);
    }
    
    public void AddCardToHand(ICard cardToAdd, Action callback)
    {
        cardToAdd.CardMovementManager.ChangeParent(selfTransform);
        Vector3 targetPos = horizontalLayoutHandler.GetCardPositionForIndex(cardsInHand.Count);
        cardToAdd.CardMovementManager.MoveToLocalPosition(targetPos,GameData.Instance.AnimationData.cardNormalMovementTime, callback);
        cardToAdd.CardMovementManager.ChangeScaleTo(GameData.Instance.GameplayData.GetCardScaleAtHand(),GameData.Instance.AnimationData.cardScaleAnimationTime);
        cardToAdd.OnCardPutInHand();
        cardsInHand.Add(cardToAdd);
        horizontalLayoutHandler.UpdateLayout();
    }

    public void RemoveCardFromHand(ICard cardToRemove)
    {
        cardsInHand.Remove(cardToRemove);
        UpdateCardsPositionInHand();
        horizontalLayoutHandler.UpdateLayout();
    }

    public ICard GetRandomPlaybleCardFromHand()
    {
        List<ICard> playableCards = cardsInHand.FindAll(card => card.IsCardActive());

        if (playableCards.Count == 0)
        {
            return null;
        }
        else
        {
            return playableCards[Random.Range(0, playableCards.Count())];
        }
    }

    public void UpdateCardsInHandActiveState(int currentCost)
    {
        foreach (var card in cardsInHand)
        {
            if (card.CardStatsManager.GetCardCost()<= currentCost)
                card.SetCardActive(true);
            else
            {
                card.SetCardActive(false);
            }
        }
    }

    #region Private Methods
    private void UpdateCardsPositionInHand()
    {
        Vector3 targetPos;
        for (int i = 0; i < cardsInHand.Count; i++)
        {
            targetPos = horizontalLayoutHandler.GetCardPositionForIndex(i);
            cardsInHand[i].CardMovementManager.SnapToLocalPosition(targetPos,GameData.Instance.AnimationData.cardSnapMovementTime);
        }
    }
    #endregion
    
}
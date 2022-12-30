using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class CardInHandManager : ICardHandManager
{
    private List<Card> cardsInHand;
    private Transform selfTransform;

    public CardInHandManager(Transform transform)
    {
        selfTransform = transform;
        cardsInHand = new List<Card>();
    }

    public void AddCardToHand(ICard cardToAdd)
    {
        //TODO: implementation pending
    }

    public void RemoveCardFromHand(ICard cardToRemove)
    {
        //TODO: implementation pending
    }
}
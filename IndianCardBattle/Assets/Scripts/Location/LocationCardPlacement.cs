using System.Collections.Generic;
using UnityEngine;

public class LocationCardPlacement :MonoBehaviour, ILocationCardPlacement
{
    private List<Vector3> placements;
    private List<ICard> currentCards;
    private Transform selfTransform;
    
    public void Init(List<Vector3> placementPositions)
    {
        placements = placementPositions;
        currentCards = new List<ICard>();
        selfTransform = transform;
    }

    public bool IsPlacementAreaFull()
    {
        return placements.Count == currentCards.Count;
    }

    public Vector3 GetNextEmptyPosition()
    {
        if (IsPlacementAreaFull())
            return Vector3.zero;

        return placements[currentCards.Count];
    }

    public void AddCard(ICard card)
    {
        if (IsPlacementAreaFull())
            return;
        
        card.CardMovementManager.ChangeParent(selfTransform);
        card.CardMovementManager.MoveToLocalPosition(GetNextEmptyPosition(),GameData.Instance.AnimationData.cardNormalMovementTime);
        card.CardMovementManager.ChangeScaleTo(GameData.Instance.GameplayData.GetCardScaleAtLocation(),GameData.Instance.AnimationData.cardScaleAnimationTime);
        card.OnCardPlacedAtLocation();
        currentCards.Add(card);
    }
    public void RemoveCard(ICard card)
    {
        currentCards.Remove(card);
    }
    
    public void LockAllPlacedCards()
    {
        foreach (var card in currentCards)
        {
            card.SetCardLockedAtLocation();
        }
    }
}
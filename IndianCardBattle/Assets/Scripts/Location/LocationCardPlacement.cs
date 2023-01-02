using System.Collections.Generic;
using UnityEngine;

public class LocationCardPlacement :MonoBehaviour, ILocationCardPlacement
{
    private List<Vector3> placements;
    private List<ICard> currentCards;
    
    public void Init(List<Vector3> placementPositions)
    {
        placements = placementPositions;
        currentCards = new List<ICard>();
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
        
        card.CardMovementManager.ChangeParent(transform);
        card.CardMovementManager.MoveToLocalPosition(GetNextEmptyPosition(),null);
        card.CardMovementManager.ChangeScaleTo(GameData.Instance.GameplayData.GetCardScaleAtLocation());
        //card.CardStateManager.SetCardState(CardState.Location);
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
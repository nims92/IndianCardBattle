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
        card.CardMovementManager.MoveToLocalPosition(GetNextEmptyPosition());
        card.CardMovementManager.ChangeScaleTo(GameData.Instance.GetCardScaleAtLocation());
        card.CardStateManager.SetCardState(CardState.Location);
        currentCards.Add(card);
    }

    public void RemoveCard(ICard card)
    {
        //TODO: add logic for unparenting 
        currentCards.Remove(card);
    }
}
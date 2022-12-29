using System.Collections.Generic;
using UnityEngine;

public class LocationCardPlacement :MonoBehaviour, ILocationCardPlacement
{
    private List<Vector3> placements;
    private List<ICard> currentCards;
    
    public void Init(List<Vector3> placementPositions)
    {
        placements = placementPositions;
    }

    public bool IsPlacementAreaFull()
    {
        return placements.Count == currentCards.Count;
    }

    public Vector3 GetNextEmptyPosition()
    {
        if (IsPlacementAreaFull())
            return Vector3.zero;

        return placements[currentCards.Count - 1];
    }

    public void AddCard(ICard card)
    {
        if (IsPlacementAreaFull())
            return;

        //TODO: add logic for placement

        currentCards.Add(card);
    }

    public void RemoveCard(ICard card)
    {
        //TODO: add logic for unparenting 
        currentCards.Remove(card);
    }
}
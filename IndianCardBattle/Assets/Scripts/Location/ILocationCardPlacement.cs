using System.Collections.Generic;
using UnityEngine;

public interface ILocationCardPlacement
{
    void Init(List<Vector3> placementPositions);
    bool IsPlacementAreaFull();
    Vector3 GetNextEmptyPosition();
    void AddCard(ICard card);
    void RemoveCard(ICard card);

    void LockAllPlacedCards();

}
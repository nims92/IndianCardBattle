using System.Collections.Generic;using UnityEngine;

public class LocationCardPlacementManager :MonoBehaviour, ILocationCardPlacementManager
{
    [SerializeField] private List<LocationCardPlacement> cardPlacements;

    public void AddCardToLocation(int playerIndex, ICard cardToAdd)
    {
        if(IsValidPlayerIndex(playerIndex))
            cardPlacements[playerIndex].AddCard(cardToAdd);
    }

    public void RemoveCardFromLocation(int playerIndex, ICard careToRemove)
    {
        if(IsValidPlayerIndex(playerIndex))
            cardPlacements[playerIndex].RemoveCard(careToRemove);
    }

    private bool IsValidPlayerIndex(int playerIndex)
    {
        if (playerIndex >= cardPlacements.Count)
            return false;

        return true;
    }
}
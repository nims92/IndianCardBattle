using System.Collections.Generic;
using UnityEngine;

public class Island : MonoBehaviour
{
    private ScoreManager scoreManager;
    private int turnUnlockNumber;
    private List<Card> cardsInIsland;
    private bool isUnlocked;

    public bool IsUnlocked { get => isUnlocked; set => isUnlocked = value; }

    public void InitIsland(int turnUnlockNumber)
    {
        this.turnUnlockNumber = turnUnlockNumber;
        //TODO: init score manager
    }

    public void OnTurnUpdate(int turnNumber)
    {
        //TODO: turn updated
        if (turnNumber == turnUnlockNumber)
            OnIslandUnlocked();
    }

    public void OnIslandUnlocked()
    {

    }

    public void AddCardToIsland(Card cardToAdd)
    {
        cardsInIsland.Add(cardToAdd);
    }

    public void RemoveToIsland(Card careToRemove)
    {
        cardsInIsland.Remove(careToRemove);
    }
}

using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Deck", menuName = "Scriptable Objects/Create Deck", order = 1)]
public class Deck : ScriptableObject
{
    [SerializeField] private List<CardID> cardsInDeck;

    public List<CardID> CardsInDeck
    {
        get => cardsInDeck;
    }
}
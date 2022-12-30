using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class CardManager : MonoBehaviour
{
    [SerializeField] private Transform deckTransform;
    [SerializeField] private Transform handTransform;

    private ICardDeckManager cardDeckManager;
    private ICardHandManager cardHandManager;

    [Header("TO BE Removed")] 
    [SerializeField] private Deck deck;


    private void Start()
    {
        Init();
        TestCardDrawLogic();
    }

    public void Init()
    {
        cardDeckManager = new CardDeckManager(deck);
        cardHandManager = new CardInHandManager(handTransform);
    }

    
    void TestCardDrawLogic()
    {
        int turnCount = GameData.Instance.GameConfiguration.numberOfTurns;
        for (int i = 0; i < turnCount; i++)
        {
            CardID card = cardDeckManager.DrawCardFromDeck(i + 1);
            Debug.Log($"Cost: {i+1},Drawn Card: {card} " +
                      $"with enery {GameData.Instance.GetCardStatsByID(card).energyCost}"); ;
        }
    }
    
}

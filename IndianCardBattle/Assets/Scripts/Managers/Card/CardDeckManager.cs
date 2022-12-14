using System.Collections.Generic;
using UnityEngine;

public class CardDeckManager : ICardDeckManager
{
    private List<Card> cardsInDeck;
    private Transform parentTransform;
    private IObjectSpawner objectSpawner;
    
    public CardDeckManager(IObjectSpawner objectSpawner,Deck deck, Transform transform)
    {
        this.objectSpawner = objectSpawner;
        cardsInDeck = new List<Card>();
        parentTransform = transform;
        
        foreach (var cardID in deck.CardsInDeck)
        {
            var card = SpawnCard(cardID);
            card.InitCard(cardID);
            AddCardToDeck(card);
        }
    }
    
    public void AddCardToDeck(Card card)
    {
        card.CardMovementManager.ChangeParent(parentTransform);
        card.CardMovementManager.MoveToPosition(parentTransform.position,GameData.Instance.AnimationData.cardNormalMovementTime);
        cardsInDeck.Add(card);
    }

    public void RemoveCardFromDeck(Card card)
    {
        cardsInDeck.Remove(card);
    }

    public ICard DrawCardFromDeck(int energyCost, bool isForStartingDeck = false)
    {
        var selectedCardID = SelectCardFromDeck(energyCost, isForStartingDeck);
        var card = cardsInDeck.Find(c => c.CardID == selectedCardID);
        RemoveCardFromDeck(card);
        return card;
    }

    #region Private methods
    private CardID SelectCardFromDeck(int energyCost, bool isForStartingDeck = false)
    {
        List<CardID> returnList = new List<CardID>();

        if (!isForStartingDeck)
        {
            returnList.AddRange(GameData.Instance.CardDatabase.GetCardIDWithGivenCost(cardsInDeck,energyCost-1));
            returnList.AddRange(GameData.Instance.CardDatabase.GetCardIDWithGivenCost(cardsInDeck,energyCost));
            returnList.AddRange(GameData.Instance.CardDatabase.GetCardIDWithGivenCost(cardsInDeck,energyCost+1));
        }
        
        int randomCardIndex;
        
        //Due to some reason, return list is still empty
        //In that case, select any random card
        if (returnList.Count == 0)
        {
            randomCardIndex = Random.Range(0, cardsInDeck.Count);
            return cardsInDeck[randomCardIndex].CardID;
        }
        
        randomCardIndex = Random.Range(0, returnList.Count);
        return returnList[randomCardIndex];
    }
    
    private Card SpawnCard(CardID cardID)
    {
        return objectSpawner.SpawnObjectOfType(GameData.Instance.CardDatabase.GetCardPrefabByID(cardID),
            parentTransform.position,
            Quaternion.identity,
            parentTransform);
    }
    
    #endregion
}

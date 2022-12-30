using System.Collections.Generic;
using UnityEngine;

public class CardDeckManager : ICardDeckManager
{
    private List<CardID> cardsInDeck;
    
    public CardDeckManager(Deck deck)
    {
        cardsInDeck = new List<CardID>(deck.CardsInDeck);
    }

    public void RemoveCardFromDeck(CardID cardID)
    {
        cardsInDeck.Remove(cardID);
    }

    public CardID DrawCardFromDeck(int energyCost)
    {
        //TODO: get a card using design logic
        var selectedCardID = SelectCardFromDeck(energyCost);
        
        RemoveCardFromDeck(selectedCardID);

        return selectedCardID;
    }

    private CardID SelectCardFromDeck(int energyCost)
    {
        List<CardID> returnList = new List<CardID>();

        returnList.AddRange(GameData.Instance.GetCardIDWithGivenCost(energyCost-1));
        returnList.AddRange(GameData.Instance.GetCardIDWithGivenCost(energyCost));
        returnList.AddRange(GameData.Instance.GetCardIDWithGivenCost(energyCost+1));
        
        int randomCardIndex = Random.Range(0, returnList.Count);
        return returnList[randomCardIndex];
    }
    
    
}

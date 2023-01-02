using UnityEngine;
using System.Collections.Generic;
using System.Linq;

[CreateAssetMenu(fileName = "CardDatabase", menuName = "Scriptable Objects/Card Database", order = 1)]
public class CardDatabase : ScriptableObject
{
    public List<CardDataEntry> cardList;
    
    public CardStats GetCardStatsByID(CardID cardID)
    {
        CardStats cardStats = cardList.Find(card => card.cardID == cardID).cardStats;
        return new CardStats(cardStats.energyCost, cardStats.power);
    }

    public List<CardID> GetCardIDWithGivenCost(List<Card> cardList,int eneryCost)
    {
        return cardList
            .FindAll(card => card.CardStatsManager.GetCardCost() == eneryCost)
            .Select(card => card.CardID)
            .ToList();
    }

    public string GetCardNameByID(CardID cardID)
    {
        return cardList.Find(card => card.cardID == cardID).name;
    }

    public Card GetCardPrefabByID(CardID cardID)
    {
        return cardList.Find(card => card.cardID == cardID).cardPrefab;
    }
}
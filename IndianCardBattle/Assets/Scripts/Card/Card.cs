using UnityEngine;
public enum CardState
{
    Deck = 0,
    Hand = 1,
    Location = 2,
    LockedAtLocation = 3
}
public class Card : MonoBehaviour, ICard
{
    public CardID CardID { get; set; }
    public ICardStateManager cardStateManager;
    public ICardStatsManager cardStatsManager;
    public ICardViewManager cardViewManager;
    
    public void InitCard(CardID cardID)
    {
        CardID = cardID;
        cardStateManager = new CardStateManager();
        cardStatsManager = new CardStatsManager(GameData.Instance.GetCardStatsByID(cardID));
        cardViewManager = GetComponentInChildren<CardViewManager>();
    }

    public void OnCardPlacedAtLocation()
    {
        cardStateManager.SetCardState(CardState.Location);
    }

    public void OnTurnUpdated()
    {
        if (cardStateManager.GetCardCurrentState() == CardState.Location)
        {
            cardStateManager.SetCardState(CardState.LockedAtLocation);
        }
    }

    public void OnCardPutInHand()
    {
        cardStateManager.SetCardState(CardState.Hand);
    }
    
    
    
}

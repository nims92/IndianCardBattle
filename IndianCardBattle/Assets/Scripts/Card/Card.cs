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
    private ICardStateManager cardStateManager;
    private ICardStatsManager cardStatsManager;
    private ICardViewManager cardViewManager;
    private ICardMovementManager cardMovementManager;
    private bool isCardActive = true;
    private Transform cardTransform;
    private ILocation currentLocation;
    
    public ICardStateManager CardStateManager
    {
        get => cardStateManager;
        set => cardStateManager = value;
    }

    public ICardStatsManager CardStatsManager
    {
        get => cardStatsManager;
        set => cardStatsManager = value;
    }

    public ICardViewManager CardViewManager
    {
        get => cardViewManager;
        set => cardViewManager = value;
    }

    public ICardMovementManager CardMovementManager
    {
        get => cardMovementManager;
        set => cardMovementManager = value;
    }
    
    public void InitCard(CardID cardID)
    {
        cardTransform = transform;
        CardID = cardID;
        cardStateManager = new CardStateManager();
        cardStatsManager = new CardStatsManager(GameData.Instance.CardDatabase.GetCardStatsByID(cardID));
        cardViewManager = GetComponentInChildren<CardViewManager>();
        cardViewManager.InitCardViewManager(GameData.Instance.CardDatabase.GetCardNameByID(cardID),cardStatsManager.GetCardCost(),cardStatsManager.GetCardPower());
        cardMovementManager = new CardMovementManager(cardTransform);
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

    public void SetCardVisible(bool value)
    {
        gameObject.SetActive(value);
    }

    public bool IsCardInteractable()
    {
        //Check card state
        if (CardStateManager.GetCardCurrentState() == CardState.Deck ||
            CardStateManager.GetCardCurrentState() == CardState.LockedAtLocation)
            return false;

        if (!IsCardActive())
            return false;

        return true;
    }

    public bool IsCardActive()
    {
        return isCardActive;
    }

    public void SetCardActive(bool value)
    {
        isCardActive = value;
        cardViewManager.SetCardActive(value);
    }

    public Transform GetCardTransform()
    {
        return cardTransform;
    }

    public ILocation GetCurrentLocation()
    {
        return currentLocation;
    }

    public void SetCurrentLocation(ILocation newLocation)
    {
        currentLocation = newLocation;
    }
}

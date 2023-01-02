using UnityEngine;

public interface ICard
{
    public ICardStateManager CardStateManager { get; set; }
    public ICardStatsManager CardStatsManager { get; set; }
    public ICardViewManager CardViewManager { get; set; }
    public ICardMovementManager CardMovementManager { get; set; }
    
    CardID CardID { get; set; }
    void InitCard(CardID cardID);
    void SetCardVisible(bool value);
    bool IsCardInteractable();
    bool IsCardActive();
    void SetCardActive(bool value);
    Transform GetCardTransform();

    ILocation GetCurrentLocation();

    void SetCurrentLocation(ILocation newLocation);
    void OnCardPlacedAtLocation();
    void OnCardPutInHand();
    void SetCardLockedAtLocation();
}

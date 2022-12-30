public interface ICard
{
    public ICardStateManager CardStateManager { get; set; }
    public ICardStatsManager CardStatsManager { get; set; }
    public ICardViewManager CardViewManager { get; set; }
    public ICardMovementManager CardMovementManager { get; set; }
    
    CardID CardID { get; set; }
    void InitCard(CardID cardID);
    void SetCardVisible(bool value);
}

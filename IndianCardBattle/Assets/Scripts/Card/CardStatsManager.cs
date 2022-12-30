public class CardStatsManager : ICardStatsManager
{
    private CardStats currentCardStats;

    public CardStatsManager(CardStats stats)
    {
        currentCardStats = stats;
    }
    
    public void SetCardStats(CardStats cardStats)
    {
        currentCardStats = cardStats;
    }

    public int GetCardPower()
    {
        return currentCardStats.power;
    }

    public int GetCardCost()
    {
        return currentCardStats.energyCost;
    }
}
public interface ICardViewManager
{
    void InitCardViewManager(string cardName, int cost, int power);
    void UpdateCardName(string name);
    void UpdateCardCost(int cost);
    void UpdateCardPower(int power);
}
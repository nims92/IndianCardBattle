public interface ICardDeckManager
{
    void RemoveCardFromDeck(CardID cardID);
    CardID DrawCardFromDeck(int energyCost);
}
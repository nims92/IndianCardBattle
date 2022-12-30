public class CardStateManager : ICardStateManager
{
    private CardState currentState;

    public CardStateManager()
    {
        currentState = CardState.Deck;
    }
    
    public CardState GetCardCurrentState()
    {
        return currentState;
    }

    public void SetCardState(CardState newState)
    {
        currentState = newState;
    }
}
public interface ICardStateManager
{
    CardState GetCardCurrentState();
    void SetCardState(CardState newState);
}
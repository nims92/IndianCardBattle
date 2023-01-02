public class AIPlayerInputManager : IPlayerInputManager
{
    private Player player;
    public bool Interactable { get; set; }

    public void SetupPlayerInput(Player player)
    {
        this.player = player;
    }

    public void OnPlayerTurnReceived()
    {
        
    }

    public void OnPlayerTurnEnded()
    {
        
    }
}
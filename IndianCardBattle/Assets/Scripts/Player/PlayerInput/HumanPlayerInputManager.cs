using UnityEngine;

public class HumanPlayerInputManager : MonoBehaviour, IPlayerInputManager
{
    private InteractionHandler interactionHandler;
    public bool Interactable { get; set; }

    public void SetupPlayerInput(Player player)
    {
        interactionHandler = InputOptionManager.Instance.EnableInputBasedOnSelectedInputType();
        interactionHandler.InitialSetup(player);
    }

    public void OnPlayerTurnReceived()
    {
        interactionHandler.InteractionEnabled = true;
    }

    public void OnPlayerTurnEnded()
    {
        interactionHandler.InteractionEnabled = false;
    }

    public MonoBehaviour GetMonoBehaviourContext()
    {
        return this;
    }
}
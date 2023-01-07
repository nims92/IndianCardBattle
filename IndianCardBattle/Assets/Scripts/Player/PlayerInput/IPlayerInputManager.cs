using UnityEngine;

public interface IPlayerInputManager
{
    bool Interactable { get; set; }
    void SetupPlayerInput(Player player);
    void OnPlayerTurnReceived();
    void OnPlayerTurnEnded();

    MonoBehaviour GetMonoBehaviourContext();
}
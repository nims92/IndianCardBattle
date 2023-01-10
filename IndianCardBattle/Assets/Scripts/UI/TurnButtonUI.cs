using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TurnButtonUI : MonoBehaviour
{
    [SerializeField] private Button turnButton;
    [SerializeField] private TextMeshProUGUI turnButtonText;
    [SerializeField] private TurnTimerUI turnTimerUI;

    public void OnPlayerTurnReceived()
    {
        turnButton.interactable = true;
        turnButtonText.text = Constants.PLAYER_TURN_BUTTON_TEXT;
        turnTimerUI.StartTimer(GameData.Instance.GameConfiguration.turnTime,OnEndTurnButtonPressed);
    }

    public void OnOpponentTurnReceived()
    {
        turnButton.interactable = false;
        turnButtonText.text = Constants.OPPONENT_TURN_BUTTON_TEXT;
        turnTimerUI.ResetTimer();
    }

    public void OnEndTurnButtonPressed()
    {
        turnTimerUI.ResetTimer();
        CustomEventManager.Instance.Invoke(UIEvents.END_TURN_BUTTON_PRESSED);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InGameScreenManager : UIBase
{
    [Header("Scene Reference")]
    [SerializeField] private PlayerProfileView selfPlayerProfileView;
    [SerializeField] private PlayerProfileView opponentPlayerProfileView;
    [SerializeField] private TextMeshProUGUI costCounterText;
    [SerializeField] private TurnButtonUI turnButtonUI;
    #region Monobehaviour callbacks

    private void OnEnable()
    {
        CustomEventManager.Instance.AddListener(UIEvents.PLAYER_PROFILE_INITIALIZED,OnSelfPlayerProfileUpdated);
        CustomEventManager.Instance.AddListener(UIEvents.OPPONENT_PROFILE_INITIALIZED,OnOpponentPlayerProfileUpdated);
        CustomEventManager.Instance.AddListener(UIEvents.UPDATE_TURN_COUNTER_UI,OnCostCounterUpdated);
        CustomEventManager.Instance.AddListener(TurnEvents.TURN_UPDATED,OnTurnUpdated);
    }

    private void OnDisable()
    {
        CustomEventManager.Instance.RemoveListener(UIEvents.PLAYER_PROFILE_INITIALIZED,OnSelfPlayerProfileUpdated);
        CustomEventManager.Instance.RemoveListener(UIEvents.OPPONENT_PROFILE_INITIALIZED,OnOpponentPlayerProfileUpdated);
        CustomEventManager.Instance.RemoveListener(UIEvents.UPDATE_TURN_COUNTER_UI,OnCostCounterUpdated);
        CustomEventManager.Instance.RemoveListener(TurnEvents.TURN_UPDATED,OnTurnUpdated);
    }

    #endregion

    private void OnSelfPlayerProfileUpdated(params object[] args)
    {
        selfPlayerProfileView.Init((string)args[0]);
    }

    private void OnOpponentPlayerProfileUpdated(params object[] args)
    {
        opponentPlayerProfileView.Init((string) args[0]);
    }

    private void OnCostCounterUpdated(params object [] args)
    {
        costCounterText.text = string.Empty + args[0];
    }

    private void OnTurnUpdated(params object [] args)
    {
        int currentTurnPlayerIndex = (int)args[0];

        if (currentTurnPlayerIndex == 0)
        {
            turnButtonUI.OnPlayerTurnReceived();
        }
        else
        {
            turnButtonUI.OnOpponentTurnReceived();
        }
    }

}

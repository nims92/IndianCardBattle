using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameScreenManager : UIBase
{
    [Header("Scene References")] 
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI youWonLocationCounterText;
    [SerializeField] private TextMeshProUGUI opponentWonLocationCounterText;

    private void OnEnable()
    {
        InitScreen();
    }

    private void InitScreen()
    {
        youWonLocationCounterText.text = $"You won {LocationManager.Instance.LocationsWonByPlayer} location";
        opponentWonLocationCounterText.text = $"Opponent won {LocationManager.Instance.LocationsWonByOpponent} location";

        if (LocationManager.Instance.LocationsWonByPlayer > LocationManager.Instance.LocationsWonByOpponent)
            title.text = "You Won!";
        else if (LocationManager.Instance.LocationsWonByPlayer < LocationManager.Instance.LocationsWonByOpponent)
            title.text = "You Lose!";
        else
        {
            title.text = "It's a tie!";
        }
    }

    public void OnGameRestartClicked()
    {
        CustomEventManager.Instance.ClearAllListenersForAllEvents();
        SceneManager.LoadScene(Constants.GAMEPLAY_SCREEN_SCENE_NAME);
    }
}

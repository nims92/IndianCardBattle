using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Managers")]
    [SerializeField] private GameAreaLocationProvider locationProvider;
    [SerializeField] private ObjectSpawner objectSpawner;
    [SerializeField] private PlayerManager playerManager;

    private TurnManager turnManager;

    private void Start()
    {
        playerManager.InitPlayers(objectSpawner,locationProvider);
        turnManager = new TurnManager(Constants.NUMBER_OF_PLAYERS,GameData.Instance.GameConfiguration.numberOfTurns);
        LocationManager.Instance.SetDependencies(objectSpawner,locationProvider.LocationParent);
        CustomEventManager.Instance.Invoke(GameFlowEvents.GAME_START_EVENT,turnManager.CurrentTurnPlayerIndex);
    }

    private void OnEnable()
    {
        CustomEventManager.Instance.AddListener(GameFlowEvents.GAME_END_EVENT,OnGameEnded);
    }

    private void OnDisable()
    {
        CustomEventManager.Instance.RemoveListener(GameFlowEvents.GAME_END_EVENT,OnGameEnded);
    }
    
    private void OnGameEnded(params object [] args)
    {
        LocationManager.Instance.CalculateDataForGameEndScreen();
        UISceneController.Instance.ShowUIScreen(ScreenManager.UIScreens.GameEndScreen);
    }
}

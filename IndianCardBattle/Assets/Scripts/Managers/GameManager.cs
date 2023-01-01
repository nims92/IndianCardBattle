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
    
    private LocationManager locationManager;
    private TurnManager turnManager;
    //private TurnCostManager turnCostManager;

    private void Start()
    {
        turnManager = new TurnManager(Constants.NUMBER_OF_PLAYERS,GameData.Instance.GameConfiguration.numberOfTurns);
        //turnCostManager = new TurnCostManager(GameData.Instance.GameConfiguration.energyCostIncrementWithEachTurn);
        locationManager = new LocationManager(turnManager,objectSpawner, locationProvider.LocationParent);
        playerManager.InitPlayers(objectSpawner,locationProvider);
        
        CustomEventManager.Instance.Invoke(GameFlowEvents.GAME_START_EVENT,turnManager.CurrentTurnPlayerIndex);
    }
    
    /*#region Testing
    private void TestCardDrawing()
    {
        cardManager.DrawNextCard();
    }

    private void TestCardToLocation()
    {
        MoveCardToLocation(locationManager.GetFirstLocation(),cardManager.GetFirstCard());
    }
    
    private void MoveCardToLocation(Location targetLocation, ICard card)
    {
        locationManager.AddCardToLocation(0,targetLocation,card);
    }

    #endregion*/
    
    
    
}

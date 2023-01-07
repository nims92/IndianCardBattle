using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Managers")]
    [SerializeField] private GameAreaLocationProvider locationProvider;
    [SerializeField] private ObjectSpawner objectSpawner;
    [SerializeField] private PlayerManager playerManager;

    private RoundManager roundManager;
    
    //Triggers
    private CustomTrigger roundStartComplete = new CustomTrigger();
    private CustomTrigger roundEndComplete = new CustomTrigger();
    private CustomTrigger currentTurnEnd = new CustomTrigger();
    
    private void Start()
    {
        playerManager.InitPlayers(objectSpawner,locationProvider);
        roundManager = new RoundManager(GameData.Instance.GameConfiguration.numberOfRounds);
        
        LocationManager.Instance.SetDependencies(objectSpawner,locationProvider.LocationParent);
        
        StartCoroutine(CoreGameLoop());
    }

    private void OnEnable()
    {
        //Events
        //Rounds
        CustomEventManager.Instance.AddListener(RoundEvents.ROUND_START_COMPLETE,OnRoundStartCompleteEventReceived);
        CustomEventManager.Instance.AddListener(RoundEvents.ROUND_END_COMPLETE,OnRoundEndCompleteEventReceived);
        CustomEventManager.Instance.AddListener(TurnEvents.CURRENT_TURN_ENDED,OnCurrentTurnEnd);
        CustomEventManager.Instance.AddListener(GameFlowEvents.GAME_END_EVENT,OnGameEnded);
    }

    private void OnDisable()
    {
        //Events
        //Rounds
        CustomEventManager.Instance.RemoveListener(RoundEvents.ROUND_START_COMPLETE,OnRoundStartCompleteEventReceived);
        CustomEventManager.Instance.RemoveListener(RoundEvents.ROUND_END_COMPLETE,OnRoundEndCompleteEventReceived);

        CustomEventManager.Instance.RemoveListener(TurnEvents.CURRENT_TURN_ENDED,OnCurrentTurnEnd);

        CustomEventManager.Instance.RemoveListener(GameFlowEvents.GAME_END_EVENT,OnGameEnded);
    }
    
    private void OnGameEnded(params object [] args)
    {
        LocationManager.Instance.CalculateDataForGameEndScreen();
        UISceneController.Instance.ShowUIScreen(ScreenManager.UIScreens.GameEndScreen);
    }

    private IEnumerator CoreGameLoop()
    {
        yield return new WaitForSeconds(1f);
        var numberOfRounds = GameData.Instance.GameConfiguration.numberOfRounds;
        
        for (var i = 0; i < numberOfRounds; i++)
        {
            roundManager.OnRoundStart();
            yield return new WaitForTrigger(roundStartComplete);

            for (var j = 0; j < Constants.NUMBER_OF_PLAYERS; j++)
            {
                playerManager.OnTurnUpdated(j);
                yield return new WaitForTrigger(currentTurnEnd);
                ResetTurnTriggers();
            }
            
            roundManager.OnRoundEnd();
            yield return new WaitForTrigger(roundEndComplete);
            ResetRoundTriggers();
            yield return new WaitForSeconds(1f);
        }
        
        LocationManager.Instance.CalculateDataForGameEndScreen();//TODO start animation
        yield return new WaitForSeconds(1f);
        UISceneController.Instance.ShowUIScreen(ScreenManager.UIScreens.GameEndScreen);
    }

    #region Event Callbacks
    
    //Rounds
    private void OnRoundStartCompleteEventReceived(params object [] args)
    {
        roundStartComplete.Set();
    }

    private void OnRoundEndCompleteEventReceived(params object[] args)
    {
        roundEndComplete.Set();
    }
    
    private void OnCurrentTurnEnd(params object[] args)
    {
        currentTurnEnd.Set();
    }
    
    #endregion

    private void ResetTurnTriggers()
    {
        currentTurnEnd.Reset();
    }

    private void ResetRoundTriggers()
    {
        roundStartComplete.Reset();
    }
}

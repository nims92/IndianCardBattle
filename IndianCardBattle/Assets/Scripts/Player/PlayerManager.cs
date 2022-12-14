using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private PlayerConfiguration selfPlayerConfiguration;
    [SerializeField] private PlayerConfiguration opponentPlayerConfiguration;

    private Player SelfPlayer { get; set; }
    private Player OpponentPlayer { get; set; }

    /*#region Monobehaviour
    private void OnEnable()
    {
        CustomEventManager.Instance.AddListener(GameFlowEvents.GAME_START_EVENT,OnTurnUpdated);
        //CustomEventManager.Instance.AddListener(TurnEvents.TURN_UPDATED,OnTurnUpdated);
    }
    private void OnDisable()
    {
        CustomEventManager.Instance.RemoveListener(GameFlowEvents.GAME_START_EVENT,OnTurnUpdated);
        //CustomEventManager.Instance.RemoveListener(TurnEvents.TURN_UPDATED,OnTurnUpdated);
    }
    #endregion*/

    public void InitPlayers(IObjectSpawner objectSpawner, GameAreaLocationProvider areaLocationProvider)
    {
        //Init self player
        SelfPlayer = new Player(selfPlayerConfiguration.name,
            0,
            selfPlayerConfiguration.playerInputType,
            GetComponentInChildren<HumanPlayerInputManager>(),
            objectSpawner,
            selfPlayerConfiguration.playerDeck,
            areaLocationProvider.PlayerCardDeckParent,
            areaLocationProvider.PlayerCardHandParent,
            GameData.Instance.GameConfiguration.maxCardInHand
            );
        
        CustomEventManager.Instance.Invoke(UIEvents.PLAYER_PROFILE_INITIALIZED,SelfPlayer.Profile.GetPlayerName());
        
        //Init opponent player
        OpponentPlayer = new Player(opponentPlayerConfiguration.name,
            1,
            opponentPlayerConfiguration.playerInputType,
            GetComponentInChildren<AIPlayerInputManager>(),
            objectSpawner,
            opponentPlayerConfiguration.playerDeck,
            areaLocationProvider.OpponentCardDeckParent,
            areaLocationProvider.OpponentCardHandParent,
            GameData.Instance.GameConfiguration.maxCardInHand
        );
        
        CustomEventManager.Instance.Invoke(UIEvents.OPPONENT_PROFILE_INITIALIZED,OpponentPlayer.Profile.GetPlayerName());
    }
    
    public void OnTurnUpdated(int currentPlayerTurnIndex)
    {
        CustomEventManager.Instance.Invoke(TurnEvents.TURN_UPDATED, currentPlayerTurnIndex);
        if (currentPlayerTurnIndex == 0)
        {
            SelfPlayer.OnPlayerTurnReceived();
        }
        else
        {
            OpponentPlayer.OnPlayerTurnReceived();
        }
    }

    public void PrewarmHand(int playerIndex)
    {
        if (playerIndex == 0)
        {
            SelfPlayer.PrewarmCardsInHand(GameData.Instance.GameConfiguration.numberOfCardsInStartingHand);
        }
        else
        {
            OpponentPlayer.PrewarmCardsInHand(GameData.Instance.GameConfiguration.numberOfCardsInStartingHand);
        }
    }
}
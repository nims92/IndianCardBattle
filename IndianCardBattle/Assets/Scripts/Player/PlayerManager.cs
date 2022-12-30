using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private PlayerConfiguration selfPlayerConfiguration;
    [SerializeField] private PlayerConfiguration opponentPlayerConfiguration;

    private Player selfPlayer;
    private Player opponentPlayer;

    public Player SelfPlayer
    {
        get => selfPlayer;
        set => selfPlayer = value;
    }
    public Player OpponentPlayer
    {
        get => opponentPlayer;
        set => opponentPlayer = value;
    }

    public void InitPlayers(IObjectSpawner objectSpawner,GameAreaLocationProvider areaLocationProvider)
    {
        //Init self player
        SelfPlayer = new Player(selfPlayerConfiguration.name,
            0,
            objectSpawner,
            selfPlayerConfiguration.playerDeck,
            areaLocationProvider.PlayerCardDeckParent,
            areaLocationProvider.PlayerCardHandParent,
            GameData.Instance.GameConfiguration.maxCardInHand
            );

        //Init opponent player
        OpponentPlayer = new Player(opponentPlayerConfiguration.name,
            1,
            objectSpawner,
            opponentPlayerConfiguration.playerDeck,
            areaLocationProvider.OpponentCardDeckParent,
            areaLocationProvider.OpponentCardHandParent,
            GameData.Instance.GameConfiguration.maxCardInHand
        );
    }
    
    
}
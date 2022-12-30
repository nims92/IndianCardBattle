using UnityEngine;

public class Player
{
    private PlayerProfile playerProfile;
    private CardManager playerCardManager;
    //TODO: think about input

    public Player(string playerName,int playerID,IObjectSpawner objectSpawner,
        Deck deck,Transform deckTransform, Transform handTransform, int maxCardInHand)
    {
        playerProfile = new PlayerProfile(playerName, playerID);
        playerCardManager = new CardManager(objectSpawner, deck, deckTransform, handTransform, maxCardInHand);
    }
}
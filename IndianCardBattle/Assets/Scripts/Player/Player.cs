using UnityEngine;

public class Player
{
    private PlayerInputType playerInputType;
    private PlayerProfile playerProfile;
    private CardManager playerCardManager;
    private TurnCostManager turnCostManager;
    private IPlayerInputManager playerInputManager;
    //TODO: think about input
    
    public PlayerProfile Profile => playerProfile;
    public CardManager PlayerCardManager => playerCardManager;

    public Player(string playerName,int playerID,PlayerInputType inputType,
        IObjectSpawner objectSpawner,
        Deck deck,Transform deckTransform,Transform handTransform, 
        int maxCardInHand)
    {
        playerProfile = new PlayerProfile(playerName, playerID);
        playerCardManager = new CardManager(objectSpawner,this, deck, deckTransform, handTransform, maxCardInHand);
        turnCostManager = new TurnCostManager();
    }

    public void OnPlayerTurnReceived()
    {
        playerCardManager.DrawNextCard(turnCostManager.CurrentCost,OnCardDrawnFromDeck);
    }

    public void OnPlayerTurnEnd()
    {
        //TODO add logic to disable system when turn ends
    }

    public void OnCardDrawnFromDeck()
    {
        Debug.LogError($"Card added to hand");
    }

    public void MoveCardFromHandToLocation(ICard card, ILocation destinationLocation)
    {
        
    }
    
    public void MoveCardToHandFromLocation(ICard card, ILocation currentLocation)
    {
        
    }
}
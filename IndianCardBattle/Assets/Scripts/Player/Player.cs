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
        turnCostManager = new TurnCostManager(inputType == PlayerInputType.Human);
    }

    public void OnPlayerTurnReceived()
    {
        playerCardManager.DrawNextCard(turnCostManager.CurrentCost,OnCardDrawnFromDeck);
    }

    public void OnPlayerTurnEnd()
    {
        //TODO add logic to disable system when turn ends
        /*
         * Disable input
         */
    }

    public void OnCardDrawnFromDeck()
    {
        //TODO : setup player for turn
        /*
         * Enable input
         */
        MoveCardFromHandToLocation(PlayerCardManager.GetRandomCardFromHand(),
            LocationManager.Instance.GetRandomLocation());
    }

    public void MoveCardFromHandToLocation(ICard card, ILocation destinationLocation)
    {
        destinationLocation.AddCardToLocation(Profile.GetPlayerID(),card);
        playerCardManager.RemoveCardFromHand(card);
    }
    
    public void MoveCardToHandFromLocation(ICard card, ILocation currentLocation)
    {
        
    }
}
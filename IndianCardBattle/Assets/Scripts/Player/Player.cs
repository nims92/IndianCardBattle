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
        IPlayerInputManager inputManager,
        IObjectSpawner objectSpawner,
        Deck deck,Transform deckTransform,Transform handTransform, 
        int maxCardInHand)
    {
        playerProfile = new PlayerProfile(playerName, playerID);
        playerCardManager = new CardManager(objectSpawner, deck, deckTransform, handTransform, maxCardInHand);
        turnCostManager = new TurnCostManager(inputType == PlayerInputType.Human);
        this.playerInputManager = inputManager;
        playerInputManager.SetupPlayerInput(this);
    }

    public void OnPlayerTurnReceived()
    {
        playerCardManager.DrawNextCard(turnCostManager.CurrentCost,OnCardDrawnFromDeck);
    }

    public void OnPlayerTurnEnd()
    {
        //Lock cards at location
        playerInputManager.OnPlayerTurnEnded();
    }

    public void OnCardDrawnFromDeck()
    {
        //TODO : setup player for turn
        /*
         * Enable input
         */
        UpdateCardInHandState();
        playerInputManager.OnPlayerTurnReceived();
        /*MoveCardFromHandToLocation(PlayerCardManager.GetRandomCardFromHand(),
            LocationManager.Instance.GetRandomLocation());*/
    }

    public void MoveCardFromHandToLocation(ICard card, ILocation destinationLocation)
    {
        destinationLocation.AddCardToLocation(Profile.GetPlayerID(),card);
        playerCardManager.RemoveCardFromHand(card);
        turnCostManager.UpdateTurnCost(-card.CardStatsManager.GetCardCost());
        UpdateCardInHandState();
    }
    
    public void MoveCardToHandFromLocation(ICard card, ILocation currentLocation)
    {
        currentLocation.RemoveCardFromLocation(Profile.GetPlayerID(),card);
        playerCardManager.AddCardToHand(card,null);
        turnCostManager.UpdateTurnCost(card.CardStatsManager.GetCardCost());
        UpdateCardInHandState();
    }

    public void MoveCardToHand(ICard card, Vector3 position)
    {
        card.CardMovementManager.SnapToPosition(position);
    }

    public void MoveCardToNewLocation(ICard card, ILocation oldLocation, ILocation newLocation)
    {
        oldLocation.RemoveCardFromLocation(Profile.GetPlayerID(),card);
        newLocation.AddCardToLocation(Profile.GetPlayerID(), card);
    }

    public void UpdateCardInHandState()
    {
        PlayerCardManager.UpdateCardActiveState(turnCostManager.CurrentCost);
    }
}
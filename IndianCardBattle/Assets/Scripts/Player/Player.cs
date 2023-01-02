using UnityEngine;

public class Player
{
    private readonly TurnCostManager turnCostManager;
    private readonly IPlayerInputManager playerInputManager;
    
    public PlayerProfile Profile { get; }
    public CardManager PlayerCardManager { get; }

    public Player(string playerName,int playerID,PlayerInputType inputType,
        IPlayerInputManager inputManager,
        IObjectSpawner objectSpawner,
        Deck deck,Transform deckTransform,Transform handTransform, 
        int maxCardInHand)
    {
        Profile = new PlayerProfile(playerName, playerID);
        PlayerCardManager = new CardManager(objectSpawner, deck, deckTransform, handTransform, maxCardInHand);
        turnCostManager = new TurnCostManager(inputType == PlayerInputType.Human);
        playerInputManager = inputManager;
        playerInputManager.SetupPlayerInput(this);
    }

    public void OnPlayerTurnReceived()
    {
        PlayerCardManager.DrawNextCard(turnCostManager.CurrentCost,OnCardDrawnFromDeck);
    }

    public void OnPlayerTurnEnd()
    {
        playerInputManager.OnPlayerTurnEnded();
    }

    public void MoveCardFromHandToLocation(ICard card, ILocation destinationLocation)
    {
        destinationLocation.AddCardToLocation(Profile.GetPlayerID(),card);
        PlayerCardManager.RemoveCardFromHand(card);
        turnCostManager.UpdateTurnCost(-card.CardStatsManager.GetCardCost());
        UpdateCardInHandState();
    }
    
    public void MoveCardToHandFromLocation(ICard card, ILocation currentLocation)
    {
        currentLocation.RemoveCardFromLocation(Profile.GetPlayerID(),card);
        PlayerCardManager.AddCardToHand(card,null);
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

    private void UpdateCardInHandState()
    {
        PlayerCardManager.UpdateCardActiveState(turnCostManager.CurrentCost);
    }
    
    private void OnCardDrawnFromDeck()
    {
        UpdateCardInHandState();
        playerInputManager.OnPlayerTurnReceived();
    }
}
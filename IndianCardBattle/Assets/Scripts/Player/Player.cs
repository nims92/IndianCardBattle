using System.Collections;
using System.Text;
using UnityEngine;

//TODO: derive from interface
public class Player
{
    private readonly TurnCostManager turnCostManager;
    private readonly IPlayerInputManager playerInputManager;
    
    //Triggers
    private CustomTrigger waitForCardAddedToHand = new CustomTrigger();
    private CustomTrigger waitForPlayerInputComplete = new CustomTrigger();
    
    
    private int numberOfCardsToBeDrawn = 0;
    private int numberOfCardsDrawn = 0;
    private bool isForStartingDeck = false;
    
    public PlayerProfile Profile { get; }
    public ICardManager PlayerCardManager { get; }

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

    private IEnumerator PlayerTurnLoop()
    {
        yield return new WaitForSeconds(1);

        for (int i = 0; i < numberOfCardsToBeDrawn; i++)
        {
            PlayerCardManager.DrawNextCard(turnCostManager.CurrentCost,OnCardDrawnFromDeck,isForStartingDeck);
            yield return new WaitForSeconds(0.25f);
        }
        
        yield return new WaitForTrigger(waitForCardAddedToHand);
        UpdateCardInHandState();
        
        yield return new WaitForSeconds(0.5f);
        playerInputManager.OnPlayerTurnReceived();
        
        yield return new WaitForTrigger(waitForPlayerInputComplete);
        OnPlayerTurnEnd();
    }

    private IEnumerator PrewarmHand()
    {
        yield return new WaitForSeconds(0.5f);
        
        for (int i = 0; i < numberOfCardsToBeDrawn; i++)
        {
            PlayerCardManager.DrawNextCard(turnCostManager.CurrentCost,OnCardDrawnFromDeck,true);
            yield return new WaitForSeconds(0.25f);
        }
    }

    public void PrewarmCardsInHand(int cardCount)
    {
        numberOfCardsToBeDrawn = cardCount;
        isForStartingDeck = false;
        numberOfCardsDrawn = 0;
        playerInputManager.GetMonoBehaviourContext().StartCoroutine(PrewarmHand());
    }

    public void OnPlayerTurnReceived()
    {
        CustomEventManager.Instance.AddListener(UIEvents.END_TURN_BUTTON_PRESSED,OnPlayerInputComplete);

        /*if (turnCostManager.CurrentCost == 1)
        {
            numberOfCardsToBeDrawn = GameData.Instance.GameConfiguration.numberOfCardsInStartingHand;
            isForStartingDeck = true;
            numberOfCardsDrawn = 0;
        }
        else
        {
            numberOfCardsToBeDrawn = 1;
            isForStartingDeck = false;
            numberOfCardsDrawn = 0;
        }*/
        
        numberOfCardsToBeDrawn = 1;
        isForStartingDeck = false;
        numberOfCardsDrawn = 0;
        playerInputManager.GetMonoBehaviourContext().StartCoroutine(PlayerTurnLoop());
    }

    public void OnPlayerTurnEnd()
    {
        CustomEventManager.Instance.RemoveListener(UIEvents.END_TURN_BUTTON_PRESSED,OnPlayerInputComplete);
        ResetTriggers();
        playerInputManager.OnPlayerTurnEnded();
        CustomEventManager.Instance.Invoke(TurnEvents.CURRENT_TURN_ENDED);
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
        card.CardMovementManager.SnapToPosition(position,GameData.Instance.AnimationData.cardSnapMovementTime);
    }

    public void MoveCardToNewLocation(ICard card, ILocation oldLocation, ILocation newLocation)
    {
        oldLocation.RemoveCardFromLocation(Profile.GetPlayerID(),card);
        newLocation.AddCardToLocation(Profile.GetPlayerID(), card);
    }

    private void UpdateCardInHandState()
    {
        PlayerCardManager.UpdateCardsInHandActiveState(turnCostManager.CurrentCost);
    }
    
    private void OnCardDrawnFromDeck()
    {
        numberOfCardsDrawn++;
        
        if(numberOfCardsDrawn == numberOfCardsToBeDrawn)
            waitForCardAddedToHand.Set();
    }

    private void OnPlayerInputComplete(params object[] args)
    {
        waitForPlayerInputComplete.Set();
    }

    private void ResetTriggers()
    {
        waitForCardAddedToHand.Reset();
    }
}
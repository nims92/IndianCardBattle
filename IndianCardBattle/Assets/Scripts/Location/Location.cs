using UnityEngine;

public class Location : MonoBehaviour, ILocation, IUnlockable
{
    private bool isUnlocked;
    private int turnUnlockNumber;
    
    public LocationID LocationID { get; set; }
    public ILocationScoreManager LocationScoreManager { get; set; }
    public ILocationViewManager LocationViewManager { get; set; }
    public ILocationCardPlacementManager LocationCardPlacementManager { get; set; }

    public void InitLocation(LocationID locationID,int turnUnlockNumber,int numberOfPlayers)
    {
        LocationID = locationID;
        this.turnUnlockNumber = turnUnlockNumber;
        
        //Score manager
        LocationScoreManager = new LocationScoreManager(numberOfPlayers);
        
        //View manager
        LocationViewManager = GetComponentInChildren<LocationViewManager>();
        LocationViewManager.InitView(LocationScoreManager.GetScoreForPlayer(0),
            LocationScoreManager.GetScoreForPlayer(1),
            "",
            GameData.Instance.LocationDatabase.GetLocationNameWithID(locationID));
        
        //Card placement manager
        LocationCardPlacementManager = GetComponent<LocationCardPlacementManager>();
        LocationCardPlacementManager.Init();
        
        //Event subscription
        CustomEventManager.Instance.AddListener(RoundEvents.ROUND_START,OnRoundStart);
        CustomEventManager.Instance.AddListener(RoundEvents.ROUND_END,OnRoundEnd);
        CustomEventManager.Instance.AddListener(TurnEvents.TURN_UPDATED,OnTurnUpdate);
        
    }

    public void OnRoundStart(params object[] args)
    {
        if (CheckIfLocationUnlocked((int)args[0]))
            OnIslandUnlocked();
    }
    
    public void OnRoundEnd(params object []args)
    {
        LocationViewManager.UpdateScore(true,LocationScoreManager.GetScoreForPlayer(0));
        LocationViewManager.UpdateScore(false,LocationScoreManager.GetScoreForPlayer(1));
        LocationViewManager.OnPlayerScoresUpdated(LocationScoreManager.GetScoreForPlayer(0),LocationScoreManager.GetScoreForPlayer(1));
    }

    public void OnTurnUpdate(params object[] args)
    {
        LocationCardPlacementManager.LockCardsAtAllPlacement();
    }
    
    public void AddCardToLocation(int playerIndex,ICard card)
    {
        LocationCardPlacementManager.AddCardToLocation(playerIndex,card);
        LocationScoreManager.AddScoreForPlayer(card.CardStatsManager.GetCardPower(),playerIndex);
        card.SetCurrentLocation(this);
    }

    public void RemoveCardFromLocation(int playerIndex, ICard card)
    {
        LocationCardPlacementManager.RemoveCardFromLocation(playerIndex,card);
        LocationScoreManager.DeductScoreForPlayer(card.CardStatsManager.GetCardPower(),playerIndex);
        card.SetCurrentLocation(null);
    }

    public bool IsLocationFullForPlayer(int playerIndex)
    {
        return LocationCardPlacementManager.IsCardPlacementAreaFullForPlayer(playerIndex);
    }
    
    
    #region IUnlockable implementation

    public bool IsUnlocked()
    {
        return isUnlocked;
    }

    public void SetUnlocked(bool value)
    {
        isUnlocked = value;
        LocationViewManager.OnLocationUnlocked();
    }

    #endregion

    #region Private methods
    private bool CheckIfLocationUnlocked(int turnNumber)
    {
        if (turnNumber == turnUnlockNumber)
            return true;
        return false;
    }

    private void OnIslandUnlocked()
    {
        SetUnlocked(true);
    }
    #endregion
}

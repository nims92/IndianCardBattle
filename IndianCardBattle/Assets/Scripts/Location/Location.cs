using UnityEngine;

public class Location : MonoBehaviour, ILocation, IUnlockable
{
    private bool isUnlocked;
    private int turnUnlockNumber;
    private LocationID locationID;
    public ILocationScoreManager LocationScoreManager { get; set; }
    public ILocationViewManager LocationViewManager { get; set; }
    public ILocationCardPlacementManager LocationCardPlacementManager { get; set; }

    public void InitLocation(LocationID locationID,int turnUnlockNumber,int numberOfPlayers)
    {
        this.locationID = locationID;
        this.turnUnlockNumber = turnUnlockNumber;
        
        //Score manager
        LocationScoreManager = new LocationScoreManager(numberOfPlayers);
        
        //View manager
        LocationViewManager = GetComponentInChildren<LocationViewManager>();
        LocationViewManager.InitView(LocationScoreManager.GetScoreForPlayer(0),
            LocationScoreManager.GetScoreForPlayer(1),
            "",
            GameData.Instance.GetLocationNameWithID(locationID));
        
        //Card placement manager
        LocationCardPlacementManager = GetComponent<LocationCardPlacementManager>();
        LocationCardPlacementManager.Init();
        
        //Event subscription
        CustomEventManager.Instance.AddListener(TurnEvents.UPDATE_TURN_COST,OnTurnUpdate);
        
        OnTurnUpdate(1);
    }

    public void OnTurnUpdate(params object []args)
    {
        if (CheckIfLocationUnlocked((int)args[0]))
            OnIslandUnlocked();
        
        LocationViewManager.UpdateScore(true,LocationScoreManager.GetScoreForPlayer(0));
        LocationViewManager.UpdateScore(false,LocationScoreManager.GetScoreForPlayer(1));
    }

    private bool CheckIfLocationUnlocked(int turnNumber)
    {
        if (turnNumber == turnUnlockNumber)
            return true;
        return false;
    }
    
    private void OnIslandUnlocked()
    {
        SetUnlocked(true);
        //TODO: show animation
        Debug.Log($"Location Unlocked: {locationID}");
    }

    #region IUnlockable implementation

    public bool IsUnlocked()
    {
        return isUnlocked;
    }

    public void SetUnlocked(bool value)
    {
        isUnlocked = value;
    }

    #endregion

    public void AddCardToLocation(int playerIndex,ICard card)
    {
        LocationCardPlacementManager.AddCardToLocation(playerIndex,card);
        LocationScoreManager.AddScoreForPlayer(card.CardStatsManager.GetCardPower(),playerIndex);
    }
    
    
}

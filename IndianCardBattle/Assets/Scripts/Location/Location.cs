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
        SetUnlocked(CheckIfLocationUnlocked(1));
        
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
    }

    public void OnTurnUpdate(int turnNumber)
    {
        //TODO: turn updated
        if (CheckIfLocationUnlocked(turnNumber))
            OnIslandUnlocked();
    }

    private bool CheckIfLocationUnlocked(int turnNumber)
    {
        if (turnNumber == turnUnlockNumber)
            return true;
        return false;
    }
    
    private void OnIslandUnlocked()
    {
        //TODO: implementation pending
        SetUnlocked(true);
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
        
        //TODO: update player index check logic
        LocationViewManager.UpdateScore(playerIndex == 0,LocationScoreManager.GetScoreForPlayer(playerIndex));
    }
    
}

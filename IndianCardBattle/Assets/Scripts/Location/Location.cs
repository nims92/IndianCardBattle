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
    }

    public void OnTurnUpdate(int turnNumber)
    {
        //TODO: turn updated
        if (turnNumber == turnUnlockNumber)
            OnIslandUnlocked();
    }

    private void OnIslandUnlocked()
    {
        //TODO: implementation pending
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
}

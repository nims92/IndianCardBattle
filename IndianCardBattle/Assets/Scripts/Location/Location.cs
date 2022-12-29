using UnityEngine;

public class Location : MonoBehaviour, ILocation, IUnlockable
{
    private bool isUnlocked;
    private int turnUnlockNumber;
    public ILocationScoreManager LocationScoreManager { get; set; }
    public ILocationViewManager LocationViewManager { get; set; }
    public ILocationCardPlacementManager LocationCardPlacementManager { get; set; }

    public void InitLocation(int turnUnlockNumber,int numberOfPlayers)
    {
        this.turnUnlockNumber = turnUnlockNumber;
        LocationScoreManager = new LocationScoreManager(numberOfPlayers);
        LocationViewManager = GetComponentInChildren<LocationViewManager>();
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

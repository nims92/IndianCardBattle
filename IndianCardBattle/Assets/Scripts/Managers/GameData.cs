using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    [SerializeField] private LocationDatabase locationDatabase;
    [SerializeField] private GameplayData gameplayData;
    [SerializeField] private CheatData cheatData;
    
    public static GameData Instance { get; private set; }

    public LocationDatabase LocationDatabase
    {
        get => locationDatabase;
        set => locationDatabase = value;
    }

    public CheatData CheatData
    {
        get => cheatData;
        set => cheatData = value;
    }

    private void Awake() 
    { 
        // If there is an instance, and it's not me, delete myself.
    
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
    }
    
    #region Location data provider methods

    public Location GetLocationPrefabWithID(LocationID locationID)
    {
        return LocationDatabase.locationList.Find(location => location.locationID == locationID).locationPrefab;
    }

    public string GetLocationNameWithID(LocationID locationID)
    {
        return LocationDatabase.locationList.Find(location => location.locationID == locationID).name;
    }
    #endregion
    
    #region Gameplay data provider methods
    public Vector3 GetLocationSpawnPosForIndex(int index)
    {
        return gameplayData.GetLocationSpawnPosForIndex(index);
    }

    public Vector3 GetCardPlacementPositionForIndex(int index)
    {
        return gameplayData.GetCardPlacementPositionForIndex(index);
    }

    public Vector3 GetCardScaleAtLocation()
    {
        return gameplayData.GetCardScaleAtLocation();
    }
    #endregion
}

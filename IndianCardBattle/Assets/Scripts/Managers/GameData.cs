using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    [SerializeField] private LocationDatabase locationDatabase;
    [SerializeField] private GameplayData gameplayData;
    public static GameData Instance { get; private set; }
    
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
        return locationDatabase.locationList.Find(location => location.locationID == locationID).locationPrefab;
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

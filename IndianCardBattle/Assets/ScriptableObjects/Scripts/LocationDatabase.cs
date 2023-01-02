using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LocationDatabase", menuName = "Scriptable Objects/Location Database", order = 1)]
public class LocationDatabase : ScriptableObject
{
    public List<LocationDataEntry> locationList;
    
    public Location GetLocationPrefabWithID(LocationID locationID)
    {
        return locationList.Find(location => location.locationID == locationID).locationPrefab;
    }

    public string GetLocationNameWithID(LocationID locationID)
    {
        return locationList.Find(location => location.locationID == locationID).name;
    }
}
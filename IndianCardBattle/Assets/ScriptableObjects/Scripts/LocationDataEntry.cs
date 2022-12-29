using UnityEngine;

public enum LocationID
{
    None = 0,
    test = 1
}

public class LocationDataEntry
{
    public string name;
    public LocationID locationID;

    [Header("Prefab")]
    public Location locationPrefab;

    [Header("Ability")]
    public LocationAbilityID locationAbilityID;
}
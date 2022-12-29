using UnityEngine;

public enum LocationAbilityID
{
    None = 0,
    TestIslandAbility = 1
}

public class LocationAbilityDataEntry
{
    public string name;
    public LocationAbilityID locationAbilityID;

    [Header("Prefab")]
    public Card locationAbilityPrefab;
}
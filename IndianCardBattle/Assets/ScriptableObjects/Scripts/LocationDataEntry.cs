using UnityEngine;

public enum LocationID
{
    None = 0,
    Kurukshetra = 1,
    Hastinapur = 2,
    Gandhar = 3,
    Ujjanak = 4,
    Takshashila = 5,
    Indraprastha = 6,
    Vrindavan = 7,
    Dwarka = 8,
    Magadh = 9
}

[System.Serializable]
public class LocationDataEntry
{
    public string name;
    public LocationID locationID;

    [Header("Prefab")]
    public Location locationPrefab;

    [Header("Ability")]
    public LocationAbilityID locationAbilityID;
}
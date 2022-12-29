using UnityEngine;

public enum LocationAbilityID
{
    None = 0,
    TestIslandAbility = 1
}

[System.Serializable]
public class LocationAbility
{
    public string nameOfAbility;
    public LocationAbilityID ID;
    public string abilityDescription;

    public void OnGoingEffectTriggered()
    {

    }

    public void OnRevealEffectTriggered()
    {

    }
}

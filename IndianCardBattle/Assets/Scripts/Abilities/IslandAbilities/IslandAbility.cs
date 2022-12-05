using UnityEngine;

public enum IslandAbilityID
{
    None = 0,
    TestIslandAbility = 1
}

[System.Serializable]
public class IslandAbility
{
    public string nameOfAbility;
    public IslandAbilityID ID;
    public string abilityDescription;

    public void OnGoingEffectTriggered()
    {

    }

    public void OnRevealEffectTriggered()
    {

    }
}

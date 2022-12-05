using UnityEngine;

public enum CardAbilityID
{
    None = 0,
    TestCardAbility = 1
}

[System.Serializable]
public class CardAbility
{
    public string nameOfAbility;
    public CardAbilityID ID;
    public string abilityDescription;

    public void OnGoingEffectTriggered()
    {

    }

    public void OnRevealEffectTriggered()
    {

    }
}

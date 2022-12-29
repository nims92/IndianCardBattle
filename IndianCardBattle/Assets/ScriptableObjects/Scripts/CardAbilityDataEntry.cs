using UnityEngine;

public enum CardAbilityID
{
    None = 0,
    TestCardAbility = 1
}

public class CardAbilityDataEntry
{
    public string name;
    public CardAbilityID cardAbilityID;

    [Header("Prefab")]
    public Card cardAbilityPrefab;
    
}

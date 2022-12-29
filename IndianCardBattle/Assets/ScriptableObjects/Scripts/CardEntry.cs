using UnityEngine;

public enum CardID
{
    None = 0,
    Naukla = 1
}


[System.Serializable]
public class CardEntry
{
    public string name;
    public CardID cardID;
    
    [Header("Stats")]
    public int power;
    public int energyCost;
    
    [Header("Prefab")]
    public Card cardPrefab;

    [Header("Ability")]
    public CardAbilityID abilityID;
}

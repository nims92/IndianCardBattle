using UnityEngine;

public enum CardID
{
    None = 0,
    Naukla = 1,
    Amba = 2,
    Sahadev = 3,
    Gandhari = 4,
    Kaurava = 5,
    Duhsasana = 6,
    Shakuni = 7,
    Dhritarashtra = 8,
    Abhimanyu = 9,
    Bakasura = 10,
    Yuddhishthira = 11,
    Drona = 12,
    Bheema = 13
}

[System.Serializable]
public class CardStats
{
    public int energyCost;
    public int power;

    public CardStats(int cost, int power)
    {
        energyCost = cost;
        this.power = power;
    }
}

[System.Serializable]
public class CardDataEntry
{
    public string name;
    public CardID cardID;

    [Header("Stats")] 
    public CardStats cardStats;
    
    [Header("Prefab")]
    public Card cardPrefab;

    [Header("Ability")]
    public CardAbilityID abilityID;
}

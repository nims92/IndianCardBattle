using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameData : MonoBehaviour
{
    [SerializeField] private GameplayData gameplayData;
    [SerializeField] private GameConfiguration gameConfiguration;
    
    [Space(10)]
    [SerializeField] private LocationDatabase locationDatabase;
    [SerializeField] private CardDatabase cardDatabase;
    
    [Space(10)]
    [SerializeField] private CheatData cheatData;

    public static GameData Instance { get; private set; }

    public LocationDatabase LocationDatabase
    {
        get => locationDatabase;
    }

    public CheatData CheatData
    {
        get => cheatData;
    }

    public CardDatabase CardDatabase
    {
        get => cardDatabase;
    }

    public GameConfiguration GameConfiguration
    {
        get => gameConfiguration;
    }

    private void Awake() 
    { 
        // If there is an instance, and it's not me, delete myself.
    
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
    }
    
    #region Location data provider methods

    public Location GetLocationPrefabWithID(LocationID locationID)
    {
        return LocationDatabase.locationList.Find(location => location.locationID == locationID).locationPrefab;
    }

    public string GetLocationNameWithID(LocationID locationID)
    {
        return LocationDatabase.locationList.Find(location => location.locationID == locationID).name;
    }
    #endregion
    
    #region Gameplay data provider methods
    public Vector3 GetLocationSpawnPosForIndex(int index)
    {
        return gameplayData.GetLocationSpawnPosForIndex(index);
    }

    public List<Vector3> GetCardPlacementPositionForIndex()
    {
        return gameplayData.GetCardPlacementPositions();
    }

    public Vector3 GetCardScaleAtLocation()
    {
        return gameplayData.GetCardScaleAtLocation();
    }
    #endregion
    
    #region Card data provider methods
    public CardStats GetCardStatsByID(CardID cardID)
    {
        CardStats cardStats = CardDatabase.cardList.Find(card => card.cardID == cardID).cardStats;
        return new CardStats(cardStats.energyCost, cardStats.power);
    }

    public List<CardID> GetCardIDWithGivenCost(int eneryCost)
    {
        return CardDatabase.cardList
            .FindAll(card => card.cardStats.energyCost == eneryCost)
            .Select(card => card.cardID)
            .ToList();
    }

    public string GetCardNameByID(CardID cardID)
    {
        return CardDatabase.cardList.Find(card => card.cardID == cardID).name;
    }

    public Card GetCardPrefabByID(CardID cardID)
    {
        return CardDatabase.cardList.Find(card => card.cardID == cardID).cardPrefab;
    }
    
    #endregion
}

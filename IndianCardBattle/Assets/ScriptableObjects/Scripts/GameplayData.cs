using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LocationData
{
    public List<Vector3> locationSpawnPositions;
    public List<Vector3> cardPlacementPositions;
}

[System.Serializable]
public class CardGameplayData
{
    public Vector3 cardScaleAtLocation;
    public Vector3 cardScaleAtHand;
    public Vector3 cardScaleAtDeck;
}

[CreateAssetMenu(fileName = "Gameplay Data", menuName = "Scriptable Objects/Gameplay Data", order = 1)]
public class GameplayData : ScriptableObject
{
    [SerializeField] private LocationData locationData;
    [SerializeField] private CardGameplayData cardGameplayData;
    public Vector3 GetLocationSpawnPosForIndex(int index)
    {
        return locationData.locationSpawnPositions[index];
    }

    public List<Vector3> GetCardPlacementPositions()
    {
        return locationData.cardPlacementPositions;
    }

    public Vector3 GetCardScaleAtLocation()
    {
        return cardGameplayData.cardScaleAtLocation;
    }

    public Vector3 GetCardScaleAtHand()
    {
        return cardGameplayData.cardScaleAtHand;
    }
    
}

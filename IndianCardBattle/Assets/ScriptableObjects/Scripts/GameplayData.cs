using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LocationData
{
    public List<Vector3> locationSpawnPositions;
    public List<Vector3> cardPlacementPositions;
    public Vector3 cardScaleAtLocation;
}

[CreateAssetMenu(fileName = "Gameplay Data", menuName = "Scriptable Objects/Gameplay Data", order = 1)]
public class GameplayData : ScriptableObject
{
    [SerializeField] private LocationData locationData;

    public Vector3 GetLocationSpawnPosForIndex(int index)
    {
        return locationData.locationSpawnPositions[index];
    }

    public Vector3 GetCardPlacementPositionForIndex(int index)
    {
        return locationData.cardPlacementPositions[index];
    }

    public Vector3 GetCardScaleAtLocation()
    {
        return locationData.cardScaleAtLocation;
    }
}
